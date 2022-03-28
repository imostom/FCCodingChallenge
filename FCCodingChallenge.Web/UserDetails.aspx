<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserDetails.aspx.cs" Inherits="FCCodingChallenge.Web.UserDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <!-- Begin Topbar -->
    <nav class="navbar navbar-expand navbar-light bg-white topbar mb-4 static-top shadow">

        <!-- Sidebar Toggle (Topbar) -->
        <button id="sidebarToggleTop" class="btn btn-link d-md-none rounded-circle mr-3">
            <i class="fa fa-bars"></i>
        </button>

        <div class="d-sm-flex align-items-center justify-content-between mb-4" style="padding-top: 20px">

            <h1 class="h3 mb-0 text-gray-800">Search Page</h1>
        </div>

        <ul class="navbar-nav ml-auto">
            <li style="width: 10%; float: right" aria-grabbed="true">
                <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-light" OnClick="btnLogout_Click" CausesValidation="False" Style="background: none; background-color: none; text-decoration: none"
                    EnableTheming="False" BorderStyle="None" />
            </li>

        </ul>
    </nav>
    <!-- End of Topbar -->


    <!-- Begin Page Content -->
    <div class="container-fluid">


        <!-- Begin Filter -->
        <div class="navbar d-sm-flex align-items-center justify-content-between mb-4" style="padding-left:30%; padding-right:30%; padding-top:2%; background-color:none; color:black">

            <div class="col-xl-10 col-md-10 mb-8">
                <label for="exampleFormControlInput1" class="form-label">Search Parameter:</label>
                <asp:TextBox ID="txtParameter" placeholder="Enter Parameter e.g email or phonenumber" CssClass="form-control" runat="server"></asp:TextBox>
            
            </div>
            
            <div class="col-xl-2 col-md-10 mb-8" style="margin-top:35px">
                <asp:Button ID="btnLoadDetails" BackColor="Black" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary" OnClick="btnLoadDetails_Click" runat="server" Text="Load Details" />
            </div>
        </div>
        <div class="navbar d-sm-flex align-items-center justify-content-between mb-4" style="padding-left:40%; padding-right:40%; background-color:none; color:black">
            <div class="col-xl-5 col-md-10 mb-8">
                <input type="radio" id="radEmail" runat="server" name="fav_language" value="Email">
                <label for="radEmail">Email</label><br>
            </div>
            <div class="col-xl-5 col-md-10 mb-8">
                <input type="radio" id="radPhone" runat="server" name="fav_language" value="Phone">
                <label for="radPhone">Phone</label><br>
            </div>
        </div>

        <%-- End Filter --%>



        <%-- Grid view --%>
        <div class="col-xl-12 col-md-10 mb-8" style="background-color: none; overflow-x: auto; width:60%; background-color: #fff; margin: 20px 20% 20px 20%; text-align: center">
            <center>
            <asp:Label ID="lbGridNotification" runat="server" Text="No records found"></asp:Label>
            <%-- #005500 --%>
            <asp:GridView ID="gridReports" runat="server" PageSize="10" OnPageIndexChanging="gridReports_PageIndexChanging" Font-Size="15px" ForeColor="Black" AllowPaging="true" CellPadding="4">
                <AlternatingRowStyle BackColor="#cdd1d0" ForeColor="#000"></AlternatingRowStyle>
                <HeaderStyle BackColor="#005500" ForeColor="White" HorizontalAlign="Center" />

                <PagerStyle BackColor="#005500" ForeColor="White" HorizontalAlign="Center"></PagerStyle>
            </asp:GridView>
                </center>
        </div>
    </div>
</asp:Content>
