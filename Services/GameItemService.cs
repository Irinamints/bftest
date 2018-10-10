using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class GameItemService : IGameItemService
    {

        private IGameContext _context;

        private int _maxRange = 100; //better to move it to config?

        public GameItemService()
        {
            this._context = new GameContext();
        }
        public GameItem InitGame()
        {
            Random r = new Random();
            GameItem result = new GameItem();
            result.UserId = Guid.NewGuid().ToString();
            result.StartRange = r.Next(_maxRange - 10);
            result.EndRange = r.Next(result.StartRange, _maxRange);
            result.HiddenNumber = r.Next(result.StartRange, result.EndRange);

            var gameItems = new List<GameItem>();
            gameItems.Add(result);

            _context.GameItems.Add(result);
            _context.SaveChanges();
            return result;
        }


        public AttemptResult SetAttempt(string userId, int selectedNumber) {

            GameItem item = _context.GameItems.Where(i => i.UserId == userId).SingleOrDefault();

            if (item == null)
                return AttemptResult.UserIdNotFound;

            if (item.HiddenNumber == selectedNumber) {
                item.IsSucceed = true;
                _context.SaveChanges();
                return AttemptResult.WelDone;
            }

            if (!item.Attempt1.HasValue) {
                item.Attempt1 = selectedNumber;
                _context.SaveChanges();
                return AttemptResult.TryAgain;
            }

            if (!item.Attempt2.HasValue)
            {
                item.Attempt2= selectedNumber;
                _context.SaveChanges();
                return AttemptResult.TryAgain;
            }

            if (!item.Attempt3.HasValue)
            {
                item.Attempt3 = selectedNumber;
                _context.SaveChanges();
                return AttemptResult.GameOver;
            }

            return AttemptResult.GameOver;

        }
    }
}
