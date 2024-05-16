using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Feedback
{
    public int Id { get; set; }

    public string Description { get; set; }

    public int Score { get; set; }

    public virtual ICollection<Dish> IdDishes { get; set; } = new List<Dish>();
}
