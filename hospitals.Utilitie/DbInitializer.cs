using Microsoft.AspNetCore.Identity;

namespace hospitals.Utilities;

public class DbInitializer : IDbInitializer
{
    private UserManager<IdentityUser> _userManager;
    private RoleManager<IdentityRole> _roleManager;
    private readonly ApplicationDbContext _context;
    public void Intailize()
    {
        throw new NotImplementedException();
    }
}
