using NewLeague.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewLeague.Domain.Models
{
    public class Outstanding
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }
        public int TeamId { get; set; }
        public int SeasonId { get; set; }
        public int MatchId { get; set; }
        public virtual Match Match { get; set; }
    }
}