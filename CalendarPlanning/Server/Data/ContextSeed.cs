using CalendarPlanning.Shared.Models;

namespace CalendarPlanning.Server.Data
{
    public class ContextSeed
    {
        public List<Employee> employees = new();
        public List<Store> stores = new();

        public ContextSeed()
        {
        }

        public void Seed(APIDbContext context)
        {
            InitStore();

            if (!context.Stores.Any() && stores.Count != 0)
            {
                context.Stores.AddRange(stores);
                context.SaveChanges();
            }

            InitEmployees(context);

            if (!context.Employees.Any() && employees.Count != 0)
            {
                context.Employees.AddRange(employees);
                context.SaveChanges();
            }
        }

        public bool HasData(APIDbContext context)
        {
            return context.Stores.Any() && context.Employees.Any();
        }

        private void InitEmployees(APIDbContext context)
        {
            employees = new List<Employee>
            {
                new Employee
                {
                    EmployeeId = Guid.NewGuid().ToString(),
                    FirstName = "John",
                    LastName = "Doe",
                    StoreId = context.Stores.First(s => s.Name == "Store 1").StoreId
                },
                new Employee
                {
                    EmployeeId = Guid.NewGuid().ToString(),
                    FirstName = "Jane",
                    LastName = "Doe",
                    StoreId = context.Stores.First(s => s.Name == "Store 2").StoreId
                }
            };
        }

        private void InitStore()
        {
            stores = new List<Store>
            {
                new Store
                {
                    StoreId = Guid.NewGuid(),
                    Name = "Store 1",
                    Address = "Address 1"
                },
                new Store
                {
                    StoreId = Guid.NewGuid(),
                    Name = "Store 2",
                    Address = "Address 2"
                }
            };
        }
    }
}
