using System.ComponentModel.DataAnnotations;

namespace Wedding.Models {
	public class RSVP {
		[Required]
		public string Names { get; set; }
	}
}