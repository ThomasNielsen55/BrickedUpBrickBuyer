﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrickedUpBrickBuyer.Data;

public partial class Order
{
    [Key]
    public int TransactionId { get; set; }
	[ForeignKey("CustomerId")]

	public int? CustomerId { get; set; }

    public string? Date { get; set; }

    public string? DayOfWeek { get; set; }

    public int? Time { get; set; }

    public string? EntryMode { get; set; }

    public int? Amount { get; set; }

    public string? TypeOfTransaction { get; set; }

    public string? CountryOfTransaction { get; set; }

    public string? ShippingAddress { get; set; }

    public string? Bank { get; set; }

    public string? TypeOfCard { get; set; }

    public bool? Fraud { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<LineItem> LineItems { get; set; } = new List<LineItem>();
}
