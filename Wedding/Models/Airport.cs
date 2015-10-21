using System.ComponentModel.DataAnnotations.Schema;

namespace Wedding.Models {
	[Table("Airports")]
	public class Airport {
		public int ID { get; set; }

		public string Name { get; set; }
	}
}