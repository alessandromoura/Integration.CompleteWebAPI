using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Integration.CompleteWebAPI.Entities
{
    [Table("Championships")]
    public class ChampionshipEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        public byte[] Trophy { get; set; }

        public Guid FederationId { get; set; }
        public FederationEntity Federation { get; set; }

    }
}
