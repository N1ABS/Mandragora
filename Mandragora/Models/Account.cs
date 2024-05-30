using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mandragora.Models
{
    public class Account
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(128)]
        public string ApplicationUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}