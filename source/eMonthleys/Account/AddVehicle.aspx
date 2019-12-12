<%@ Page Title="Sell Your Car" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddVehicle.aspx.cs" Inherits="eMonthleys.AddVehicle" %>
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
    <link href="/Content/jquery-ui-1.10.4.custom.css" rel="stylesheet" />
    <script src="/Scripts/jquery-ui-1.10.4.custom.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#tabs").tabs();
        });
    </script>
    <script>
        // JQUERY ".Class" SELECTOR.
        $(document).ready(function () {
            $('.dollarvalue').keypress(function (event) {
                return isNumber(event, this);
            });
        });
        // THE SCRIPT THAT CHECKS IF THE KEY PRESSED IS A NUMERIC OR DECIMAL VALUE.
        function isNumber(evt, element) {

            var charCode = (evt.which) ? evt.which : event.keyCode;

            if (
                (charCode != 45 || $(element).val().indexOf('-') != -1) &&      // “-” CHECK MINUS, AND ONLY ONE.
                (charCode != 46 || $(element).val().indexOf('.') != -1) &&      // “.” CHECK DOT, AND ONLY ONE.
                (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
    </script>
    <script type="text/javascript">

        var isSubmitted = false;

        function preventMultipleSubmissions() {
            if (!isSubmitted) {
                $('#<%=BtnSaveImages.ClientID %>').val('Submitting ad.. Plz Wait..');
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
    <div class="container-fluid mainpanel">
        <h1><%: Title %></h1>
        <div class="pricing bold white">
            <h3 class="white">Ad pricing</h3>
            <p>Private ads are free</p>
            <p>$19.99 including tax for 1 months (Business)</p>
            <p></p>
        </div>
        <asp:Literal ID="ltlRemaining" runat="server"></asp:Literal>
        <div class="clear10"></div>
        <asp:Panel ID="pnlDetails" runat="server">
            <div id="tabs">
                <ul>
                    <li><a href="#tabs-1">Vehicle or Item Information</a></li>
                    <li><a href="#tabs-2">Pricing</a></li>
                    <li><a href="#tabs-3">Pictures</a></li>
                </ul>
                <div id="tabs-1">
                    <div class="clear"></div>
                    <fieldset>
                        <legend></legend>
                        <div>
                            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="vgVehicle" ShowMessageBox="True" CssClass="text-danger" />
                        </div>
                        <%-- Part 1 --%>
                        <div class="form-group">
                            <div class="col-md-9">
                                <asp:RadioButtonList ID="rblCondition" runat="server" RepeatLayout="Table" CssClass="floatleft"
                                    ValidationGroup="vgVehicle" Width="200px" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="new">New</asp:ListItem>
                                    <asp:ListItem Value="used">Pre-Owned</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ErrorMessage="Please select whether new or pre-owned." ValidationGroup="vgVehicle"
                                    ControlToValidate="rblCondition" CssClass="text-danger" InitialValue="" Text="*"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="clear5"></div>
                        <div class="form-group">
                            <asp:Label ID="lblVehicleType" runat="server" AssociatedControlID="rblVehicleType" CssClass="col-md-3 control-label">Vehicle or Item Type:</asp:Label>
                            <div class="col-md-9">
                                <asp:RadioButtonList ID="rblVehicleType" runat="server" GroupName="vType" RepeatColumns="2" Width="100%">
                                    <asp:ListItem Value="22" Text="<img src='/images/sedan-icon.png' /> Cars"></asp:ListItem>
                                    <asp:ListItem Value="29" Text="<img src='/images/minivan-icon.png' /> Vans"></asp:ListItem>
                                    <asp:ListItem Value="25" Text="<img src='/images/SUV-icon.png' /> SUV's"></asp:ListItem>
                                    <asp:ListItem Value="24" Text="<img src='/images/truck-icon.png' /> Trucks"></asp:ListItem>
                                    <asp:ListItem Value="31" Text="<img src='/images/cabriolet-icon.png' /> Convertibles"></asp:ListItem>
                                    <asp:ListItem Value="39" Text="<img src='/images/collector-icon.png' /> Collector Cars"></asp:ListItem>
                                </asp:RadioButtonList>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Vehicle type is required." ValidationGroup="vgVehicle"
                                    ControlToValidate="rblVehicleType" CssClass="text-danger" Text="*"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="clear5"></div>
                        <div class="form-group">
                            <asp:Label ID="lblYear" runat="server" AssociatedControlID="ddlYear" CssClass="col-md-3 control-label">Model Year:</asp:Label>
                            <div class="col-md-9">
                                <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="false" CssClass="form-control floatleft" ValidationGroup="vgVehicle" Width="200px" DataSourceID="odsModelYears" DataTextField="ModelYear" DataValueField="ModelYear"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Model year is required." ValidationGroup="vgVehicle"
                                    ControlToValidate="ddlYear" CssClass="text-danger" InitialValue="Please select" Text="*"></asp:RequiredFieldValidator>
                            </div>
                            <asp:ObjectDataSource runat="server" ID="odsModelYears" SelectMethod="GetAllModelYearLookup" TypeName="eMonthleys.BLL.ModelYearLookup"></asp:ObjectDataSource>
                        </div>
                        <div class="clear5"></div>
                        <div class="form-group">
                            <asp:Label ID="lblMake" runat="server" AssociatedControlID="DdlMakes" CssClass="col-md-3 control-label">Manufacturer:</asp:Label>
                            <div class="col-md-3">
                                <asp:DropDownList ID="DdlMakes" runat="server" AutoPostBack="true" CssClass="form-control floatleft" OnSelectedIndexChanged="DdlMakes_SelectedIndexChanged"
                                    ValidationGroup="vgVehicle" DataSourceID="odsManufacturers" DataTextField="Make" DataValueField="Make" Width="200px">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Manufacturer is required." ValidationGroup="vgVehicle"
                                    ControlToValidate="DdlMakes" CssClass="text-danger" InitialValue="Please select" Text="*"></asp:RequiredFieldValidator>
                                <asp:ObjectDataSource runat="server" ID="odsManufacturers" SelectMethod="GetAllMakeLookup" TypeName="eMonthleys.BLL.MakeLookup">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="ddl" Name="ListType" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="TxtMakeOther" runat="server" Visible="false" Enabled="false" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RfvMakeOther" runat="server" ErrorMessage="Please enter other manufacturer" Text="*"
                                            CssClass="text-danger" ControlToValidate="TxtMakeOther" Enabled="false"></asp:RequiredFieldValidator>
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="DdlMakes" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                        <div class="clear5"></div>
                        <div class="form-group">
                            <asp:Label ID="lblModel" runat="server" AssociatedControlID="DdlModel" CssClass="col-md-3 control-label">Model:</asp:Label>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <div class="col-md-3">
                                        <asp:DropDownList ID="DdlModel" runat="server" AutoPostBack="true" CssClass="form-control floatleft" ValidationGroup="vgVehicle"
                                            DataSourceID="OdsModels" DataTextField="Model" DataValueField="Model" Width="200px" OnSelectedIndexChanged="DdlModel_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RfvModel" runat="server" ErrorMessage="Model is required." ValidationGroup="vgVehicle"
                                            ControlToValidate="DdlModel" CssClass="text-danger" InitialValue="Please select" Text="*"></asp:RequiredFieldValidator>
                                        <asp:ObjectDataSource runat="server" ID="OdsModels" SelectMethod="GetAllModelsLookup" TypeName="eMonthleys.BLL.ModelLookup" OnSelecting="OdsModels_Selecting">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="DdlMakes" PropertyName="SelectedValue" Name="Manufacturer" Type="String"></asp:ControlParameter>
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </div>
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                        <ContentTemplate>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="TxtModelOther" runat="server" Visible="false" Enabled="false" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RfvModelOther" runat="server" ErrorMessage="Please enter other model" Text="*"
                                                    CssClass="text-danger" ControlToValidate="TxtModelOther" Enabled="false"></asp:RequiredFieldValidator>
                                            </div>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="DdlModel" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="DdlMakes" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                        <div class="clear5"></div>
                        <div class="form-group">
                            <asp:Label ID="lblTrim" runat="server" AssociatedControlID="DdlTrim" CssClass="col-md-3 control-label">Model Trim:</asp:Label>
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <div class="col-md-3">
                                        <asp:DropDownList ID="DdlTrim" runat="server" CssClass="form-control floatleft" ValidationGroup="vgVehicle" AutoPostBack="true"
                                            DataSourceID="OdsTrims" DataTextField="ModelTrim" DataValueField="ModelId" Width="200px" OnSelectedIndexChanged="DdlTrim_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RfvTrim" runat="server" ErrorMessage="Model trim is required." ValidationGroup="vgVehicle"
                                            ControlToValidate="DdlTrim" CssClass="text-danger" InitialValue="0" Text="*"></asp:RequiredFieldValidator>
                                    </div>
                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                        <ContentTemplate>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="TxtModelTrim" runat="server" Visible="false" Enabled="false" CssClass="form-control floatleft"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RfvTxtTrim" runat="server" ErrorMessage="Please enter other model trim" Text="*"
                                                    CssClass="text-danger" ControlToValidate="TxtModelTrim" Enabled="false"></asp:RequiredFieldValidator>
                                            </div>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="DdlModel" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    <asp:ObjectDataSource runat="server" ID="OdsTrims" SelectMethod="GetAllModelTrimLookup" TypeName="eMonthleys.BLL.ModelTrimLookup" OnSelecting="OdsTrims_Selecting">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="DdlModel" PropertyName="SelectedValue" Name="ModelName" Type="String"></asp:ControlParameter>
                                            <asp:ControlParameter ControlID="DdlMakes" PropertyName="SelectedValue" Name="Manufacturer" Type="String"></asp:ControlParameter>
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="DdlModel" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="DdlMakes" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                            <div class="clear5"></div>
                        </div>
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="form-group">
                                    <asp:Label ID="lblBodyColour" runat="server" AssociatedControlID="ddlBodyColour" CssClass="col-md-3 control-label">Body Colour:</asp:Label>
                                    <div class="col-md-9">
                                        <asp:DropDownList ID="ddlBodyColour" runat="server" CssClass="form-control floatleft" ValidationGroup="vgVehicle" Width="200px">
                                            <asp:ListItem Value="">Please select</asp:ListItem>
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
                                            <asp:ListItem Value="Yellow">Yellow</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvBodyColor" runat="server" ErrorMessage="Body colour is required." ValidationGroup="vgVehicle"
                                            ControlToValidate="ddlBodyColour" CssClass="text-danger" InitialValue="" Text="*"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="clear5"></div>

                                <div class="form-group">
                                    <asp:Label ID="lblInteriorColour" runat="server" AssociatedControlID="ddlInteriorColour" CssClass="col-md-3 control-label">Interior Colour:</asp:Label>
                                    <div class="col-md-9">
                                        <asp:DropDownList ID="ddlInteriorColour" runat="server" CssClass="form-control floatleft" ValidationGroup="vgVehicle" Width="200px">
                                            <asp:ListItem Value="">Please select</asp:ListItem>
                                            <asp:ListItem Value="Beige">Beige</asp:ListItem>
                                            <asp:ListItem Value="Black">Black</asp:ListItem>
                                            <asp:ListItem Value="Blue">Blue</asp:ListItem>
                                            <asp:ListItem Value="Brown">Brown</asp:ListItem>
                                            <asp:ListItem Value="Burgundy">Burgundy</asp:ListItem>
                                            <asp:ListItem Value="Dark Grey">Dark Grey</asp:ListItem>
                                            <asp:ListItem Value="Graphite">Graphite</asp:ListItem>
                                            <asp:ListItem Value="Gray">Gray</asp:ListItem>
                                            <asp:ListItem Value="Green">Green</asp:ListItem>
                                            <asp:ListItem Value="Grey">Grey</asp:ListItem>
                                            <asp:ListItem Value="Light Grey">Light Grey</asp:ListItem>
                                            <asp:ListItem Value="Pewter">Pewter</asp:ListItem>
                                            <asp:ListItem Value="Red">Red</asp:ListItem>
                                            <asp:ListItem Value="Tan">Tan</asp:ListItem>
                                            <asp:ListItem Value="Taupe">Taupe</asp:ListItem>
                                            <asp:ListItem Value="White">White</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvInteriorColor" runat="server" ErrorMessage="Interior colour is required." ValidationGroup="vgVehicle"
                                            ControlToValidate="ddlInteriorColour" CssClass="text-danger" InitialValue="" Text="*"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="clear5"></div>
                                <div class="form-group">
                                    <asp:Label ID="lblMilage" runat="server" AssociatedControlID="txtMileage" CssClass="col-md-3 control-label">Current Mileage:</asp:Label>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtMileage" runat="server" CssClass="dollarvalue form-control floatleft" ValidationGroup="vgVehicle" Text="0"></asp:TextBox>&nbsp;KM&nbsp;(Enter 1 for new)
                                        <asp:RequiredFieldValidator ID="rfvMilage" runat="server" ErrorMessage="Mileage is required." ValidationGroup="vgVehicle"
                                            ControlToValidate="txtMileage" CssClass="text-danger" Text="*"></asp:RequiredFieldValidator>
                                        <asp:RangeValidator ID="rngvMilage" runat="server" ControlToValidate="txtMileage" CssClass="text-danger"
                                            ErrorMessage="Mileage must be numeric" MaximumValue="9999999" MinimumValue="0" ValidationGroup="vgVehicle">*</asp:RangeValidator>
                                    </div>
                                </div>
                                <div class="clear5"></div>
                                <div class="form-group">
                                    <asp:Label ID="Label18" runat="server" AssociatedControlID="ddlFuel" CssClass="col-md-3 control-label">Fuel type:</asp:Label>
                                    <div class="col-md-9">
                                        <asp:DropDownList ID="ddlFuel" runat="server" CssClass="form-control floatleft" ValidationGroup="vgVehicle" Width="150px">
                                            <asp:ListItem Value="">Please select</asp:ListItem>
                                            <asp:ListItem>Diesel</asp:ListItem>
                                            <asp:ListItem>Gas</asp:ListItem>
                                            <asp:ListItem>Electric</asp:ListItem>
                                            <asp:ListItem>Hybrid</asp:ListItem>
                                            <asp:ListItem>FlexFuel</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvFuel" runat="server" ErrorMessage="Fuel type is required." ValidationGroup="vgVehicle"
                                            ControlToValidate="ddlFuel" CssClass="text-danger" InitialValue="" Text="*"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="clear5"></div>
                                <div class="form-group">
                                    <asp:Label ID="Label28" runat="server" AssociatedControlID="ddlFuel" CssClass="col-md-3 control-label">Displacement:</asp:Label>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtDisplacement" runat="server" CssClass="form-control floatleft" ValidationGroup="vgVehicle" Width="300px" />
                                        <asp:RequiredFieldValidator ID="rfvDisplacement" runat="server" ErrorMessage="Displacement is required." ValidationGroup="vgVehicle"
                                            ControlToValidate="txtDisplacement" CssClass="text-danger">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="clear5"></div>
                                <div class="form-group">
                                    <asp:Label ID="lblTransmission" runat="server" AssociatedControlID="ddlTransmission" CssClass="col-md-3 control-label">Transmission:</asp:Label>
                                    <div class="col-md-9">
                                        <asp:DropDownList ID="ddlTransmission" runat="server" CssClass="form-control floatleft" ValidationGroup="vgVehicle" Width="200px">
                                            <asp:ListItem Value="">Please select</asp:ListItem>
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
                                        <asp:RequiredFieldValidator ID="rfvTransmission" runat="server" ErrorMessage="Tranmission is required." ValidationGroup="vgVehicle"
                                            ControlToValidate="ddlTransmission" CssClass="text-danger" InitialValue="" Text="*"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="clear5"></div>
                                <%-- Part 2  Features--%>

                                <%-- Dropdown List Wheels --%>
                                <asp:Panel ID="pnlTires" runat="server">
                                    <div class="form-group">
                                        <asp:Label ID="lblWheels" runat="server" AssociatedControlID="ddlWheels" CssClass="col-md-3 control-label">Type of wheels:</asp:Label>
                                        <div class="col-md-9">
                                            <asp:DropDownList ID="ddlWheels" runat="server" CssClass="form-control" ValidationGroup="vgVehicle" Width="200px">
                                                <asp:ListItem Value="">Please select</asp:ListItem>
                                                <asp:ListItem Value="Wheel covers">Wheel covers</asp:ListItem>
                                                <asp:ListItem Value="14 inch steel wheels">14 inch steel wheels</asp:ListItem>
                                                <asp:ListItem Value="14 inch alloy wheels">14 inch alloy wheels</asp:ListItem>
                                                <asp:ListItem Value="15 inch steel wheels">15 inch steel wheels</asp:ListItem>
                                                <asp:ListItem Value="15 inch alloy wheels">15 inch alloy wheels</asp:ListItem>
                                                <asp:ListItem Value="16 inch steel wheels">16 inch steel wheels</asp:ListItem>
                                                <asp:ListItem Value="16 inch alloy wheels">16 inch alloy wheels</asp:ListItem>
                                                <asp:ListItem Value="17 inch steel wheels">17 inch steel wheels</asp:ListItem>
                                                <asp:ListItem Value="17 inch alloy wheels">17 inch alloy wheels</asp:ListItem>
                                                <asp:ListItem Value="18 inch alloy wheels">18 inch alloy wheels</asp:ListItem>
                                                <asp:ListItem Value="19 inch alloy wheels">19 inch alloy wheels</asp:ListItem>
                                                <asp:ListItem Value="20 inch alloy wheels">20 inch alloy wheels</asp:ListItem>
                                                <asp:ListItem Value="22 inch alloy wheels">22 inch alloy wheels</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:CheckBox ID="cbxChrome" runat="server" Text="Chrome wheels" Width="160px" />
                                            <div class="clear5"></div>
                                        </div>
                                    </div>
                                    <div class="clear5"></div>
                                    <%-- Dropdown List Tires--%>
                                    <div class="form-group">
                                        <asp:Label ID="lblTires" runat="server" AssociatedControlID="ddlTires" CssClass="col-md-3 control-label">Tires:</asp:Label>
                                        <div class="col-md-9">
                                            <asp:DropDownList ID="ddlTires" runat="server" CssClass="form-control" ValidationGroup="vgVehicle" Width="200px">
                                                <asp:ListItem Value="">Please select</asp:ListItem>
                                                <asp:ListItem Value="All season">All season</asp:ListItem>
                                                <asp:ListItem Value="All terrain">All terrain</asp:ListItem>
                                                <asp:ListItem Value="Performance">Performance</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:CheckBox ID="cbxWinterTires" runat="server" Text="Extra set of winter tires" />
                                            <div class="clear5"></div>
                                            <div class="clear5"></div>
                                        </div>
                                    </div>
                                </asp:Panel>
                                <%-- Dropdown List Heating and air conditioning  --%>
                                <asp:Panel ID="pnlFeatures" runat="server">
                                    <div class="clear5"></div>
                                    <div class="form-group">
                                        <asp:Label ID="Label1" runat="server" AssociatedControlID="ddlAirConditioning" CssClass="col-md-3 control-label">Heating and air conditioning:</asp:Label>
                                        <div class="col-md-9">
                                            <asp:DropDownList ID="ddlAirConditioning" runat="server" CssClass="form-control" ValidationGroup="vgVehicle" DataSourceID="odsAirConditioning" DataTextField="Feature" DataValueField="Id" Width="300px">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource runat="server" ID="odsAirConditioning" SelectMethod="GetAllFeatureLookup" TypeName="eMonthleys.BLL.FeatureLookup">
                                                <SelectParameters>
                                                    <asp:Parameter DefaultValue="Heating and air conditioning" Name="FeatureType" Type="String"></asp:Parameter>
                                                    <asp:Parameter DefaultValue="ddl" Name="Listtype" Type="String"></asp:Parameter>
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                            <div class="clear5"></div>
                                            <%-- Checkbox Rear heating --%>
                                        </div>
                                    </div>
                                    <%-- Checkbox List Power features --%>
                                    <div class="clear5"></div>
                                    <div class="form-group">
                                        <asp:Label ID="lblPowerFeatures" runat="server" AssociatedControlID="cblPowerFeatures" CssClass="col-md-3 control-label">Power features:</asp:Label>
                                        <div class="col-md-9">
                                            <asp:CheckBoxList ID="cblPowerFeatures" runat="server" DataSourceID="odsPowerFeatures" DataTextField="Feature" DataValueField="Id" RepeatColumns="4"
                                                Width="100%" RepeatDirection="Horizontal">
                                            </asp:CheckBoxList>
                                            <asp:ObjectDataSource runat="server" ID="odsPowerFeatures" SelectMethod="GetAllFeatureLookup" TypeName="eMonthleys.BLL.FeatureLookup">
                                                <SelectParameters>
                                                    <asp:Parameter DefaultValue="Power features" Name="FeatureType" Type="String"></asp:Parameter>
                                                    <asp:Parameter DefaultValue="cbl" Name="Listtype" Type="String"></asp:Parameter>
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                            <div class="clear5"></div>
                                        </div>
                                    </div>
                                    <%-- Dropdown List Seating --%>
                                    <div class="clear5"></div>
                                    <div class="form-group">
                                        <asp:Label ID="lblSeating" runat="server" AssociatedControlID="ddlSeating" CssClass="col-md-3 control-label">Seating:</asp:Label>
                                        <div class="col-md-9">
                                            <asp:DropDownList ID="ddlSeating" runat="server" CssClass="form-control" ValidationGroup="vgVehicle" DataSourceID="odsSeating" DataTextField="Feature" DataValueField="Id" Width="200px">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource runat="server" ID="odsSeating" SelectMethod="GetAllFeatureLookup" TypeName="eMonthleys.BLL.FeatureLookup">
                                                <SelectParameters>
                                                    <asp:Parameter DefaultValue="Seating" Name="FeatureType" Type="String"></asp:Parameter>
                                                    <asp:Parameter DefaultValue="ddl" Name="Listtype" Type="String"></asp:Parameter>
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                            <div class="clear5"></div>
                                            <%-- Checkbox List Seating --%>
                                            <asp:CheckBoxList ID="cblSeating" runat="server" DataSourceID="odsSeatingCbl" DataTextField="Feature" DataValueField="Id" RepeatColumns="4"
                                                Width="100%" RepeatDirection="Horizontal">
                                            </asp:CheckBoxList>
                                            <asp:ObjectDataSource runat="server" ID="odsSeatingCbl" SelectMethod="GetAllFeatureLookup" TypeName="eMonthleys.BLL.FeatureLookup">
                                                <SelectParameters>
                                                    <asp:Parameter DefaultValue="Seating" Name="FeatureType" Type="String"></asp:Parameter>
                                                    <asp:Parameter DefaultValue="cbl" Name="Listtype" Type="String"></asp:Parameter>
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </div>
                                    </div>
                                    <div class="clear5"></div>
                                    <%-- Dropdown List Audio and video --%>
                                    <div class="clear5"></div>
                                    <div class="form-group">
                                        <asp:Label ID="lblAudioVideoFeatures" runat="server" AssociatedControlID="ddlAudioVideoFeatures" CssClass="col-md-3 control-label">Communication/Media features:</asp:Label>
                                        <div class="col-md-9">
                                            <asp:DropDownList ID="ddlAudioVideoFeatures" runat="server" CssClass="form-control" ValidationGroup="vgVehicle" DataSourceID="odsAudioVideoFeatures" DataTextField="Feature" DataValueField="Id" Width="300px">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource runat="server" ID="odsAudioVideoFeatures" SelectMethod="GetAllFeatureLookup" TypeName="eMonthleys.BLL.FeatureLookup">
                                                <SelectParameters>
                                                    <asp:Parameter DefaultValue="Audio and video features" Name="FeatureType" Type="String"></asp:Parameter>
                                                    <asp:Parameter DefaultValue="ddl" Name="Listtype" Type="String"></asp:Parameter>
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                            <%-- Checkbox List Audio and video --%>
                                            <asp:CheckBoxList ID="cblAudioVideoFeatures" runat="server" DataSourceID="odsAudioVideoFeaturesCbl" DataTextField="Feature" DataValueField="Id" RepeatColumns="4"
                                                Width="100%" RepeatDirection="Horizontal">
                                            </asp:CheckBoxList>
                                            <asp:ObjectDataSource runat="server" ID="odsAudioVideoFeaturesCbl" SelectMethod="GetAllFeatureLookup" TypeName="eMonthleys.BLL.FeatureLookup">
                                                <SelectParameters>
                                                    <asp:Parameter DefaultValue="Audio and video features" Name="FeatureType" Type="String"></asp:Parameter>
                                                    <asp:Parameter DefaultValue="cbl" Name="Listtype" Type="String"></asp:Parameter>
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                            <div class="clear5"></div>
                                        </div>
                                    </div>
                                    <div class="clear5"></div>
                                    <%-- Dropdown List Safety and security --%>
                                    <div class="form-group">
                                        <asp:Label ID="lblSafetySecurityFeatures" runat="server" AssociatedControlID="ddlSafetySecurityFeatures" CssClass="col-md-3 control-label">Safety and security features:</asp:Label>
                                        <div class="col-md-9">
                                            <asp:DropDownList ID="ddlSafetySecurityFeatures" runat="server" CssClass="form-control" ValidationGroup="vgVehicle" DataSourceID="odsSafetySecurityFeatures" DataTextField="Feature" DataValueField="Id" Width="200px">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource runat="server" ID="odsSafetySecurityFeatures" SelectMethod="GetAllFeatureLookup" TypeName="eMonthleys.BLL.FeatureLookup">
                                                <SelectParameters>
                                                    <asp:Parameter DefaultValue="Safety and security features" Name="FeatureType" Type="String"></asp:Parameter>
                                                    <asp:Parameter DefaultValue="ddl" Name="Listtype" Type="String"></asp:Parameter>
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                            <%-- Checkbox List Safety and security --%>
                                            <asp:CheckBoxList ID="cblSafetySecurityFeatures" runat="server" DataSourceID="odsSafetySecurityFeaturesCbl" DataTextField="Feature" DataValueField="Id" RepeatColumns="4"
                                                Width="100%" RepeatDirection="Horizontal">
                                            </asp:CheckBoxList>
                                            <asp:ObjectDataSource runat="server" ID="odsSafetySecurityFeaturesCbl" SelectMethod="GetAllFeatureLookup" TypeName="eMonthleys.BLL.FeatureLookup">
                                                <SelectParameters>
                                                    <asp:Parameter DefaultValue="Safety and security features" Name="FeatureType" Type="String"></asp:Parameter>
                                                    <asp:Parameter DefaultValue="cbl" Name="Listtype" Type="String"></asp:Parameter>
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </div>
                                    </div>
                                    <div class="clear5"></div>
                                    <%-- Checkbox List Convenience --%>
                                    <div class="clear5"></div>
                                    <div class="form-group">
                                        <asp:Label ID="lblConvenienceFeatures" runat="server" AssociatedControlID="cblConvenienceFeatures" CssClass="col-md-3 control-label">Extras:</asp:Label>
                                        <div class="col-md-9">
                                            <asp:CheckBoxList ID="cblConvenienceFeatures" runat="server" DataSourceID="odsConvenienceFeatures" DataTextField="Feature" DataValueField="Id" RepeatColumns="4"
                                                Width="100%" RepeatDirection="Horizontal">
                                            </asp:CheckBoxList>
                                            <asp:ObjectDataSource runat="server" ID="odsConvenienceFeatures" SelectMethod="GetAllFeatureLookup" TypeName="eMonthleys.BLL.FeatureLookup">
                                                <SelectParameters>
                                                    <asp:Parameter DefaultValue="Convenience features" Name="FeatureType" Type="String"></asp:Parameter>
                                                    <asp:Parameter DefaultValue="cbl" Name="Listtype" Type="String"></asp:Parameter>
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                            <div class="clear5"></div>
                                        </div>
                                    </div>
                                    <%-- Dropdown List Warranties and insurance --%>
                                    <div class="clear5"></div>
                                    <div class="form-group">
                                        <asp:Label ID="lblWarrantiesInsurance" runat="server" AssociatedControlID="ddlWarrantiesInsurance" CssClass="col-md-3 control-label">Warranty:</asp:Label>
                                        <div class="col-md-9">
                                            <asp:DropDownList ID="ddlWarrantiesInsurance" runat="server" CssClass="form-control" ValidationGroup="vgVehicle" DataSourceID="odsWarrantiesInsurance" DataTextField="Feature" DataValueField="Id" Width="300px">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource runat="server" ID="odsWarrantiesInsurance" SelectMethod="GetAllFeatureLookup" TypeName="eMonthleys.BLL.FeatureLookup">
                                                <SelectParameters>
                                                    <asp:Parameter DefaultValue="Warranties and insurance" Name="FeatureType" Type="String"></asp:Parameter>
                                                    <asp:Parameter DefaultValue="ddl" Name="Listtype" Type="String"></asp:Parameter>
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                            <div class="clear5"></div>
                                            <%-- Checkbox List Warranties and insurance --%>
                                            <asp:CheckBoxList ID="cblWarrantiesInsurance" runat="server" DataSourceID="odsWarrantiesInsuranceCbl" DataTextField="Feature" DataValueField="Id" RepeatColumns="4"
                                                Width="100%" RepeatDirection="Horizontal">
                                            </asp:CheckBoxList>
                                            <asp:ObjectDataSource runat="server" ID="odsWarrantiesInsuranceCbl" SelectMethod="GetAllFeatureLookup" TypeName="eMonthleys.BLL.FeatureLookup">
                                                <SelectParameters>
                                                    <asp:Parameter DefaultValue="Warranties and insurance" Name="FeatureType" Type="String"></asp:Parameter>
                                                    <asp:Parameter DefaultValue="cbl" Name="Listtype" Type="String"></asp:Parameter>
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </div>
                                    </div>
                                    <div class="clear5"></div>
                                    <%-- Checkbox List Pickups - SUV - Vans --%>
                                    <div class="clear5"></div>
                                    <div class="form-group">
                                        <asp:Label ID="lblPickupsSUVVans" runat="server" AssociatedControlID="cblPickupsSUVVans" CssClass="col-md-3 control-label">Pickups - SUV's - Vans:</asp:Label>
                                        <div class="col-md-9">
                                            <asp:CheckBoxList ID="cblPickupsSUVVans" runat="server" DataSourceID="odsPickupsSUVVans" DataTextField="Feature" DataValueField="Id" RepeatColumns="4"
                                                Width="100%" RepeatDirection="Horizontal">
                                            </asp:CheckBoxList>
                                            <asp:ObjectDataSource runat="server" ID="odsPickupsSUVVans" SelectMethod="GetAllFeatureLookup" TypeName="eMonthleys.BLL.FeatureLookup">
                                                <SelectParameters>
                                                    <asp:Parameter DefaultValue="Pickups - SUV - Vans" Name="FeatureType" Type="String"></asp:Parameter>
                                                    <asp:Parameter DefaultValue="cbl" Name="Listtype" Type="String"></asp:Parameter>
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                            <hr />
                                        </div>
                                    </div>
                                    <%-- Checkbox List Aftermarket accessories --%>
                                    <div class="clear5"></div>
                                    <div class="form-group">
                                        <asp:Label ID="lblAftermarketAccessories" runat="server" AssociatedControlID="cblAftermarketAccessories" CssClass="col-md-3 control-label">Aftermarket accessories:</asp:Label>
                                        <div class="col-md-9">
                                            <asp:CheckBoxList ID="cblAftermarketAccessories" runat="server" DataSourceID="odsAftermarketAccessories" DataTextField="Feature" DataValueField="Id" RepeatColumns="4"
                                                Width="100%" RepeatDirection="Horizontal">
                                            </asp:CheckBoxList>
                                            <asp:ObjectDataSource runat="server" ID="odsAftermarketAccessories" SelectMethod="GetAllFeatureLookup" TypeName="eMonthleys.BLL.FeatureLookup">
                                                <SelectParameters>
                                                    <asp:Parameter DefaultValue="Aftermarket accessories" Name="FeatureType" Type="String"></asp:Parameter>
                                                    <asp:Parameter DefaultValue="cbl" Name="Listtype" Type="String"></asp:Parameter>
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </div>
                                    </div>
                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="clear5"></div>
                        <div class="form-group">
                            <asp:Label ID="Label2" runat="server" AssociatedControlID="txtComments" CssClass="col-md-3 control-label">Additional Comments:</asp:Label>
                            <div class="col-md-9">
                                <asp:TextBox ID="txtComments" runat="server" ValidationGroup="vgVehicle" Rows="5" TextMode="MultiLine" Width="95%"
                                    Text="Model may not be as shown." />
                            </div>
                        </div>
                    </fieldset>
                    <div class="centered paddingtop10">
                        <asp:Button ID="BtnSaveVehicle" runat="server" CausesValidation="true" ValidationGroup="vgVehicle" Text="Next" OnClick="BtnSaveVehicle_Click" CssClass="btn btn-primary" />
                        &nbsp;<asp:Button ID="BtnCancel1" runat="server" CausesValidation="false" Text="Cancel" CssClass="btn btn-primary" OnClick="BtnCancel1_Click" />
                    </div>
                </div>

                <%-- Lease or finance information --%>

                <div id="tabs-2">
                    <fieldset>
                        <div class="clear5"></div>
                        <div>
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="text-danger" ValidationGroup="vgLease" ShowMessageBox="True" />
                        </div>
                        <asp:UpdatePanel ID="upnlFinancial" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="form-group">
                                    <asp:Label ID="lblLeaseOrFinance" runat="server" AssociatedControlID="rblLeaseOrFinance" CssClass="col-md-3 control-label">Purchase option:</asp:Label>
                                    <div class="col-md-5">
                                        <asp:RadioButtonList ID="rblLeaseOrFinance" runat="server" CellSpacing="10" RepeatDirection="Horizontal" ClientIDMode="AutoID" CssClass="lfcrbl"
                                            RepeatColumns="3" Width="350px" ValidationGroup="vgLease" AutoPostBack="true" OnSelectedIndexChanged="RblLeaseOrFinance_SelectedIndexChanged">
                                            <asp:ListItem Value="l">Lease</asp:ListItem>
                                            <asp:ListItem Value="f">Finance</asp:ListItem>
                                            <asp:ListItem Value="c">Cash deal</asp:ListItem>
                                        </asp:RadioButtonList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Please select if this a lease or finance vehicle or cash purchase."
                                            ControlToValidate="rblLeaseOrFinance" Text="*" InitialValue="" ValidationGroup="vgLease" CssClass="text-danger"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-3, bold">
                                        <asp:Literal ID="lfcNote" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                <div class="clear"></div>
                                <div class="form-group">
                                    <asp:Label ID="Label17" runat="server" AssociatedControlID="txtPurchasePrice" CssClass="col-md-3 control-label">Purchase price:</asp:Label>
                                    <div class="col-md-3">
                                        <asp:TextBox runat="server" ID="txtPurchasePrice" CssClass="dollarvalue form-control" ValidationGroup="vgLease" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter the purchase price."
                                            ControlToValidate="txtPurchasePrice" Text="*" ValidationGroup="vgLease" CssClass="text-danger"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="Purchase price must be numeric."
                                            Text="*" CssClass="text-danger" ValidationGroup="vgLease" ControlToValidate="txtPurchasePrice" ValidationExpression="\d+(\.\d{1,2})?"></asp:RegularExpressionValidator>
                                    </div>
                                    <asp:Label ID="Label27" runat="server" CssClass="col-md-6" Text="(incl. Tax/Frt/PDI/Env. Fee/Admin/OMVIC for businesses)"></asp:Label>
                                </div>
                                <div class="clear"></div>
                                <asp:Panel ID="pnlFinancialInfo" runat="server">
                                    <%--                                    <div class="form-group">
                                        <asp:Label ID="Label3" runat="server" AssociatedControlID="txtLienholder" CssClass="col-md-3 control-label">Financial institution:</asp:Label>
                                        <div class="col-md-9">
                                            <asp:TextBox runat="server" ID="txtLienholder" CssClass="form-control" ValidationGroup="vgLease" />
                                        </div>
                                    </div>--%>
                                    <div class="clear20"></div>
                                    <div class="form-group">
                                        <asp:Label ID="Label4" runat="server" AssociatedControlID="ddlPayCycle" CssClass="col-md-3 control-label">Payment cycle:</asp:Label>
                                        <div class="col-md-9">
                                            <asp:DropDownList runat="server" ID="ddlPayCycle" CssClass="form-control" Width="150px" AutoPostBack="true"
                                                ValidationGroup="vgLease" OnSelectedIndexChanged="DdlPayCycle_SelectedIndexChanged">
                                                <asp:ListItem Value="">Please select</asp:ListItem>
                                                <asp:ListItem>Weekly</asp:ListItem>
                                                <asp:ListItem>Bi-weekly</asp:ListItem>
                                                <asp:ListItem>Semi-monthly</asp:ListItem>
                                                <asp:ListItem>Monthly</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvPayCycle" runat="server" ErrorMessage="Payment cycle is required."
                                                ControlToValidate="ddlPayCycle" Text="*" ValidationGroup="vgLease" InitialValue="" CssClass="text-danger"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="clear"></div>
                                    <div class="form-group">
                                        <asp:Label ID="Label5" runat="server" AssociatedControlID="txtMonthlyWithTax" CssClass="col-md-3 control-label">Payment:</asp:Label>
                                        <div class="col-md-3">
                                            <asp:TextBox runat="server" ID="txtMonthlyWithTax" CssClass="dollarvalue form-control" ValidationGroup="vgLease" />
                                            <asp:RequiredFieldValidator ID="rfvMonthly" runat="server" ErrorMessage="Please enter payment with tax."
                                                ControlToValidate="txtMonthlyWithTax" Text="*" ValidationGroup="vgLease" CssClass="text-danger"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Please enter a numeric value for payment."
                                                Text="*" CssClass="text-danger" ValidationGroup="vgLease" ControlToValidate="txtMonthlyWithTax" ValidationExpression="\d+(\.\d{1,2})?"></asp:RegularExpressionValidator>
                                        </div>
                                        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                            <ContentTemplate>
                                                <asp:Panel ID="pnlBiWeekly" runat="server" Visible="false">
                                                    <div class="col-md-3">
                                                        <asp:TextBox runat="server" ID="txtBiWeeklyWithTax" CssClass="dollarvalue form-control" ValidationGroup="vgLease" placeholder="Bi-Weekly Payment" />
                                                        <asp:RequiredFieldValidator ID="rfvBiWeekly" runat="server" ErrorMessage="Please enter Bi-Weekly payment with tax."
                                                            ControlToValidate="txtBiWeeklyWithTax" Text="*" ValidationGroup="vgLease" CssClass="text-danger"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="revBiWeekly" runat="server" ErrorMessage="Please enter a numeric value for payment."
                                                            Text="*" CssClass="text-danger" ValidationGroup="vgLease" ControlToValidate="txtMonthlyWithTax" ValidationExpression="\d+(\.\d{1,2})?"></asp:RegularExpressionValidator>
                                                    </div>
                                                </asp:Panel>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlPayCycle" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                        <asp:Label ID="Label25" runat="server" CssClass="col-md-2" Text="(incl. Tax)"></asp:Label>
                                    </div>
                                    <div class="clear"></div>
                                    <div class="form-group">
                                        <asp:Label ID="Label6" runat="server" AssociatedControlID="txtOriginalDown" CssClass="col-md-3 control-label">Total due on delivery:</asp:Label>
                                        <div class="col-md-3">
                                            <asp:TextBox runat="server" ID="txtOriginalDown" CssClass="dollarvalue form-control" ValidationGroup="vgLease" />
                                        </div>
                                        <asp:Label ID="Label23" runat="server" CssClass="col-md-4" Text="(incl. Tax/Frt/PDI/Env. Fee/Admin/OMVIC)"></asp:Label>
                                    </div>
                                    <div class="clear20"></div>
                                    <div class="form-group">
                                        <asp:Label ID="Label7" runat="server" AssociatedControlID="txtSecurityDeposit" CssClass="col-md-3 control-label">Security deposit:</asp:Label>
                                        <div class="col-md-3">
                                            <asp:TextBox runat="server" ID="txtSecurityDeposit" CssClass="dollarvalue form-control" ValidationGroup="vgLease" />
                                        </div>
                                        <asp:Label ID="Label26" runat="server" CssClass="col-md-3" Text="(Lease only, incl. Tax)"></asp:Label>
                                    </div>
                                    <div class="clear20"></div>
                                    <div class="form-group">
                                        <asp:Label ID="Label8" runat="server" AssociatedControlID="ddlPurchaseOpEndOfLease" CssClass="col-md-3 control-label">Purchase option at end of lease:</asp:Label>
                                        <div class="col-md-4">
                                            <asp:DropDownList ID="ddlPurchaseOpEndOfLease" runat="server" ValidationGroup="vgLease" CssClass="form-control">
                                                <asp:ListItem Value="">Please select</asp:ListItem>
                                                <asp:ListItem>End purchase price guaranteed by customer</asp:ListItem>
                                                <asp:ListItem>End purchase price guaranteed by lien holder</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <asp:Label ID="Label21" runat="server" CssClass="col-md-2" Text="(lease only)"></asp:Label>
                                    </div>
                                    <div class="clear20"></div>
                                    <div class="form-group">
                                        <asp:Label ID="Label9" runat="server" AssociatedControlID="txtKmAllowance" CssClass="col-md-3 control-label">Km Allowance:</asp:Label>
                                        <div class="col-md-3">
                                            <asp:TextBox runat="server" ID="txtKmAllowance" CssClass="dollarvalue form-control" ValidationGroup="vgLease" />
                                            <asp:RangeValidator ID="RangeValidator4" runat="server" ErrorMessage="Km allowance must be numeric." Text="*"
                                                CssClass="text-danger" ControlToValidate="txtKmAllowance" MaximumValue="99999999" MinimumValue="0"></asp:RangeValidator>
                                        </div>
                                        <asp:Label ID="Label24" runat="server" CssClass="col-md-2" Text="(lease only)"></asp:Label>
                                    </div>
                                    <div class="clear"></div>
                                    <div class="form-group">
                                        <asp:Label ID="Label10" runat="server" AssociatedControlID="txtExcessKmCharge" CssClass="col-md-3 control-label">Excess Km charge in cents:</asp:Label>
                                        <div class="col-md-3">
                                            <asp:TextBox runat="server" ID="txtExcessKmCharge" CssClass="dollarvalue form-control" ValidationGroup="vgLease" />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Excess Km charge must be numeric."
                                                Text="*" CssClass="text-danger" ValidationGroup="vgLease" ControlToValidate="txtExcessKmCharge" ValidationExpression="\d+(\.\d{1,2})?"></asp:RegularExpressionValidator>
                                        </div>
                                        <asp:Label ID="Label20" runat="server" CssClass="col-md-3" Text="(lease only, incl. tax)"></asp:Label>
                                    </div>
                                    <div class="clear"></div>
                                    <div class="form-group">
                                        <asp:Label ID="Label11" runat="server" AssociatedControlID="txtOriginalLeaseTerm" CssClass="col-md-3 control-label">Term of loan (months):</asp:Label>
                                        <div class="col-md-9">
                                            <asp:TextBox runat="server" ID="txtOriginalLeaseTerm" CssClass="dollarvalue form-control" ValidationGroup="vgLease" MaxLength="2" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="Original lease/finance term is required."
                                                ControlToValidate="txtOriginalLeaseTerm" Text="*" CssClass="text-danger"></asp:RequiredFieldValidator>
                                            <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txtOriginalLeaseTerm" Type="Integer" MinimumValue="1"
                                                MaximumValue="96" ErrorMessage="Lease term must be between 1 and 96" CssClass="text-danger"></asp:RangeValidator>
                                        </div>
                                    </div>
                                    <div class="clear"></div>
                                    <div class="form-group">
                                        <asp:Label ID="Label12" runat="server" AssociatedControlID="txtLeaseExpiry" CssClass="col-md-3 control-label">Lease expires on:</asp:Label>
                                        <div class="col-md-3">
                                            <div class='input-group date' id='LeaseExpiry' data-date-format="MM/DD/YYYY">
                                                <asp:TextBox runat="server" ID="txtLeaseExpiry" CssClass="form-control" ValidationGroup="vgLease" />
                                                <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                                                <asp:RequiredFieldValidator ID="rfvLeaseExp" runat="server" ErrorMessage="Lease expiry date is required." ValidationGroup="vgLease"
                                                    ControlToValidate="txtLeaseExpiry" Text="*" CssClass="text-danger"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <asp:Label ID="Label19" runat="server" CssClass="col-md-2" Text="(lease only)"></asp:Label>
                                    </div>
                                    <div class="clear20"></div>
                                    <div class="form-group">
                                        <asp:Label ID="Label15" runat="server" AssociatedControlID="txtBuyBack" CssClass="col-md-3 control-label">Buyback/Residual value:</asp:Label>
                                        <div class="col-md-3">
                                            <asp:TextBox runat="server" ID="txtBuyBack" CssClass="dollarvalue form-control" ValidationGroup="vgLease" />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Buyback cost must be numeric."
                                                Text="*" CssClass="text-danger" ValidationGroup="vgLease" ControlToValidate="txtBuyBack" ValidationExpression="\d+(\.\d{1,2})?"></asp:RegularExpressionValidator>
                                        </div>
                                        <asp:Label ID="lblLeaseBR" runat="server" CssClass="col-md-3" Text="(lease only, incl. tax)"></asp:Label>
                                    </div>
                                    <div class="clear"></div>
                                    <div class="form-group">
                                        <asp:Label ID="Label16" runat="server" AssociatedControlID="txtBalloon" CssClass="col-md-3 control-label">Balloon payment:</asp:Label>
                                        <div class="col-md-3">
                                            <asp:TextBox runat="server" ID="txtBalloon" CssClass="dollarvalue form-control" ValidationGroup="vgLease" />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="Balloon payment must be numeric."
                                                Text="*" CssClass="text-danger" ValidationGroup="vgLease" ControlToValidate="txtBalloon" ValidationExpression="\d+(\.\d{1,2})?"></asp:RegularExpressionValidator>
                                        </div>
                                        <asp:Label ID="Label22" runat="server" CssClass="col-md-3" Text="(finance only, incl. tax)"></asp:Label>
                                    </div>
                                    <div class="clear"></div>
                                </asp:Panel>
                                <div class="form-group">
                                    <asp:Label ID="Label13" runat="server" AssociatedControlID="txtSummary" CssClass="col-md-3 control-label">Lease/Finance information:</asp:Label>
                                    <div class="col-md-9">
                                        <asp:TextBox runat="server" ID="txtSummary" CssClass="form-control" TextMode="MultiLine" Rows="5" Width="100%"
                                            Text="On approved credit only.Prices and payments are estimates Only.Dealer may charge additional fees. Licence plates are extra." />
                                    </div>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="rblLeaseOrFinance" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                        <script type="text/javascript">
                            function pageLoad(sender, args) {
                                $('#LeaseExpiry').datetimepicker({
                                    pickTime: false
                                });
                            }
                        </script>
                        <div class="clear20"></div>
                        <%--                        <div class="form-group">
                            <asp:Label ID="Label14" runat="server" AssociatedControlID="txtComments" CssClass="col-md-3 control-label">Other Comments/Details:</asp:Label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="TextBox1" CssClass="form-control" TextMode="MultiLine" Rows="5" Width="100%"
                                    Text="On approved credit only. Dealer may charge additional fees. Licence plates are extra." />
                            </div>
                        </div>--%>
                    </fieldset>
                    <div class="centered paddingtop10">
                        <asp:Button ID="BtnSubmitLease" runat="server" CausesValidation="true" ValidationGroup="vgLease" Text="Next" OnClick="BtnSubmitLease_Click" CssClass="btn btn-primary" />
                        &nbsp;<asp:Button ID="BtnCancel2" runat="server" CausesValidation="false" Text="Cancel" CssClass="btn btn-primary" OnClick="BtnCancel1_Click" />
                    </div>
                </div>

                <%-- Images tab --%>

                <div id="tabs-3">
                    <div class="clear5"></div>
                    <p>
                        You can upload upto eight pictures for this vehicle and one video file.<br />
                        If you have a link to a YouTube video for the vehicle, you may enter the YouTube link instead of uploading a video.
                    </p>
                    <p>
                        <strong>Please note:</strong> image files must not exceed the file size of 200Kb.<br />
                        All images must be for web (72 dpi).<br />
                        The dimensions for the video file in <strong>avi</strong> format uploaded to this site are 320 x 200 pixels. The video file must not exceed 1 minute in length.
                    </p>
                    <p>Allowed file formats for images and video files are as follows:</p>
                    <ul>
                        <li>Images: GIF, JPEG, JPG, PNG - maximum file size: 200 KB per image</li>
                        <li>Video: AVI, MOV, MP4, MPG, WMV - maximum file size: 8 MB</li>
                    </ul>
                    <asp:Panel ID="pnlErr" runat="server" Visible="false" CssClass="bg-warning">
                        <asp:Label ID="lblErr" runat="server" CssClass="text-danger label-danger"></asp:Label>
                    </asp:Panel>
                    <fieldset>
                        <legend>Files</legend>
                        <asp:Panel ID="pnlImages" runat="server" Width="100%">
                            <div class="clear5"></div>
                            <div class="form-group">
                                <asp:Label ID="lblImage1" runat="server" AssociatedControlID="FileUpload1" CssClass="col-md-3 control-label">Image 1:</asp:Label>
                                <div class="col-md-9">
                                    <asp:FileUpload ID="FileUpload1" runat="server" Width="95%" />
                                </div>
                            </div>
                            <div class="clear5"></div>
                            <div class="form-group">
                                <asp:Label ID="lblImage2" runat="server" AssociatedControlID="FileUpload2" CssClass="col-md-3 control-label">Image 2:</asp:Label>
                                <div class="col-md-9">
                                    <asp:FileUpload ID="FileUpload2" runat="server" Width="95%" />
                                </div>
                            </div>
                            <div class="clear5"></div>
                            <div class="form-group">
                                <asp:Label ID="lblImage3" runat="server" AssociatedControlID="FileUpload3" CssClass="col-md-3 control-label">Image 3:</asp:Label>
                                <div class="col-md-9">
                                    <asp:FileUpload ID="FileUpload3" runat="server" Width="95%" />
                                </div>
                            </div>
                            <div class="clear5"></div>
                            <div class="form-group">
                                <asp:Label ID="lblImage4" runat="server" AssociatedControlID="FileUpload4" CssClass="col-md-3 control-label">Image 4:</asp:Label>
                                <div class="col-md-9">
                                    <asp:FileUpload ID="FileUpload4" runat="server" Width="95%" />
                                </div>
                            </div>
                            <div class="clear5"></div>
                            <div class="form-group">
                                <asp:Label ID="lblImage5" runat="server" AssociatedControlID="FileUpload5" CssClass="col-md-3 control-label">Image 5:</asp:Label>
                                <div class="col-md-9">
                                    <asp:FileUpload ID="FileUpload5" runat="server" Width="95%" />
                                </div>
                            </div>
                            <div class="clear5"></div>
                            <div class="form-group">
                                <asp:Label ID="lblImage6" runat="server" AssociatedControlID="FileUpload6" CssClass="col-md-3 control-label">Image 6:</asp:Label>
                                <div class="col-md-9">
                                    <asp:FileUpload ID="FileUpload6" runat="server" Width="95%" />
                                </div>
                            </div>
                            <div class="clear5"></div>
                            <div class="form-group">
                                <asp:Label ID="lblImage7" runat="server" AssociatedControlID="FileUpload7" CssClass="col-md-3 control-label">Image 7:</asp:Label>
                                <div class="col-md-9">
                                    <asp:FileUpload ID="FileUpload7" runat="server" Width="95%" />
                                </div>
                            </div>
                            <div class="clear5"></div>
                            <div class="form-group">
                                <asp:Label ID="lblImage8" runat="server" AssociatedControlID="FileUpload8" CssClass="col-md-3 control-label">Image 8:</asp:Label>
                                <div class="col-md-9">
                                    <asp:FileUpload ID="FileUpload8" runat="server" Width="95%" />
                                </div>
                            </div>


                            <div class="clear5"></div>
                            <div class="form-group">
                                <asp:Label ID="lblImage9" runat="server" AssociatedControlID="FileUpload10" CssClass="col-md-3 control-label">Image 9:</asp:Label>
                                <div class="col-md-9">
                                    <asp:FileUpload ID="FileUpload10" runat="server" Width="95%" />
                                </div>
                            </div>

                            <div class="clear5"></div>
                            <div class="form-group">
                                <asp:Label ID="Label3" runat="server" AssociatedControlID="FileUpload11" CssClass="col-md-3 control-label">Image 10:</asp:Label>
                                <div class="col-md-9">
                                    <asp:FileUpload ID="FileUpload11" runat="server" Width="95%" />
                                </div>
                            </div>
                            <div class="clear5"></div>
                            <div class="form-group">
                                <asp:Label ID="Label14" runat="server" AssociatedControlID="FileUpload12" CssClass="col-md-3 control-label">Image 11:</asp:Label>
                                <div class="col-md-9">
                                    <asp:FileUpload ID="FileUpload12" runat="server" Width="95%" />
                                </div>
                            </div>
                            <div class="clear5"></div>
                            <div class="form-group">
                                <asp:Label ID="Label29" runat="server" AssociatedControlID="FileUpload13" CssClass="col-md-3 control-label">Image 12:</asp:Label>
                                <div class="col-md-9">
                                    <asp:FileUpload ID="FileUpload13" runat="server" Width="95%" />
                                </div>
                            </div><div class="clear5"></div>
                            <div class="form-group">
                                <asp:Label ID="Label30" runat="server" AssociatedControlID="FileUpload14" CssClass="col-md-3 control-label">Image 13:</asp:Label>
                                <div class="col-md-9">
                                    <asp:FileUpload ID="FileUpload14" runat="server" Width="95%" />
                                </div>
                            </div><div class="clear5"></div>
                            <div class="form-group">
                                <asp:Label ID="Label31" runat="server" AssociatedControlID="FileUpload15" CssClass="col-md-3 control-label">Image 14:</asp:Label>
                                <div class="col-md-9">
                                    <asp:FileUpload ID="FileUpload15" runat="server" Width="95%" />
                                </div>
                            </div><div class="clear5"></div>
                            <div class="form-group">
                                <asp:Label ID="Label32" runat="server" AssociatedControlID="FileUpload16" CssClass="col-md-3 control-label">Image 15:</asp:Label>
                                <div class="col-md-9">
                                    <asp:FileUpload ID="FileUpload16" runat="server" Width="95%" />
                                </div>
                            </div><div class="clear5"></div>
                            <div class="form-group">
                                <asp:Label ID="Label33" runat="server" AssociatedControlID="FileUpload17" CssClass="col-md-3 control-label">Image 16:</asp:Label>
                                <div class="col-md-9">
                                    <asp:FileUpload ID="FileUpload17" runat="server" Width="95%" />
                                </div>
                            </div><div class="clear5"></div>
                            <div class="form-group">
                                <asp:Label ID="Label34" runat="server" AssociatedControlID="FileUpload18" CssClass="col-md-3 control-label">Image 17:</asp:Label>
                                <div class="col-md-9">
                                    <asp:FileUpload ID="FileUpload18" runat="server" Width="95%" />
                                </div>
                            </div><div class="clear5"></div>
                            <div class="form-group">
                                <asp:Label ID="Label35" runat="server" AssociatedControlID="FileUpload19" CssClass="col-md-3 control-label">Image 18:</asp:Label>
                                <div class="col-md-9">
                                    <asp:FileUpload ID="FileUpload19" runat="server" Width="95%" />
                                </div>
                            </div><div class="clear5"></div>
                            <div class="form-group">
                                <asp:Label ID="Label36" runat="server" AssociatedControlID="FileUpload20" CssClass="col-md-3 control-label">Image 19:</asp:Label>
                                <div class="col-md-9">
                                    <asp:FileUpload ID="FileUpload20" runat="server" Width="95%" />
                                </div>
                            </div><div class="clear5"></div>
                            <div class="form-group">
                                <asp:Label ID="Label37" runat="server" AssociatedControlID="FileUpload21" CssClass="col-md-3 control-label">Image 20:</asp:Label>
                                <div class="col-md-9">
                                    <asp:FileUpload ID="FileUpload21" runat="server" Width="95%" />
                                </div>
                            </div>



                            <div class="clear5"></div>
                            <div class="form-group">
                                <asp:Label ID="lblVideo" runat="server" CssClass="col-md-3 control-label">Video file:</asp:Label>
                                <div class="col-md-9">
                                    <asp:DropDownList ID="ddlVideoSource" runat="server" AutoPostBack="true" CssClass="form-control" Width="150px"
                                        ValidationGroup="vgImages" OnSelectedIndexChanged="DdlVideoSource_SelectedIndexChanged">
                                        <asp:ListItem Selected="True">No video</asp:ListItem>
                                        <asp:ListItem>File upload</asp:ListItem>
                                    </asp:DropDownList>&nbsp;Do not change if no video available.
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:Panel ID="pnlUpload" runat="server" Visible="false" Enabled="false" Width="100%">
                                        <asp:FileUpload ID="FileUpload9" runat="server" Width="95%" />
                                    </asp:Panel>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlVideoSource" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                                </div>
                            </div>
                            <div class="clear5"></div>
                        </asp:Panel>
                    </fieldset>
                    <div class="centered paddingtop10">
                        <asp:Button ID="BtnSaveImages" runat="server" CausesValidation="true" ValidationGroup="vgImages" Text="Submit" OnClientClick="preventMultipleSubmissions();" OnClick="BtnSaveImages_Click" CssClass="btn btn-primary" />
                        &nbsp;<asp:Button ID="BtnCancel3" runat="server" CausesValidation="false" Text="Cancel" CssClass="btn btn-primary" OnClick="BtnCancel1_Click" />
                    </div>
                </div>
            </div>
            <div class="clear25"></div>
        </asp:Panel>
        <asp:Panel ID="pnlCheckout" runat="server" Visible="false">
            <h2>Check out</h2>
            <fieldset>
                <legend>Select your plan</legend>
                <div class="form-group">
                    <div class="radio">
                        <% 
                            eMonthleys.BLL.Customer c = new eMonthleys.BLL.Customer();
                            if (Request.QueryString.Keys.Count > 0)
                                c = (eMonthleys.BLL.Customer)Session["SelectedCustomer"];
                            else
                                c = (eMonthleys.BLL.Customer)Session["User"];

                            if (c.CustomerType == "Business")
                            { %>
                        <asp:RadioButtonList ID="rblPricing" runat="server" ValidationGroup="vgCheckOut">
                            <asp:ListItem Value="1">1 Vehicle - $19.99</asp:ListItem>
                            <asp:ListItem Value="8">8 Vehicles - $89.99</asp:ListItem>
                            <asp:ListItem Value="20">20 Vehicles - $199.99</asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator ID="rfvBusiness" runat="server" ErrorMessage="Please select a plan."
                            ControlToValidate="rblPricing" ValidationGroup="vgCheckOut" CssClass="text-danger">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="clear15"></div>
                    <%}
                    %>
                    <%--                    <asp:Panel ID="pnlPromo" runat="server" Visible="false">
                        <p>Use promo code <strong>emonthliesFree514</strong> to get your first 3 months for free.</p>
                        <div class="col-md-4">
                            <div class="input-group">
                                <span class="input-group-addon">Promo code</span>
                                <asp:TextBox ID="txtPromoCode" runat="server" CssClass="form-control" ValidationGroup="vgCheckOut" Text="emonthliesFree514"></asp:TextBox>
                            </div>
                        </div>
                    </asp:Panel>--%>
                </div>
                <div class="clear25"></div>
                <div class="centered">
                    <p class="bold">I consent to receive marketing communications (electronic and otherwise) from <em>emonthlies</em> to offer me their products and services.</p>
                    <asp:Button ID="BtnCheckout" runat="server" CausesValidation="true" ValidationGroup="vgCheckout" Text="Check out" CssClass="btn btn-primary" OnClick="BtnCheckout_Click" />&nbsp;
                    <asp:Button ID="BtnCancelCheckout" runat="server" CausesValidation="false" CssClass=" btn btn-primary" Text="Cancel" OnClick="BtnCancelCheckout_Click" />
                </div>
            </fieldset>
        </asp:Panel>
        <div class="clear15"></div>
    </div>

</asp:Content>
