using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mandragora.Models
{
    public class Post
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int PlantId { get; set; }
        public DateTime PostDate { get; set; }
        public string Content { get; set; }

        public virtual Account Account { get; set; }
        public virtual Plant Plant { get; set; }


    }
}