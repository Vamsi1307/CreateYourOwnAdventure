using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateYourOwnAdventure.Core.Models
{
    public class GameTraverse
    {
        public int GameId { get; set; }
        public List<GameResponse> Choices { get; set; }
    }
}
