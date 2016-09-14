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
            Dictionary<string, Dice> die = LoadDices();

            ViewBag.Die = die;

            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection formCollection)
        {
            Dictionary<string, Dice> die = LoadDices();
            string diceRolled = formCollection["rollDice"];
            Dice diceToRoll = die[diceRolled];

            if (diceToRoll != null)
            {
                diceToRoll.Roll();
            }

            ViewBag.Die = die;

            return View();
        }

        private Dictionary<string, Dice> LoadDices()
        {
            Dictionary<string, Dice> die;

            if (Session["die"] == null)
            {
                die = new Dictionary<string, Dice>();
                die.Add("One", new Dice());
                die.Add("Two", new Dice());
                Session["die"] = die;
            }
            else
            {
                die = (Dictionary<string, Dice>)Session["die"];
            }

            return die;
        }
    }
}