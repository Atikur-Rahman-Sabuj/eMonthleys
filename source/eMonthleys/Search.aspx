<%@ Page Title="Search" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="eMonthleys.SearchVehicles" %>

<%@ Register Src="~/controls/adsLeft.ascx" TagPrefix="uc1" TagName="adsLeft" %>
<%@ Register Src="~/controls/adsRight.ascx" TagPrefix="uc1" TagName="adsRight" %>

<asp:Content ID="Header1" ContentPlaceHolderID="HeaderContent" runat="server">
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
        $("#budgetrange").click(function () {
            $("#<%=ddlPriceLow.ClientID%>").attr("disabled", true);
            $("#<%=ddlPriceHigh.ClientID%>").attr("disabled", true);
            $("#<%=ddlPaymentLowerBound.ClientID%>").attr("disabled", false);
            $("#<%=ddlPaymentUpperBound.ClientID%>").attr("disabled", false);
        });
        $("#pricerange").click(function () {
            $("#<%=ddlPriceLow.ClientID%>").attr("disabled", false);
            $("#<%=ddlPriceHigh.ClientID%>").attr("disabled", false);
            $("#<%=ddlPaymentLowerBound.ClientID%>").attr("disabled", true);
            $("#<%=ddlPaymentUpperBound.ClientID%>").attr("disabled", true);
        });
    </script>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-3">
            <uc1:adsLeft runat="server" ID="adsLeft" />
        </div>
        <div class="col-md-6 mainpanel">

            <h1>Lets Go Search</h1>
            <div class="form-group">
                <fieldset>
                    <legend><span class="blue bold">Pick a Payment or Price (incl. Tax)</span></legend>
                    <div>
                        <input type="radio" name="budgetrange" id="budgetrange" class="bgtRange" value="payment"><label for="budgetrange" class="bold"> Select a Payment </label>
                        <br />
                        from $<asp:DropDownList ID="ddlPaymentLowerBound" runat="server">
                            <asp:ListItem Value=""></asp:ListItem>
                            <asp:ListItem Value="50">50</asp:ListItem>
                            <asp:ListItem Value="100">100</asp:ListItem>
                            <asp:ListItem Value="200">200</asp:ListItem>
                            <asp:ListItem Value="300">300</asp:ListItem>
                            <asp:ListItem Value="400">400</asp:ListItem>
                            <asp:ListItem Value="500">500</asp:ListItem>
                            <asp:ListItem Value="600">600</asp:ListItem>
                            <asp:ListItem Value="700">700</asp:ListItem>
                            <asp:ListItem Value="800">800</asp:ListItem>
                            <asp:ListItem Value="900">900</asp:ListItem>
                            <asp:ListItem Value="1000">1000</asp:ListItem>
                            <asp:ListItem Value="3000">3000</asp:ListItem>
                            <asp:ListItem Value="6000">6000</asp:ListItem>
                            <asp:ListItem Value="10000">10000</asp:ListItem>
                            <asp:ListItem Value="15000">15000</asp:ListItem>
                        </asp:DropDownList>&nbsp;to&nbsp;
					$<asp:DropDownList ID="ddlPaymentUpperBound" runat="server">
                        <asp:ListItem Value=""></asp:ListItem>
                        <asp:ListItem Value="100">100</asp:ListItem>
                        <asp:ListItem Value="200">200</asp:ListItem>
                        <asp:ListItem Value="300">300</asp:ListItem>
                        <asp:ListItem Value="400">400</asp:ListItem>
                        <asp:ListItem Value="500">500</asp:ListItem>
                        <asp:ListItem Value="600">600</asp:ListItem>
                        <asp:ListItem Value="700">700</asp:ListItem>
                        <asp:ListItem Value="800">800</asp:ListItem>
                        <asp:ListItem Value="900">900</asp:ListItem>
                        <asp:ListItem Value="1000">1000</asp:ListItem>
                        <asp:ListItem Value="3000">3000</asp:ListItem>
                        <asp:ListItem Value="6000">6000</asp:ListItem>
                        <asp:ListItem Value="10000">10000</asp:ListItem>
                        <asp:ListItem Value="15000">15000</asp:ListItem>
                        <asp:ListItem Value="20000">20000</asp:ListItem>
                    </asp:DropDownList>
                    </div>
                    <div class="clear25 bold text-center">OR</div>
                    <div>
                        <input type="radio" name="budgetrange" id="pricerange" class="bgtRange" value="price"><label for="budget" class="bold">Price </label>
                        <br />
                        from $<asp:DropDownList ID="ddlPriceLow" runat="server">
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
                            <asp:ListItem>6000</asp:ListItem>
                            <asp:ListItem>10000</asp:ListItem>
                            <asp:ListItem>20000</asp:ListItem>
                            <asp:ListItem>30000</asp:ListItem>
                            <asp:ListItem>40000</asp:ListItem>
                            <asp:ListItem>50000</asp:ListItem>
                            <asp:ListItem>70000</asp:ListItem>
                            <asp:ListItem>100000</asp:ListItem>
                            <asp:ListItem>200000</asp:ListItem>
                            <asp:ListItem>300000</asp:ListItem>
                            <asp:ListItem>400000</asp:ListItem>
                            <asp:ListItem>500000+</asp:ListItem>
                        </asp:DropDownList>&nbsp;to&nbsp;
					$<asp:DropDownList ID="ddlPriceHigh" runat="server">
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
                        <asp:ListItem>10000</asp:ListItem>
                        <asp:ListItem>20000</asp:ListItem>
                        <asp:ListItem>30000</asp:ListItem>
                        <asp:ListItem>40000</asp:ListItem>
                        <asp:ListItem>50000</asp:ListItem>
                        <asp:ListItem>70000</asp:ListItem>
                        <asp:ListItem>100000</asp:ListItem>
                        <asp:ListItem>200000</asp:ListItem>
                        <asp:ListItem>300000</asp:ListItem>
                        <asp:ListItem>400000</asp:ListItem>
                        <asp:ListItem>500000</asp:ListItem>
                    </asp:DropDownList>
                        <span id="errmsg"></span>
                    </div>
                </fieldset>
                <div class="clear25"></div>
                <fieldset>
                    <legend><span class="blue bold">Type of Vehicle</span></legend>

                    <asp:CheckBoxList ID="cbxvType" runat="server" GroupName="vType" RepeatColumns="2" Width="100%">
                        <asp:ListItem Value="22,23,26,27,30,34,35,38" Text="<img src='/images/sedan-icon.png' /> Cars/Sports cars"></asp:ListItem>
                        <asp:ListItem Value="29" Text="<img src='/images/minivan-icon.png' /> Vans"></asp:ListItem>
                        <asp:ListItem Value="25,32,36" Text="<img src='/images/SUV-icon.png' /> SUV's"></asp:ListItem>
                        <asp:ListItem Value="24,28,37" Text="<img src='/images/truck-icon.png' /> Trucks"></asp:ListItem>
                        <asp:ListItem Value="31" Text="<img src='/images/cabriolet-icon.png' /> Convertibles"></asp:ListItem>
                        <asp:ListItem Value="39" Text="<img src='/images/collector-icon.png' /> Collector Cars"></asp:ListItem>
                    </asp:CheckBoxList>
                </fieldset>
                <div class="clear25"></div>
                <fieldset>
                    <legend><span class="blue bold">Manufacturers</span></legend>
                    <%--                    <span id="multiOption">To select multiple hold the <span class="bold">Ctrl</span> key down and then select.</span>
                                         <asp:Label ID="lblYears" runat="server" AssociatedControlID="ddlYears" class="col-md-3">Model Year: </asp:Label>
                   <div class="col-md-9">
                        <asp:DropDownList ID="ddlYears" runat="server" CssClass="form-control" Width="200px"
                            DataSourceID="odsYears" DataTextField="ModelYear" DataValueField="ModelYear" AutoPostBack="false">
                        </asp:DropDownList>
                        <asp:ObjectDataSource runat="server" ID="odsYears" SelectMethod="GetAllModelYearLookup" TypeName="eMonthleys.BLL.ModelYearLookup"></asp:ObjectDataSource>
                    </div>--%>
                    <div>
                        <asp:ListBox ID="lbxMakes" runat="server" DataTextField="Make" DataValueField="Make"
                            ValidationGroup="vgSearch" DataSourceID="odsMakes" Rows="5" SelectionMode="Multiple"></asp:ListBox>
                        <asp:ObjectDataSource ID="odsMakes" runat="server" SelectMethod="GetAllMakeLookup" TypeName="eMonthleys.BLL.MakeLookup">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="cbl" Name="ListType" Type="String"></asp:Parameter>
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </div>

                </fieldset>
                <div class="clear25"></div>
                <fieldset>
                    <legend><span class="blue bold">Area of Search</span></legend>
                    <div class="form-group">
                        <asp:Label ID="lblProv" runat="server" AssociatedControlID="ddlState" CssClass="col-md-2">Province:</asp:Label>
                        <div class="col-md-5">
                            <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control" Width="200px">
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


                        </div>
                        <%--                        <asp:Label ID="lblCity" runat="server" CssClass="col-md-1" AssociatedControlID="txtCity">City:</asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtCity" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>--%>
                    </div>
                </fieldset>
                <div class="clear25"></div>
                <div class="centered">
                    <asp:Button ID="BtnSearch" runat="server" Text="Search" CausesValidation="true" OnClick="BtnSearch_Click" CssClass="btn btn-primary" />
                </div>
            </div>
        </div>
        <div class="col-md-3">
            <uc1:adsRight runat="server" ID="adsRight" />
        </div>
        <div class="clear"></div>
    </div>
    <script>
        $(document).ready(function () {
            $('#<%=ddlPriceLow.ClientID%>').attr('disabled', 1);
            $('#<%=ddlPriceHigh.ClientID%>').attr('disabled', 1);
            $('#<%=ddlPaymentLowerBound.ClientID%>').attr('disabled', 1);
            $('#<%=ddlPaymentUpperBound.ClientID%>').attr('disabled', 1);

            $(".budgetrange").keypress(function (e) {
                //if the letter is not digit then display error and don't type anything
                if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                    //display error message
                    $("#errmsg").html("Digits Only").show().fadeOut("slow");
                    return false;
                }
            });
        });

        $('#<%=ddlPriceLow.ClientID%>').change(function () {
            var min = $('#<%=ddlPriceLow.ClientID%> option:selected').text();
            if (min.indexOf("+") > 0) {
                $('#<%=ddlPriceHigh.ClientID%>').attr('disabled', 1);
            }
            else {
                $('#<%=ddlPriceHigh.ClientID%>').removeAttr('disabled');
            }
        });

        $('.bgtRange').click(function () {
            if ($("input[name=budgetrange]:checked").val() == "payment") {
                $('#<%=ddlPaymentLowerBound.ClientID%>').removeAttr('disabled');
            $('#<%=ddlPaymentUpperBound.ClientID%>').removeAttr('disabled');
            $('#<%=ddlPriceLow.ClientID%>').attr('disabled', 1);
            $('#<%=ddlPriceHigh.ClientID%>').attr('disabled', 1);
            $('#<%=ddlPriceLow.ClientID%>')[0].selectedIndex = 0;
            $('#<%=ddlPriceHigh.ClientID%>')[0].selectedIndex = 0;
        }
        else if ($("input[name=budgetrange]:checked").val() == "price") {
            $('#<%=ddlPaymentLowerBound.ClientID%>').attr('disabled', 1);
            $('#<%=ddlPaymentUpperBound.ClientID%>').attr('disabled', 1);
            $('#<%=ddlPriceLow.ClientID%>').removeAttr('disabled');
            $('#<%=ddlPriceHigh.ClientID%>').removeAttr('disabled');
            $('#<%=ddlPaymentLowerBound.ClientID%>')[0].selectedIndex = 0;
            $('#<%=ddlPaymentUpperBound.ClientID%>')[0].selectedIndex = 0;
            }
        });
        // payment dropdowns check 
        $('#<%=ddlPaymentLowerBound.ClientID%>').on('change', function () {
            var self = this;
            $('#<%=ddlPaymentUpperBound.ClientID%>').find('option').prop('disabled', function () {
                return parseInt(this.value) <= parseInt(self.value);
            });
        });

        // price dropdowns check
        $('#<%=ddlPriceLow.ClientID%>').on('change', function () {
            var self = this;
            $('#<%=ddlPriceHigh.ClientID%>').find('option').prop('disabled', function () {
                return parseInt(this.value) <= parseInt(self.value);
            });
        });

    </script>
</asp:Content>
