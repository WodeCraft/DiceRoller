using DiceRoller.Models;
using System.Web.Mvc;

namespace DiceRoller.Controllers
{
    public class DoubleDiceController : Controller
    {
        // GET: DoubleDice
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection formCollection)
        {
            string diceRolled = formCollection["rollDice"];
            Dice diceOne = (Dice)Session["diceOne"];
            Dice diceTwo = (Dice)Session["diceTwo"];

            if ("Roll Dice One".Equals(diceRolled))
            {
                if (diceOne == null)
                {
                    diceOne = new Dice();
                    diceOne.Roll();
                    Session["diceOne"] = diceOne;
                }
                else
                {
                    diceOne.Roll();
                }
            }
            else
            {
                if (diceTwo == null)
                {
                    diceTwo = new Dice();
                    diceTwo.Roll();
                    Session["diceTwo"] = diceTwo;
                }
                else
                {
                    diceTwo.Roll();
                }
            }

            ViewBag.DiceOne = diceOne;
            ViewBag.DiceTwo = diceTwo;

            return View();
        }
    }
}