using Compuskills.Projects.Security.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compuskills.Projects.Security.Domain.DataSource
{
    public class SecurityInitializer : DropCreateDatabaseAlways<SecurityContext>
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

            ctx.Doors.Add(new Door { Name = "MainDoor" });
            ctx.Doors.Add(new Door { Name = "Safe" });
            ctx.Doors.Add(new Door { Name = "Office" });
            ctx.Doors.Add(new Door { Name = "EmergencyExit" });

            int UserCount = ctx.Users.Count();
            for (int i = 0; i < UserCount; i++)
            {
                ctx.UsersCredentials.Add(new UsersCredential { CredentialID = 1, UsersID = i + 1, Value = (i + 1).ToString() + (i + 1) + (i + 1) });
                ctx.UsersCredentials.Add(new UsersCredential { CredentialID = 2, UsersID = i + 1, Value = (i + 1).ToString() + (i + 1) + (i + 1) + (i + 1)});
                ctx.UsersCredentials.Add(new UsersCredential { CredentialID = 3, UsersID = i + 1, Value = (i + 1).ToString() + (i + 1) + (i + 1) + (i + 1) + (i + 1)});
            }

            int DoorCount = ctx.Doors.Count();
            Random rnd = new Random(15);
            for (int i = 0; i < DoorCount; i++)
            {
                for (int j = 0; j < rnd.Next(1,4); j++)
                {
                    ctx.DoorsCredentials.Add(new DoorsCredential { CredentialID = rnd.Next(1, 4), DoorsID = i + 1 });
                }
            }

            ctx.SaveChanges();
            base.Seed(ctx);
        }
    }
}