<%@ Page Title="Password Help" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PasswordHelp.aspx.cs" Inherits="eMonthleys.PasswordHelp" %>

<%@ Register Src="~/controls/adsLeft.ascx" TagPrefix="uc1" TagName="adsLeft" %>
<%@ Register Src="~/controls/adsRight.ascx" TagPrefix="uc1" TagName="adsRight" %>
<%@ Register Assembly="BotDetect" Namespace="BotDetect.Web.UI" TagPrefix="BotDetect" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <style>
        body {
            padding-top: 50px;
            padding-bottom: 20px;
            background-color: #002664;
            background-image: url("/images/stars2.png");
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
    <div class="row">
        <div class="col-md-3">
            <uc1:adsLeft runat="server" ID="adsLeft" />
        </div>
        <div class="col-md-6 mainpanel">
            <h2><%: Title %></h2>

            <section id="loginForm">
                <div class="form-group">
                    <fieldset>
                        <legend></legend>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="txtUserId" CssClass="col-md-2 control-label">Email:</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="txtUserId" CssClass="form-control" ValidationGroup="vgHelp" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUserId" Text="*"
                                    CssClass="text-danger" ErrorMessage="The user name field is required." ValidationGroup="vgHelp" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-offset-4 col-md-8">
                                <BotDetect:WebFormsCaptcha ID="PasswordHelpCaptcha" runat="server" />
                            </div>
                            <asp:Label runat="server" AssociatedControlID="CaptchaCode" CssClass="col-md-4 control-label">Retype code</asp:Label>
                            <div class="col-md-8">
                                <asp:TextBox runat="server" ID="CaptchaCode" CssClass="form-control captchaVal" />
                                <asp:RequiredFieldValidator ID="CaptchaRequiredValidator" runat="server" ControlToValidate="CaptchaCode"
                                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Retyping the code from the picture is required." />
                                <asp:CustomValidator runat="server" ID="CaptchaValidator" ControlToValidate="CaptchaCode"
                                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Incorrect code, please try again."
                                    OnServerValidate="CaptchaValidator_ServerValidate" ClientValidationFunction="ValidateCaptcha" />
                            </div>
                        </div>
                    </fieldset>
                    <div class="centered">
                        <asp:ValidationSummary ID="ValidationSummary" runat="server" CssClass="text-danger" />
                    </div>
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="ErrorMessage" />
                        </p>
                    <div class="form-group centered paddingtop10">
                        <asp:Button ID="BtnHelp" runat="server" OnClick="BtnHelp_Click" Text="Get Password" CausesValidation="true" CssClass="btn btn-primary" ValidationGroup="vgHelp" />
                    </div>
                </div>
                <p>
                    <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled" NavigateUrl="~/Account/Register.aspx">
                        Register</asp:HyperLink>&nbsp;if you don't have an account. 
                </p>
            </section>
        </div>
        <div class="col-md-3">
            <uc1:adsRight runat="server" ID="adsRight" />
        </div>
        <div class="clear"></div>
    </div>
</asp:Content>
