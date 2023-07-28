using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarPlanning.Shared.Exceptions.IncentiveValueExceptions
{
    public class IncentiveValueSaveUpdateException : Exception
    {
        public IncentiveValueSaveUpdateException(int id, string message) : base($"Error saving or updating incentive value with id {id}: {message}")
        {
        }
    }
}
