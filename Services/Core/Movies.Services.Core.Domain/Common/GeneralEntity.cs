﻿using Movies.Services.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services.Core.Domain.Common
{
    public class GeneralEntity
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Name { get; set; }
        public int AgeLimit { get; set; }
        public int Duration { get; set; }
        public int CategoriesId { get; set; }
        public Categories Categories { get; set; }
        public int ContentsId { get; set; }
        public List<Contents> Contents { get; set; }
    }
}
