using Compuskills.Projects.Security.Domain.DataSource;
using Compuskills.Projects.Security.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compuskills.Projects.Security
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var sr = new SecurityRepository())
            {
                Console.WriteLine(sr.GetDoorActivity(new DateTime(2020, 04, 04), new DateTime(2020, 06, 06),1).Count()); 
                foreach (var a in sr.GetSuspiciousActivity(new DateTime(2020,04,04), new DateTime(2020, 06, 06)).Where(x=> x.DoorID==1 && x.UserID==2))
                {
                    Console.WriteLine(a.Result+"    " + a.User.FirstName+a.User.LastName + "    " +a.Door.Name + "    " +a.AttemptDate + "    " +a.AuthorizationAttemptID);
                }
                
                Console.ReadLine();
            }
        }
    }
}
