using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GeeShopping.IdentityServer.Model.Context
{
    public class SqlContext : IdentityDbContext<ApplicationUser>
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {

        }

    }
}
