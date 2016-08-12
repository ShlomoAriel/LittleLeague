using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewLeague.Domain.Models;

namespace NewLeague.Models
{
    public class LeagueChampViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeamId { get; set; }
        public virtual TeamViewModel Team { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int Attendances { get; set; }
        public int Outstanding { get; set; }
        public int CleanSheets { get; set; }
        public int PositionId { get; set; }
        public virtual PositionViewModel Position { get; set; }
    }
}