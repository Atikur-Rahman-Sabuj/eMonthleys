namespace eMonthleys.DAL
{
    public class iUserRole
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
    
        public iUserRole() { }

        public iUserRole(int id, string rolename) 
        {
            Id = id;
            RoleName = rolename;
        }
    }
}
