using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compuskills.Projects.Security.Domain.Models
{
    public class DoorCredential
    {
        public int DoorCredentialID { get; set; }
        public int DoorID { get; set; }
        public virtual Door Door { get; set; }
        public virtual ICollection<DoorCredentialDetail> DoorCredentialDetails { get; set; }
    }
}
