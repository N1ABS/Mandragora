using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mandragora.Models
{
    public class Plant 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Details { get; set; }

        public virtual IList<Post> Posts { get; set; }
    }
      
}