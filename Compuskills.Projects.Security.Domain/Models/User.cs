﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compuskills.Projects.Security.Domain.Models
{
    public class User
    {
        public int UsersID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime DOB { get; set; }

        public virtual ICollection<AuthorizationAttempt> AuthorizationAttempts { get; set; }
        public virtual ICollection<UsersCredential> UsersCredentials { get; set; }
    }
}
