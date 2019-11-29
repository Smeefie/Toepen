using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPToep.Models;
using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace ASPToep.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        GameLogic gameLogic = new GameLogic(false);

        [Route("Game/CreateGame")]
        public IActionResult CreateGame()   
        {
            return View();
        }

        [Route("Game/GameRoom")]
        public IActionResult GameRoom(string Datastream)
        {
            GameViewModel gameViewModel = new GameViewModel();
            string[] datastream = Datastream.Split(';');
            foreach(var id in datastream)
            {
                if(Int32.TryParse(id, out int num))
                    gameViewModel.playerList.Add(new Player(Convert.ToInt32(id), "Smeef"));
            }
            //gameViewModel.playerList.Add(new Player(1, "Smeef"));
            return View(gameViewModel);
        }

        // Todo: Figure out why 'return View' doesnt work
        [HttpPost]
        public JsonResult StartGame(string dataStream)
        {
            return Json(new { newUrl = Url.Action("GameRoom", "Game", new { DataStream = dataStream }) });
        }

        // GAME BUTTON EVENTS
        public IActionResult PlayerWonRound(string playerId)
        {
            
            return View();
        }

        public IActionResult PlayerKnocks(string playerId)
        {
            return View();
        }
    }
}