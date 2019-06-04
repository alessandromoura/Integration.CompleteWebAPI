using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration.CompleteWebAPI.Models
{
    public class TeamDto
    {
        public Guid TeamId { get; set; }
        public string TeamName { get; set; }
        public DateTime TeamFoundation { get; set; }
        public byte[] MascotImage { get; set; }
        public byte[] LogoImage { get; set; }
    }
}
