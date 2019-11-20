<%@ Page Title="Customer Ad" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ads.aspx.cs" Inherits="eMonthleys.Ads" %>

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
    <script type="text/javascript" src="/scripts/jquery.fancybox.js?v=2.1.5"></script>
    <link rel="stylesheet" type="text/css" href="/content/jquery.fancybox.css?v=2.1.5" media="screen" />
    <script type="text/javascript">
        $(".fancybox-effects-a").fancybox({
            helpers: {
                title: {
                    type: 'outside'
                },
                overlay: {
                    speedOut: 0
                }
            }
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid mainpanel">
        <h1><%: Title %></h1>
        <div class="form-group">
            <asp:Label ID="lblStatus" runat="server" AssociatedControlID="ddlStatus" CssClass="col-md-2 control-label">Customer Ads Status:</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="true">
                    <asp:ListItem Value="on">Approved</asp:ListItem>
                    <asp:ListItem Value="off">Pending approval</asp:ListItem>
                    <asp:ListItem Value="declined">Declined</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="clear"></div>
        <div>
            <asp:GridView ID="gvCustomersAds" runat="server" Width="100%" CssClass="table table-striped footable" AutoGenerateColumns="False" DataSourceID="odsCustomersAds"
                GridLines="None" OnDataBound="gvCustomersAds_DataBound" OnDataBinding="gvCustomersAds_DataBinding" OnRowCommand="gvCustomersAd_RowCommand">
                <Columns>
                    <asp:BoundField DataField="AdDetails" HeaderText="Ad Details" SortExpression="AdDetails" />
                    <asp:BoundField DataField="Company" HeaderText="Company" SortExpression="Company" />
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
                    <asp:BoundField DataField="AdType" HeaderText="Ad Type" SortExpression="AdType" />
                    <asp:BoundField DataField="Expires" HeaderText="Expires" SortExpression="Expires" DataFormatString="{0:MMM-dd-yyyy}" />
                    <asp:TemplateField HeaderText="PayPal" SortExpression="PayPalState">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# SetPaypal(Container.DataItem) %>' ID="Label1"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" CommandArgument='<%# Eval("Id") %>' ToolTip="Activate"
                                OnClientClick="return confirm('Activate this Ad?');" CommandName="on" ImageUrl="~/images/approve.png" AlternateText="On" />
                        </ItemTemplate>
                        <ItemStyle Width="16px" />
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton3" runat="server" CausesValidation="False" CommandArgument='<%# Eval("Id") %>' ToolTip="Deactivate"
                                OnClientClick="return confirm('Deactivate this Ad?');" CommandName="off" ImageUrl="~/images/deny.png" AlternateText="Off" />
                        </ItemTemplate>
                        <ItemStyle Width="16px" />
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton4" runat="server" CausesValidation="False" CommandArgument='<%# Eval("Id") %>' ToolTip="Review ad"
                               CommandName="Review" ImageUrl="~/images/View_Detail.png" AlternateText="Review" />
                        </ItemTemplate>
                        <ItemStyle Width="16px" />
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    No ads found.
                </EmptyDataTemplate>
            </asp:GridView>
            <asp:ObjectDataSource ID="odsCustomersAds" runat="server" SelectMethod="GetAllCustomersAdsByStatus" TypeName="eMonthleys.BLL.AdsAdmin">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddlStatus" DefaultValue="off" Name="Status" PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            $('#<%=gvCustomersAds.ClientID %>').footable({
                breakpoints: {
                    phone: 300,
                    tablet: 640
                }
            });
        });
    </script>
    <!-- Modal -->
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabel">Ad Details</h4>
                </div>
                <div class="modal-body">
                    <asp:PlaceHolder ID="plhImages" runat="server"></asp:PlaceHolder>
                    <div class="clear"></div>
                    <asp:Literal ID="ltlAdDetails" runat="server"></asp:Literal>
                    <p><asp:Label ID="txtUrl" runat="server"></asp:Label></p>
                    <asp:HiddenField ID="hfAdId" runat="server" />
                    <asp:HiddenField ID="hfCustomerId" runat="server" />
                </div>
                <div class="modal-footer">
                    <asp:Button ID="BtnApprove" runat="server" CausesValidation="false" CssClass="btn btn-primary" Text="Approve" OnClick="BtnApprove_Click" />
                    <asp:Button ID="BtnDecline" runat="server" CausesValidation="false" CssClass="btn btn-primary" Text="Decline" OnClick="BtnDecline_Click" />
                    <button type="button" class="Btn Btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
