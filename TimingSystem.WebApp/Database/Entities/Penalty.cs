using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TimingSystem.WebApp.Database.Entities
{
    public class Penalty
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int PenaltyId { get; set; }
        public string Description { get; set; }
        [ForeignKey("Tournament")]
        public int TournamentRefId { get; set; }
        public Tournament Tournament { get; set; }
    }
}
