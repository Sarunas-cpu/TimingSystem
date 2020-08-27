using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace TimingSystem.WebApp.Database.Entities
{
    public class Time
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int TimeId { get; set; }
        public TimeSpan DriveTime { get; set; }
        [ForeignKey("Tournament")]
        public int TournamentRefId { get; set; }
        public Tournament Tournament { get; set; }
    }
}
