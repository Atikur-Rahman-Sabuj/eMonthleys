<%@ Page Title="Registered Customers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="eMonthleys.Customers" %>

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
        <h1><%: Title %></h1>
        <div class="form-group col-md-12">
            <asp:Label ID="lblStatus" runat="server" AssociatedControlID="ddlStatus" CssClass="col-md-2 control-label">Customer Status:</asp:Label>
            <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="true" class="col-md-6">
                <asp:ListItem Value="new">New pending approval</asp:ListItem>
                <asp:ListItem Value="existing">Existing approved</asp:ListItem>
            </asp:DropDownList>
            <div class="col-md-2"></div>
            <button type="button" class="btn btn-primary col-md-2" value="New Customer" onclick="self.location='NewCustomer.aspx';">Add New Customer</button>
        </div>
        <div class="clear"></div>
        <div class="col-md-12 text-right">
            <div class="col-md-3">
                <img src="/images/new_ad-b.png" alt="" class="gridmenuicon" />New business ad for customer
            </div>
            <div class="col-md-3">
                <img src="/images/CarGrey-icon.png" alt="" class="gridmenuicon" />New vehicle ad for customer
            </div>
            <div class="col-md-2">
                <img src="/images/View_Detail.png" alt="" class="gridmenuicon" />Review
            </div>
            <div class="col-md-2">
                <img src="/images/add_user.png" alt="" class="gridmenuicon" />Approve
            </div>
            <div class="col-md-2">
                <img src="/images/remove_user.png" alt="" class="gridmenuicon" />Remove
            </div>
        </div>
        <div>
            <asp:GridView ID="gvCustomers" runat="server" Width="100%" CssClass="table table-striped footable" AutoGenerateColumns="False"
                DataSourceID="odsCustomers" DataKeyNames="Id" OnDataBinding="gvCustomers_DataBinding" OnRowCommand="gvCustomers_RowCommand"
                OnDataBound="gvCustomers_DataBound" GridLines="None">
                <Columns>
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
                    <asp:BoundField DataField="CustomerType" HeaderText="Customer Type" SortExpression="CustomerType" />
                    <asp:BoundField DataField="Company" HeaderText="Company" SortExpression="Company" />
                    <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                    <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
                    <asp:BoundField DataField="DateAdded" HeaderText="Signup Date" SortExpression="DateAdded" DataFormatString="{0:MMM-dd-yyyy}" />
                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id">
                        <ItemStyle HorizontalAlign="Right" Width="50px" />
                    </asp:BoundField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:ImageButton ID="BtnNewAd" runat="server" CausesValidation="False" CommandArgument='<%# Eval("Id") %>' ToolTip="New business ad" CommandName="NewAd" ImageUrl="~/images/new_ad-b.png" />
                        </ItemTemplate>
                        <ItemStyle Width="16px" />
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:ImageButton ID="BtnNewItem" runat="server" CausesValidation="False" CommandArgument='<%# Eval("Id") %>' ToolTip="New item" CommandName="NewItem" ImageUrl="~/images/CarGrey-icon.png" />
                        </ItemTemplate>
                        <ItemStyle Width="16px" />
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:ImageButton ID="BtnReview" runat="server" CausesValidation="False" CommandArgument='<%# Eval("Id") %>' ToolTip="Review" CommandName="Select" ImageUrl="~/images/View_Detail.png" />
                        </ItemTemplate>
                        <ItemStyle Width="16px" />
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" CommandArgument='<%# Eval("Id") %>' ToolTip="Activate"
                                OnClientClick="return confirm('Activate this Customer?');" CommandName="Activate" ImageUrl="~/images/add_user.png" />
                        </ItemTemplate>
                        <ItemStyle Width="16px" />
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton3" runat="server" CausesValidation="False" CommandArgument='<%# Eval("Id") %>' ToolTip="Deactivate"
                                OnClientClick="return confirm('Deactivate this Customer?');" CommandName="Deactivate" ImageUrl="~/images/remove_user.png" />
                        </ItemTemplate>
                        <ItemStyle Width="16px" />
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    No customers found.
                </EmptyDataTemplate>
            </asp:GridView>
            <asp:ObjectDataSource ID="odsCustomers" runat="server" SelectMethod="GetAllCustomers" TypeName="eMonthleys.BLL.Customer">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddlStatus" DefaultValue="new" Name="Status" PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <script type="text/javascript">
                $(function () {
                    $('#<%=gvCustomers.ClientID %>').footable({
                        breakpoints: {

                            phone: 300,
                            tablet: 640
                        }
                    });
                });
            </script>
        </div>
    </div>

    <!-- Modal -->
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabel">Customer Details</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <asp:Label ID="lblCustomerType" runat="server" CssClass="col-md-3 control-label">Customer Type:</asp:Label>
                        <asp:Label ID="txtCustomerType" runat="server" CssClass="col-md-9 control-label"></asp:Label>
                    </div>
                    <div class="clear"></div>
                    <div class="form-group">
                        <asp:Label ID="lblCustomerName" runat="server" CssClass="col-md-3 control-label">Name:</asp:Label>
                        <asp:Label ID="txtCustomerName" runat="server" CssClass="col-md-9 control-label"></asp:Label>
                    </div>
                    <div class="clear"></div>
                    <div class="form-group">
                        <asp:Label ID="lblCompany" runat="server" CssClass="col-md-3 control-label">Company Name:</asp:Label>
                        <asp:Label ID="txtCompany" runat="server" CssClass="col-md-9 control-label"></asp:Label>
                    </div>
                    <div class="clear"></div>
                    <div class="form-group">
                        <asp:Label ID="lblAddress" runat="server" CssClass="col-md-3 control-label">Address:</asp:Label>
                        <asp:Label ID="txtAddress" runat="server" CssClass="col-md-9 control-label"></asp:Label>
                    </div>
                    <div class="clear"></div>
                    <div class="form-group">
                        <asp:Label ID="lblPhone" runat="server" CssClass="col-md-3 control-label">Phone:</asp:Label>
                        <asp:Label ID="txtPhone" runat="server" CssClass="col-md-9 control-label"></asp:Label>
                    </div>
                    <div class="clear"></div>
                    <div class="form-group">
                        <asp:Label ID="lblEmail" runat="server" CssClass="col-md-3 control-label">Email:</asp:Label>
                        <asp:Label ID="TxtEmail" runat="server" CssClass="col-md-9 control-label"></asp:Label>
                    </div>
                    <div class="clear"></div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="Btn Btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
