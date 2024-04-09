using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrickedUpBrickBuyer.Data;

public partial class LineItem
{
    [Key]
    public int LineItemId { get; set; }
	[ForeignKey("TransactionId")]
    public int? TransactionId { get; set; }
	[ForeignKey("ProductId")]
	public int? ProductId { get; set; }

    public int? Qty { get; set; }

    public int? Rating { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Order? Transaction { get; set; }
}
