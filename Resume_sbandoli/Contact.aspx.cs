using Resume_sbandoli.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Resume_sbandoli
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Checking for unique email address
            Boolean isUniqueName = true;

            DataSourceSelectArguments arguments = new DataSourceSelectArguments();
            foreach (DataRowView view in ContactInfoTable.Select(arguments))
            {
                if (view.Row["Email"].Equals(txtEmail.Text))
                {
                    isUniqueName = false;
                }
            }

            if (isUniqueName)
            {
                // Create and populate a ContactInfo object
                ContactInfo Cinfo = new ContactInfo();

                Cinfo.name = txtName.Text;
                Cinfo.date = txtDate.Text;
                Cinfo.email = txtEmail.Text;
                Cinfo.subject = txtSubject.Text;
                Cinfo.message = txtMessage.Text;

                // Add the new user contact info to the database
                ContactInfoTable.InsertParameters["Name"].DefaultValue = Cinfo.name;
                ContactInfoTable.InsertParameters["Date"].DefaultValue = Cinfo.date;
                ContactInfoTable.InsertParameters["Email"].DefaultValue = Cinfo.email;
                ContactInfoTable.InsertParameters["Subject"].DefaultValue = Cinfo.subject;
                ContactInfoTable.InsertParameters["Message"].DefaultValue = Cinfo.message;

                ContactInfoTable.Insert();

                // Add the user to the session
                Session.Add("AuthenticatedUser", Cinfo);
            }
            else
            {
                // User Information isn't unique
                Response.Redirect("Contact.aspx");
            }
        }
    }
}