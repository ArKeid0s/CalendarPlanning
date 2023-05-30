﻿using System.ComponentModel.DataAnnotations;

namespace CalendarPlanning.Shared.Models.Requests
{
    public class AddScheduleRequest : RequestModelBase
    {
        [Required]
        public Guid StoreId { get; set; }

        [Required]
        public DateTime WeekStart { get; set; }

        [Required]
        public DateTime WeekEnd { get; set; }
    }
}
