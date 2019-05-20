using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration.CompleteWebAPI.Models
{
    public class ChampionshipDto
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public OrganizerDto Organizer { get; set; }
        public byte[] TrophyImage { get; set; }
        public DateTime DateConquered { get; set; }
    }
}
