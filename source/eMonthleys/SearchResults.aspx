<%@ Page Title="Search results" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchResults.aspx.cs" Inherits="eMonthleys.SearchResults" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <script type="text/javascript">
        function validateRange(sender, args) {
            var yearLB = document.getElementById('<%=ddlYearLowerBound.ClientID%>');
            var yearUB = document.getElementById('<%=ddlYearUpperBound.ClientID%>');
            var priceLB = document.getElementById('<%=ddlPriceLower.ClientID%>');
            var pricetUB = document.getElementById('<%=ddlPriceUpper.ClientID%>');
            var paymentLB = document.getElementById('<%=ddlPaymentLowerBound.ClientID%>');
            var paymentUB = document.getElementById('<%=ddlPaymentUpperBound.ClientID%>');
            var monthLB = document.getElementById('<%=ddlRemMonthsLB.ClientID%>');
            var monthUB = document.getElementById('<%=ddlRemMonthsUB.ClientID%>');
            var odoLB = document.getElementById('<%=ddlCurrKiloMin.ClientID%>');
            var odoUB = document.getElementById('<%=ddlCurrKiloMax.ClientID%>');

            //alert(paymentUB.options[paymentUB.selectedIndex].text);

            if (Number(yearUB.options[yearUB.selectedIndex].value) < Number(yearLB.options[yearLB.selectedIndex].value))
                args.IsValid = false;
            else if (Number(pricetUB.options[pricetUB.selectedIndex].value) < Number(priceLB.options[priceLB.selectedIndex].value))
                args.IsValid = false;
            else if (Number(paymentUB.options[paymentUB.selectedIndex].value) < Number(paymentLB.options[paymentLB.selectedIndex].value))
                args.IsValid = false;
            else if (Number(monthUB.options[monthUB.selectedIndex].value) < Number(monthLB.options[monthLB.selectedIndex].value))
                args.IsValid = false;
            else if (Number(odoUB.options[odoUB.selectedIndex].value) < Number(odoLB.options[odoLB.selectedIndex].value))
                args.IsValid = false;
            else
                args.IsValid = true;
        }

        $(document).ready(function() {
            var upper = $('#<%=ddlYearUpperBound.ClientID%>');
            var lower = $('#<%=ddlYearLowerBound.ClientID%>');
            $('#<%=ddlYearLowerBound.ClientID%>').on('change', function() {

                });
        });

        $('document').ready(function() {
            $('#<%=ddlYearLowerBound.ClientID%>').on('change', function() {
                var $lastYear = $('#<%=ddlYearUpperBound.ClientID%> option');
                var startYearValue = this.value;

                $lastYear.prop("disabled", false);
    
                if(startYearValue === 0){
                    return;
                }

                $lastYear.each(function() {
                    if (this.value != 0 && this.value < startYearValue) {
                        $(this).prop("disabled", true);
                    }
                });
            });

            $('#<%=ddlYearUpperBound.ClientID%>').on('change', function() {
                var $startYear = $('#<%=ddlYearLowerBound.ClientID%> option');
                var lastYearValue = this.value;

                $startYear.prop("disabled", false);
    
                if(lastYearValue == 0){
                    return;
                }

                $startYear.each(function() {
                    if (this.value > lastYearValue) {
                        $(this).prop("disabled", true);
                    }
                });
            });
        });
    </script>
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

        legend {
            cursor: pointer;
        }

        .fscontent {
            display: none;
        }

        h1 {
            font-size: 2em;
            font-weight: bold;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $("legend").click(function () {
                $(".fscontent").toggle();
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid mainpanel">
        <div class="col-md-3">
            <h1>Search results&nbsp;
            <span class="glyphicon glyphicon-info-sign lgtext" id="shelp" data-toggle="tooltip" data-placement="bottom"
                onclick="$('#shelp').tooltip('show');"
                style="cursor: help" title="The results are based on the search criteria selected in the main search screen."></span></h1>
        </div>
        <div class="col-md-8 centered pad10">
            <button type="button" value="New Search" class="btn btn-primary" onclick="self.location='search.aspx'">New Search</button>
        </div>
        <div class="clear"></div>
        <div class="col-md-3 mainpanel">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="vgFine" ShowMessageBox="true" ShowSummary="false" CssClass="text-danger" />
            <fieldset class="finesearch">
                <legend class="btn btn-primary">Narrow Your Search </legend>
                <div>
                    <div>
                        <div class="form-group">
                            <asp:RadioButtonList ID="rblCondition" runat="server" CssClass="col-md-5" RepeatDirection="Horizontal" Width="250px" ValidationGroup="vgFine" RepeatLayout="table" RepeatColumns="3">
                                <asp:ListItem Selected="True">Any</asp:ListItem>
                                <asp:ListItem Value="new">New</asp:ListItem>
                                <asp:ListItem Value="used">Used</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="clear10"></div>
                    <div class="form-group small">
                        <asp:RadioButtonList ID="rblItemType" runat="server" CssClass="col-md-5" RepeatDirection="Horizontal" Width="250px" ValidationGroup="vgFine" RepeatLayout="table" RepeatColumns="2">
                            <asp:ListItem Value="22,23,26,27,30,34,35,38" Text="<img src='/images/sedan-icon.png' /> Cars/Sports cars"></asp:ListItem>
                            <asp:ListItem Value="29" Text="<img src='/images/minivan-icon.png' /> Vans"></asp:ListItem>
                            <asp:ListItem Value="25,32,36" Text="<img src='/images/SUV-icon.png' /> SUV's"></asp:ListItem>
                            <asp:ListItem Value="24,28,37" Text="<img src='/images/truck-icon.png' /> Trucks"></asp:ListItem>
                            <asp:ListItem Value="31" Text="<img src='/images/cabriolet-icon.png' /> Convertibles"></asp:ListItem>
                            <asp:ListItem Value="39" Text="<img src='/images/collector-icon.png' /> Collector Cars"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div class="clear10"></div>
                    <div>
                        <div class="form-group">
                            <asp:RadioButtonList ID="rblFinancial" runat="server" CssClass="col-md-5" RepeatDirection="Horizontal"
                                AutoPostBack="true" OnSelectedIndexChanged="rblFinancial_SelectedIndexChanged"
                                Width="250px" ValidationGroup="vgFine" RepeatLayout="table" RepeatColumns="3">
                                <asp:ListItem Value="f">Finance</asp:ListItem>
                                <asp:ListItem Value="l">Lease</asp:ListItem>
                                <asp:ListItem Value="c">Cash</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="clear15"></div>

                    <%-- payment options --%>

                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Panel ID="pnlCashPay" runat="server" Enabled="false" Visible="false">
                                <div>
                                    My cash price budget (incl. Tax):<br />
                                    $<asp:DropDownList ID="ddlCashpriceLB" runat="server" ValidationGroup="vgFine">
                                        <asp:ListItem Value=""></asp:ListItem>
                                        <asp:ListItem>0</asp:ListItem>
                                        <asp:ListItem>1000</asp:ListItem>
                                        <asp:ListItem>2000</asp:ListItem>
                                        <asp:ListItem>3000</asp:ListItem>
                                        <asp:ListItem>4000</asp:ListItem>
                                        <asp:ListItem>5000</asp:ListItem>
                                        <asp:ListItem>6000</asp:ListItem>
                                        <asp:ListItem>7000</asp:ListItem>
                                        <asp:ListItem>8000</asp:ListItem>
                                        <asp:ListItem>9000</asp:ListItem>
                                        <asp:ListItem>10000</asp:ListItem>
                                    </asp:DropDownList>&nbsp;To&nbsp;
					$<asp:DropDownList ID="ddlCashpriceUB" runat="server" ValidationGroup="vgFine">
                        <asp:ListItem Value=""></asp:ListItem>
                        <asp:ListItem>1000</asp:ListItem>
                        <asp:ListItem>2000</asp:ListItem>
                        <asp:ListItem>3000</asp:ListItem>
                        <asp:ListItem>4000</asp:ListItem>
                        <asp:ListItem>5000</asp:ListItem>
                        <asp:ListItem>6000</asp:ListItem>
                        <asp:ListItem>7000</asp:ListItem>
                        <asp:ListItem>8000</asp:ListItem>
                        <asp:ListItem>9000</asp:ListItem>
                        <asp:ListItem>10000</asp:ListItem>
                        <asp:ListItem>30000</asp:ListItem>
                    </asp:DropDownList>
                                    <asp:CustomValidator ID="CustomValidator5" runat="server"
                                        ErrorMessage="The value in the right side for cash payment must be larger than the left side."
                                        ClientValidationFunction="validateRange" ControlToValidate="ddlCashpriceUB" CssClass="text-danger"
                                        ValidationGroup="vgFine">*</asp:CustomValidator>
                            </asp:Panel>
                            <asp:Panel ID="pnlFinaning" runat="server" Enabled="false" Visible="false">
                                <div>
                                    My payment preference:<br />
                                    <asp:DropDownList ID="ddlPayCycle" runat="server" ValidationGroup="vgFine">
                                        <asp:ListItem Value=""></asp:ListItem>
                                        <asp:ListItem>Monthly</asp:ListItem>
                                        <asp:ListItem>Semi-monthly</asp:ListItem>
                                        <asp:ListItem>Bi-weekly</asp:ListItem>
                                        <asp:ListItem>Weekly</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="clear15"></div>
                                <div>
                                    Payment budget (incl. Tax):<br />
                                    $<asp:DropDownList ID="ddlPaymentLowerBound" runat="server" ValidationGroup="vgFine">
                                        <asp:ListItem Value=""></asp:ListItem>
                                        <asp:ListItem>50</asp:ListItem>
                                        <asp:ListItem>100</asp:ListItem>
                                        <asp:ListItem>200</asp:ListItem>
                                        <asp:ListItem>300</asp:ListItem>
                                        <asp:ListItem>400</asp:ListItem>
                                        <asp:ListItem>500</asp:ListItem>
                                        <asp:ListItem>600</asp:ListItem>
                                        <asp:ListItem>700</asp:ListItem>
                                        <asp:ListItem>800</asp:ListItem>
                                        <asp:ListItem>900</asp:ListItem>
                                        <asp:ListItem>1000</asp:ListItem>
                                        <asp:ListItem>3000</asp:ListItem>
                                    </asp:DropDownList>&nbsp;To&nbsp;
					$<asp:DropDownList ID="ddlPaymentUpperBound" runat="server" ValidationGroup="vgFine">
                        <asp:ListItem Value=""></asp:ListItem>
                        <asp:ListItem>100</asp:ListItem>
                        <asp:ListItem>200</asp:ListItem>
                        <asp:ListItem>300</asp:ListItem>
                        <asp:ListItem>400</asp:ListItem>
                        <asp:ListItem>500</asp:ListItem>
                        <asp:ListItem>600</asp:ListItem>
                        <asp:ListItem>700</asp:ListItem>
                        <asp:ListItem>800</asp:ListItem>
                        <asp:ListItem>900</asp:ListItem>
                        <asp:ListItem>1000</asp:ListItem>
                        <asp:ListItem>3000</asp:ListItem>
                        <asp:ListItem>6000</asp:ListItem>
                    </asp:DropDownList>
                                    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="The value in the right side for monthly payment must be larger than the left side." ClientValidationFunction="validateRange" ControlToValidate="ddlPaymentUpperBound" CssClass="text-danger" ValidationGroup="vgFine">*</asp:CustomValidator>
                                </div>
                                <div class="clear15"></div>
                                <div>
                                    Purchase price (includes Tax):<br />
                                    <asp:DropDownList ID="ddlPriceLower" runat="server" ValidationGroup="vgFine">
                                        <asp:ListItem Value=""></asp:ListItem>
                                        <asp:ListItem Value="1">$1</asp:ListItem>
                                        <asp:ListItem Value="500">$500</asp:ListItem>
                                        <asp:ListItem Value="1000">$1,000</asp:ListItem>
                                        <asp:ListItem Value="5000">$5,000</asp:ListItem>
                                        <asp:ListItem Value="10000">$10,000</asp:ListItem>
                                        <asp:ListItem Value="20000">$20,000</asp:ListItem>
                                        <asp:ListItem Value="30000">$30,000</asp:ListItem>
                                        <asp:ListItem Value="60000">$60,000</asp:ListItem>
                                        <asp:ListItem Value="100000">$100,000</asp:ListItem>
                                        <asp:ListItem Value="200000">$200,000</asp:ListItem>
                                        <asp:ListItem Value="500000">$500,000</asp:ListItem>
                                    </asp:DropDownList>&nbsp;To&nbsp;
					<asp:DropDownList ID="ddlPriceUpper" runat="server" ValidationGroup="vgFine">
                        <asp:ListItem Value=""></asp:ListItem>
                        <asp:ListItem Value="500">$500</asp:ListItem>
                        <asp:ListItem Value="1000">$1,000</asp:ListItem>
                        <asp:ListItem Value="5000">$5,000</asp:ListItem>
                        <asp:ListItem Value="10000">$10,000</asp:ListItem>
                        <asp:ListItem Value="20000">$20,000</asp:ListItem>
                        <asp:ListItem Value="30000">$30,000</asp:ListItem>
                        <asp:ListItem Value="60000">$60,000</asp:ListItem>
                        <asp:ListItem Value="100000">$100,000</asp:ListItem>
                        <asp:ListItem Value="200000">$200,000</asp:ListItem>
                        <asp:ListItem Value="500000">$500,000</asp:ListItem>
                        <asp:ListItem Value="1000000">$1000,000</asp:ListItem>
                    </asp:DropDownList>
                                    <asp:CustomValidator ID="CustomValidator4" runat="server" ErrorMessage="The value in the right side for purchse price must be larger than the left side." ClientValidationFunction="validateRange" ControlToValidate="ddlPriceUpper" CssClass="text-danger" ValidationGroup="vgFine">*</asp:CustomValidator>
                                </div>
                                <div class="clear10"></div>
                                <div>
                                    Term of loan (Months):<br />
                                    <asp:DropDownList ID="ddlRemMonthsLB" runat="server" ValidationGroup="vgFine">
                                        <asp:ListItem Value=""></asp:ListItem>
                                        <asp:ListItem>6</asp:ListItem>
                                        <asp:ListItem>12</asp:ListItem>
                                        <asp:ListItem>18</asp:ListItem>
                                        <asp:ListItem>24</asp:ListItem>
                                        <asp:ListItem>30</asp:ListItem>
                                        <asp:ListItem>36</asp:ListItem>
                                        <asp:ListItem>42</asp:ListItem>
                                        <asp:ListItem>48</asp:ListItem>
                                        <asp:ListItem>54</asp:ListItem>
                                        <asp:ListItem>60</asp:ListItem>
                                        <asp:ListItem>72</asp:ListItem>
                                        <asp:ListItem>84</asp:ListItem>
                                    </asp:DropDownList>&nbsp;To&nbsp;
					<asp:DropDownList ID="ddlRemMonthsUB" runat="server" ValidationGroup="vgFine">
                        <asp:ListItem Value=""></asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>18</asp:ListItem>
                        <asp:ListItem>24</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>36</asp:ListItem>
                        <asp:ListItem>42</asp:ListItem>
                        <asp:ListItem>48</asp:ListItem>
                        <asp:ListItem>54</asp:ListItem>
                        <asp:ListItem>60</asp:ListItem>
                        <asp:ListItem>72</asp:ListItem>
                        <asp:ListItem>84</asp:ListItem>
                        <asp:ListItem>96</asp:ListItem>
                    </asp:DropDownList>
                                    <asp:CustomValidator ID="CustomValidator2" runat="server"
                                        ErrorMessage="The value in the right side for term of loan must be larger than the left side."
                                        ClientValidationFunction="validateRange" ControlToValidate="ddlRemMonthsUB" CssClass="text-danger"
                                        ValidationGroup="vgFine">*</asp:CustomValidator>
                                </div>
                            </asp:Panel>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="rblFinancial" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>

                    <%-- end payment options --%>

                    <div class="clear15"></div>
                    <div>
                        <div class="form-group">
                            Model year:<br />
                            <asp:DropDownList ID="ddlYearLowerBound" runat="server" ValidationGroup="vgFine">
                                <asp:ListItem Value=""></asp:ListItem>
                                <asp:ListItem>1910</asp:ListItem>
                                <asp:ListItem>1915</asp:ListItem>
                                <asp:ListItem>1920</asp:ListItem>
                                <asp:ListItem>1925</asp:ListItem>
                                <asp:ListItem>1930</asp:ListItem>
                                <asp:ListItem>1935</asp:ListItem>
                                <asp:ListItem>1940</asp:ListItem>
                                <asp:ListItem>1945</asp:ListItem>
                                <asp:ListItem>1950</asp:ListItem>
                                <asp:ListItem>1955</asp:ListItem>
                                <asp:ListItem>1960</asp:ListItem>
                            </asp:DropDownList>&nbsp;To&nbsp;
					<asp:DropDownList ID="ddlYearUpperBound" runat="server" ValidationGroup="vgFine">
                        <asp:ListItem Value=""></asp:ListItem>
                        <asp:ListItem>1915</asp:ListItem>
                        <asp:ListItem>1920</asp:ListItem>
                        <asp:ListItem>1925</asp:ListItem>
                        <asp:ListItem>1930</asp:ListItem>
                        <asp:ListItem>1935</asp:ListItem>
                        <asp:ListItem>1940</asp:ListItem>
                        <asp:ListItem>1945</asp:ListItem>
                        <asp:ListItem>1950</asp:ListItem>
                        <asp:ListItem>1955</asp:ListItem>
                        <asp:ListItem>1960</asp:ListItem>
                    </asp:DropDownList>
                        </div>
                    </div>
                    <div class="clear10"></div>
                    <div>
                        Odometer reading (Km):<br />
                        <asp:DropDownList ID="ddlCurrKiloMin" runat="server" ValidationGroup="vgFine">
                            <asp:ListItem Value=""></asp:ListItem>
                            <asp:ListItem Value="0">0</asp:ListItem>
                            <asp:ListItem Value="10000">10,000</asp:ListItem>
                            <asp:ListItem Value="20000">20,000</asp:ListItem>
                            <asp:ListItem Value="30000">30,000</asp:ListItem>
                            <asp:ListItem Value="40000">40,000</asp:ListItem>
                            <asp:ListItem Value="60000">60,000</asp:ListItem>
                            <asp:ListItem Value="80000">80,000</asp:ListItem>
                            <asp:ListItem Value="100000">100,000</asp:ListItem>
                            <asp:ListItem Value="200000">200,000</asp:ListItem>
                            <asp:ListItem Value="500000">500,000</asp:ListItem>
                        </asp:DropDownList>&nbsp;To&nbsp;
					<asp:DropDownList ID="ddlCurrKiloMax" runat="server" ValidationGroup="vgFine">
                        <asp:ListItem Value=""></asp:ListItem>
                        <asp:ListItem Value="10000">10,000</asp:ListItem>
                        <asp:ListItem Value="20000">20,000</asp:ListItem>
                        <asp:ListItem Value="30000">30,000</asp:ListItem>
                        <asp:ListItem Value="40000">40,000</asp:ListItem>
                        <asp:ListItem Value="60000">60,000</asp:ListItem>
                        <asp:ListItem Value="80000">80,000</asp:ListItem>
                        <asp:ListItem Value="100000">100,000</asp:ListItem>
                        <asp:ListItem Value="125000">125,000</asp:ListItem>
                        <asp:ListItem Value="150000">150,000</asp:ListItem>
                        <asp:ListItem Value="200000">200,000</asp:ListItem>
                        <asp:ListItem Value="500000">500,000</asp:ListItem>
                        <asp:ListItem Value="1000000">1000,000</asp:ListItem>
                    </asp:DropDownList>
                        <asp:CustomValidator ID="CustomValidator3" runat="server" ErrorMessage="The value in the right side for odometer reading must be larger than the left side." ClientValidationFunction="validateRange" ControlToValidate="ddlCurrKiloMax" CssClass="text-danger" ValidationGroup="vgFine">*</asp:CustomValidator>
                    </div>
                    <div class="clear15"></div>
                    <div>
                        Body colour:<br />
                        <asp:DropDownList ID="ddlExteriorColor" runat="server" ValidationGroup="vgFine">
                            <asp:ListItem Value="">Any colour</asp:ListItem>
                            <asp:ListItem Value="Beige">Beige</asp:ListItem>
                            <asp:ListItem Value="Black">Black</asp:ListItem>
                            <asp:ListItem Value="Blue">Blue</asp:ListItem>
                            <asp:ListItem Value="Bronze">Bronze</asp:ListItem>
                            <asp:ListItem Value="Brown">Brown</asp:ListItem>
                            <asp:ListItem Value="Champagne">Champagne</asp:ListItem>
                            <asp:ListItem Value="Dark Blue">Dark Blue</asp:ListItem>
                            <asp:ListItem Value="Dark Green">Dark Green</asp:ListItem>
                            <asp:ListItem Value="Dark Grey">Dark Grey</asp:ListItem>
                            <asp:ListItem Value="Gold">Gold</asp:ListItem>
                            <asp:ListItem Value="Graphite">Graphite</asp:ListItem>
                            <asp:ListItem Value="Green">Green</asp:ListItem>
                            <asp:ListItem Value="Grey">Grey</asp:ListItem>
                            <asp:ListItem Value="Light Blue">Light Blue</asp:ListItem>
                            <asp:ListItem Value="Light Green">Light Green</asp:ListItem>
                            <asp:ListItem Value="Maroon">Maroon</asp:ListItem>
                            <asp:ListItem Value="Orange">Orange</asp:ListItem>
                            <asp:ListItem Value="Pearl white">Pearl white</asp:ListItem>
                            <asp:ListItem Value="Pewter">Pewter</asp:ListItem>
                            <asp:ListItem Value="Purple">Purple</asp:ListItem>
                            <asp:ListItem Value="Red">Red</asp:ListItem>
                            <asp:ListItem Value="Silver">Silver</asp:ListItem>
                            <asp:ListItem Value="Tan">Tan</asp:ListItem>
                            <asp:ListItem Value="Taupe">Taupe</asp:ListItem>
                            <asp:ListItem Value="Teal">Teal</asp:ListItem>
                            <asp:ListItem Value="White">White</asp:ListItem>
                            <asp:ListItem Value="Yellow">Yellow </asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="clear15"></div>
                    <div>
                        Transmission type:<br />
                        <asp:DropDownList ID="ddlTransmission" runat="server" ValidationGroup="vgFine">
                            <asp:ListItem Value="">Select a Transmission</asp:ListItem>
                            <asp:ListItem Value="Automatic">Automatic</asp:ListItem>
                            <asp:ListItem Value="Automatic - CVT">Automatic - CVT</asp:ListItem>
                            <asp:ListItem Value="Automatic - 4 speed">Automatic - 4 speed</asp:ListItem>
                            <asp:ListItem Value="Automatic - 5 speed">Automatic - 5 speed</asp:ListItem>
                            <asp:ListItem Value="Automatic - 6 speed">Automatic - 6 speed</asp:ListItem>
                            <asp:ListItem Value="Automatic - 7 speed">Automatic - 7 speed</asp:ListItem>
                            <asp:ListItem Value="Automatic - 8 speed">Automatic - 8 speed</asp:ListItem>
                            <asp:ListItem Value="Automatic - 9 speed">Automatic - 9 speed</asp:ListItem>
                            <asp:ListItem Value="Automatic - 10 speed">Automatic - 10 speed</asp:ListItem>
                            <asp:ListItem Value="Automatic - 11 speed">Automatic - 11 speed</asp:ListItem>
                            <asp:ListItem Value="Automatic - 12 speed">Automatic - 12 speed</asp:ListItem>
                            <asp:ListItem Value="Manual">Manual</asp:ListItem>
                            <asp:ListItem Value="Manual- 4 speed">Manual - 4 speed</asp:ListItem>
                            <asp:ListItem Value="Manual- 5 speed">Manual - 5 speed</asp:ListItem>
                            <asp:ListItem Value="Manual- 6 speed">Manual - 6 speed</asp:ListItem>
                            <asp:ListItem Value="Manual- 7 speed">Manual - 7 speed</asp:ListItem>
                            <asp:ListItem Value="Manual- 8 speed">Manual - 8 speed</asp:ListItem>
                            <asp:ListItem Value="Manual- 9 speed">Manual - 9 speed</asp:ListItem>
                            <asp:ListItem Value="Manual - 10 speed">Manual - 10 speed</asp:ListItem>
                            <asp:ListItem Value="Manual - 11 speed">Manual - 11 speed</asp:ListItem>
                            <asp:ListItem Value="Manual - 12 speed">Manual - 12 speed</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="clear15"></div>
                    <div>
                        Fuel Type:<br />
                        <asp:CheckBoxList ID="cblFuelType" runat="server" RepeatDirection="Horizontal" RepeatColumns="2" Width="100%" ValidationGroup="vgFine">
                            <asp:ListItem>Diesel</asp:ListItem>
                            <asp:ListItem>Gas</asp:ListItem>
                            <asp:ListItem>Electric</asp:ListItem>
                            <asp:ListItem>Plug-in</asp:ListItem>
                            <asp:ListItem>Hybrid</asp:ListItem>
                            <asp:ListItem>FlexFuel</asp:ListItem>
                        </asp:CheckBoxList>
                    </div>
                    <div class="clear25"></div>
                    <div class="centered">
                        <asp:Button ID="BtnSortSearch" runat="server" Text="Search" OnClick="BtnSortSearch_OnClick" CssClass="btn btn-primary" CausesValidation="true" ValidationGroup="vgFine" />
                    </div>

                    <div class="clear25"></div>
                </div>
            </fieldset>

        </div>
        <div class="spacer-block-2"></div>
        <div class="col-md-8 mainpanel">
            <asp:Panel ID="pnlResults" runat="server">
                <p>
                    <asp:Literal ID="ltlCount" runat="server"></asp:Literal>
                </p>
                <asp:GridView ID="gvResult" runat="server" AllowPaging="True" AutoGenerateColumns="false" AutoGenerateEditButton="false" AutoGenerateSelectButton="false"
                    ShowHeader="false" ShowFooter="false" GridLines="None" Width="100%" OnPageIndexChanging="gvResult_PageIndexChanging"
                    PagerStyle-CssClass="GridPager">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <%# getVehicleData(Container.DataItem) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:Panel>
            <br />
            <%-- Refined results --%>

            <asp:Panel ID="pnlFineResults" runat="server" Enabled="false" Visible="false" CssClass="pad10">
                <%
                    //ToDo: Sabuj: Use this code if uning improved speed code
                    //var nsearchresutls = (List<eMonthleys.DAL.iSearch>)Session["SearchResults"];
                    //var searchresutls = new List<eMonthleys.BLL.Search>();
                    //searchresutls = nsearchresutls.Select(item =>
                    //{
                    //   return eMonthleys.BLL.Search.GetOneSearch(item);
                    //}).ToList();


                    var searchresutls = (List<eMonthleys.BLL.Search>)Session["SearchResults"];
                    string[] lf = new string[] { "f", "l", "c" };
                    if (searchresutls != null)
                    {
                        List<string> cbl = new List<string>();
                        string fuel = string.Empty;
                        foreach (ListItem l in cblFuelType.Items)
                        {
                            if (l.Selected)
                                cbl.Add(l.Value);
                        }
                        if (cbl.Count > 0)
                        {
                            fuel = string.Join(",", cbl.ToArray());
                        }

                        var fine = (from s in searchresutls
                                    select s).ToList();
                        if (rblCondition.SelectedIndex > 0)
                        {
                            fine = (List<eMonthleys.BLL.Search>)fine.Where(u => u.VehicleCondition == rblCondition.SelectedValue).ToList();
                        }
                        if (rblItemType.SelectedIndex >= 0)
                        {
                            var SelectedCategories = rblItemType.SelectedValue.Split(',');
                            var vehCatetory = SelectedCategories.Select(int.Parse).ToList();
                            fine = (List<eMonthleys.BLL.Search>)fine.Where(s => (vehCatetory.Contains(s.VehicleCategory))).ToList();
                        }

                        if (rblFinancial.SelectedIndex == -1)
                        {
                            if (ddlPayCycle.SelectedIndex > 0)
                                fine = (List<eMonthleys.BLL.Search>)fine.Where(y => y.PaymentCycle == ddlPayCycle.SelectedValue
                                    && (lf.Contains(y.LeaseOrFinance))).ToList();
                            if (ddlPaymentLowerBound.SelectedIndex > 0 && ddlPaymentUpperBound.SelectedIndex > 0)
                                fine = (List<eMonthleys.BLL.Search>)fine.Where(s => (s.PaymentWithTax >= Convert.ToDouble(ddlPaymentLowerBound.SelectedValue)
                                        && s.PaymentWithTax <= Convert.ToDouble(ddlPaymentUpperBound.SelectedValue))
                                        && (lf.Contains(s.LeaseOrFinance))).ToList();
                            else if (ddlPaymentLowerBound.SelectedIndex <= 0 && ddlPaymentUpperBound.SelectedIndex > 0)
                                fine = (List<eMonthleys.BLL.Search>)fine.Where(s => s.PaymentWithTax <= Convert.ToDouble(ddlPaymentUpperBound.SelectedValue)
                                    && (lf.Contains(s.LeaseOrFinance))).ToList();
                            else if (ddlPaymentLowerBound.SelectedIndex > 0 && ddlPaymentUpperBound.SelectedIndex <= 0)
                                fine = (List<eMonthleys.BLL.Search>)fine.Where(s => s.PaymentWithTax >= Convert.ToDouble(ddlPaymentLowerBound.SelectedValue)
                                    && (lf.Contains(s.LeaseOrFinance))).ToList();
                        }
                        else
                        {
                            switch (rblFinancial.SelectedIndex)
                            {
                                case 0:
                                case 1:
                                    fine = (List<eMonthleys.BLL.Search>)fine.Where(u => u.LeaseOrFinance == rblFinancial.SelectedValue).ToList();
                                    if (ddlPaymentLowerBound.SelectedIndex > 0 && ddlPaymentUpperBound.SelectedIndex > 0)
                                        fine = (List<eMonthleys.BLL.Search>)fine.Where(s => (s.PaymentWithTax >= Convert.ToDouble(ddlPaymentLowerBound.SelectedValue)
                                                && s.PaymentWithTax <= Convert.ToDouble(ddlPaymentUpperBound.SelectedValue))).ToList();
                                    else if (ddlPaymentLowerBound.SelectedIndex <= 0 && ddlPaymentUpperBound.SelectedIndex > 0)
                                        fine = (List<eMonthleys.BLL.Search>)fine.Where(s => s.PaymentWithTax <= Convert.ToDouble(ddlPaymentUpperBound.SelectedValue)).ToList();
                                    else if (ddlPaymentLowerBound.SelectedIndex > 0 && ddlPaymentUpperBound.SelectedIndex <= 0)
                                        fine = (List<eMonthleys.BLL.Search>)fine.Where(s => s.PaymentWithTax >= Convert.ToDouble(ddlPaymentLowerBound.SelectedValue)).ToList();
                                    if (ddlRemMonthsLB.SelectedIndex > 0)
                                        fine = (List<eMonthleys.BLL.Search>)fine.Where(t => t.LeaseTerm >= Convert.ToInt16(ddlRemMonthsLB.SelectedValue)
                                            && t.LeaseTerm <= Convert.ToInt16(ddlRemMonthsUB.SelectedValue)).ToList();
                                    if (ddlPayCycle.SelectedIndex > 0)
                                        fine = (List<eMonthleys.BLL.Search>)fine.Where(y => y.PaymentCycle == ddlPayCycle.SelectedValue).ToList();
                                    break;
                                case 2:
                                    fine = (List<eMonthleys.BLL.Search>)fine.Where(u => u.LeaseOrFinance == "c").ToList();
                                    if (ddlCashpriceLB.SelectedIndex > 0 && ddlCashpriceUB.SelectedIndex > 0)
                                        fine = (List<eMonthleys.BLL.Search>)fine.Where(s => (s.PurchasePrice >= Convert.ToDouble(ddlCashpriceLB.SelectedValue)
                                                && s.PurchasePrice <= Convert.ToDouble(ddlCashpriceUB.SelectedValue))).ToList();
                                    else if (ddlCashpriceLB.SelectedIndex <= 0 && ddlCashpriceUB.SelectedIndex > 0)
                                        fine = (List<eMonthleys.BLL.Search>)fine.Where(s => s.PurchasePrice <= Convert.ToDouble(ddlCashpriceLB.SelectedValue)).ToList();
                                    else if (ddlCashpriceLB.SelectedIndex > 0 && ddlCashpriceUB.SelectedIndex <= 0)
                                        fine = (List<eMonthleys.BLL.Search>)fine.Where(s => s.PurchasePrice >= Convert.ToDouble(ddlCashpriceLB.SelectedValue)).ToList();
                                    break;
                                default:
                                    //fine = (List<eMonthleys.BLL.Search>)fine.Where(u => (u.LeaseOrFinance == "f" || u.LeaseOrFinance == "l")).ToList();
                                    if (ddlPaymentLowerBound.SelectedIndex > 0 && ddlPaymentUpperBound.SelectedIndex > 0)
                                        fine = (List<eMonthleys.BLL.Search>)fine.Where(s => (s.PaymentWithTax >= Convert.ToDouble(ddlPaymentLowerBound.SelectedValue)
                                                && s.PaymentWithTax <= Convert.ToDouble(ddlPaymentUpperBound.SelectedValue))).ToList();
                                    else if (ddlPaymentLowerBound.SelectedIndex <= 0 && ddlPaymentUpperBound.SelectedIndex > 0)
                                        fine = (List<eMonthleys.BLL.Search>)fine.Where(s => s.PaymentWithTax <= Convert.ToDouble(ddlPaymentUpperBound.SelectedValue)).ToList();
                                    else if (ddlPaymentLowerBound.SelectedIndex > 0 && ddlPaymentUpperBound.SelectedIndex <= 0)
                                        fine = (List<eMonthleys.BLL.Search>)fine.Where(s => s.PaymentWithTax >= Convert.ToDouble(ddlPaymentLowerBound.SelectedValue)).ToList();
                                    break;
                            }
                        }
                        if (ddlYearLowerBound.SelectedIndex > 0)
                            fine = (List<eMonthleys.BLL.Search>)fine.Where(s => (s.ModelYear >= Convert.ToInt16(ddlYearLowerBound.SelectedValue)
                                    && s.ModelYear <= Convert.ToInt16(ddlYearUpperBound.SelectedValue))).ToList();
                        if (ddlPriceLower.SelectedIndex > 0)
                            fine = (List<eMonthleys.BLL.Search>)fine.Where(s => (s.PurchasePrice >= Convert.ToDouble(ddlPriceLower.SelectedValue)
                                    && s.PurchasePrice <= Convert.ToDouble(ddlPriceUpper.SelectedValue))).ToList();
                        if (ddlCurrKiloMin.SelectedIndex > 0)
                            fine = (List<eMonthleys.BLL.Search>)fine.Where(v => v.CurrentMileage >= Convert.ToInt32(ddlCurrKiloMin.SelectedValue)
                                && v.CurrentMileage <= Convert.ToInt32(ddlCurrKiloMax.SelectedValue)).ToList();
                        if (ddlExteriorColor.SelectedIndex > 0)
                            fine = (List<eMonthleys.BLL.Search>)fine.Where(x => x.ExteriorColor == ddlExteriorColor.SelectedValue).ToList();
                        if (ddlTransmission.SelectedIndex > 0)
                            fine = (List<eMonthleys.BLL.Search>)fine.Where(y => y.Transmission == ddlTransmission.SelectedValue).ToList();
                        if (cbl.Count > 0)
                        {
                            fuel = string.Join(",", cbl.ToArray());
                            fine = (List<eMonthleys.BLL.Search>)fine.Where(z => fuel.Contains(z.FuelType)).ToList();
                        }

                        if (fine.Count > 0)
                        {
                            string totalCars = (fine.Count == 1) ? string.Concat(fine.Count, " vehicle") : string.Concat(fine.Count, " vehicles");
                %>
                <div class="bold">
                    <p><%=totalCars %> matched your search criteria.</p>
                </div>
                <%
                    for (int i = 0; i < fine.Count; i++)
                    {
                        var imgsfine = eMonthleys.BLL.VehicleImage.SelectByVehicleId(fine[i].VehicleId);
                %>
                <div class="srimg border-grey">
                    <div class="status">
                        <%if (fine[i].VehicleCondition.Equals("used"))
                            {
                                Response.Write("<p><span>Pre-Owned</span></p>");
                            }
                            else
                            {
                                Response.Write("<p><span>New</span></p>");
                            }
                        %>
                    </div>
                    <div class="img-rounded centered">
                        <img id="imgDetailFine" src="<%
                            if (imgsfine != null)
                            {
                                Response.Write("/thumbnail.ashx?pic=" + imgsfine.Img1 + "&size=150");
                            }
                            else
                            {
                                Response.Write("/images/cargrey.png");
                            }
					%>                        
						"
                            alt="generic car image" />
                        <%if (!string.IsNullOrEmpty(fine[i].Status))
                            {
                                Response.Write("<p class='sold'><span>" + fine[i].Status + "</span></p>");
                            }
                        %>
                    </div>
                </div>
                <div class="srdetail">
                    <%
                        string heading = fine[i].ModelYear.ToString();
                        if (fine[i].Manufacturer == "Other")
                            heading += " " + fine[i].MakeOther;
                        else
                            heading += " " + fine[i].Manufacturer;
                        if (fine[i].Model == "Other")
                            heading += " " + fine[i].ModelOther;
                        else
                            heading += " " + fine[i].Model;
                        if (fine[i].ModelTrim == "Other")
                            heading += " " + fine[i].OtherTrim;
                        else
                            heading += " " + fine[i].ModelTrim;
                    %>
                    <strong><%= heading %></strong>
                    <div>
                        Id# <% Response.Write(fine[i].VehicleId); %>
                    </div>
                    City: <% Response.Write(fine[i].City);
                              if (fine[i].VehicleCondition.Equals("used"))
                              {
                    %>
                    <div>
                        Finance or Lease: <% switch (fine[i].LeaseOrFinance)
                                              {
                                                  case "f":
                                                      Response.Write("Finance");
                                                      break;
                                                  case "l":
                                                      Response.Write("Lease");
                                                      break;
                                                  case "c":
                                                      Response.Write("Cash price");
                                                      break;
                                                  default:
                                                      break;
                                              }
                        %>
                    </div>
                    <%} %>
                    <div class="bold">
                        Purchase price: <% Response.Write(fine[i].PurchasePrice.ToString(@"$#,##0.00;($#,##0.00\)")); %>
                    </div>
                    <%if (fine[i].LeaseOrFinance.Equals("f") || fine[i].LeaseOrFinance.Equals("l"))
                        { %>
                    <div>
                        Payment cycle: <% Response.Write(fine[i].PaymentCycle); %>
                    </div>
                    <div>
                        Payment: <% Response.Write(fine[i].PaymentWithTax.ToString(@"$#,##0.00;($#,##0.00\)")); %>
                    </div>
                    <div>
                        Term of loan: <% Response.Write(fine[i].LeaseTerm); %>
                    </div>
                    <%
                        if (fine[i].LeaseOrFinance.Equals("l"))
                        {
                            if (fine[i].VehicleCondition.Equals("used"))
                            {
                    %>
                    <div>
                        Odometer reading: <% Response.Write(fine[i].CurrentMileage.ToString("N0")); %> Km
                    </div>
                    <%} %>
                    <div>
                        Free km's per year: <% Response.Write(fine[i].KmAllowance.ToString("N0")); %>
                    </div>
                    <%}
                        else
                        {
                            if (fine[i].VehicleCondition.Equals("used"))
                            {
                    %>
                    <div>
                        Odometer reading: <% Response.Write(fine[i].CurrentMileage.ToString("N0")); %> Km
                    </div>
                    <%}
                            }
                        }
                        else if (fine[i].LeaseOrFinance.Equals("c"))
                        {
                            if (fine[i].CurrentMileage > 1)
                            {
                    %>
                    <div>
                        Odometer reading: <% Response.Write(fine[i].CurrentMileage.ToString("N0")); %> Kms
                    </div>
                    <% }
                        } %>
                </div>

                <div class="sraction">
                    <%if (fine[i].CustomerType.Equals("private"))
                        {
                            Response.Write("Private sales");
                        }
                        else
                        {
                            Response.Write(Server.HtmlDecode(fine[i].Company));
                        }
                    %>
                    <p><%Response.Write(Server.HtmlDecode(fine[i].Comments)); %></p>
                    <div class="centered">
                        <a id="BtnShowDetails2" class="btn btn-primary"
                            href="/VehicleDetails.aspx?id=<%=fine[i].VehicleId%>&fid=<%=fine[i].FinId%>">Details</a>
                    </div>
                </div>

                <div class="clear"></div>

                <%       
                                if (i < fine.Count - 1)
                                    Response.Write("<br/><hr class='hred' />");
                            }
                        }
                    }
                    else
                        Response.Write("No items found!");

                %>
            </asp:Panel>

        </div>
        <div class="clear25"></div>
    </div>
</asp:Content>
