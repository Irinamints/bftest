using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class GameItem
    {
        [Key]
        public string UserId { get; set; }
        public int StartRange { get; set; }
        public int EndRange { get; set; }
        public int HiddenNumber { get; set; }
        public int? Attempt1 { get; set; }
        public int? Attempt2 { get; set; }
        public int? Attempt3 { get; set; }
        public bool IsSucceed { get; set; }

    }
}
