using System;
using System.Collections.Generic;
using System.Data;
using eMonthleys.Utils;

namespace eMonthleys.DAL
{
    public abstract class UserRoleBase : DataAccess
    {
        static private UserRoleBase _instance = null;

        static public UserRoleBase Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (UserRoleBase)Activator.CreateInstance(Type.GetType("eMonthleys.DAL.UserRoleDA"));
                return _instance;
            }
        }

        public UserRoleBase()
        {
            ConnectionString = Helpers.GetConnectionString();
        }

        public abstract iUserRole Select(int id);

        protected virtual iUserRole GetUserRoleFromReader(IDataReader reader, bool singleRecord)
        {
            if (singleRecord)
                reader.Read();
            iUserRole UserRole = new iUserRole(
                Convert.ToInt32(reader["id"]),
                reader["usertype"].ToString()
                );
            return UserRole;
        }

        protected virtual List<iUserRole> GetUserRoleCollectionFromReader(IDataReader reader)
        {
            List<iUserRole> UserRoles = new List<iUserRole>();
            while (reader.Read())
                UserRoles.Add(GetUserRoleFromReader(reader, false));
            return UserRoles;
        }
    }
}
