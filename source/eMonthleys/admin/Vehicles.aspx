<%@ Page Title="Customer Vehicles" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Vehicles.aspx.cs" Inherits="eMonthleys.Vehicles" %>

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid mainpanel">
        <h1><%:Title %></h1>
        <div class="form-group">
            <asp:Label ID="lblStatus" runat="server" AssociatedControlID="ddlStatus" CssClass="col-md-2 control-label">Vehicle Status:</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="true">
                    <asp:ListItem Value="approvedNew">New vehicle ads, approved</asp:ListItem>
                    <asp:ListItem Value="approvedUsed">Used vehicle ads, approved</asp:ListItem>
                    <asp:ListItem Value="pendingNew">New vehicle ads, pending approval</asp:ListItem>
                    <asp:ListItem Value="pendingUsed">Used vehicle ads, pending approval</asp:ListItem>
                    <asp:ListItem Value="declined">Declined ads</asp:ListItem>
                    <asp:ListItem Value="expired">Expired ads</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="clear"></div>
        <div class="bg-info">
            <div class="col-md-5">
                <asp:Label ID="lblCount" runat="server"></asp:Label>
            </div>
            <div class="col-md-5 right text-right">
                <img src="/images/View_Detail.png" alt="" />&nbsp;Review,&nbsp;
                <img src="/images/recycle.png" alt="" />&nbsp;Repost,&nbsp;
                <img src="/images/trash.png" alt="" />&nbsp;Suspend
            </div>
        </div>
        <div>
            <asp:GridView ID="GvVehicles" runat="server" Width="100%" CssClass="table table-striped footable" AutoGenerateColumns="False"
                DataSourceID="OdsCustomersInfo" GridLines="None" OnRowCommand="GvVehicles_RowCommand" OnDataBound="GvVehicles_DataBound" 
                AllowPaging="True" PageSize="50" PagerStyle-HorizontalAlign="Left" PagerStyle-CssClass="GridPager">
                <Columns>
                    <asp:TemplateField HeaderText="Make/Model" SortExpression="Make">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# GetVehicleInfo(Container.DataItem) %>' ID="Label2"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Seller" SortExpression="Seller">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# GetVendor(Container.DataItem) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Expires" HeaderText="Expires" SortExpression="Expires" DataFormatString="{0:MMM-dd-yyyy}" />
                    <asp:TemplateField HeaderText="Price">
                        <ItemTemplate>
                            <asp:Label ID="lblPrice" runat="server" Text='<%# GetPrice(Container.DataItem) %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="PaymentCycle" HeaderText="Payment Cycle" SortExpression="PaymentCycle"></asp:BoundField>
                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id">
                        <ItemStyle HorizontalAlign="Right" Width="50px"></ItemStyle>
                    </asp:BoundField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:ImageButton ID="BtnReview" runat="server" CausesValidation="False" CommandArgument='<%#Eval("Id") + "," + Eval("FinId") + "," + Eval("Declined") %>' ToolTip="Review/Approve"
                                CommandName="Activate" ImageUrl="~/images/View_Detail.png" AlternateText="Review/Approve" />
                        </ItemTemplate>
                        <ItemStyle Width="35px" />
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:ImageButton ID="BtnRepost" runat="server" CausesValidation="False" CommandArgument='<%#Eval("Id") + "," + Eval("FinId") %>' ToolTip="Repost"
                                OnClientClick="return confirm('Repost this vehicle?');" CommandName="Repost" ImageUrl="~/images/recycle.png" AlternateText="Repost" />
                        </ItemTemplate>
                        <ItemStyle Width="35px" />
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:ImageButton ID="BtnSuspend" runat="server" CausesValidation="False" CommandArgument='<%#Eval("Id") + "," + Eval("FinId") %>' ToolTip="Deactivate"
                                OnClientClick="return confirm('Deactivate this vehicle?');" CommandName="Deactivate" ImageUrl="~/images/trash.png" AlternateText="Delete" />
                        </ItemTemplate>
                        <ItemStyle Width="35px" />
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    No vehicles found.
                </EmptyDataTemplate>
            </asp:GridView>
            <asp:ObjectDataSource ID="OdsCustomersInfo" runat="server" SelectMethod="GetAllCustomerVehicleInfo" TypeName="eMonthleys.BLL.CustomerVehicleInfo"
                OnSelected="OdsCustomersInfo_Selected">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddlStatus" DefaultValue="approvedNew" Name="Status" PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
        <script type="text/javascript">
            $(function () {
                $('#<%=GvVehicles.ClientID %>').footable({
                    breakpoints: {
                        phone: 300,
                        tablet: 640
                    }
                });
            });
        </script>
    </div>
    <!-- Modal -->
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        ×</button>
                    <h3 id="myModalLabel">Repost vehicle
                <asp:Label ID="lblVehicleId" runat="server"></asp:Label></h3>
                </div>
                <div class="modal-body">
                    <fieldset>
                        <asp:RadioButtonList ID="rblVehicleType" runat="server" GroupName="vType" RepeatColumns="2" Width="100%">
                            <asp:ListItem Value="22" Text="<img src='/images/sedan-icon.png' /> Cars"></asp:ListItem>
                            <asp:ListItem Value="29" Text="<img src='/images/minivan-icon.png' /> Vans"></asp:ListItem>
                            <asp:ListItem Value="25" Text="<img src='/images/SUV-icon.png' /> SUV's"></asp:ListItem>
                            <asp:ListItem Value="24" Text="<img src='/images/truck-icon.png' /> Trucks"></asp:ListItem>
                            <asp:ListItem Value="31" Text="<img src='/images/cabriolet-icon.png' /> Convertibles"></asp:ListItem>
                            <asp:ListItem Value="39" Text="<img src='/images/collector-icon.png' /> Collector Cars"></asp:ListItem>
                        </asp:RadioButtonList>

                        <div class="form-group">
                            <asp:Label ID="lblYear" runat="server" AssociatedControlID="ddlYear" CssClass="col-md-2 control-label">Model Year:</asp:Label>
                            <div class="col-md-9">
                                <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="false" CssClass="form-control" ValidationGroup="vgVehicle" Width="200px"
                                    DataSourceID="odsModelYears" DataTextField="ModelYear" DataValueField="ModelYear">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvYear" runat="server" ErrorMessage="Model year is required." ValidationGroup="vgVehicle"
                                    ControlToValidate="ddlYear" CssClass="text-danger" InitialValue="" Text="*"></asp:RequiredFieldValidator>
                            </div>
                            <asp:ObjectDataSource runat="server" ID="odsModelYears" SelectMethod="GetAllModelYearLookup" TypeName="eMonthleys.BLL.ModelYearLookup"></asp:ObjectDataSource>
                        </div>
                        <br class="clear" />
                        <div class="form-group">
                            <asp:Label ID="lblMake" runat="server" AssociatedControlID="DdlMakes" CssClass="col-md-2 control-label">Manufacturer:</asp:Label>
                            <div class="col-md-3">
                                <asp:DropDownList ID="DdlMakes" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="DdlMakes_SelectedIndexChanged"
                                    ValidationGroup="vgVehicle" DataSourceID="odsManufacturers" DataTextField="Make" DataValueField="Make" Width="200px">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvMake" runat="server" ErrorMessage="Manufacturer is required." ValidationGroup="vgVehicle"
                                    ControlToValidate="DdlMakes" CssClass="text-danger" InitialValue="" Text="*"></asp:RequiredFieldValidator>
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
                        <br class="clear" />
                        <div class="form-group">
                            <asp:Label ID="lblModel" runat="server" AssociatedControlID="DdlModel" CssClass="col-md-2 control-label">Model:</asp:Label>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <div class="col-md-3">
                                        <asp:DropDownList ID="DdlModel" runat="server" AutoPostBack="true" CssClass="form-control floatleft" ValidationGroup="vgVehicle"
                                            DataTextField="Model" DataValueField="Model" Width="200px" OnSelectedIndexChanged="DdlModel_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RfvModel" runat="server" ErrorMessage="Model is required." ValidationGroup="vgVehicle"
                                            ControlToValidate="DdlModel" CssClass="text-danger" InitialValue="Please select" Text="*"></asp:RequiredFieldValidator>
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
                                    <asp:AsyncPostBackTrigger ControlID="DdlMakes" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                        <br class="clear" />
                        <div class="form-group">
                            <asp:Label ID="lblTrim" runat="server" AssociatedControlID="DdlTrim" CssClass="col-md-2 control-label">Model Trim:</asp:Label>
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <div class="col-md-3">
                                        <asp:DropDownList ID="DdlTrim" runat="server" CssClass="form-control floatleft" ValidationGroup="vgVehicle" AutoPostBack="true"
                                            DataTextField="ModelTrim" DataValueField="ModelId" Width="200px" OnSelectedIndexChanged="DdlTrim_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RfvTrim" runat="server" ErrorMessage="Model trim is required." ValidationGroup="vgVehicle"
                                            ControlToValidate="DdlTrim" CssClass="text-danger" InitialValue="" Text="*"></asp:RequiredFieldValidator>
                                    </div>
                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                        <ContentTemplate>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="TxtModelTrim" runat="server" Visible="false" Enabled="false" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RfvTxtTrim" runat="server" ErrorMessage="Please enter other model trim" Text="*"
                                                    CssClass="text-danger" ControlToValidate="TxtModelTrim" Enabled="false"></asp:RequiredFieldValidator>
                                            </div>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="DdlModel" EventName="SelectedIndexChanged" />
                                            <asp:AsyncPostBackTrigger ControlID="DdlTrim" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="DdlModel" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                                    <asp:AsyncPostBackTrigger ControlID="DdlMakes" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                                </Triggers>
                            </asp:UpdatePanel>
                            <br class="clear" />
                            <div class="form-group">
                                <asp:Label ID="Label17" runat="server" AssociatedControlID="txtPurchasePrice" CssClass="col-md-2 control-label">Purchase price:</asp:Label>
                                <div class="col-md-3">
                                    <asp:TextBox runat="server" ID="txtPurchasePrice" CssClass="dollarvalue form-control" ValidationGroup="vgLease" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter the purchase price."
                                        ControlToValidate="txtPurchasePrice" Text="*" ValidationGroup="vgLease" CssClass="text-danger"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="Purchase price must be numeric."
                                        Text="*" CssClass="text-danger" ValidationGroup="vgLease" ControlToValidate="txtPurchasePrice" ValidationExpression="\d+(\.\d{1,2})?"></asp:RegularExpressionValidator>
                                </div>
                                <asp:Label ID="Label27" runat="server" CssClass="col-md-6" Text="(incl. Tax/Frt/PDI/Env. Fee/Admin/OMVIC for businesses)"></asp:Label>
                            </div>
                            <br class="clear" />
                            <div class="form-group">
                                <asp:Label ID="Label4" runat="server" AssociatedControlID="ddlPayCycle" CssClass="col-md-2 control-label">Payment cycle:</asp:Label>
                                <div class="col-md-3">
                                        <asp:DropDownList runat="server" ID="ddlPayCycle" CssClass="form-control" Width="150px" ValidationGroup="vgLease">
                                            <asp:ListItem Value="">Please select</asp:ListItem>
                                            <asp:ListItem>Weekly</asp:ListItem>
                                            <asp:ListItem>Bi-weekly</asp:ListItem>
                                            <asp:ListItem>Semi-monthly</asp:ListItem>
                                            <asp:ListItem>Monthly</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvPayCycle" runat="server" ErrorMessage="Please payment cycle."
                                            ControlToValidate="ddlPayCycle" Text="*" ValidationGroup="vgLease" InitialValue="" CssClass="text-danger"></asp:RequiredFieldValidator>
                                    </div>
                            </div>
                            <br class="clear" />
                                <div class="form-group">
                                    <asp:Label ID="Label6" runat="server" AssociatedControlID="txtMonthlyWithTax" CssClass="col-md-3 control-label">Payment:</asp:Label>
                                    <div class="col-md-3">
                                        <asp:TextBox runat="server" ID="txtMonthlyWithTax" CssClass="dollarvalue form-control" ValidationGroup="vgLease" />
                                        <asp:RequiredFieldValidator ID="rfvMonthly" runat="server" ErrorMessage="Please enter payment with tax."
                                            ControlToValidate="txtMonthlyWithTax" Text="*" ValidationGroup="vgLease" CssClass="text-danger"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Please enter a numeric value for payment."
                                            Text="*" CssClass="text-danger" ValidationGroup="vgLease" ControlToValidate="txtMonthlyWithTax" ValidationExpression="\d+(\.\d{1,2})?"></asp:RegularExpressionValidator>
                                    </div>
                                    <asp:Label ID="Label25" runat="server" CssClass="col-md-2" Text="(incl. Tax)"></asp:Label>

                                </div>
                            </div>
                            <div class="clear"></div>
                    </fieldset>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="BtnUpdateCar" runat="server" ValidationGroup="vgVehicle" CausesValidation="true" Text="Save" OnClick="BtnUpdateCar_Click" CssClass="Btn" />
                    <button data-dismiss="modal" aria-hidden="true" class="Btn">
                        Cancel</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
