﻿using NewLeague.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewLeague.Domain.Models
{
    public class CleanSheetViewModel
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public virtual PlayerViewModel Player { get; set; }
        public int SeasonId { get; set; }
    }
}