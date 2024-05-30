using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mandragora.Models
{
    public class PostComment
    {
        public int Id { get; set; }
        public int? PostId { get; set; }
        public int? AccountId { get; set; }
        public string Comment { get; set; }

        public virtual Account Account { get; set; }

        public virtual Post Post { get; set; }
     }
}