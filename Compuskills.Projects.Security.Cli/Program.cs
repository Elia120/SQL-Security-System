using Compuskills.Projects.Security.Domain.DataSource;
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
            using (var db = new SecurityContext())
            {
                foreach (var user in db.Users)
                {
                    Console.WriteLine(user.FirstName+"   "+user.LastName + "   " + user.DOB);
                }
                
                Console.ReadLine();
            }
        }
    }
}
