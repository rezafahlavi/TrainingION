using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;

namespace TP.Models
{
    public class CombinedModels
    {
        public Order order { get; set; }
        public Supplier supplier { get; set; }
    }
}