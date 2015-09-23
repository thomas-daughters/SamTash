using System.ComponentModel.DataAnnotations;

namespace Wedding.Models {
	public class RSVP {
		[Required]
		[Display(Name = "Your Name(s)", Prompt = "Guest + Partner + Children")]
		public string Names { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		[Display(Name = "Are You Available?")]
		public bool Available { get; set; }

		public string Comments { get; set; }
	}
}