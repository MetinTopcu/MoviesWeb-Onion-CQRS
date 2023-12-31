﻿using Movies.Services.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services.Core.Domain.Entities
{
    public class Films : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }
        public int AgeLimit { get; set; }
        public int Duration { get; set; }
        public int CategoriesId { get; set; }
        public DateTime CreatedTime { get; set; }
        public Categories Categories { get; set; }
        public Contents Contents { get; set; }
    }
}
