using Compuskills.Projects.Security.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compuskills.Projects.Security.Domain.DataSource
{
    public class SecurityContext : DbContext
    {
        public DbSet<Door> Doors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AuthorizationAttempt> AuthorizationAttempts { get; set; }
        public DbSet<Credential> Credentials { get; set; }
        public DbSet<UsersCredential> UsersCredentials { get; set; }
        public DbSet<DoorsCredential> DoorsCredentials { get; set; }
    }
}
