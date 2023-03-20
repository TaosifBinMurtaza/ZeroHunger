using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroHunger.Model
{
    public class Request
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int RestaurantId { get; set; }
        [ForeignKey("RestaurantId")]
        [ValidateNever]
        public Restaurant Restaurant { get; set; }
        public int? EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        [ValidateNever]
        public Employee? Employee { get; set; }

        public DateTime RequestDate { get; set; } = DateTime.Now;

        public DateTime ExpiredTime { get; set; }
        public string? Status { get; set; } = null;

    }
}
