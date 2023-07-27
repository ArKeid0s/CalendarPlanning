using CalendarPlanning.Server.Services.Interfaces;
using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.Requests.AuthenticationRequests;
using CalendarPlanning.Shared.Models.Requests.EmployeeRequests;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CalendarPlanning.Server.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IEmployeesService _employeesService;

        public AuthenticationService(IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }

        public async Task<LoginResult> LoginUserAsync(LoginUserRequest loginUserRequest, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            var result = await signInManager.PasswordSignInAsync(loginUserRequest.Email, loginUserRequest.Password, false, false);

            if (!result.Succeeded)
            {
                string errorMessage;

                if (result.IsLockedOut)
                {
                    errorMessage = "User account is locked out.";
                }
                else if (result.IsNotAllowed)
                {
                    errorMessage = "User is not allowed to sign in.";
                }
                else if (result.RequiresTwoFactor)
                {
                    errorMessage = "User requires two-factor authentication.";
                }
                else
                {
                    errorMessage = "Invalid login credentials.";
                }

                return new LoginResult { Succeeded = false, ErrorMessage = errorMessage };
            }

            var user = await signInManager.UserManager.FindByEmailAsync(loginUserRequest.Email);
            var roles = await signInManager.UserManager.GetRolesAsync(user!);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, loginUserRequest.Email),
                new Claim(ClaimTypes.NameIdentifier, user!.Id)
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));

                switch (role)
                {
                    case "Admin":
                        claims.Add(new Claim("scope", "Calendar:Read"));
                        claims.Add(new Claim("scope", "Calendar:Write"));
                        break;
                    case "Employee":
                        claims.Add(new Claim("scope", "Calendar:Read"));
                        break;
                }
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(Convert.ToInt32(configuration["Jwt:ExpiryInDays"]));

            var token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: expiry,
                signingCredentials: credentials);

            return new LoginResult { Succeeded = true, Token = new JwtSecurityTokenHandler().WriteToken(token) };
        }

        public async Task<RegisterResult> RegisterUserAsync(RegisterUserRequest registerUserRequest, UserManager<ApplicationUser> userManager)
        {
            var newUser = new ApplicationUser
            {
                UserName = registerUserRequest.Email,
                Email = registerUserRequest.Email
            };

            var result = await userManager.CreateAsync(newUser, registerUserRequest.Password);

            if (!result.Succeeded)
            {
                var errors = string.Join(" ", result.Errors.Select(x => x.Description));

                return new RegisterResult { Succeeded = false, ErrorMessage = $"User registration failed. Details: {errors}" };
            }

            await userManager.AddToRoleAsync(newUser, "Employee");

            // Create employee
            await _employeesService.CreateEmployeeAsync(new CreateEmployeeRequest
            {
                EmployeeId = newUser.Id,
                FirstName = registerUserRequest.FirstName,
                LastName = registerUserRequest.LastName,
                StoreName = registerUserRequest.StoreName,
            });

            return new RegisterResult { Succeeded = true };
        }
    }
}
