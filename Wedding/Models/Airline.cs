using System.ComponentModel.DataAnnotations.Schema;

namespace Wedding.Models {
	[Table("Airlines")]
	public class Airline {
		public int ID { get; set; }

		public string Name { get; set; }
	}
}