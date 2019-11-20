using System.Collections.Generic;
using eMonthleys.DAL;

namespace eMonthleys.BLL
{
    public class UserRole
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
    
        public UserRole() { }

        public UserRole(int id, string rolename) 
        {
            Id = id;
            RoleName = rolename;
        }

        #region Private Methods

        private static UserRole GetUserRoleValuesFromiUserRole(iUserRole record)
        {
            if (record == null)
                return null;
            else
            {
                return new UserRole(
                    record.Id,
                    record.RoleName
                    );
            }
        }

        private static List<UserRole> GetUserRoleListFromiUserRole(List<iUserRole> recordset)
        {
            if (recordset == null)
                return null;
            else
            {
                List<UserRole> roles = new List<UserRole>();
                foreach (iUserRole record in recordset)
                    roles.Add(GetUserRoleValuesFromiUserRole(record));
                return roles;
            }
        }

        #endregion

        public static UserRole GetUserRoleDetails(int UserId)
        {
            UserRole usrrole = GetUserRoleValuesFromiUserRole(UserRoleBase.Instance.Select(UserId));
            return usrrole;
        }

    }
}
