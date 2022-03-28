using FCCodingChallenge.Web.Models;
using FCCodingChallenge.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FCCodingChallenge.Web
{
    public partial class CreateUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateUser_Click(object sender, EventArgs e)
        {
            try
            {
                //get the entered data from the controls
                var firstname = txtFirstname.Text;
                var lastname = txtLastname.Text;
                var email = txtEmail.Text;
                var phone = txtPhone.Text;
                var gender = drpGender.SelectedValue;
                var nationality = txtNationality.Text;
                var role = drpRoles.SelectedValue;
                var dob = Convert.ToDateTime(txtDateOfBirth.Text).ToString("yyyy-MM-dd");

                var user = new UserVM
                {
                    DateOfBirth = dob,
                    Email = email,
                    Firstname = firstname,
                    Gender = gender,
                    Lastname = lastname,
                    Nationality = nationality,
                    Phone = phone,
                    Role = role
                };

                //var getResponse = ApiHelper.GetAsync<object>(Constants.GetUserByEmail, "tomi@gmail.com");
                //var createUserResponse = ApiHelper.PostAsync<object>(Constants.CreateUser, user);
                var createUserResponse = ApiHelper.PostAsync(user);
                if(createUserResponse != null)
                {
                    if(createUserResponse.Status == TaskStatus.WaitingForActivation)
                    {
                        lbNotificationInfo.Text = "Request is being Processed";
                        divNotificationInfo.Visible = true;
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            
        }
    }
}