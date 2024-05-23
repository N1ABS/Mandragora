using Microsoft.AspNet.Identity.EntityFramework;

namespace Mandragora.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Mandragora.Models.Plant> Plants { get; set; }

        public System.Data.Entity.DbSet<Mandragora.Models.Account> Accounts { get; set; }

        public System.Data.Entity.DbSet<Mandragora.Models.Reaction> Reactions { get; set; }

        public System.Data.Entity.DbSet<Mandragora.Models.Post> Posts { get; set; }

        public System.Data.Entity.DbSet<Mandragora.Models.PostComment> PostComments { get; set; }
    }
}