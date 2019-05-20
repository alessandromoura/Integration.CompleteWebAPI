using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration.CompleteWebAPI.Entities
{
    public class TitleEntity
    {
        public Guid Id { get; set; }
        public int Year { get; set; }
        public DateTime Conquered { get; set; }


        public Guid ChampionshipId { get; set; }
        public ChampionshipEntity Championship { get; set; }

        public Guid TeamId { get; set; }
        public TitleEntity Team { get; set; }
    }
}
