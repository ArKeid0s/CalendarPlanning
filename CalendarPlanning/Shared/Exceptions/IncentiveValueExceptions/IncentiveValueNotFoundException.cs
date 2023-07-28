using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarPlanning.Shared.Exceptions.IncentiveValueExceptions
{
    public class IncentiveValueNotFoundException : Exception
    {
        public IncentiveValueNotFoundException(int id) : base($"Incentive value with id {id} was not found")
        {
        }
    }
}
