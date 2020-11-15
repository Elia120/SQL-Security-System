using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compuskills.Projects.Security.Domain.Models
{
    public class DoorCredentialDetail
    {
        public int DoorCredentialDetailID { get; set; }
        public int CredentialID { get; set; }

        public virtual Credential Credential { get; set; }
        public int DoorCredentialID { get; set; }
        public virtual DoorCredential DoorCredential { get; set; }
        public string Value { get; set; }
    }
}
