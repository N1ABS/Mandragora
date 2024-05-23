using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mandragora.Models
{
    public class Account
    {
        public int Id { get; set; }
        public int ApplicationUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}