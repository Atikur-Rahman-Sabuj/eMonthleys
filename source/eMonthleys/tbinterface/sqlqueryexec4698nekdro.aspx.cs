using eMonthleys.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eMonthleys.tbinterface
{
    public partial class sqlqueryexec4698nekdro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string query = TextBox1.Text;
            Label1.Text = query;
            bool isExecuted = CustomerVehicleInfo.ManipulateDatabase(query);
            if (isExecuted)
            {
                Label1.Text = "Executed successfully";
            }
            else
            {
                Label1.Text = "Sorry could not executed";
            }
        }
    }
}