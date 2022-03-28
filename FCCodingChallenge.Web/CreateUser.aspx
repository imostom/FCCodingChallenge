<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="FCCodingChallenge.Web.CreateUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/sb-admin-2.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Begin Topbar -->
    <nav class="navbar navbar-expand navbar-light bg-white topbar mb-4 static-top shadow">

        <!-- Sidebar Toggle (Topbar) -->
        <button id="sidebarToggleTop" class="btn btn-link d-md-none rounded-circle mr-3">
            <i class="fa fa-bars"></i>
        </button>

        <div class="d-sm-flex align-items-center justify-content-between mb-4" style="padding-top: 20px">

            <h1 class="h3 mb-0 text-gray-800">New User Page</h1>
        </div>

        <ul class="navbar-nav ml-auto">
            <li style="width: 10%; float: right" aria-grabbed="true">
                <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-light" OnClick="btnLogout_Click" CausesValidation="False" Style="background: none; background-color: none; text-decoration: none"
                    EnableTheming="False" BorderStyle="None" />
            </li>

        </ul>
    </nav>
    <!-- End of Topbar -->
    <div style="padding-top:3%"></div>
    <!-- Begin Page Content -->
    <div class="container-fluid" style="padding-left:30%; padding-right:30%; background-color:none; ">

        <div class="navbar d-sm-flex align-items-center justify-content-between mb-4" style="color: black; background-color: white; border:groove red 1px" id="divNotificationError" visible="false" runat="server">
            <div style="background-color:none; text-align:right; margin:0; width:10%">
                <asp:Image ID="imgNotificationError" ImageUrl="~/assets/images/error icon.png" Width="30px" Height="25px" runat="server" />
            </div>
            <div style="background-color:none; text-align:left; margin:0; width:90%; padding-left:8px">
                <asp:Label ID="lbNotificationError" runat="server" Font-Size="Small" CssClass="form-label" ForeColor="Red" Text="Label jeqhi iqe ief igyqeqi idh" Visible="true"></asp:Label>
            </div>
        </div>

    </div>

    <div class="container-fluid" style="padding-left:30%; padding-right:30%; background-color:none; ">

        <div class="navbar d-sm-flex align-items-center justify-content-between mb-4" style="color: black; background-color: white; border:groove green 1px" id="divNotificationSuccess" visible="false" runat="server">
            <div style="background-color:none; text-align:right; margin:0; width:10%">
                <asp:Image ID="imgNotificationSuccess" ImageUrl="~/assets/images/success-icon.jpg" Width="27px" Height="25px" runat="server" />
            </div>
            <div style="background-color:none; text-align:left; margin:0; width:90%; padding-left:8px">
                <asp:Label ID="lbNotificationSuccess" runat="server" Font-Size="Small" CssClass="form-label" ForeColor="Green" Text="Label jeqhi iqe ief igyqeqi idh" Visible="true"></asp:Label>
            </div>
        </div>

    </div>

    <div class="container-fluid" style="padding-left:30%; padding-right:30%; background-color:none; ">

        <div class="navbar d-sm-flex align-items-center justify-content-between mb-4" style="color: black; background-color: white; border:groove green 1px" id="divNotificationInfo" visible="false" runat="server">
            <div style="background-color:none; text-align:right; margin:0; width:10%">
                <asp:Image ID="imgNotificationInfo" ImageUrl="~/assets/images/success-icon.jpg" Width="27px" Height="25px" runat="server" />
            </div>
            <div style="background-color:none; text-align:left; margin:0; width:90%; padding-left:8px">
                <asp:Label ID="lbNotificationInfo" runat="server" Font-Size="Small" CssClass="form-label" ForeColor="Blue" Text="Label jeqhi iqe ief igyqeqi idh" Visible="true"></asp:Label>
            </div>
        </div>

    </div>
    <%-- End Notification  --%>

    <div class="row" style="padding-left:35%; padding-right:35%; padding-top:2%; background-color:none; color:black">

        <!-- Total APIs Card Example -->
        <div class="col-xl-12 col-md-10 mb-8">
            <label for="exampleFormControlInput1" class="form-label">Firstname:</label>
                <asp:TextBox ID="txtFirstname" CssClass="form-control" runat="server" placeholder="Enter Firstname"></asp:TextBox>
        </div>
        
        <div style="padding:15px"></div>

        <!-- Total APIs Card Example -->
        <div class="col-xl-12 col-md-10 mb-8">
            <label for="exampleFormControlInput1" class="form-label">Lastname:</label>
                <asp:TextBox ID="txtLastname" CssClass="form-control" runat="server" placeholder="Enter Lastname"></asp:TextBox>
        </div>

        <div style="padding:10px"></div>

        <!-- Phone -->
        <div class="col-xl-12 col-md-10 mb-8">
            <label for="exampleFormControlInput1" class="form-label">Phone:</label>
                <asp:TextBox ID="txtPhone" CssClass="form-control" runat="server" placeholder="Enter Phone Number"></asp:TextBox>
        </div>

        <div style="padding:15px"></div>

        <!-- Email -->
        <div class="col-xl-12 col-md-10 mb-8">
            <label for="exampleFormControlInput1" class="form-label">Email:</label>
                <asp:TextBox ID="txtEmail" CssClass="form-control" TextMode="Email" runat="server" placeholder="Enter Email Address"></asp:TextBox>
        </div>

        <div style="padding:15px"></div>

        <!-- DOB -->
        <div class="col-xl-12 col-md-10 mb-8">
            <label for="exampleFormControlInput1" class="form-label">Date of Birth:</label>
                <asp:TextBox ID="txtDateOfBirth" CssClass="form-control" TextMode="Date" runat="server" placeholder="Enter Date of Birth"></asp:TextBox>
        </div>

        <div style="padding:15px"></div>

        <!-- Gender -->
        <div class="col-xl-12 col-md-10 mb-8">
            <label for="exampleFormControlInput1" class="form-label">Gender:</label>
                <asp:DropDownList ID="drpGender" CssClass="form-control" runat="server">
                    <asp:ListItem Selected="True">Please Select Gender</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                    <asp:ListItem>Male</asp:ListItem>
                </asp:DropDownList>
        </div>

        <div style="padding:15px"></div>

         <!-- Nationality -->
        <div class="col-xl-12 col-md-10 mb-8">
            <label for="exampleFormControlInput1" class="form-label">Nationality:</label>
                <asp:TextBox ID="txtNationality" CssClass="form-control" runat="server" placeholder="Enter Nationality e.g. Nigerian"></asp:TextBox>
        </div>

        <div style="padding:15px"></div>

        <!-- Roles -->
        <div class="col-xl-12 col-md-10 mb-8">
            <label for="exampleFormControlInput1" class="form-label">Role:</label>
                <asp:DropDownList ID="drpRoles" CssClass="form-control" runat="server">
                    <asp:ListItem Selected="True">Please Select User Role</asp:ListItem>
                    <asp:ListItem>Administrator</asp:ListItem>
                    <asp:ListItem>Customer</asp:ListItem>
                </asp:DropDownList>
        </div>

        <div style="padding:15px"></div>

        <div class="col-xl-12 col-md-10 mb-8" style="text-align:right">
            <asp:Button ID="btnCreateUser" BackColor="Black" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary" OnClick="btnCreateUser_Click" runat="server" Text="Create User" />
        </div>
    </div>
</asp:Content>
