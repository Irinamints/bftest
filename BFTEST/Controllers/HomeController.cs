using BFTEST.Models;
using Repository;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BFTEST.Controllers
{
    public class HomeController : Controller
    {
        private IGameItemService _gameItemService;

        public object GameItem { get; private set; }

        public HomeController(IGameItemService gameItemService) {
            this._gameItemService = gameItemService;
        }

        public ActionResult Index()
        {
            GameItem gameItem = _gameItemService.InitGame();
            return View(new GameModel() { StartRange = gameItem.StartRange, EndRange = gameItem.EndRange, UserId = gameItem.UserId });
        }

        [HttpPost]
        public ActionResult Attempt(AttemptModel attemptModel)
        {
            AttemptResult result = _gameItemService.SetAttempt(attemptModel.UserId, attemptModel.SelectedNumber);
            return Json(result.ToString());
        }

     }
}