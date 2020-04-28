﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compuskills.Projects.Security.Domain.Models
{
    public class UsersCredential
    {
        public int UsersCredentialsID { get; set; }
        public int UsersID { get; set; }
        public virtual User User { get; set; }
        public int CredentialsID { get; set; }
        public virtual Credential Credential { get; set; }
        public string Value { get; set; }

        
        
    }
}