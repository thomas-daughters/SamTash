using System;
using System.Net.Mail;
using System.Web.Mvc;
using Wedding.Models;

namespace Wedding.Controllers {
	public class HomeController : Controller {
		public ActionResult Index() {
			return View();
		}

		public ActionResult Location() {
			return View();
		}

		public ActionResult RSVP() {
			return View();
		}

		[HttpPost]
		public ActionResult Thanks(RSVP rsvp) {
			string body = "Names: " + rsvp.Names + Environment.NewLine
				+ "Email: " + rsvp.Email + Environment.NewLine
				+ "Available: " + rsvp.Available.ToString() + Environment.NewLine
				+ "Comments: " + rsvp.Comments;

			MailMessage message = new MailMessage("wedding@samtash.com", "wedding@samtash.com", "Wedding RSVP", body);
			SmtpClient client = new SmtpClient("relay-hosting.secureserver.net", 25);
			client.Send(message);

			ViewBag.Message = rsvp.Available ? "Great! We look forward to seeing you there." : "Sorry you can't join us.";

			return View();
		}
	}
}