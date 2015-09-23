using System.Data.Entity;

namespace Wedding.Models {
	public class Context {
		public DbSet<RSVP> RSVPs { get; set; }
	}
}