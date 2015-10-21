using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wedding.Models {
	[Table("Flights")]
	public class Flight {
		public int ID { get; set; }

		[Column("Origin ID")]
		public int OriginID { get; set; }

		[Column("Destination ID")]
		public int DestinationID { get; set; }

		[Column("Airline ID")]
		public int AirlineID { get; set; }

		public DateTime Depart { get; set; }

		public DateTime Arrive { get; set; }

		public bool Outbound { get; set; }

		// Navigation
		public virtual Airport Origin { get; set; }
		public virtual Airport Destination { get; set; }
		public virtual Airline Airline { get; set; }
	}
}