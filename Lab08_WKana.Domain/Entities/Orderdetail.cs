﻿namespace Lab08_WKana.Domain.Entities;

public partial class Orderdetail
{
    public int Orderdetailid { get; set; }

    public int Orderid { get; set; }

    public int Productid { get; set; }

    public int Quantity { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
