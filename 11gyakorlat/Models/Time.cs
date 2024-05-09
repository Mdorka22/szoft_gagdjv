﻿using System;
using System.Collections.Generic;

namespace _11gyakorlat.Models;

public partial class Time
{
    public byte TimeId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}