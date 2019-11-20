<%@ Page Title="Create an account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="eMonthleys.Register" %>

<%@ Register Src="~/controls/adsLeft.ascx" TagPrefix="uc1" TagName="adsLeft" %>
<%@ Register Src="~/controls/adsRight.ascx" TagPrefix="uc1" TagName="adsRight" %>
<%@ Register Assembly="BotDetect" Namespace="BotDetect.Web.UI" TagPrefix="BotDetect" %>

<asp:Content ID="Header1" ContentPlaceHolderID="HeaderContent" runat="server">
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

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <section class="withads">
        <div class="row">
            <article class="col-md-3">
                <uc1:adsLeft runat="server" ID="adsLeft" />
            </article>
            <article class="col-md-6 mainpanel">
                <h2><%: Title %></h2>

                <div class="form-horizontal">
                    <hr />
                    <asp:ValidationSummary runat="server" CssClass="text-danger" />
                    <fieldset>
                        <legend>* = required field
                        </legend>
                        <p>By entering your information you consent to the <a href="/Policy.aspx">privacy policy</a> and the <a href="/TermsOfUse.aspx">conditions and terms of use</a> of emonthlies/James Wood Logix Inc&#8482;.</p>
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="ErrorMessage" />
                        </p>
                        <div class="form-group">
                            <div class="col-md-10">
                                <asp:RadioButtonList runat="server" ID="RblCustomerType"
                                    RepeatDirection="Horizontal" Width="250" RepeatColumns="2" AutoPostBack="true" OnSelectedIndexChanged="RblCustomerType_SelectedIndexChanged">
                                    <asp:ListItem Value="Business">Business</asp:ListItem>
                                    <asp:ListItem Value="Private">Private seller</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="RblCustomerType"
                                    CssClass="text-danger" ErrorMessage="Please indetify whether you are a private seller or business." />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="TxtEmail" CssClass="col-md-3">Email *</asp:Label>
                            <div class="col-md-9">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox runat="server" ID="TxtEmail" CssClass="form-control" MaxLength="100" AutoPostBack="True" OnTextChanged="TxtEmail_TextChanged" TabIndex="1" />
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="TxtEmail"
                                            CssClass="text-danger" ErrorMessage="Email is required." />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please use correct email syntax."
                                            ControlToValidate="TxtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="text-danger"></asp:RegularExpressionValidator>

                                    </ContentTemplate>
                                    <Triggers>

                                        <asp:AsyncPostBackTrigger ControlID="TxtEmail" EventName="TextChanged" />

                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="txtPassword" CssClass="col-md-3">Password *</asp:Label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control" TabIndex="2" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword"
                                    CssClass="text-danger" ErrorMessage="Password is required." />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="txtConfirmPassword" CssClass="col-md-3">Confirm password *</asp:Label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtConfirmPassword" TextMode="Password" CssClass="form-control" TabIndex="3" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtConfirmPassword"
                                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Confirm password field is required." />
                                <asp:CompareValidator runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword"
                                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Passwords do not match." />
                            </div>
                        </div>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:Panel ID="pnlCompanyName" runat="server">
                                    <div class="form-group">
                                        <asp:Label ID="lblCompany" runat="server" AssociatedControlID="txtCompany" CssClass="col-md-3">Company name *</asp:Label>
                                        <div class="col-md-9">
                                            <asp:TextBox runat="server" ID="txtCompany" CssClass="form-control" TabIndex="4" />
                                            <asp:RequiredFieldValidator ID="rfvCompany" runat="server" ErrorMessage="Company name is required." ControlToValidate="txtCity" CssClass="text-danger"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </asp:Panel>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="RblCustomerType" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                        <div class="form-group">
                            <asp:Label ID="lblFirstName" runat="server" AssociatedControlID="txtFirstName" CssClass="col-md-3">First name *</asp:Label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtFirstName" CssClass="form-control" TabIndex="5" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFirstName"
                                    CssClass="text-danger" ErrorMessage="First name is required." />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblLastName" runat="server" AssociatedControlID="txtLastName" CssClass="col-md-3">Last name *</asp:Label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtLastName" CssClass="form-control" TabIndex="6" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLastName"
                                    CssClass="text-danger" ErrorMessage="Last name is required." />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblStreetNo" runat="server" AssociatedControlID="txtStreetNo" CssClass="col-md-3">Street No. *</asp:Label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtStreetNo" CssClass="form-control" MaxLength="10" TabIndex="7" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Street No is required." ControlToValidate="txtStreetNo" CssClass="text-danger"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtStreetNo" CssClass="text-danger" ErrorMessage="Street no. must be numeric" ValidationExpression="^\d{1,10}$"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblStreetNoSuffix" runat="server" AssociatedControlID="txtStreetNoSuffix" CssClass="col-md-3">Street No Suffix</asp:Label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtStreetNoSuffix" CssClass="form-control" MaxLength="10" TabIndex="8" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lbltxtAddress1" runat="server" AssociatedControlID="txtAddress1" CssClass="col-md-3">Address 1 *</asp:Label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtAddress1" CssClass="form-control" MaxLength="100" TabIndex="9" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Address is required." ControlToValidate="txtAddress1" CssClass="text-danger"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblAddress2" runat="server" AssociatedControlID="txtAddress2" CssClass="col-md-3">Address 2</asp:Label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtAddress2" CssClass="form-control" MaxLength="50" TabIndex="10" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblPobox" runat="server" AssociatedControlID="txtPobox" CssClass="col-md-3">PO Box</asp:Label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtPobox" CssClass="form-control" MaxLength="10" TabIndex="11" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblCity" runat="server" AssociatedControlID="txtCity" CssClass="col-md-3">City *</asp:Label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtCity" CssClass="form-control" MaxLength="50" TabIndex="12" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="City is required." ControlToValidate="txtCity" CssClass="text-danger"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblProvince" runat="server" AssociatedControlID="ddlState" CssClass="col-md-3">Province/State *</asp:Label>
                            <div class="col-md-9">
                                <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control" Width="200px" TabIndex="13">
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


                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="State is required." ControlToValidate="ddlState" CssClass="text-danger" InitialValue=""></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lbltxtZip" runat="server" AssociatedControlID="txtZip" CssClass="col-md-3">Postal/Zip code *</asp:Label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtZip" CssClass="form-control" MaxLength="7" TabIndex="14" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="ZIP code is required." ControlToValidate="txtZip" CssClass="text-danger"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblCountry" runat="server" AssociatedControlID="ddlCountry" CssClass="col-md-3">Country *</asp:Label>
                            <div class="col-md-9">
                                <asp:DropDownList runat="server" ID="ddlCountry" CssClass="form-control" Width="200px" TabIndex="15">
                                    <asp:ListItem Value="">Please select</asp:ListItem>
                                    <asp:ListItem>Canada</asp:ListItem>
                                    <asp:ListItem>U.S.A.</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Country is required." ControlToValidate="ddlCountry"
                                    InitialValue="" CssClass="text-danger"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblPhone" runat="server" AssociatedControlID="txtPhone" CssClass="col-md-3">Phone *</asp:Label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtPhone" CssClass="form-control" MaxLength="30" TabIndex="16" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Phone number is required." ControlToValidate="txtPhone" CssClass="text-danger"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblCellPhone" runat="server" AssociatedControlID="txtCellPhone" CssClass="col-md-3">Cell Phone</asp:Label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtCellPhone" CssClass="form-control" MaxLength="20" TabIndex="17" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-offset-4 col-md-8">
                                <BotDetect:WebFormsCaptcha ID="RegisterCaptcha" runat="server" />
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
                    <div class="form-group centered paddingtop10">
                        <div class="centered">
                            <asp:Label Visible="False" ID="lblResult" runat="server" CssClass="text-danger"></asp:Label>
                            <asp:Button ID="BtnCreateUser" runat="server" OnClick="BtnCreateUser_Click" Text="Register" CssClass="btn btn-primary" TabIndex="19" />
                        </div>
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
