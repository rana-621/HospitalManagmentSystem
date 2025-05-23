using Microsoft.AspNet.Identity.EntityFramework;

namespace Hospital.Repositories
{
    class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
