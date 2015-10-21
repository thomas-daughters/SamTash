using System.Data.Entity;

namespace Wedding.Models {
	public class Context : DbContext {
		public DbSet<Guest> Guests { get; set; }
		public DbSet<Flight> Flights { get; set; }
		public DbSet<Airport> Airports { get; set; }
		public DbSet<Airline> Airlines { get; set; }
	}
}