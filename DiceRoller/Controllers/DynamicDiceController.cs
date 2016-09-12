using DiceRoller.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DiceRoller.Controllers
{
    public class DynamicDiceController : Controller
    {
        // GET: DynamicDice
        public ActionResult Index()
        {
            Dictionary<string, Dice> die = (Dictionary<string, Dice>)Session["die"];
            if (die == null)
            {
                die = new Dictionary<string, Dice>();
                die.Add("One", new Dice());
                die.Add("Two", new Dice());
                Session["die"] = die;
            }

            ViewBag.Die = die;

            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection formCollection)
        {
            Dictionary<string, Dice> die = (Dictionary<string, Dice>)Session["die"];
            if (die == null)
            {
                die = new Dictionary<string, Dice>();
                die.Add("One", new Dice());
                die.Add("Two", new Dice());
                Session["die"] = die;
            }
            string diceRolled = formCollection["rollDice"];
            Dice diceToRoll = die[diceRolled];

            if (diceToRoll != null)
            {
                diceToRoll.Roll();
            }

            ViewBag.Die = die;

            return View();
        }
    }
}