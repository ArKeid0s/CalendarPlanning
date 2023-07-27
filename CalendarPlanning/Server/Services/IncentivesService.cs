using CalendarPlanning.Server.Repositories.Interfaces;
using CalendarPlanning.Server.Services.Interfaces;
using CalendarPlanning.Shared.Exceptions.EmployeeExceptions;
using CalendarPlanning.Shared.Exceptions.IncentiveExceptions;
using CalendarPlanning.Shared.ModelExtensions;
using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.DTO;
using CalendarPlanning.Shared.Models.Requests.IncentiveRequests;

namespace CalendarPlanning.Server.Services
{
    public class IncentivesService : IIncentivesService
    {
        private readonly IIncentivesRepository _incentivesRepository;
        private readonly IEmployeesRepository _employeesRepository;

        public IncentivesService(IIncentivesRepository incentivesRepository, IEmployeesRepository employeesRepository)
        {
            _incentivesRepository = incentivesRepository;
            _employeesRepository = employeesRepository;
        }

        public async Task<IncentiveDto> CreateIncentiveAsync(CreateIncentiveRequest createIncentiveRequest)
        {
            var employee = await _employeesRepository.GetEmployeeByIdAsNoTrackingAsync(createIncentiveRequest.EmployeeId) ?? throw new EmployeeNotFoundException(createIncentiveRequest.EmployeeId);

            var incentive = new Incentive()
            {
                ClientFirstName = createIncentiveRequest.ClientFirstName,
                ClientLastName = createIncentiveRequest.ClientLastName,
                IncentiveUnifocal = createIncentiveRequest.IncentiveUnifocal,
                IncentiveProgressive = createIncentiveRequest.IncentiveProgressive,
                EmployeeId = employee.EmployeeId
            };

            return await _incentivesRepository.CreateIncentiveAsync(incentive);
        }

        public async Task DeleteIncentiveAsync(Guid id)
        {
            await _incentivesRepository.DeleteIncentiveAsync(id);
        }

        public async Task<IncentiveDto> GetIncentiveByIdAsync(Guid id)
        {
            return await _incentivesRepository.GetIncentiveByIdAsNoTrackingAsync(id);
        }

        public async Task<IEnumerable<IncentiveDto>> GetIncentivesAsync()
        {
            return await _incentivesRepository.GetIncentivesAsNoTrackingAsync();
        }

        public async Task<IEnumerable<IncentiveDto>> GetIncentivesOfUserById(string userId)
        {
            var incentives = await _incentivesRepository.GetIncentivesAsNoTrackingAsync();

            return incentives.Where(incentive => incentive.EmployeeId == userId);
        }


        public async Task UpdateIncentiveAsync(Guid id, UpdateIncentiveRequest updateIncentiveRequest)
        {
            var incentiveDto = await _incentivesRepository.GetIncentiveByIdAsNoTrackingAsync(id) ?? throw new IncentiveNotFoundException(id);
            incentiveDto.ClientFirstName = updateIncentiveRequest.ClientFirstName;
            incentiveDto.ClientLastName = updateIncentiveRequest.ClientLastName;
            incentiveDto.IncentiveUnifocal = updateIncentiveRequest.IncentiveUnifocal;
            incentiveDto.IncentiveProgressive = updateIncentiveRequest.IncentiveProgressive;

            var incentive = incentiveDto.ToModel();

            await _incentivesRepository.UpdateIncentiveAsync(incentive);
        }
    }
}
