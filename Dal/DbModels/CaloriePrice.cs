﻿using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class CaloriePrice
{
    public int Id { get; set; }

    public string Name { get; set; }

    public double Price { get; set; }

    public int Calorie { get; set; }
}
