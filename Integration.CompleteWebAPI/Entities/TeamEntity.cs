using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Integration.CompleteWebAPI.Entities
{
    public class TeamEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime FoundationDate { get; set; }
        public byte[] Mascot { get; set; }
        public byte[] Logo { get; set; }
    }
}
