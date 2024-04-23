﻿using Domain.Constants;
using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities
{
    [ExcludeFromCodeCoverage(Justification = CodeCoverageJustifications.NoBusinessLogic)]
    public class Event : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public DateTime EventStartDate { get; set; } = DateTime.Now;
        public DateTime EventEndDate { get; set; } = DateTime.Now;
        [ForeignKey("Organization")]
        public string OrganizationId { get; set; } = string.Empty;
        public string OrganizedByUserId { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int SeatAllocation { get; set; } = default;
        public bool IsAvailableForRegistraton { get; set; } = default;

        // Navigation propertise
        public Organization Organization { get; set; }  
    }
}
