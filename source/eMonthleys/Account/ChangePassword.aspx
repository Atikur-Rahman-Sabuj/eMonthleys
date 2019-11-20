<%@ Page Title="Change Password" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="eMonthleys.ChangePassword" %>

<%@ Register Src="~/controls/adsLeft.ascx" TagPrefix="uc1" TagName="adsLeft" %>
<%@ Register Src="~/controls/adsRight.ascx" TagPrefix="uc1" TagName="adsRight" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <style>
        body {
            padding-top: 50px;
            padding-bottom: 20px;
            background-color: #002664;
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
    <script type="text/javascript">
        equalheight = function (container) {

            var currentTallest = 0,
                 currentRowStart = 0,
                 rowDivs = new Array(),
                 $el,
                 topPosition = 0;
            $(container).each(function () {

                $el = $(this);
                $($el).height('auto');
                topPostion = $el.position().top;

                if (currentRowStart != topPostion) {
                    for (currentDiv = 0 ; currentDiv < rowDivs.length ; currentDiv++) {
                        rowDivs[currentDiv].height(currentTallest);
                    }
                    rowDivs.length = 0; // empty the array
                    currentRowStart = topPostion;
                    currentTallest = $el.height();
                    rowDivs.push($el);
                } else {
                    rowDivs.push($el);
                    currentTallest = (currentTallest < $el.height()) ? ($el.height()) : (currentTallest);
                }
                for (currentDiv = 0 ; currentDiv < rowDivs.length ; currentDiv++) {
                    rowDivs[currentDiv].height(currentTallest);
                }
            });
        };

        $(window).load(function () {
            equalheight('.withads article');
        });


        $(window).resize(function () {
            equalheight('.withads article');
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="withads">
        <div class="row">
            <article class="col-md-3">
                <uc1:adsLeft runat="server" ID="adsLeft" />
            </article>
            <article class="col-md-6 mainpanel">
            <h1><%: Page.Title %></h1>

            <fieldset>
                <legend>Create a new password</legend>
                <div class="form-group">
                    <asp:Label ID="lblCurrentPassword" runat="server" AssociatedControlID="txtOldPassword" CssClass="col-md-4 control-label">Current password:</asp:Label>
                    <div class="col-md-5">
                        <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPwdCh" runat="server" ValidationGroup="vgPwdCh" ControlToValidate="txtOldPassword"
                            CssClass="text-danger" ErrorMessage="Current password is required"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="clear"></div>
                <div class="form-group">
                    <asp:Label ID="lblNewPassword" runat="server" AssociatedControlID="txtNewPassword" CssClass="col-md-4 control-label">New password:</asp:Label>
                    <div class="col-md-5">
                        <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="vgPwdCh" ControlToValidate="txtNewPassword"
                            CssClass="text-danger" ErrorMessage="New password is required"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="clear"></div>
                <div class="form-group">
                    <asp:Label ID="lblConfirm" runat="server" AssociatedControlID="txtConfirmNew" CssClass="col-md-4 control-label">Confirm new password:</asp:Label>
                    <div class="col-md-5">
                        <asp:TextBox ID="txtConfirmNew" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="vgPwdCh" ControlToValidate="txtConfirmNew"
                            CssClass="text-danger" ErrorMessage="Please confirm new password."></asp:RequiredFieldValidator><br />
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password doesn't match with new password."
                            ControlToCompare="txtNewPassword" ControlToValidate="txtConfirmNew" CssClass="text-danger" ValidationGroup="vgPwdCh"></asp:CompareValidator>
                    </div>
                </div>
                <div class="clear"></div>
            </fieldset>
            <div class="centered">
                <asp:Button ID="BtnChangePwd" runat="server" CausesValidation="true" ValidationGroup="vgPwdCh" Text="Change"
                    CssClass="btn btn-primary" OnClick="BtnChangePwd_Click" />
            </div>
            <div class="clear20"></div>
            </article>
            <article class="col-md-3">
                <uc1:adsRight runat="server" ID="adsRight" />
            </article>
            <div class="clear"></div>
        </div>
    </section>
</asp:Content>
