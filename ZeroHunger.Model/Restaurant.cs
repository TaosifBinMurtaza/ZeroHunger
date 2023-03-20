using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroHunger.Model
{
	public class Restaurant
	{
		[Key]
		public int Id { get; set; }
		[Required(ErrorMessage ="Enter your name")]
		public string Name { get; set; }
		[Required]
		public string City { get; set; }
		[Required]
		public string Area { get; set; }

		[Required]
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }

	}
}
