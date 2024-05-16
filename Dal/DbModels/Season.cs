using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Season
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int MonthStart { get; set; }

    public int MonthEnd { get; set; }

    public virtual ICollection<Dish> Dishes { get; set; } = new List<Dish>();

    public virtual ICollection<GroupDish> GroupDishes { get; set; } = new List<GroupDish>();
}
