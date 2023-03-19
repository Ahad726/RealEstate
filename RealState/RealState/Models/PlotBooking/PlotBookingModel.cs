using RealState.Core.Entity;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace RealState.Models.PlotBooking
{
    public class PlotBookingModel
    {
        public int Id { get; set; }
        public int BlockId { get; set; }
        public string BlockName { get; set; }
        [Required(ErrorMessage = "Block cannot be empty")]
        public Block Block { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Plot cannot be empty")]
        public int PlotId { get; set; }
        public string PlotNumber { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Customer cannot be empty")]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime BookedOn { get; set; } 
        public DateTime? VacatedOn { get; set; }
    }
}
