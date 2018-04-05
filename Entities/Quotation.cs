using System;
using System.Collections.Generic;
using System.Text;
using Common.Entity;

namespace Entities
{
    public class Quotation : EntityBase
    {
        public string Company { get; set; }
        public decimal Price { get; set; }
    }
}
