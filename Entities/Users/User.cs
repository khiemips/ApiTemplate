using Common.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Values
{
    public class User : EntityBase
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? Birthday { get; set; }
    }
}
