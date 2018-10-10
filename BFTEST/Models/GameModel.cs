using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BFTEST.Models
{
    public class GameModel
    {
        public int StartRange { get; set; }
        public int EndRange { get; set; }
        public int Attemts { get; set; }
        public string UserId { get; set; }
    }
}