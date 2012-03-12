using System.Web.Mvc;

namespace Engineer.Web.Controllers
{
    public class QuestionsController : Controller
    {
        public ActionResult PersonalDetails()
        {
            return View();
        }

        public ActionResult Preferences()
        {
            return View();
        }

        public ActionResult Answers()
        {
            return Redirect("preferences");
        }
    }
}