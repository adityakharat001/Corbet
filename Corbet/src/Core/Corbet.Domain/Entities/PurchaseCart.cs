﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Domain.Entities
{
    public class PurchaseCart
    {

        [Key]
        public int CartId { get; set; }
        public int UserId { get; set; }
        public double Price { get; set; }
        public int StockId { get; set; }
        public int Quantity { get; set; }


    }
}