﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TimingSystem.WebApp.Models;

namespace TimingSystem.WebApp.Database.Entities
{
    public class Tournament
    {
        public Tournament()
        {
            Participants = new List<Participants>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Participants> Participants { get; set; }


    }
}
