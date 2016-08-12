using NewLeague.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewLeague.Domain.Models
{
    public class LeagueViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<SeasonViewModel> Seasons { get; set; }
    }
}