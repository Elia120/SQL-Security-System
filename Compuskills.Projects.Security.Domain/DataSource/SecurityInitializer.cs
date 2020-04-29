using Compuskills.Projects.Security.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compuskills.Projects.Security.Domain.DataSource
{
    public class SecurityInitializer : DropCreateDatabaseIfModelChanges<SecurityContext>
    {
        protected override void Seed(SecurityContext ctx)
        {
            ctx.Credentials.Add(new Credential { Name = "SecurityBadge" });
            ctx.Credentials.Add(new Credential { Name = "Fingerprint" });
            ctx.Credentials.Add(new Credential { Name = "KeyCode" });

            ctx.Users.Add(new User { FirstName = "Stuard", LastName = "Kibry", DOB = new DateTime(1990, 09, 15), });
            ctx.Users.Add(new User { FirstName = "Elijahu", LastName = "Sternbuch", DOB = new DateTime(1998, 10, 16), });
            ctx.Users.Add(new User { FirstName = "Chananel", LastName = "Miller", DOB = new DateTime(1999, 05, 15), });
            ctx.Users.Add(new User { FirstName = "Chaim", LastName = "Mozes", DOB = new DateTime(1998, 09, 05), });
            ctx.Users.Add(new User { FirstName = "Harry", LastName = "Licht", DOB = new DateTime(1930, 09, 13), });
            ctx.Users.Add(new User { FirstName = "Aron", LastName = "Katzauer", DOB = new DateTime(1998, 09, 15), });
            ctx.Users.Add(new User { FirstName = "Nussi", LastName = "Ollech", DOB = new DateTime(1997, 07, 25), });

            ctx.SaveChanges();
        }
    }
}