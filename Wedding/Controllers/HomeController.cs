using System;
using System.Net.Mail;
using System.Web.Mvc;
using Wedding.Models;

namespace Wedding.Controllers {
	public class HomeController : Controller {
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

		[HttpPost]
		public ActionResult Thanks(RSVP rsvp) {
			string body = "Names: " + rsvp.Names;

			MailMessage message = new MailMessage("wedding@samtash.com", "wedding@samtash.com", "Wedding RSVP", body);
			SmtpClient client = new SmtpClient("relay-hosting.secureserver.net", 25);
			client.Send(message);

			ViewBag.Message = "Great! We look forward to seeing you there.";

			return View();
		}
	}
}