using DiceRoller.Models;
using System.Web.Mvc;

namespace DiceRoller.Controllers
{
    public class DiceController : Controller
    {
        // GET: Dice
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection formCollection)
        {
            Dice dice;
            if (Session["dice"] == null)
            {
                dice = new Dice();
                dice.Roll();
                Session["dice"] = dice;
            }
            else
            {
                dice = (Dice)Session["dice"];
                dice.Roll();
            }

            ViewBag.LatestRoll = dice.Outcome;
            ViewBag.NumRolls = dice.NumRolls;
            ViewBag.TotalSum = dice.TotalSum;
            ViewBag.AvgScore = dice.AvgScore;
            ViewBag.Distribution = dice.Distribution;

            ViewBag.Dice = dice;

            return View();
        }
    }
}