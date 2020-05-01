﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Compuskills.Projects.Security.Domain.DataSource;
using Compuskills.Projects.Security.Domain.Models;

namespace Compuskills.Projects.Security.Domain.Repositories
{
    public class SecurityRepository : IDisposable
    {

        private SecurityContext _Db;
        public SecurityContext Db
        {
            get
            {
                if (_Db == null)
                {
                    _Db = new SecurityContext();
                }
                return _Db;
            }
        }

        /// <summary>
        /// Add a new credential to the system.  A credential is a PROOF OF IDENTITY.  It does not
        /// authorize the holder to do anything by itself.  You must use the GrantAccess and
        /// RevokeAccess methods with the new credential for that.
        /// </summary>
        /// <param name="credential">The credential to add.  This should be a security badge, fingerprint, etc</param>
        public void AddCredential(Credential credential)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get a list of all authorization attempts between the two dates.  This includes both successes
        /// and failures.
        /// </summary>
        /// <param name="from">Start date</param>
        /// <param name="to">End date</param>
        /// <returns>Attempts</returns>
        public IQueryable<AuthorizationAttempt> GetActivity(DateTime from, DateTime to)
        {
            return Db.AuthorizationAttempts.Where(x => x.AttemptDate > from && x.AttemptDate < to);
        }

        /// <summary>
        /// Gets a list of only authorization attempts for a specific door by ID.
        /// </summary>
        /// <param name="from">Start date</param>
        /// <param name="to">End date</param>
        /// <param name="doorId">The door to check</param>
        /// <returns></returns>
        public IQueryable<AuthorizationAttempt> GetDoorActivity(DateTime from, DateTime to, int doorId)
        {
            return GetActivity(from, to).Where(x => x.DoorID == doorId);
        }

        /// <summary>
        /// Get a list of only "suspicious" authorization attempts.  An attempt is suspicious if it fails AND
        /// there's not a subsequent success within two minutes.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public IQueryable<AuthorizationAttempt> GetSuspiciousActivity(DateTime from, DateTime to)
        {
            return GetActivity(from,to).Where(e1=> e1.Result==false && Db.AuthorizationAttempts.Where(x => x.AttemptDate > e1.AttemptDate && x.AttemptDate < DbFunctions.AddMinutes(e1.AttemptDate,2)).Any(e2 => e2.Result == true));
        }

        /// <summary>
        /// Grant access to the specified door using the specified set of credentials.  Credentials
        /// always work in SETS.  You need all the credentials in the set for the authorization to pass.
        /// Make sure to store this information in the database in a way that you can query entire sets
        /// at a time in the IsAuthorized method.
        /// </summary>
        /// <param name="doorId">The door to grant access to</param>
        /// <param name="credentials">The credentials to be used</param>
        public void GrantAccess(int doorId, IEnumerable<Credential> credentials)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determine if the authentication items (ie security badge, key code) are valid to open the
        /// door with the specified ID.  This query should look up the authentication requirements for
        /// the door with specified ID and check if the supplied items meet those requirements.
        /// 
        /// This method should also automatically log the attempted authorization and the result.  You
        /// should call the LogAuthorizationAttempt method to log this.
        /// </summary>
        /// <param name="doorId">Database ID of the door to authorize.</param>
        /// <param name="credentials">Items being used to perform the auth (eg security badge, key code)</param>
        /// <returns>true if the request is authorized, otherwise false</returns>
        public bool IsAuthorized(int doorId, IEnumerable<Credential> credentials)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Log an attempt to open a door.  This does not validate the attempt, it only stores the result
        /// in the database.
        /// </summary>
        /// <param name="doorId">The door being accessed</param>
        /// <param name="credentials">The items presented to authorize entry</param>
        /// <param name="result">Whether or not entry was allowed</param>
        public void LogAuthorizationAttempt(int doorId, IEnumerable<Credential> credentials, bool result)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reverse a grant access operation.  When you revoke access for a single credential it revokes
        /// access for any group of credentials that credential was in.
        /// NB: In a "real" app, you would need a much more complex grant / revoke access system to
        /// accomodate changes to individual credentials that don't affect other credentials.
        /// </summary>
        /// <param name="doorId">The door being accessed</param>
        /// <param name="credential">The credential</param>
        public void RevokeAccess(int doorId, Credential credential)
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            if (_Db != null) _Db.Dispose();
        }
    }
}
