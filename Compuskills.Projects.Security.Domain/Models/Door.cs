using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compuskills.Projects.Security.Domain.Models
{
    public class Door
    {
        public int DoorID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<DoorsCredential> DoorsCredentials { get; set; }
        public virtual ICollection<AuthorizationAttempt> AuthorizationAttempts { get; set; }
    }
}
