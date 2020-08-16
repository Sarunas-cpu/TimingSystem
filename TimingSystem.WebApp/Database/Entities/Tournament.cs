using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimingSystem.WebApp.Database.Entities
{
    public class Tournament
    {
        [Key]
        public int id { get; set; }

        public string name { get; set; }
    }
}
