<%@ Page Title="Check out" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CheckOut.aspx.cs" Inherits="eMonthleys.CheckOut" %>

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

        $(function () {
            $('#<%=txtCardNumber.ClientID%>').keydown(function (e) {
                if (e.shiftKey || e.ctrlKey || e.altKey) {
                    e.preventDefault();
                } else {
                    var key = e.keyCode;
                    if (!((key == 8) || (key == 46) || (key >= 35 && key <= 40) || (key >= 48 && key <= 57) || (key >= 96 && key <= 105))) {
                        e.preventDefault();
                    }
                }
            });
        });
    </script>
    <script type="text/javascript">

        var isSubmitted = false;

        function preventMultipleSubmissions() {
            if (!isSubmitted) {
                $('#<%=BtnPayNow.ClientID %>').val('Submitting payment.. Plz Wait..');
                isSubmitted = true;
                return true;
            }
            else {
                return false;
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="withads">
        <div class="row">
            <article class="col-md-3">
                <uc1:adsLeft runat="server" ID="adsLeft" />
            </article>
            <article class="col-md-6 mainpanel">
                <h2><%: Title %></h2>
                <fieldset>
                    <legend>
                        <asp:Label ID="lblItem" runat="server"></asp:Label></legend>
                    <div class="form-group">
                        <asp:Label ID="lblAmount" runat="server" CssClass="col-md-3">Amount</asp:Label>
                        <div class="col-md-5">
                            $<asp:Label ID="txtPayment" runat="server"></asp:Label>
                        </div>
                        <div class="clear15"></div>
                        <div class="col-md-10">
                            <asp:RadioButtonList ID="rblCardType" runat="server" ValidationGroup="vgCheckout" RepeatColumns="4" RepeatDirection="Horizontal" Width="100%">
                                <asp:ListItem Value="visa">VISA</asp:ListItem>
                                <asp:ListItem Value="mastercard">MasterCard</asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Credit card type is required." Text="*"
                                ControlToValidate="rblCardType" ValidationGroup="vgCheckout" CssClass="text-danger"></asp:RequiredFieldValidator>
                        </div>
                        <div class="clear15"></div>
                        <asp:Label ID="lblFirstName" runat="server" AssociatedControlID="txtFirstNameOnCard" CssClass="col-md-3">First Name</asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtFirstNameOnCard" runat="server" CssClass="form-control" Width="300px" 
                                ValidationGroup="vgCheckout"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="First name is required." Text="*"
                                ControlToValidate="txtFirstNameOnCard" ValidationGroup="vgCheckout" CssClass="text-danger"></asp:RequiredFieldValidator>
                        </div>
                        <div class="clear15"></div>
                        <asp:Label ID="Label1" runat="server" AssociatedControlID="txtLastNameOnCard" CssClass="col-md-3">Last Name</asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtLastNameOnCard" runat="server" CssClass="form-control" Width="300px" ValidationGroup="vgCheckout"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Last name is required." Text="*"
                                ControlToValidate="txtLastNameOnCard" ValidationGroup="vgCheckout" CssClass="text-danger"></asp:RequiredFieldValidator>
                        </div>
                        <div class="clear15"></div>
                        <asp:Label ID="lblCardNumber" runat="server" AssociatedControlID="txtCardNumber" CssClass="col-md-3">Card Number (no spaces)</asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtCardNumber" runat="server" CssClass="form-control" Width="200px" MaxLength="16" ValidationGroup="vgCheckout"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ErrorMessage="Credit card number is required." Text="*"
                                ControlToValidate="txtCardNumber" ValidationGroup="vgCheckout" CssClass="text-danger"></asp:RequiredFieldValidator>
                            <span id="errmsg"></span>
                        </div>
                        <div class="clear15"></div>
                        <asp:Label ID="lblExpiry" runat="server" CssClass="col-md-3">Expires (MM/YYYY)</asp:Label>
                        <div class="col-md-5">
                            <asp:DropDownList ID="ddlMonthExp" runat="server" CssClass="form-control col-md-1" Width="75px " ValidationGroup="vgCheckout">
                                <asp:ListItem>01</asp:ListItem>
                                <asp:ListItem>02</asp:ListItem>
                                <asp:ListItem>03</asp:ListItem>
                                <asp:ListItem>04</asp:ListItem>
                                <asp:ListItem>05</asp:ListItem>
                                <asp:ListItem>06</asp:ListItem>
                                <asp:ListItem>07</asp:ListItem>
                                <asp:ListItem>08</asp:ListItem>
                                <asp:ListItem>09</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>11</asp:ListItem>
                                <asp:ListItem>12</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Label ID="lblSlash" runat="server" Width="20px" CssClass="col-md-1"> / </asp:Label>
                            <asp:DropDownList ID="ddlExpYear" runat="server" CssClass="form-control col-md-1" Width="75px " ValidationGroup="vgCheckout"></asp:DropDownList>
                            <%--<asp:TextBox ID="txtYearExpires" runat="server" CssClass="form-control col-md-1" Width="60px" MaxLength="4" ValidationGroup="vgCheckout" placeholder="YYYY"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ErrorMessage="Year of expiry date is required." Text="*"
                                ControlToValidate="txtYearExpires" ValidationGroup="vgCheckout" CssClass="text-danger"></asp:RequiredFieldValidator>--%>
                        </div>
                        <div class="clear15"></div>
                        <asp:Label ID="lblCCV" runat="server" AssociatedControlID="txtCCV" CssClass="col-md-3">CCV</asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtCCV" runat="server" CssClass="form-control" Width="60px" MaxLength="4" ValidationGroup="vgCheckout"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ErrorMessage="Credit card verification code is required." Text="*"
                                ControlToValidate="txtCCV" ValidationGroup="vgCheckout" CssClass="text-danger"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="clear25"></div>
                </fieldset>
                <fieldset>
                    <legend>
                        Billing details</legend>
                    <div class="form-group">
                        <div class="clear15"></div>
                        <asp:Label ID="lblAddress" runat="server" AssociatedControlID="txtAddress" CssClass="col-md-3">Address</asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" Width="300px" ValidationGroup="vgCheckout"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Address is required." Text="*"
                                ControlToValidate="txtAddress" ValidationGroup="vgCheckout" CssClass="text-danger"></asp:RequiredFieldValidator>
                        </div>
                        <div class="clear15"></div>
                        <asp:Label ID="lblCity" runat="server" AssociatedControlID="txtCity" CssClass="col-md-3">City</asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" Width="300px" ValidationGroup="vgCheckout"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="City is required." Text="*"
                                ControlToValidate="txtCity" ValidationGroup="vgCheckout" CssClass="text-danger"></asp:RequiredFieldValidator>
                        </div>
                        <div class="clear15"></div>
                        <asp:Label ID="Label7" runat="server" AssociatedControlID="txtCardNumber" CssClass="col-md-3">Province</asp:Label>
                        <div class="col-md-5">
                            <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control" Width="200px" ValidationGroup="vgCheckout">
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


                            <%--                    <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control" Width="200px" ValidationGroup="vgRegister">
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
                        <asp:ListItem Value="">--- U.S.A. ---</asp:ListItem>
                        <asp:ListItem Value="AL">Alabama</asp:ListItem>
                        <asp:ListItem Value="AK">Alaska</asp:ListItem>
                        <asp:ListItem Value="AZ">Arizona</asp:ListItem>
                        <asp:ListItem Value="AR">Arkansas</asp:ListItem>
                        <asp:ListItem Value="CA">California</asp:ListItem>
                        <asp:ListItem Value="CO">Colorado</asp:ListItem>
                        <asp:ListItem Value="CT">Connecticut</asp:ListItem>
                        <asp:ListItem Value="DC">District of Columbia</asp:ListItem>
                        <asp:ListItem Value="DE">Delaware</asp:ListItem>
                        <asp:ListItem Value="FL">Florida</asp:ListItem>
                        <asp:ListItem Value="GA">Georgia</asp:ListItem>
                        <asp:ListItem Value="HI">Hawaii</asp:ListItem>
                        <asp:ListItem Value="ID">Idaho</asp:ListItem>
                        <asp:ListItem Value="IL">Illinois</asp:ListItem>
                        <asp:ListItem Value="IN">Indiana</asp:ListItem>
                        <asp:ListItem Value="IA">Iowa</asp:ListItem>
                        <asp:ListItem Value="KS">Kansas</asp:ListItem>
                        <asp:ListItem Value="KY">Kentucky</asp:ListItem>
                        <asp:ListItem Value="LA">Louisiana</asp:ListItem>
                        <asp:ListItem Value="ME">Maine</asp:ListItem>
                        <asp:ListItem Value="MD">Maryland</asp:ListItem>
                        <asp:ListItem Value="MA">Massachusetts</asp:ListItem>
                        <asp:ListItem Value="MI">Michigan</asp:ListItem>
                        <asp:ListItem Value="MN">Minnesota</asp:ListItem>
                        <asp:ListItem Value="MS">Mississippi</asp:ListItem>
                        <asp:ListItem Value="MO">Missouri</asp:ListItem>
                        <asp:ListItem Value="MT">Montana</asp:ListItem>
                        <asp:ListItem Value="NE">Nebraska</asp:ListItem>
                        <asp:ListItem Value="NV">Nevada</asp:ListItem>
                        <asp:ListItem Value="NH">New Hampshire</asp:ListItem>
                        <asp:ListItem Value="NJ">New Jersey</asp:ListItem>
                        <asp:ListItem Value="NM">New Mexico</asp:ListItem>
                        <asp:ListItem Value="NY">New York</asp:ListItem>
                        <asp:ListItem Value="NC">North Carolina</asp:ListItem>
                        <asp:ListItem Value="ND">North Dakota</asp:ListItem>
                        <asp:ListItem Value="OH">Ohio</asp:ListItem>
                        <asp:ListItem Value="OK">Oklahoma</asp:ListItem>
                        <asp:ListItem Value="OR">Oregon</asp:ListItem>
                        <asp:ListItem Value="PA">Pennsylvania</asp:ListItem>
                        <asp:ListItem Value="RI">Rhode Island</asp:ListItem>
                        <asp:ListItem Value="SC">South Carolina</asp:ListItem>
                        <asp:ListItem Value="SD">South Dakota</asp:ListItem>
                        <asp:ListItem Value="TN">Tennessee</asp:ListItem>
                        <asp:ListItem Value="TX">Texas</asp:ListItem>
                        <asp:ListItem Value="UT">Utah</asp:ListItem>
                        <asp:ListItem Value="VT">Vermont</asp:ListItem>
                        <asp:ListItem Value="VA">Virginia</asp:ListItem>
                        <asp:ListItem Value="WA">Washington</asp:ListItem>
                        <asp:ListItem Value="WV">West Virginia</asp:ListItem>
                        <asp:ListItem Value="WI">Wisconsin</asp:ListItem>
                        <asp:ListItem Value="WY">Wyoming</asp:ListItem>
                    </asp:DropDownList>--%>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Province is required." Text="*"
                                ControlToValidate="ddlState" ValidationGroup="vgCheckout" CssClass="text-danger" InitialValue=""></asp:RequiredFieldValidator>
                        </div>
                        <div class="clear15"></div>
                        <asp:Label ID="lblPostal" runat="server" AssociatedControlID="txtPostalCode" CssClass="col-md-3">Postal Code</asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtPostalCode" runat="server" CssClass="form-control" Width="100px" MaxLength="16" ValidationGroup="vgCheckout"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Postal code is required." Text="*"
                                ControlToValidate="txtPostalCode" ValidationGroup="vgCheckout" CssClass="text-danger"></asp:RequiredFieldValidator>
                        </div>
                        <div class="clear15"></div>
                        <asp:Label ID="lblCountry" runat="server" AssociatedControlID="ddlCountry" CssClass="col-md-3">Country</asp:Label>
                        <div class="col-md-5">
                        <asp:DropDownList runat="server" ID="ddlCountry" CssClass="form-control" ValidationGroup="vgCheckout" Width="200px" TabIndex="15">
                            <asp:ListItem Value="">Please select</asp:ListItem>
                            <asp:ListItem Value="CA">Canada</asp:ListItem>
                            <asp:ListItem Value="US">U.S.A.</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Country is required." ControlToValidate="ddlCountry"
                            InitialValue="" CssClass="text-danger" ValidationGroup="vgCheckout" Text="*"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="clear25"></div>
                </fieldset>
                <div class="centered">
                    <asp:Button ID="BtnPayNow" runat="server" Text="Pay Now" CausesValidation="true" ValidationGroup="vgCheckout" OnClientClick="preventMultipleSubmissions();" OnClick="BtnPayNow_Click" /></div>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="vgCheckout" CssClass="text-danger" ShowMessageBox="True" />
                <div class="clear25"></div>
            </article>
            <article class="col-md-3">
                <uc1:adsRight runat="server" ID="adsRight" />
            </article>
            <div class="clear"></div>
        </div>
    </section>
</asp:Content>
