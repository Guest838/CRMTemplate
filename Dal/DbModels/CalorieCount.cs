using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class CalorieCount
{
    public string Name { get; set; }

    public int Calorie { get; set; }

    public double Price { get; set; }

    public string MeasureUnit { get; set; }

    public int CountForCalorie { get; set; }
}
