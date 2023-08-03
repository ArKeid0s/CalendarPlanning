using CalendarPlanning.Client.Services.Interfaces;
using CalendarPlanning.Shared.Enums;
using CalendarPlanning.Shared.Models.DTO;
using CalendarPlanning.Shared.Models.Requests.IncentiveValueRequests;
using System.Net.Http.Json;

namespace CalendarPlanning.Client.Services
{
    public class IncentiveValuesService : IIncentiveValuesService
    {
        public decimal TotalIndividualIncentiveValue { get; private set; }
        public decimal TotalCollectiveIncentiveValue { get; private set; }
        public decimal UserIndividualIncentiveValue { get; private set; }

        public event Action? OnValuesUpdated;

        private readonly HttpClient _http;
        private readonly IEmployeesService _employeesService;
        private readonly IIncentivesService _incentivesService;

        public IncentiveValuesService(HttpClient http, IEmployeesService employeesService, IIncentivesService incentivesService)
        {
            _http = http;
            _employeesService = employeesService;
            _incentivesService = incentivesService;

            _incentivesService.OnIncentivesUpdated += CalculateIncentiveValues;
        }

        public async Task<bool> UpdateIncentiveValue(int incentiveValueId, UpdateIncentiveValueRequest request)
        {
            var response = await _http.PutAsJsonAsync($"api/IncentiveValues/{incentiveValueId}", request);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<IncentiveValueDto>?> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<IncentiveValueDto>>("api/IncentiveValues");
        }

        private async Task<decimal> GetTotalIndividualIncentiveValueAsync(List<IncentiveDto>? incentives)
        {
            if (incentives == null) return 0m;

            var incentiveValues = (await GetAllAsync())!.ToDictionary(iv => iv.Id, iv => iv);

            decimal total = 0;
            decimal percentage = 0.6m;

            foreach (var incentive in incentives)
            {
                if (incentiveValues.TryGetValue((int)incentive.IncentiveUnifocal, out var unifocalValue))
                {
                    total += incentive.IncentiveUnifocal != IncentiveTypeEnum.AVIS_GOOGLE
                        ? Math.Round(unifocalValue.UnifocalValue * percentage, 2)
                        : 0m;
                }

                if (incentiveValues.TryGetValue((int)incentive.IncentiveProgressive, out var progressiveValue))
                {
                    total += incentive.IncentiveProgressive != IncentiveTypeEnum.AVIS_GOOGLE
                        ? Math.Round(progressiveValue.ProgressiveValue * percentage, 2)
                        : 0m;
                }
            }

            return Math.Round(total, 2);
        }


        private async Task<decimal> GetTotalCollectiveIncentiveValueAsync(List<IncentiveDto>? incentives)
        {
            if (incentives == null) return 0m;

            var incentiveValues = (await GetAllAsync())!.ToDictionary(iv => iv.Id, iv => iv);

            decimal total = 0;
            decimal percentage = 0.4m;

            foreach (var incentive in incentives)
            {
                if (incentiveValues.TryGetValue((int)incentive.IncentiveUnifocal, out var unifocalValue))
                {
                    total += incentive.IncentiveUnifocal != IncentiveTypeEnum.AVIS_GOOGLE
                             ? Math.Round(unifocalValue.UnifocalValue * percentage, 2)
                             : Math.Round(unifocalValue.UnifocalValue, 2);
                }

                if (incentiveValues.TryGetValue((int)incentive.IncentiveProgressive, out var progressiveValue))
                {
                    total += incentive.IncentiveProgressive != IncentiveTypeEnum.AVIS_GOOGLE
                             ? Math.Round(progressiveValue.ProgressiveValue * percentage, 2)
                             : Math.Round(progressiveValue.ProgressiveValue, 2);
                }
            }

            var employeesCount = await _employeesService.GetEmployeesCountAsync();

            return Math.Round(total / employeesCount, 2);
        }

        public void CalculateIncentiveValues()
        {
            _ = CalculateIncentiveValuesAsync();
        }

        private async Task CalculateIncentiveValuesAsync()
        {
            TotalIndividualIncentiveValue = await GetTotalIndividualIncentiveValueAsync(_incentivesService.Incentives);
            TotalCollectiveIncentiveValue = await GetTotalCollectiveIncentiveValueAsync(_incentivesService.Incentives);

            NotifyValuesUpdated();
        }

        public void NotifyValuesUpdated()
        {
            OnValuesUpdated?.Invoke();
        }

        public void CalculateUserIncentiveValues(string userId)
        {
            _ = CalculateUserIncentiveValuesAsync(userId);
        }

        private async Task CalculateUserIncentiveValuesAsync(string userId)
        {
            UserIndividualIncentiveValue = await GetUserTotalIndividualIncentiveValue(userId);
            TotalCollectiveIncentiveValue = await GetTotalCollectiveIncentiveValueAsync(_incentivesService.Incentives);
            NotifyValuesUpdated();
            Console.WriteLine(userId + " indi: " + UserIndividualIncentiveValue + " " + TotalCollectiveIncentiveValue);
        }

        private async Task<decimal> GetUserTotalIndividualIncentiveValue(string userId)
        {
            var incentives = _incentivesService.Incentives?.Where(i => i.EmployeeId == userId).ToList();

            if (incentives == null || incentives.Count == 0) return 0m;

            var incentiveValues = (await GetAllAsync())!.ToDictionary(iv => iv.Id, iv => iv);

            decimal total = 0;
            decimal percentage = 0.6m;

            foreach (var incentive in incentives)
            {
                if (incentiveValues.TryGetValue((int)incentive.IncentiveUnifocal, out var unifocalValue))
                {
                    total += incentive.IncentiveUnifocal != IncentiveTypeEnum.AVIS_GOOGLE
                        ? Math.Round(unifocalValue.UnifocalValue * percentage, 2)
                        : 0m;
                }

                if (incentiveValues.TryGetValue((int)incentive.IncentiveProgressive, out var progressiveValue))
                {
                    total += incentive.IncentiveProgressive != IncentiveTypeEnum.AVIS_GOOGLE
                        ? Math.Round(progressiveValue.ProgressiveValue * percentage, 2)
                        : 0m;
                }
            }

            Console.WriteLine($"Total: {total}");
            return Math.Round(total, 2);
        }
    }
}