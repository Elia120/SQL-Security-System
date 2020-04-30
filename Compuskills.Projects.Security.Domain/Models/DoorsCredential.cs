using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compuskills.Projects.Security.Domain.Models
{
    public class DoorsCredential
    {
        public int DoorsCredentialID { get; set; }
        public int DoorsID { get; set; }
        public virtual Door Door { get; set; }
        public int CredentialID { get; set; }

        public virtual Credential Credential { get; set; }
        
    }
}
