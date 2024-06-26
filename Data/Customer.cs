﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BrickedUpBrickBuyer.Data;

public partial class Customer
{
    [Key]
    public int customer_ID { get; set; }

    public string? first_name { get; set; }

    public string? last_name { get; set; }

    public string? birth_date { get; set; }

    public string? country_of_residence { get; set; }

    public string? gender { get; set; }

    public double? age { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
