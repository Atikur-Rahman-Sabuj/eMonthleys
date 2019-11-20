<%@ Page Title="My Vehicles" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyVehicles.aspx.cs" Inherits="eMonthleys.MyVehicles" %>

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
    <div class="container-fluid mainpanel">
        <h1>My Vehicles</h1>
        <div class="form-group">
            <asp:Label ID="lblCondition" runat="server" AssociatedControlID="ddlCondition" CssClass="col-md-2 control-label">Vehicle Status:</asp:Label>
            <div class="col-md-4">
                <asp:DropDownList ID="ddlCondition" runat="server" AutoPostBack="true">
                    <asp:ListItem Value="new">New vehicles ads</asp:ListItem>
                    <asp:ListItem Value="used">Used vehicles ads</asp:ListItem>
                    <asp:ListItem Value="expired">Expired ads</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="clear"></div>

        <div>
            <div class="col-md-5">
                <asp:Label ID="lblCount" runat="server"></asp:Label>
            </div>
            <div class="col-md-7 right text-right bg-info">
                <img src="/images/View_Detail.png" alt="" />&nbsp;View ad,&nbsp;
                <img src="/images/sold.png" alt="" />&nbsp;Sold,&nbsp;
                <img src="/images/soldnmore.png" alt="" />&nbsp;Sold but more,&nbsp;
                <img src="/images/trash.png" alt="" />&nbsp;Delete&nbsp;
            </div>
        </div>

        <asp:Literal ID="ltlRemaining" runat="server"></asp:Literal>
        <asp:GridView ID="GvMyVehicles" runat="server" AutoGenerateColumns="False" CssClass="table table-striped footable" Width="100%" DataSourceID="OdsCustomerVehicles"
            OnRowCommand="GvMyVehicles_RowCommand" GridLines="None" OnDataBound="GvMyVehicles_DataBound" OnRowDataBound="GvMyVehicles_RowDataBound" DataKeyNames="Id"
            AllowPaging="True" PageSize="20" OnPageIndexChanging="GvMyVehicles_PageIndexChanging" PagerStyle-CssClass="GridPager">
            <Columns>
                <asp:TemplateField HeaderText="Make/Model" SortExpression="Make">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# GetVehicleInfo(Container.DataItem) %>' ID="Label2"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Category" SortExpression="VehicleCategoryId">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# GetCategory(Container.DataItem) %>' ID="Label5"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="PaymentCycle" HeaderText="Pay Cycle" SortExpression="PaymentCycle" />
                <asp:BoundField DataField="CurrentMileage" HeaderText="Current Mileage" SortExpression="CurrentMileage" DataFormatString="{0:N0}" />
                <asp:BoundField DataField="Expires" HeaderText="Expires" SortExpression="Expires" DataFormatString="{0:MMM/dd/yyyy}" />
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id"></asp:BoundField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:ImageButton ID="BtnModify" runat="server" CausesValidation="False" ToolTip="Modify" CommandName="Edit" 
                                         CommandArgument='<%# GetItemId(Container.DataItem)%>' ImageUrl="~/images/View_Detail.png" Text="Edit" />
                    </ItemTemplate>
                    <ItemStyle Width="35px" />
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:ImageButton ID="BtnSold" runat="server" CausesValidation="False"  ToolTip="Sold" CommandName="Sold" 
                                         OnClientClick="return confirm('Mark this vehicle as sold?');" CommandArgument='<%# GetItemId(Container.DataItem)%>' ImageUrl="~/images/sold.png" Text="Sold" />
                    </ItemTemplate>
                    <ItemStyle Width="35px" />
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:ImageButton ID="BtnSoldMore" runat="server" CausesValidation="False"  ToolTip="Sold but more" CommandName="SoldButMore" 
                                         CommandArgument='<%# GetItemId(Container.DataItem)%>' ImageUrl="~/images/soldnmore.png" Text="Sold but more" />
                        <asp:Label ID="lblItemSold" runat="server" Text="Sold" CssClass="bold alert-success" Visible="false"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="35px" />
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:ImageButton ID="BtnDelete" runat="server" CausesValidation="False"  ToolTip="Delete" CommandArgument='<%# GetItemId(Container.DataItem)%>'
                            OnClientClick="return confirm('Delete this vehicle?');" CommandName="Remove" ImageUrl="~/images/trash.png" Text="Delete" />
                    </ItemTemplate>
                    <ItemStyle Width="35px" />
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                No vehicles found.
            </EmptyDataTemplate>
        </asp:GridView>
        <asp:ObjectDataSource ID="OdsCustomerVehicles" runat="server" SelectMethod="GetAllCustomerVehicleInfoByCustomerId"
            OnSelected="OdsCustomerVehicles_Selected" TypeName="eMonthleys.BLL.CustomerVehicleInfo">
            <SelectParameters>
                <asp:SessionParameter SessionField="CustomerId" Name="CustomerId" Type="String"></asp:SessionParameter>
                <asp:ControlParameter ControlID="ddlCondition" DefaultValue="new" Name="Condition" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <script type="text/javascript">
            $(function () {
                $('#<%=GvMyVehicles.ClientID %>').footable({
                    breakpoints: {

                        phone: 300,
                        tablet: 640
                    }
                });
            });
        </script>
    </div>
</asp:Content>
