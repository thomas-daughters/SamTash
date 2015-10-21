using System;
using System.Data.Entity;
using System.Linq;
using System.Net.Mail;
using System.Web.Mvc;
using Wedding.Models;

namespace Wedding.Controllers {
	public class HomeController : Controller {
		private Context context = new Context();

		public ActionResult Index() {
			return View("Home");
		}

		public ActionResult Location() {
			return View();
		}

		public ActionResult RSVP() {
			return View();
		}

		public ActionResult Accommodation() {
			return View();
		}

		public ActionResult Photos() {
			return View();
		}

		public ActionResult Logistics() {
			ViewBag.OutboundFlights = context.Flights
				.Where(x => x.Outbound)
				.Select(flight => new {
					ID = flight.ID,
					Text = flight.Origin.Name + " to " + flight.Destination.Name + " (" + flight.Airline.Name + ") " + flight.Depart
				});

			ViewBag.ReturnFlights = context.Flights
				.Where(x => !x.Outbound)
				.Select(flight => new {
					ID = flight.ID,
					Text = flight.Origin.Name + " to " + flight.Destination.Name + " (" + flight.Airline.Name + ") " + flight.Depart
				});

			ViewBag.Status = TempData["Status"];
			ViewBag.Class = ViewBag.Status == "Saved" ? "status" : "status error";

			return View(context.Guests);
		}

		[HttpPost]
		public ActionResult UpdateFlights([Bind(Include = "ID,Email,DepartID,ReturnID")] Guest guest) {
			Guest original = context.Guests.Find(guest.ID);
			
			// Only continue if emails match
			if (original.Email.Equals(guest.Email, StringComparison.CurrentCultureIgnoreCase)) {
				try {
					// Update original with new fields and save
					original.DepartID = guest.DepartID;
					original.ReturnID = guest.ReturnID;

					context.SaveChanges();
					TempData["Status"] = "Saved";

					// Send email
					string body = guest.Names + " entered flight details.";
					MailMessage message = new MailMessage("wedding@samtash.com", "wedding@samtash.com", "Wedding RSVP", body);
					SmtpClient client = new SmtpClient("relay-hosting.secureserver.net", 25);
					client.Send(message);
				} catch (Exception e) {
					TempData["Status"] = "Failed to save: " + e.Message;
				}
			}
			else {
				TempData["Status"] = "Email doesn't match our records";
			}

			return RedirectToAction("Logistics");
		}

		[HttpPost]
		public ActionResult Thanks(Guest guest) {
			// Add guest to database
			context.Guests.Add(guest);
			context.SaveChanges();

			// Send email
			string body = "Names: " + guest.Names + Environment.NewLine + "Email: " + guest.Email;
			MailMessage message = new MailMessage("wedding@samtash.com", "wedding@samtash.com", "Wedding RSVP", body);
			SmtpClient client = new SmtpClient("relay-hosting.secureserver.net", 25);
			client.Send(message);

			// Redirect to logistics page
			TempData["Status"] = "Thanks for your RSVP. Please also complete your flight details below.";
			return RedirectToAction("Logistics");
		}
	}
}