using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class ModDish
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int Calorie { get; set; }

    public string PosInMenu { get; set; }

    public double Price { get; set; }

    public string PosInCat { get; set; }
}
