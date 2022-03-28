using FCCodingChallenge.Web.Models;
using FCCodingChallenge.Web.Services;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FCCodingChallenge.Web
{
    public partial class UserDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLoadDetails_Click(object sender, EventArgs e)
        {
            try
            {
                var param = txtParameter.Text;
                if (string.IsNullOrEmpty(param))
                {

                }
                else
                {
                    var paramType = radEmail.Checked ? "Email" : "Phone";
                    var getResponse = ApiHelper.GetAsync(param, paramType);
                    if (getResponse != null)
                    {
                        var users = new List<UserVM>();
                        if (radPhone.Checked) 
                        {
                            var response = JsonConvert.DeserializeObject<GenericResponse<List<UserVM>>>(getResponse);
                            users = response.IsSuccessful ? response.Data : null;
                        }
                        if (radEmail.Checked)
                        {
                            var response = JsonConvert.DeserializeObject<GenericResponse<UserVM>>(getResponse);
                            users = response.IsSuccessful ? new List<UserVM> { response.Data } : null;
                        }

                        if (users != null)
                        if (users.Count > 0)
                        {
                            lbGridNotification.Visible = false;
                            gridReports.DataSource = users;
                            gridReports.DataBind();
                        }
                        
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

        protected void gridReports_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
    }
}