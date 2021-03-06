﻿using Compuskills.Projects.Security.Domain.Models;
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
        public SecurityContext() : base("SecurityDB")
        {
            Database.SetInitializer(new SecurityInitializer());
        }
        public DbSet<Door> Doors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AuthorizationAttempt> AuthorizationAttempts { get; set; }
        public DbSet<AuthorizationAttemptCredential> AuthorizationAttemptsCredentials { get; set; }
        public DbSet<Credential> Credentials { get; set; }
        public DbSet<UserCredential> UserCredentials { get; set; }
        public DbSet<DoorCredential> DoorCredentials { get; set; }
        public DbSet<DoorCredentialDetail> DoorCredentialsDetails { get; set; }

    }
}
