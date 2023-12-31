﻿using System;
using System.Collections.Generic;

namespace PTUDW_01_KHMT.Models;

public partial class TbLocation
{
    public int LocationId { get; set; }

    public string? Name { get; set; }

    public int? Parent { get; set; }

    public virtual ICollection<TbCustomer> TbCustomers { get; set; } = new List<TbCustomer>();
}
