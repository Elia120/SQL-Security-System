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

            ctx.Credentials.Add(new Credential { Name = "SecurityBadge", ValueType = false });
            ctx.Credentials.Add(new Credential { Name = "Fingerprint", ValueType = false });
            ctx.Credentials.Add(new Credential { Name = "KeyCode", ValueType = true });

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

            ctx.SaveChanges();

            int UserCount = ctx.Users.Count();
            for (int i = 0; i < UserCount; i++)
            {
                ctx.UserCredentials.Add(new UserCredential { CredentialID = 1, UsersID = i + 1, Value = (i + 1).ToString() + (i + 1) + (i + 1) });
                ctx.UserCredentials.Add(new UserCredential { CredentialID = 2, UsersID = i + 1, Value = (i + 1).ToString() + (i + 1) + (i + 1) + (i + 1) });
            }
            ctx.SaveChanges();

            int DoorCount = ctx.Doors.Count();
            Random rnd = new Random(14);
            for (int i = 0; i < DoorCount; i++)
            {
                for (int j = 0; j < rnd.Next(1, 3); j++)
                {
                    List<int> temp = new List<int>();
                    var DoorCredential = new DoorCredential { DoorID = i + 1 };
                    ctx.DoorCredentials.Add(DoorCredential);
                    for (int x = 0; x < rnd.Next(1, 4); x++)
                    {
                        int now = rnd.Next(1, 4);
                        while (temp.Contains(now))
                        {
                            now = rnd.Next(1, 4);
                        }
                        temp.Add(now);
                        foreach (var id in temp)
                        {
                            ctx.DoorCredentialsDetails.Add(new DoorCredentialDetail { DoorCredential = DoorCredential, CredentialID = id, Value = "111" });
                        }
                    }
                }
            }
            ctx.SaveChanges();

            for (int i = 0; i < 1000; i++)
            {
                ctx.AuthorizationAttempts.Add(new AuthorizationAttempt { DoorID = rnd.Next(1, DoorCount), UserID = rnd.Next(1, UserCount), Result = rnd.Next(0, 2) == 0 ? false : true, AttemptDate = new DateTime(2020, 05, 05, rnd.Next(24), rnd.Next(60), rnd.Next(60)) });
            }

            ctx.SaveChanges();
            base.Seed(ctx);

        }
    }
}