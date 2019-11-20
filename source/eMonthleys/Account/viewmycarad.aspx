<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="viewmycarad.aspx.cs" Inherits="eMonthleys.Account.viewmycarad" %>

<%@ Import Namespace="System.Reflection" %>
<%@ Import Namespace="eMonthleys.Constants" %>

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
    <script type="text/javascript" src="/scripts/jquery.fancybox.js?v=2.1.5"></script>
    <link rel="stylesheet" type="text/css" href="/content/jquery.fancybox.css?v=2.1.5" media="screen" />
    <script type="text/javascript">
        $('.fancybox-buttons').fancybox({
            openEffect: 'none',
            closeEffect: 'none',

            prevEffect: 'none',
            nextEffect: 'none',

            closeBtn: true,
            helpers: {
                title: {
                    type: 'inside'
                },
                buttons: {}
            },

            afterLoad: function () {
                this.title = 'Image ' + (this.index + 1) + ' of ' + this.group.length + (this.title ? ' - ' + this.title : '');
            }
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid mainpanel">
        <%
            var args = Request.QueryString["id"].Split(',');
            var VehicleId = Convert.ToInt32(args[0]);
            var FinId = Convert.ToInt32(args[1]);
            //var VehicleId = Convert.ToInt32(Request.QueryString["id"].ToString());
            var vehicle = eMonthleys.BLL.CustomerVehicleInfo.GetCustomerVehicleInfoDetails(VehicleId, FinId, false);

            if (vehicle != null)
            {
                {
                    string heading = vehicle.ModelYear.ToString();
                    if (vehicle.Manufacturer == "Other")
                        heading += " " + vehicle.OtherMake;
                    else
                        heading += " " + vehicle.Manufacturer;
                    if (vehicle.Model == "Other")
                        heading += " " + vehicle.OtherModel;
                    else
                        heading += " " + vehicle.Model;
                    if (vehicle.ModelTrim == 60931)
                        heading += " " + vehicle.OtherTrim;
                    else
                        heading += " " + vehicle.ModelTrimValue;
        %>
        <h1><%= heading %></h1>
        <div class="col-md-12">
            <%--Pictures--%>
            <div class="row">
                <%
                    var imgs = eMonthleys.BLL.VehicleImage.SelectByVehicleId(VehicleId);
                    if (imgs != null)
                    {
                        PropertyInfo[] props = imgs.GetType().GetProperties();
                        foreach (PropertyInfo p in props)
                        {
                            if (p.Name.Contains("Img") && !p.Name.Contains("Path"))
                            {
                                object img = p.GetValue(imgs, null);
                                if (img.ToString() != "")
                                {

                %>
                <a href="<%= img.ToString() %>" class="fancybox-buttons" data-fancybox-group="button">
                    <img src="/thumbnail.ashx?pic=<%= img.ToString() %>&size=80" class="thumb" alt="<%= vehicle.Model %>" /></a>
                <%
                                }
                            }
                        }
                        if (imgs.Video != "")
                        {
                %>
                <img id="video" src="/images/video-play.png" class="thumb link" alt="<%= vehicle.Model %>" onclick="$('#myModal').modal('show');" />
                <!-- Modal -->
                <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                <h4 class="modal-title" id="myModalLabel">Video</h4>
                            </div>
                            <div class="modal-body">
                                <div class="centered">
                                    <video controls style="width: 320px; height: 240px">
                                        <source src="<%= imgs.Video %>" type="<%= imgs.VideoFormat %>" />
                                    </video>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="Btn Btn-default" data-dismiss="modal">Close</button>
                            </div>
                        </div>
                    </div>
                </div>
                <%
                        }
                %>
                <div class="clear"></div>
                Click on images to enlarge.
                    <% } %>
            </div>

            <div class="clear25"></div>

            <div class="row mainpanel">
                <%--Vehicle information--%>
                <div class="col-md-6">
                    <h4>Vehicle information</h4>
                    <div class="col-md-4">
                        Year:
                    </div>
                    <div class="col-md-8">
                        <% Response.Write(vehicle.ModelYear); %>
                    </div>
                    <div class="clear"></div>
                    <div class="col-md-4">
                        Make:
                    </div>
                    <div class="col-md-8">
                        <% if (vehicle.Manufacturer == "Other")
                                Response.Write(vehicle.OtherMake);
                            else
                                Response.Write(vehicle.Manufacturer);
                        %>
                    </div>
                    <div class="clear"></div>
                    <div class="col-md-4">
                        Model:
                    </div>
                    <div class="col-md-8">
                        <% if (vehicle.Model == "Other")
                                Response.Write(vehicle.OtherModel);
                            else
                                Response.Write(vehicle.Model);
                        %>
                    </div>
                    <div class="clear"></div>
                    <div class="col-md-4">
                        Trim:
                    </div>
                    <div class="col-md-8">
                        <% if (vehicle.ModelTrim == 60931)
                                Response.Write(vehicle.OtherTrim);
                            else
                                Response.Write(vehicle.ModelTrimValue);
                        %>
                    </div>
                    <div class="clear"></div>
                    <div class="col-md-4">
                        Category:
                    </div>
                    <div class="col-md-8">
                        <% Response.Write(eMonthleys.BLL.Vehiclecategories.GetVehicleCategoryDetails(vehicle.VehicleCategoryId).Name);%>
                    </div>
                    <div class="clear"></div>
                    <div class="col-md-4">
                        Body colour:
                    </div>
                    <div class="col-md-8">
                        <% Response.Write(vehicle.ExteriorColor); %>
                    </div>
                    <div class="clear"></div>
                    <div class="col-md-4">
                        Interior colour:
                    </div>
                    <div class="col-md-8">
                        <% Response.Write(vehicle.InteriorColor); %>
                    </div>
                    <div class="clear"></div>
                    <div class="col-md-4">
                        Transmission:
                    </div>
                    <div class="col-md-8">
                        <% Response.Write(vehicle.Transmission); %>
                    </div>
                    <div class="clear"></div>
                    <div class="col-md-4">
                        Fuel type:
                    </div>
                    <div class="col-md-8">
                        <% Response.Write(vehicle.FuelType); %>
                    </div>
                    <div class="clear"></div>
                    <div class="col-md-4">
                        Displacement:
                    </div>
                    <div class="col-md-8">
                        <% Response.Write(vehicle.Displacement); %>
                    </div>
                    <div class="clear"></div>
                    <div class="col-md-4">
                        Odometer reading:
                    </div>
                    <div class="col-md-8">
                        <% if (vehicle.VehicleCondition == "new")
                                Response.Write("New");
                            else
                                Response.Write(vehicle.CurrentMileage.ToString("N0")); %>
                    </div>
                    <div class="clear"></div>
                    <div class="col-md-4">
                        Type of wheels:
                    </div>
                    <div class="col-md-8">
                        <% Response.Write(vehicle.Wheels);
                            if (vehicle.ChromeWheels)
                            {
                                Response.Write("<br />- Chrome Wheels");
                            }
                        %><br />
                    </div>
                    <div class="clear"></div>
                    <div class="col-md-4">
                        Type of tires:
                    </div>
                    <div class="col-md-8">
                        <% Response.Write(vehicle.Tires);
                            if (vehicle.ExtraWinterTires)
                            {
                                Response.Write("<br />- Extra set of winter tires");
                            }
                        %>
                    </div>
                    <div class="clear"></div>
                    <div class="col-xs-4">
                        Additional Information:
                    </div>
                    <div class="col-xs-6">
                        <% Response.Write(vehicle.Comments);
                        %>
                    </div>
                    <div class="clear"></div>
                </div>
                <%-- Financial details --%>

                <div class="col-md-6">
                    <h4>Financial details</h4>
                    <%
                        var financial = eMonthleys.BLL.Financial.GetFinancialDetailsByVehicleId(vehicle.Id, FinId);
                        if (financial != null)
                        {
                    %>
                    <div class="col-md-5">
                        Purchase price:
                    </div>
                    <div class="col-md-6">
                        <% Response.Write(financial.PurchasePrice.ToString(@"$#,##0.00;($#,##0.00\)")); %> (incl. tax)
                    </div>
                    <div class="clear"></div>
                    <%if (financial.LeaseOrFinance.Equals("l") || financial.LeaseOrFinance.Equals("f"))
                        {

                    %>
                    <div class="col-md-5">
                        Payment cycle:
                    </div>
                    <div class="col-md-6">
                        <% Response.Write(financial.PaymentCycle);
                            var payCycles = eMonthleys.BLL.Financial.CheckPayCycle(financial.VehicleId);
                            if (financial.PaymentCycle == emConstants.PaymentMonthly || financial.PaymentCycle == emConstants.PaymentBiWeekly)
                            {
                                if (payCycles.Count == 1 && payCycles.Contains(emConstants.PaymentBiWeekly))
                                {
                                    pnlRepostMonthly.Visible = true;
                                    paymentModalLabel.InnerText = "Monthly payment cycle";
                                    hfPayCycle.Value = emConstants.PaymentMonthly;
                                }
                                else if (payCycles.Count == 1 && payCycles.Contains(emConstants.PaymentMonthly))
                                {
                                    pnlRepostBiWeekly.Visible = true;
                                    paymentModalLabel.InnerText = "Bi-Weekly payment cycle";
                                    hfPayCycle.Value = emConstants.PaymentMonthly;
                                }
                            }
                        %>
                    </div>
                    <div class="clear"></div>
                    <div class="col-md-5">
                        Payment with taxes:
                    </div>
                    <div class="col-md-6">
                        <% Response.Write(financial.PaymentWithTax.ToString(@"$#,##0.00;($#,##0.00\)")); %>
                    </div>
                    <div class="clear"></div>
                    <div class="col-md-5">
                        Total due on delivery:
                    </div>
                    <div class="col-md-6">
                        <% Response.Write(financial.OriginalDown.ToString(@"$#,##0.00;($#,##0.00\)")); %>
                    </div>
                    <div class="clear"></div>
                    <%if (financial.LeaseOrFinance.Equals("l"))
                        {
                    %>
                    <div class="col-md-5">
                        Security deposit::
                    </div>
                    <div class="col-md-6">
                        <% Response.Write(financial.SecurityDeposit.ToString(@"$#,##0.00;($#,##0.00\)")); %>
                    </div>
                    <div class="clear"></div>
                    <div class="col-md-5">
                        Purchase Option at end of lease:
                    </div>
                    <div class="col-md-6">
                        <% Response.Write(financial.PoEndOfLease); %>
                    </div>
                    <div class="clear"></div>
                    <div class="col-md-5">
                        Total Kilometre allowance:
                    </div>
                    <div class="col-md-6">
                        <% Response.Write(financial.KmAllowance); %>
                    </div>
                    <div class="clear"></div>
                    <div class="col-md-5">
                        Excess km charge:
                    </div>
                    <div class="col-md-6">
                        <% Response.Write(financial.ExcessKmCharge.ToString(@"$#,##0.00;($#,##0.00\)")); %>
                    </div>
                    <div class="clear"></div>
                    <%} %>
                    <div class="col-md-5">
                        Term of loan (months):
                    </div>
                    <div class="col-md-6">
                        <% Response.Write(financial.LeaseTerm); %>
                    </div>
                    <div class="clear"></div>
                    <%if (financial.LeaseOrFinance.Equals("l"))
                        {
                    %>
                    <div class="col-md-5">
                        Lease expiry date:
                    </div>
                    <div class="col-md-6">
                        <% if (financial.LeaseExpiry != null)
                                Response.Write(Convert.ToDateTime(financial.LeaseExpiry.ToString()).ToShortDateString());
                        %>
                    </div>
                    <div class="clear"></div>
                    <div class="col-md-5">
                        Buyback/Residual value:
                    </div>
                    <div class="col-md-6">
                        <% Response.Write(financial.BuyBack.ToString(@"$#,##0.00;($#,##0.00\)")); %> (incl. tax)
                    </div>
                    <div class="clear"></div>
                    <%}
                        if (financial.LeaseOrFinance.Equals("f"))
                        {
                    %>
                    <div class="col-md-4">
                        Balloon payment:
                    </div>
                    <div class="col-md-8">
                        <% Response.Write(financial.Balloon.ToString(@"$#,##0.00;($#,##0.00\)")); %> (incl. tax)
                    </div>
                    <div class="clear"></div>
                    <%
                                }
                            }
                        }%>
                </div>
                <div class="clear"></div>
                <%--Seller information and Vehicle location--%>

                <%
                    var seller = eMonthleys.BLL.Customer.GetCustomerDetails(vehicle.Seller);
                    Session["Seller"] = seller.Id;
                %>
                <div class="col-md-6">
                    <h4>Seller information and seller location</h4>
                    <div class="col-md-4">
                        Name:
                    </div>
                    <div class="col-md-8">
                        <% Response.Write(seller.FirstName + " " + seller.LastName); %>
                    </div>
                    <div class="clear"></div>
                    <div class="col-md-4">
                        City:
                    </div>
                    <div class="col-md-8">
                        <% Response.Write(seller.City); %>
                    </div>
                    <div class="clear"></div>
                    <div class="col-md-4">
                        Province:
                    </div>
                    <div class="col-md-8">
                        <% Response.Write(seller.State); %>
                    </div>
                    <div class="clear"></div>
                    <div class="col-md-4">
                        Phone Number:
                    </div>
                    <div class="col-md-8">
                        <% Response.Write(seller.Phone); %>
                    </div>
                    <div class="clear"></div>
                    <div class="col-md-4">
                        Mobile:
                    </div>
                    <div class="col-md-8">
                        <% Response.Write(seller.CellPhone); %>
                    </div>
                    <div class="clear"></div>
                    <div class="col-md-4">
                        Email:
                    </div>
                    <div class="col-md-8">
                        <% Response.Write(seller.Email); %>
                    </div>
                    <div class="clear"></div>
                    <%
                        if (!financial.LeaseOrFinance.Equals("c"))
                        {
                    %>
                    <hr class="hred" />
                    <div>
                        <h4>Lease/Finance information</h4>
                        <% Response.Write(financial.Summary); %>
                    </div>
                    <%} %>
                    <div class="clear25"></div>
                </div>
                <div class="clear"></div>
                <hr class="hred" />

                <div class="col-md-12">
                    <h4>Vehicle Features</h4>
                    <%
                        List<eMonthleys.BLL.FeaturesOfVehicle> vf = eMonthleys.BLL.FeaturesOfVehicle.GetAllFeaturesOfVehicle(vehicle.Id);
                        if (vf != null)
                        {
                            var fc = (from f in vf
                                      select f.FeatureType).Distinct().ToArray();
                            foreach (string vc in fc)
                            {
                                Response.Write("<div class='col-md-3'><h5>" + vc + "</h5>");
                                var vfl = (from s in vf
                                           where s.FeatureType == vc
                                           select s.Feature).ToArray();
                                Response.Write("<ul>");
                                foreach (string t in vfl)
                                {
                                    Response.Write("<li>" + t + "</li>");
                                }
                                Response.Write("</ul></div>");
                            }
                        }
                    %>
                    <br />
                </div>
                <div class="clear"></div>
            </div>
            <div class="clear25"></div>
            <%       
                    }
                }
            %>
            <div class="centered">
                <asp:Panel ID="pnlRepostBiWeekly" runat="server" Visible="false" CssClass="col-md-2">
                    <button id="BtnRepostBiWeekly" class="btn btn-primary" type="button"
                        onclick="$('#paymentModal').modal('show');">
                        Repost with Bi-Weekly Pay Cycle</button>
                </asp:Panel>
                <asp:Panel ID="pnlRepostMonthly" runat="server" Visible="false" CssClass="col-md-2">
                    <button id="BtnRepostMonthly" class="btn btn-primary" type="button"
                        onclick="$('#paymentModal').modal('show');">
                        Repost with Monthly Pay Cycle</button>
                </asp:Panel>
                <div class="col-md-6">
                    <asp:Button ID="BtnModify" runat="server" CausesValidation="false" Text="Modify Ad" CssClass="btn btn-primary" OnClick="BtnModify_Click" />
                    <asp:Button ID="BtnBack" runat="server" CausesValidation="false" Text="Go Back" CssClass="btn btn-primary" OnClick="BtnBack_Click" />
                </div>
            </div>
            <div class="clear25"></div>
        </div>
    </div>
    <!-- Modal -->
    <div class="modal fade" id="paymentModal" tabindex="-1" role="dialog" aria-labelledby="paymentModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="paymentModalLabel" runat="server"></h4>
                    <asp:HiddenField ID="hfPayCycle" runat="server" />
                </div>
                <div class="modal-body">
                    <asp:Label ID="lblBiWeeklyPayment" runat="server" AssociatedControlID="txtBiWeeklyPayment" CssClass="col-md-3 control-label">Payment:</asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox runat="server" ID="txtBiWeeklyPayment" CssClass="dollarvalue form-control" ValidationGroup="vgLease" />
                        <asp:RequiredFieldValidator ID="rfvMonthly" runat="server" ErrorMessage="Please enter payment with tax."
                            ControlToValidate="txtBiWeeklyPayment" Text="*" ValidationGroup="vgLease" CssClass="text-danger"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Please enter a numeric value for payment."
                            Text="*" CssClass="text-danger" ValidationGroup="vgLease" ControlToValidate="txtBiWeeklyPayment" ValidationExpression="\d+(\.\d{1,2})?"></asp:RegularExpressionValidator>
                    </div>
                    <asp:Label ID="Label25" runat="server" CssClass="col-md-2" Text="(incl. Tax)"></asp:Label>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="BtnSublit" runat="server" CausesValidation="false" CssClass="btn btn-primary" Text="Submit" OnClick="BtnRepost_Click" />
                    <button type="button" class="Btn Btn-default" data-dismiss="modal">Cancel</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
