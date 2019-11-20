<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="eMonthleys.Profile" %>

<%@ Register Src="~/controls/adsLeft.ascx" TagPrefix="uc1" TagName="adsLeft" %>
<%@ Register Src="~/controls/adsRight.ascx" TagPrefix="uc1" TagName="adsRight" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <style>
        body {
            padding-top: 50px;
            padding-bottom: 20px;
            background-color: #002664;
            background-image: url('data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAGQAAABkCAMAAABHPGVmAAABGlBMVEX///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////9y/ChlAAAAXXRSTlMAAQIDBQYHCAkLDQ4PEBETFBYXGxwdHiUsLS4vMTM2ODw9P0tNUlNaXl9hYmRmaWprbm91dnt9f4KDiZicoqeoqbGyv8DFyMrP0NHT1Nba3N3g4eLj5fHy8/b3+v7/lRU/AAAA9UlEQVQYGe3BWTsCARgF4JPSxFiGki1b9hCJLKXsxCS7St///xsmHtduHI+L874QERGR/yGEP5BcRUdiGUSRq/IAkH7aBFPeqjO5ZiMOpomWvZudgKtqgQyYogcNC1ymwDN5YV9a2S6QTJ3X/ZuW2XPt/jEfAUev6zjdJXtL9bheIgKieTsDnfe6A76jafCNxiAiIiIiIiLyG/oH8SkeAs/waRqBwh6Yys0svGObA9OCWeXWfAdMfQ8W2AdV8s4CBTAtvlhHu+iCZaho32qzIBnbXl9bubb24cbWbiYGopzVo2Abb5dAF/aXwJcZAV8YIiIi8rMPkXYpgqMB9TMAAAAASUVORK5CYII=') /*/images/stars2.png*/;
        }

        footer {
            color: #fff;
            width: 100%;
        }

            footer a {
                color: #fff;
                font-weight: bold;
            }

                footer a:hover {
                    color: #BB133E;
                    text-decoration: none;
                }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="withads">
        <div class="row">
            <article class="col-md-3">
                <uc1:adsLeft runat="server" ID="adsLeft" />
            </article>
            <article class="col-md-6 mainpanel">
                <h1><%: Title %></h1>
                <div class="text-right bold">
                    <a href="/account/ChangePassword.aspx">Change my password</a>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblCustomerType" runat="server" AssociatedControlID="RblCustomerType" CssClass="col-md-3 control-label">I am a:</asp:Label>
                    <div class="col-md-7">
                        <asp:RadioButtonList runat="server" ID="RblCustomerType" ValidationGroup="vgModify"
                            RepeatDirection="Horizontal" Width="250" RepeatColumns="2">
                            <asp:ListItem Value="Business">Business</asp:ListItem>
                            <asp:ListItem Value="Private">Private seller</asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="RblCustomerType" SkinID="valSkin"
                            CssClass="text-danger" ErrorMessage="Please indetify whether you are a private seller or business." ValidationGroup="vgModify" />
                    </div>
                </div>
                <br class="clear" />
                <div class="form-group">

                    <asp:Label ID="Label1" runat="server" CssClass="col-md-2 control-label">Email</asp:Label>
                    <div class="col-md-7">
                        <asp:Label ID="lblEmail" runat="server" Text="Label" CssClass="col-md-10 control-label"></asp:Label>
                    </div>
                </div>
                <br class="clear" />
                <div class="form-group">
                    <asp:Label ID="lblCompany" runat="server" AssociatedControlID="txtCompany" CssClass="col-md-3 control-label">Company name</asp:Label>
                    <div class="col-md-7">
                        <asp:TextBox runat="server" ID="txtCompany" CssClass="form-control" ValidationGroup="vgModify" TabIndex="4" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Company name is required." ControlToValidate="txtCity" CssClass="text-danger" ValidationGroup="vgModify"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <br class="clear" />
                <div class="form-group">
                    <asp:Label ID="lblFirstName" runat="server" AssociatedControlID="txtFirstName" CssClass="col-md-3 control-label">First name</asp:Label>
                    <div class="col-md-7">
                        <asp:TextBox runat="server" ID="txtFirstName" CssClass="form-control" ValidationGroup="vgModify" TabIndex="5" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFirstName"
                            CssClass="text-danger" ErrorMessage="First name is required." ValidationGroup="vgModify" SkinID="valSkin" />
                    </div>
                </div>
                <br class="clear" />
                <div class="form-group">
                    <asp:Label ID="lblLastName" runat="server" AssociatedControlID="txtLastName" CssClass="col-md-3 control-label">Last name</asp:Label>
                    <div class="col-md-7">
                        <asp:TextBox runat="server" ID="txtLastName" CssClass="form-control" ValidationGroup="vgModify" TabIndex="6" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtLastName"
                            CssClass="text-danger" ErrorMessage="Last name is required." ValidationGroup="vgModify" SkinID="valSkin" />
                    </div>
                </div>
                <br class="clear" />
                <div class="form-group">
                    <asp:Label ID="lblStreetNo" runat="server" AssociatedControlID="txtStreetNo" CssClass="col-md-3 control-label">Street No.</asp:Label>
                    <div class="col-md-7">
                        <asp:TextBox runat="server" ID="txtStreetNo" CssClass="form-control" ValidationGroup="vgModify" MaxLength="10" TabIndex="7" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Street No is required." ControlToValidate="txtStreetNo" CssClass="text-danger" ValidationGroup="vgModify"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtStreetNo" CssClass="text-danger" ErrorMessage="Street no. must be numeric" ValidationExpression="^\d{1,10}$" ValidationGroup="vgModify"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <br class="clear" />
                <div class="form-group">
                    <asp:Label ID="lblStreetNoSuffix" runat="server" AssociatedControlID="txtStreetNoSuffix" CssClass="col-md-3 control-label">Street No Suffix</asp:Label>
                    <div class="col-md-7">
                        <asp:TextBox runat="server" ID="txtStreetNoSuffix" CssClass="form-control" ValidationGroup="vgModify" MaxLength="10" TabIndex="8" />
                    </div>
                </div>
                <br class="clear" />
                <br class="clear" />
                <div class="form-group">
                    <asp:Label ID="lbltxtAddress1" runat="server" AssociatedControlID="txtAddress1" CssClass="col-md-3 control-label">Address 1</asp:Label>
                    <div class="col-md-7">
                        <asp:TextBox runat="server" ID="txtAddress1" CssClass="form-control" ValidationGroup="vgModify" MaxLength="100" TabIndex="9" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Address is required." ControlToValidate="txtAddress1" CssClass="text-danger" ValidationGroup="vgModify"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <br class="clear" />
                <div class="form-group">
                    <asp:Label ID="lblAddress2" runat="server" AssociatedControlID="txtAddress2" CssClass="col-md-3 control-label">Address 2</asp:Label>
                    <div class="col-md-7">
                        <asp:TextBox runat="server" ID="txtAddress2" CssClass="form-control" ValidationGroup="vgModify" MaxLength="50" TabIndex="10" />
                    </div>
                </div>
                <br class="clear" />
                <br class="clear" />
                <div class="form-group">
                    <asp:Label ID="lblPobox" runat="server" AssociatedControlID="txtPobox" CssClass="col-md-3 control-label">PO Box</asp:Label>
                    <div class="col-md-7">
                        <asp:TextBox runat="server" ID="txtPobox" CssClass="form-control" ValidationGroup="vgModify" MaxLength="10" TabIndex="11" />
                    </div>
                </div>
                <br class="clear" />
                <br class="clear" />
                <div class="form-group">
                    <asp:Label ID="lblCity" runat="server" AssociatedControlID="txtCity" CssClass="col-md-3 control-label">City</asp:Label>
                    <div class="col-md-7">
                        <asp:TextBox runat="server" ID="txtCity" CssClass="form-control" MaxLength="50" ValidationGroup="vgModify" TabIndex="12" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="City is required." ControlToValidate="txtCity" CssClass="text-danger" ValidationGroup="vgModify"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <br class="clear" />
                <div class="form-group">
                    <asp:Label ID="lblProvince" runat="server" AssociatedControlID="ddlState" CssClass="col-md-3 control-label">Province/State</asp:Label>
                    <div class="col-md-7">
                        <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control" Width="200px" ValidationGroup="vgModify" TabIndex="13">
                            <asp:ListItem Value="">Please Select</asp:ListItem>
                            <asp:ListItem Value="AB">Alberta</asp:ListItem>
                            <asp:ListItem Value="BC">British Columbia</asp:ListItem>
                            <asp:ListItem Value="MB">Manitoba</asp:ListItem>
                            <asp:ListItem Value="NB">New Brunswick</asp:ListItem>
                            <asp:ListItem Value="NF">Newfoundland and Labrador</asp:ListItem>
                            <asp:ListItem Value="NT">Northwest Territories</asp:ListItem>
                            <asp:ListItem Value="NS">Nova Scotia</asp:ListItem>
                            <asp:ListItem Value="NU">Nunavut</asp:ListItem>
                            <asp:ListItem Value="ON">Ontario</asp:ListItem>
                            <asp:ListItem Value="PE">Prince Edward Island</asp:ListItem>
                            <asp:ListItem Value="QE">Quebec</asp:ListItem>
                            <asp:ListItem Value="SK">Saskatchewan</asp:ListItem>
                            <asp:ListItem Value="YT">Yukon</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="State is required." ControlToValidate="ddlState" CssClass="text-danger" InitialValue="" ValidationGroup="vgModify"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <br class="clear" />
                <div class="form-group">
                    <asp:Label ID="lbltxtZip" runat="server" AssociatedControlID="txtZip" CssClass="col-md-3 control-label">Postal/Zip code</asp:Label>
                    <div class="col-md-7">
                        <asp:TextBox runat="server" ID="txtZip" CssClass="form-control" MaxLength="7" ValidationGroup="vgModify" TabIndex="14" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="ZIP code is required." ControlToValidate="txtZip" CssClass="text-danger" ValidationGroup="vgModify"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <br class="clear" />
                <div class="form-group">
                    <asp:Label ID="lblCountry" runat="server" AssociatedControlID="ddlCountry" CssClass="col-md-3 control-label">Country</asp:Label>
                    <div class="col-md-7">
                        <asp:DropDownList runat="server" ID="ddlCountry" CssClass="form-control" ValidationGroup="vgModify" Width="200px" TabIndex="15">
                            <asp:ListItem>Please select</asp:ListItem>
                            <asp:ListItem>Canada</asp:ListItem>
                            <asp:ListItem>U.S.A.</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="Country is required." ControlToValidate="ddlCountry"
                            InitialValue="Please select" CssClass="text-danger" ValidationGroup="vgModify"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <br class="clear" />
                <div class="form-group">
                    <asp:Label ID="lblPhone" runat="server" AssociatedControlID="txtPhone" CssClass="col-md-3 control-label">Phone</asp:Label>
                    <div class="col-md-7">
                        <asp:TextBox runat="server" ID="txtPhone" CssClass="form-control" MaxLength="30" TabIndex="16" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="Phone number is required." ControlToValidate="txtPhone" CssClass="text-danger" ValidationGroup="vgModify"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <br class="clear" />
                <div class="form-group">
                    <asp:Label ID="lblCellPhone" runat="server" AssociatedControlID="txtCellPhone" CssClass="col-md-3 control-label">Cell Phone</asp:Label>
                    <div class="col-md-7">
                        <asp:TextBox runat="server" ID="txtCellPhone" CssClass="form-control" MaxLength="20" TabIndex="17" />
                    </div>
                </div>
                <br class="clear" />
                <div class="form-group centered paddingtop10">
                    <div class="centered">
                        <asp:Label Visible="False" ID="lblResult" runat="server" CssClass="text-danger"></asp:Label>
                        <asp:Button ID="BtnModifyUser" runat="server" OnClick="BtnModifyCustomer_Click" Text="Update" CssClass="btn btn-primary" ValidationGroup="vgModify" TabIndex="19" />
                    </div>
                </div>
            </article>
            <article class="col-md-3">
                <uc1:adsRight runat="server" ID="adsRight" />
            </article>
            <div class="clear"></div>
        </div>
    </section>
</asp:Content>
