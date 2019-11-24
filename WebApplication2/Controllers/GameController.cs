using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPToep.Models;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace ASPToep.Controllers
{
    public class GameController : Controller
    {
        [Route("CreateGame")]
        public IActionResult CreateGame()
        {
            return View();
        }

        [Route("Game")]
        public IActionResult Game(GameViewModel gameViewModel)
        {
            return View();
        }

        // todo figure out why 'return View' doesnt work
        public IActionResult StartGame(string dataStream)
        {
            GameViewModel gameViewModel = new GameViewModel();
            gameViewModel.AddPlayer(new Player(1, "Smeef"));
            return View("Game", gameViewModel);
        }
    }
}