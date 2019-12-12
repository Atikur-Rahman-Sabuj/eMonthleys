<%@ Page Title="Advertise With Us" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Advertise.aspx.cs" Inherits="eMonthleys.advertise" %>

<%@ Register Src="~/controls/adsLeft.ascx" TagPrefix="uc1" TagName="adsLeft" %>
<%@ Register Src="~/controls/adsRight.ascx" TagPrefix="uc1" TagName="adsRight" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <style>
        body {
            padding-top: 50px;
            padding-bottom: 20px;
            background-color: #002664;
            background-image: url('data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAGQAAABkCAMAAABHPGVmAAABGlBMVEX///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////9y/ChlAAAAXXRSTlMAAQIDBQYHCAkLDQ4PEBETFBYXGxwdHiUsLS4vMTM2ODw9P0tNUlNaXl9hYmRmaWprbm91dnt9f4KDiZicoqeoqbGyv8DFyMrP0NHT1Nba3N3g4eLj5fHy8/b3+v7/lRU/AAAA9UlEQVQYGe3BWTsCARgF4JPSxFiGki1b9hCJLKXsxCS7St///xsmHtduHI+L874QERGR/yGEP5BcRUdiGUSRq/IAkH7aBFPeqjO5ZiMOpomWvZudgKtqgQyYogcNC1ymwDN5YV9a2S6QTJ3X/ZuW2XPt/jEfAUev6zjdJXtL9bheIgKieTsDnfe6A76jafCNxiAiIiIiIiLyG/oH8SkeAs/waRqBwh6Yys0svGObA9OCWeXWfAdMfQ8W2AdV8s4CBTAtvlhHu+iCZaho32qzIBnbXl9bubb24cbWbiYGopzVo2Abb5dAF/aXwJcZAV8YIiIi8rMPkXYpgqMB9TMAAAAASUVORK5CYII=');
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
        $(document).ready(function () {
            var tbval = $('#<%=txtUrl.ClientID%>').val();
            $('#<%=txtUrl.ClientID%>').focus(function () { $(this).val(''); });
            $('#<%=txtUrl.ClientID%>').blur(function () { if ($(this).val().length === 0) $(this).val(tbval); });
        });
    </script>
    <script type="text/javascript">

        var isSubmitted = false;

        function preventMultipleSubmissions() {
            if (!isSubmitted) {
                $('#<%=BtnSaveAd.ClientID %>').val('Submitting ad.. Plz Wait..');
                isSubmitted = true;
                return true;
            }
            else {
                return false;
            }
        }
    </script>

</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-3">
            <uc1:adsLeft runat="server" ID="adsLeft" />
        </div>
        <div class="col-md-6 mainpanel">
            <h1><%: Title %></h1>
            <hr />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="text-danger" />
            <fieldset>
                <legend>Create a new ad</legend>
                <div class="form-group">
                    <asp:Label ID="Label1" runat="server" AssociatedControlID="rblAdFormat" CssClass="col-md-2 control-label">Ad type</asp:Label>
                    <div class="col-md-10">
                        <asp:RadioButtonList ID="rblAdFormat" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" Width="450px" ValidationGroup="vgAd">
                            <asp:ListItem Value="S">Small - $199.00</asp:ListItem>
                            <asp:ListItem Value="L">Large - $599.00</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <asp:RequiredFieldValidator ID="rfvAdType" runat="server" ValidationGroup="vgAd" ControlToValidate="rblAdFormat"
                        CssClass="text-danger" ErrorMessage="Ad type is required"></asp:RequiredFieldValidator>
                </div>
                <p>
                    Large ads appear as rotating banners in the top section of the website. 
                    Small ads appear rotating on either left or right side of the page. All ads are randomly picked to accomodate volume.
                </p>
                <div class="alert alert-info">
                    <p>Please note the size and file format for the ads <strong>must</strong> be as follows:</p>
                    <ul>
                        <li>Large ad: 1130 x 200 pixels (maximum file size 2 Mb per image)</li>
                        <li>Small ad: 250 x 200 pixels (maximum file size 1 Mb per image)</li>
                        <li>Allowed image formats are: GIF, JPEG, JPG, PNG</li>
                    </ul>
                    <p class="bold">
                        If your pictures do not conform to the correct size as prescribed above you may have to resize the pictures before uploading. We recommend you review our <a href="/TermsOfUse.aspx">terms of use</a> prior to placing any business ads.
                    </p>
                    <p>
                        We also provide graphics services at an added cost. Please contact <a href="mailto:sales@emonthlies.com">sales@emonthlies.com</a>.
                    </p>
                </div>
                <asp:Panel ID="pnlErr" runat="server" Visible="false" CssClass="alert alert-danger">
                    <asp:Literal ID="ltlErr" runat="server"></asp:Literal>
                </asp:Panel>
                <br class="clear" />
                <div class="form-group">
                    <asp:Label ID="Label2" runat="server" AssociatedControlID="txtAdDetails" CssClass="col-md-3 control-label">Ad Details</asp:Label>
                    <div class="col-md-9">
                        <asp:TextBox runat="server" ID="txtAdDetails" CssClass="form-control" Rows="6" TextMode="MultiLine" ValidationGroup="vgAd" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="vgAd" ControlToValidate="txtAdDetails"
                            CssClass="text-danger" ErrorMessage="Ad details is a required field."></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="clear25"></div>

                <div class="form-group">
                    <asp:Label ID="lblImage1" runat="server" AssociatedControlID="FileUpload1" CssClass="col-md-3 control-label">Image 1:</asp:Label>
                    <div class="col-md-9">
                        <asp:FileUpload ID="FileUpload1" runat="server" Width="99%" />
                    </div>
                </div>
                <br class="clear" />
                <div class="form-group">
                    <asp:Label ID="lblImage2" runat="server" AssociatedControlID="FileUpload2" CssClass="col-md-3 control-label">Image 2:</asp:Label>
                    <div class="col-md-9">
                        <asp:FileUpload ID="FileUpload2" runat="server" Width="99%" />
                    </div>
                </div>
                <br class="clear" />
                <div class="form-group">
                    <asp:Label ID="lblImage3" runat="server" AssociatedControlID="FileUpload3" CssClass="col-md-3 control-label">Image 3:</asp:Label>
                    <div class="col-md-9">
                        <asp:FileUpload ID="FileUpload3" runat="server" Width="99%" />
                    </div>
                </div>
                <br class="clear" />
                <div class="form-group">
                    <asp:Label ID="lblImage4" runat="server" AssociatedControlID="FileUpload4" CssClass="col-md-3 control-label">Image 4:</asp:Label>
                    <div class="col-md-9">
                        <asp:FileUpload ID="FileUpload4" runat="server" Width="99%" />
                    </div>
                </div>
                <br class="clear" />
                <div class="form-group">
                    <asp:Label ID="lblUrl" runat="server" AssociatedControlID="txtUrl" CssClass="col-md-3 control-label">Website:</asp:Label>
                    <div class="col-md-9">
                        <asp:TextBox ID="txtUrl" runat="server" CssClass="form-control" Placeholder="http://www.yoursite.com"></asp:TextBox>
                    </div>
                    <asp:RegularExpressionValidator ID="rexvUrl" runat="server" ErrorMessage="Please enter the correct URL." ControlToValidate="txtUrl" CssClass="text-danger" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?" ValidationGroup="vgAd"></asp:RegularExpressionValidator>
                </div>
                <br class="clear" />
            </fieldset>
            <div class="centered">
                <p class="bold">I consent to receive marketing communications (electronic and otherwise) from <em>emonthlies</em> to offer me their products and services.</p>
                <asp:Button ID="BtnSaveAd" runat="server" ValidationGroup="vgAd" Text="Submit" CausesValidation="true" CssClass="btn btn-primary" OnClientClick="preventMultipleSubmissions();" OnClick="BtnSaveAd_Click" />
            </div>
            <div class="clear25"></div>
        </div>
        <div class="col-md-3">
            <uc1:adsRight runat="server" ID="adsRight" />
        </div>
        <div class="clear25"></div>
    </div>
</asp:Content>
