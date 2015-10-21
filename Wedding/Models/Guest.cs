using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wedding.Models {
	[Table("Guests")]
	public class Guest {
		public int ID { get; set; }

		public string Names { get; set; }

		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Column("Depart ID")]
		public int? DepartID { get; set; }

		[Column("Return ID")]
		public int? ReturnID { get; set; }

		// Navigation
		public virtual Flight Depart { get; set; }
		public virtual Flight Return { get; set; }
	}
}