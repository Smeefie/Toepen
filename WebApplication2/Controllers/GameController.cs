using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPToep.Models;
using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ASPToep.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        GameLogic gameLogic = new GameLogic(false);
        GameInstance gameModel = new GameInstance();

        [Route("Game/CreateGame")]
        public IActionResult CreateGame()
        {
            return View();
        }

        [Route("Game/GameRoom")]
        public IActionResult GameRoom(string Datastream)
        {
            string[] datastream = Datastream.Split(';');
            foreach (var id in datastream)
            {
                if (Int32.TryParse(id, out int num))
                    gameModel.playerList.Add(new Player(Convert.ToInt32(id), "Smeef"));
            }
            return View(new GameViewModel(gameModel));
        }

        [HttpPost]
        public JsonResult StartGame(string dataStream)
        {
            return Json(new { newUrl = Url.Action("GameRoom", "Game", new { DataStream = dataStream }) });
        }

        // GAME BUTTON EVENTS
        [HttpPost]
        public ActionResult PlayerWonRound(string winPlayer, string json)
        {
            List<Player> tempPlayerList = gameLogic.GetPlayerList(json);
            gameModel.playerList = tempPlayerList;

            foreach (var player in tempPlayerList)
            {
                if(player.Id != Convert.ToInt32(winPlayer))
                    player.Score += player.RoundPoints;
            }

            foreach (var player in gameModel.playerList)
            {
                player.ResetRound();
            }
            return PartialView("Razorpages/GameContainer", gameModel);
        }

        [HttpPost]
        public IActionResult PlayerKnocks(string playerId)
        {
            return View();
        }
    }
}