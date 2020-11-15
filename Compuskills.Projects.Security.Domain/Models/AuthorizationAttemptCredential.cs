using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compuskills.Projects.Security.Domain.Models
{
    public class AuthorizationAttemptCredential
    {
        public int AuthorizationAttemptCredentialID { get; set; }
        public int AuthorizationAttemptID { get; set; }

        public virtual AuthorizationAttempt AuthorizationAttempt { get; set; }
        public int CredentialID { get; set; }

        public virtual Credential Credential { get; set; }
        public string Value { get; set; }
    }
}
