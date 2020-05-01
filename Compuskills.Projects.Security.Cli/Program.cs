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
                foreach (var a in sr.GetSuspiciousActivity(new DateTime(2020,05,05), new DateTime(2020, 05, 06)).ToList())
                {
                    Console.WriteLine(a.Result+"    " + a.User.FirstName+"    "+a.User.LastName + "    " +a.Door.Name);
                }
                
                Console.ReadLine();
            }
        }
    }
}
