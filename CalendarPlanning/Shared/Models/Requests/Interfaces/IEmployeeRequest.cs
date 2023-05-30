using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CalendarPlanning.Shared.Models.Requests.Interfaces
{
    public interface IEmployeeRequest
    {
        void Validate();
    }
}
