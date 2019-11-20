<%@ Page Title="Item details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VehicleDetails.aspx.cs" Inherits="eMonthleys.VehicleDetails" %>

<%@ Import Namespace="System.Reflection" %>
<%@ Register Src="~/controls/singleAd.ascx" TagPrefix="uc1" TagName="singleAd" %>


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
    <script type="text/javascript" src="/scripts/jquery.fancybox.js?v=2.1.5"></script>
    <script type="text/javascript" src="/scripts/jquery.fancybox-buttons.js?v=1.0.5"></script>
    <link rel="stylesheet" type="text/css" href="/content/jquery.fancybox.css?v=2.1.5" media="screen" />
    <link rel="stylesheet" type="text/css" href="/content/jquery.fancybox-buttons.css?v=1.0.5" media="screen" />
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
    <script type="text/javascript">
        function printdiv(printpage) {
            var cssStr = "<link href='https://www.emonthlies.com/Content/Site.css' rel='stylesheet' /><link href='https://www.emonthlies.com/Content/bootstrap.css' rel='stylesheet' />";
            var headstr = "<html><head><title></title>" + cssStr + "</head><body>";
            var footstr = "</body>";
            var newstr = document.getElementById(printpage).innerHTML;
            var oldstr = document.body.innerHTML;
            document.body.innerHTML = headstr + newstr + footstr;
            window.print();
            document.body.innerHTML = oldstr;
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid mainpanel">
        <%
            var VehicleId = Convert.ToInt32(Request.QueryString["id"]);
            var FinId = Convert.ToInt32(Request.QueryString["fid"]);
            List<eMonthleys.BLL.Search> vehicle = new List<eMonthleys.BLL.Search>();
            List<eMonthleys.BLL.Search> searchresutls = new List<eMonthleys.BLL.Search>();
            if (Session["SearchResults"] == null)
            {
                vehicle = eMonthleys.BLL.Search.SelectByVehicleId(VehicleId, FinId);
                searchresutls = vehicle;
            }
            else
                searchresutls = (List<eMonthleys.BLL.Search>)Session["SearchResults"];

            if (searchresutls != null)
            {
                var result = (from s in searchresutls
                              where s.VehicleId.Equals(VehicleId)
                              select s).ToList();
                if (result != null)
                {
                    string heading = result[0].ModelYear.ToString();
                    if (result[0].Manufacturer == "Other")
                        heading += " " + result[0].MakeOther;
                    else
                        heading += " " + result[0].Manufacturer;
                    if (result[0].Model == "Other")
                        heading += " " + result[0].ModelOther;
                    else
                        heading += " " + result[0].Model;
        %>
        <h1><%= heading %></h1>
        <div class="col-md-12">
            <%--Pictures--%>
            <div class="row">
                <%
                    var imgs = eMonthleys.BLL.VehicleImage.SelectByVehicleId(result[0].VehicleId);
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
                <a href="<%=img.ToString() %>" class="fancybox-buttons" data-fancybox-group="button">
                    <img src="/thumbnail.ashx?pic=<%=img.ToString()%>&size=80" class="thumb" alt="<%= result[0].Model %>" /></a>
                <%
                                }
                            }
                        }
                        if (!string.IsNullOrEmpty(imgs.Video))
                        {
                            pnlVideo.Visible = true;
                            vSrc.Attributes.Add("src", imgs.Video);
                            vSrc.Attributes.Add("type", imgs.VideoFormat);
                   
                %>
                <img id="video" src="/images/video-play.png" class="thumb link" alt="<%= result[0].Model%>" onclick="$('#myModal').modal('show');" />
                <%
                        }
                        else
                            pnlVideo.Visible = false;
                %>
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
                                    <asp:Panel ID="pnlVideo" runat="server" Visible="false">
                                        <video controls style="width: 320px; height: 240px">
                                            <source id="vSrc" runat="server" />
                                        </video>
                                    </asp:Panel>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="Btn Btn-default" data-dismiss="modal">Close</button>
                            </div>
                        </div>
                    </div>
                </div>
                <%
                    } %>
                <div class="clear"></div>
                Click on images to enlarge.<br />
                Mobile devices please rotate screen for best viewing.
            </div>
        </div>
        <div class="clear25"></div>



        <div class="col-sm-6">
            <%--Vehicle information--%>
            <div id="div_print">
                <div class="col-xs-12">
                    <div class="row">
                        <h4>Vehicle information</h4>
                        <div class="col-xs-4">
                            Year:
                        </div>
                        <div class="col-xs-6">
                            <% Response.Write(result[0].ModelYear); %>
                        </div>
                        <div class="clear"></div>
                        <div class="col-xs-4">
                            Make:
                        </div>
                        <div class="col-xs-6">
                            <% if (result[0].Manufacturer == "Other")
                                   Response.Write(result[0].MakeOther);
                               else
                                   Response.Write(result[0].Manufacturer); 
                            %>
                        </div>
                        <div class="clear"></div>
                        <div class="col-xs-4">
                            Model:
                        </div>
                        <div class="col-xs-6">
                            <% if (result[0].Model == "Other")
                                   Response.Write(result[0].ModelOther);
                               else
                                   Response.Write(result[0].Model);
                            %>
                        </div>
                        <div class="clear"></div>
                        <div class="col-xs-4">
                            Trim:
                        </div>
                        <div class="col-xs-6">
                            <% if (result[0].ModelTrim == "Other")
                                   Response.Write(result[0].OtherTrim);
                               else
                                   Response.Write(result[0].ModelTrim); 
                            %>
                        </div>
                        <div class="clear"></div>
                        <div class="col-xs-4">
                            Category:
                        </div>
                        <div class="col-xs-6">
                            <% Response.Write(result[0].VehicleCategory);%>
                        </div>
                        <div class="clear"></div>
                        <div class="col-xs-4">
                            Body colour:
                        </div>
                        <div class="col-xs-6">
                            <% Response.Write(result[0].ExteriorColor); %>
                        </div>
                        <div class="clear"></div>
                        <div class="col-xs-4">
                            Interior colour:
                        </div>
                        <div class="col-xs-6">
                            <% Response.Write(result[0].InteriorColor); %>
                        </div>
                        <div class="clear"></div>
<%--                        <div class="col-xs-4">
                            Engine:
                        </div>
                        <div class="col-xs-6">
                            <% Response.Write(result[0].Engine); %> L
                        </div>
                        <div class="clear"></div>
                        <div class="col-xs-4">
                            Cylinder:
                        </div>
                        <div class="col-xs-6">
                            <% Response.Write(result[0].Cylinder); %>
                        </div>
                        <div class="clear"></div>--%>
                        <div class="col-xs-4">
                            Transmission:
                        </div>
                        <div class="col-xs-6">
                            <% Response.Write(result[0].Transmission); %>
                        </div>
                        <div class="clear"></div>
                        <div class="col-xs-4">
                            Fuel type:
                        </div>
                        <div class="col-xs-6">
                            <% Response.Write(result[0].FuelType); %>
                        </div>
                        <div class="clear"></div>
                        <div class="col-xs-4">
                            Displacement:
                        </div>
                        <div class="col-xs-6">
                            <% Response.Write(result[0].Displacement); %>
                        </div>
                        <div class="clear"></div>
                        <div class="col-xs-4">
                            Odometer reading:
                        </div>
                        <div class="col-xs-6">
                            <% if (result[0].VehicleCondition == "new")
                                    Response.Write("New");
                               else
                                    Response.Write(result[0].CurrentMileage.ToString("N0")); %>
                        </div>
                        <div class="clear"></div>
                        <div class="col-xs-4">
                            Type of wheels:
                        </div>
                        <div class="col-xs-6">
                            <% Response.Write(result[0].Wheels);
                               if (result[0].ChromeWheels)
                               {
                                   Response.Write("<br />- Chrome Wheels");
                               }
                            %><br />
                        </div>
                        <div class="clear"></div>
                        <div class="col-xs-4">
                            Type of tires:
                        </div>
                        <div class="col-xs-6">
                            <% Response.Write(result[0].Tires);
                               if (result[0].ExtraWinterTires)
                               {
                                   Response.Write("<br />- Extra set of winter tires");
                               }
                            %>
                        </div>
                        <%
                    if (result[0].Comments != "")
                    { %>
                        <div class="clear"></div>
                        <div class="col-xs-4">
                            Additional Information:
                        </div>
                        <div class="col-xs-6">
                            <% Response.Write(result[0].Comments);
                            %>
                        </div>
                        <%}
                        %>
                        <div class="clear"></div>
                    </div>
                    <%-- Financial details --%>

                    <div class="row">
                        <h4>Financial details</h4>
                        <div class="col-xs-4 bold">
                            Type of Sales price:
                        </div>
                        <div class="col-xs-6 bold">
                            <% 
                    switch (result[0].LeaseOrFinance)
                    {
                        case "c":
                            Response.Write("Cash purchase");
                            if (result[0].CustomerType == "Private")
                                Response.Write(" (Plus local taxes)");
                            break;
                        case "l":
                            Response.Write("Leasing (On approved credit)");
                            break;
                        case "f":
                            Response.Write("Financing (On approved credit)");
                            break;
                    }
                            %>
                        </div>
                        <div class="clear"></div>
                        <div class="col-xs-4 bold">
                            Purchase price:
                        </div>
                        <div class="col-xs-6 bold">
                            <% Response.Write(result[0].PurchasePrice.ToString(@"$#,##0.00;($#,##0.00\)"));
                               if (result[0].CustomerType == "Business")
                                   Response.Write(" (incl. tax)");
                               %> 
                        </div>
                        <div class="clear"></div>
                        <%if (result[0].LeaseOrFinance.Equals("l") || result[0].LeaseOrFinance.Equals("f"))
                          { 
                        %>
<%--                        <div class="col-xs-4">
                            Lien holder:
                        </div>
                        <div class="col-xs-6">
                            <% Response.Write(result[0].LienHolder); %>
                        </div>
                        <div class="clear"></div>--%>
                        <div class="col-xs-4">
                            Payment cycle:
                        </div>
                        <div class="col-xs-6">
                            <% Response.Write(result[0].PaymentCycle); %>
                        </div>
                        <div class="clear"></div>
                        <div class="col-xs-4 bold">
                            Payment:
                        </div>
                        <div class="col-xs-6 bold">
                            <% Response.Write(result[0].PaymentWithTax.ToString(@"$#,##0.00;($#,##0.00\)")); %> (incl. tax)
                        </div>
                        <div class="clear"></div>
                        <div class="col-xs-4">
                            Total due on delivery:
                        </div>
                        <div class="col-xs-6">
                            <% Response.Write(result[0].OriginalDown.ToString(@"$#,##0.00;($#,##0.00\)")); %> (incl. tax)
                        </div>
                        <div class="clear"></div>
                        <%if (result[0].LeaseOrFinance.Equals("l"))
                          { 
                        %>
                        <div class="col-xs-4">
                            Security deposit::
                        </div>
                        <div class="col-xs-6">
                            <% Response.Write(result[0].SecurityDeposit.ToString(@"$#,##0.00;($#,##0.00\)")); %> (incl. tax)
                        </div>
                        <div class="clear"></div>
                        <div class="col-xs-4">
                            Purchase Option at end of lease:
                        </div>
                        <div class="col-xs-6">
                            <% Response.Write(result[0].PoEndOfLease); %>
                        </div>
                        <div class="clear"></div>
                        <div class="col-xs-4">
                            Total Kilometre allowance:
                        </div>
                        <div class="col-xs-6">
                            <% Response.Write(result[0].KmAllowance); %>
                        </div>
                        <div class="clear"></div>
                        <div class="col-xs-4">
                            Excess km charge:
                        </div>
                        <div class="col-xs-6">
                            <% Response.Write(result[0].ExcessKmCharge.ToString(@"$#,##0.00;($#,##0.00\)")); %> (incl. tax)
                        </div>
                        <div class="clear"></div>
                        <%} %>
                        <div class="col-xs-4">
                            Term of loan (months):
                        </div>
                        <div class="col-xs-6">
                            <% Response.Write(result[0].LeaseTerm); %>
                        </div>
                        <div class="clear"></div>
                        <%if (result[0].LeaseOrFinance.Equals("l"))
                          { 
                        %>
                        <div class="col-xs-4">
                            Lease expiry date:
                        </div>
                        <div class="col-xs-6">
                            <% if (result[0].LeaseExpiry != null)
                                   Response.Write(Convert.ToDateTime(result[0].LeaseExpiry.ToString()).ToShortDateString());
                            %>
                        </div>
                        <div class="clear"></div>
                        <div class="col-xs-4">
                            Buyback/Residual value:
                        </div>
                        <div class="col-xs-6">
                            <% Response.Write(result[0].BuyBack.ToString(@"$#,##0.00;($#,##0.00\)")); %> (incl. tax)
                        </div>
                        <div class="clear"></div>
                        <%}
                          if (result[0].LeaseOrFinance.Equals("f"))
                          {
                        %>
                        <div class="col-xs-4">
                            Balloon payment:
                        </div>
                        <div class="col-xs-6">
                            <% Response.Write(result[0].Balloon.ToString(@"$#,##0.00;($#,##0.00\)")); %> (incl. tax)
                        </div>
                        <div class="clear"></div>
                        <%
                          }
                          } %>
                    </div>

                    <%--Seller information and Vehicle location--%>
                    <div class="row">
                        <h4>Seller information and Vehicle location</h4>
                        <div class="col-xs-4">
                            Name:
                        </div>
                        <div class="col-xs-6">
                            <% Response.Write(result[0].FirstName + " " + result[0].LastName); %>
                        </div>
                        <div class="clear"></div>
                        <div class="col-xs-4">
                            City:
                        </div>
                        <div class="col-xs-6">
                            <% Response.Write(result[0].City); %>
                        </div>
                        <div class="clear"></div>
                        <div class="col-xs-4">
                            Province:
                        </div>
                        <div class="col-xs-6">
                            <% Response.Write(result[0].State); %>
                        </div>
                        <div class="clear"></div>
                        <div class="col-xs-4">
                            Phone Number:
                        </div>
                        <div class="col-xs-6">
                            <% Response.Write(result[0].Phone); %>
                        </div>
                        <div class="clear"></div>
                        <div class="col-xs-4">
                            Mobile:
                        </div>
                        <div class="col-xs-6">
                            <% Response.Write(result[0].CellPhone); %>
                        </div>
                        <div class="clear"></div>
                        <div class="col-xs-4">
                            Email:
                        </div>
                        <div class="col-xs-6">
                            <a href="mailto:<% Response.Write(result[0].Email); %>?subject=Vehicle listed on eMonthlies"><% Response.Write(result[0].Email); %></a>
                        </div>
                        <div class="clear"></div>
                        <%
                    if (!result[0].LeaseOrFinance.Equals("c"))
                    { 
                        %>
                        <hr class="hred" />
                        <%
                        if (result[0].Summary != "")
                        { %>
                        <div>
                            <h4>Additional Leasing/Financial information:</h4>
                            <% Response.Write(result[0].Summary); %>
                        </div>
                        <%}
                    }
                    %>
                        <div class="clear25"></div>
                    </div>

                </div>
                <hr class="hred" />
                <div class="col-xs-12">
                    <h4>Vehicle Features</h4>
                    <%
                          List<eMonthleys.BLL.FeaturesOfVehicle> vf = eMonthleys.BLL.FeaturesOfVehicle.GetAllFeaturesOfVehicle(result[0].VehicleId);
                          if (vf != null)
                          {

                              var fc = (from f in vf
                                        select f.FeatureType).Distinct().ToArray();
                              foreach (string vc in fc)
                              {
                                  Response.Write("<h5>" + vc + "</h5>");
                                  var vfl = (from s in vf
                                             where s.FeatureType == vc
                                             select s.Feature).ToArray();
                                  Response.Write("<ul>");
                                  foreach (string t in vfl)
                                  {
                                      Response.Write("<li>" + t + "</li>");
                                  }
                                  Response.Write("</ul>");
                              }
                          }
                          else
                          {
                              Response.Write("Features list not available yet.");
                          }
                    %>
                    <br />
                </div>
            </div>
            <p class="centered">
                <input name="b_print" type="button" class="btn btn-primary" onclick="printdiv('div_print');" value=" Print ">
            </p>
            <div class="clear25"></div>
            <div class="adcentersm center-block">
                <uc1:singleAd runat="server" ID="singleAd" />
            </div>
            <div class="clear25"></div>
        </div>
        <div class="col-sm-4">
            <div class="clear25"></div>
            <div class="singlecentered">
                <%
                               var adsRight = eMonthleys.BLL.CustomerAd.Get6SmallAdsRandom();
                               if (adsRight != null)
                               {
                                   for (int i = 0; i < adsRight.Count; i++)
                                   {
                                       string rdivid = string.Concat("rdiv", i);
                %>
                <div class="adsingle" id="<%=rdivid %>" style="cursor: pointer;">
                    <script>
                        $(function () {
                            $("#sliderRight<%=i%>").responsiveSlides({
                                maxwidth: 250,
                                speed: 500
                            });
                        });
                    </script>
                    <ul class="rslides" id="sliderRight<%=i%>">
                        <%
                                   PropertyInfo[] props = adsRight[i].GetType().GetProperties();
                                   foreach (PropertyInfo p in props)
                                   {
                                       if (p.Name.Contains("Img") && p.ToString() != null)
                                       {
                                           object img = p.GetValue(adsRight[i], null);
                                           if (img.ToString() != "")
                                           {
                        %>
                        <li>
                            <img src="<%=img.ToString() %>" alt="" width="250" height="200" class="img-responsive"></li>
                        <%
                                           }
                                       }
                                   } %>
                    </ul>
                </div>
                <script type="text/javascript">
                    $(document).delegate('#<%=rdivid%>', "click", function () {
                        window.open('<%=adsRight[i].URL%>', '_blank', 'toolbar=1, location=1, menubar=1, resizable=1, scrollbars=1');
                    });
                </script>
                <div class="clear25"></div>
                <%}
                               var remaining = 6 - adsRight.Count;
                               if (remaining > 0)
                               {
                                   for (int i = 0; i < remaining; i++)
                                   {
                %>
                <div class="adsingle">
                    <script>
                        $(function () {
                            $("#sliderRightrem<%=i%>").responsiveSlides({
                                maxwidth: 250,
                                speed: 500
                            });
                        });
                    </script>
                    <ul class="rslides" id="sliderRightrem<%=i%>">
                        <li>
                            <img src="/imgs/emonthlies/smallslide1.png" alt="" width="250" height="200" class="img-responsive"></li>
                        <li>
                            <img src="/imgs/emonthlies/smallslide2.png" alt="" width="250" height="200" class="img-responsive"></li>
                        <li>
                            <img src="/imgs/emonthlies/smallslide3.png" alt="" width="250" height="200" class="img-responsive"></li>
                    </ul>
                </div>
                <div class="clear25"></div>
                <%
                                   }
                               }
                           }
                           else
                           {
                               for (int i = 0; i < 6; i++)
                               {
                %>
                <div class="adsingle">
                    <script>
                        $(function () {
                            $("#sliderRight<%=i%>").responsiveSlides({
                                maxwidth: 250,
                                speed: 500
                            });
                        });
                    </script>
                    <ul class="rslides" id="sliderRight<%=i%>">
                        <li>
                            <img src="/imgs/emonthlies/smallslide1.png" alt="" width="250" height="200" class="img-responsive"></li>
                        <li>
                            <img src="/imgs/emonthlies/smallslide2.png" alt="" width="250" height="200" class="img-responsive"></li>
                        <li>
                            <img src="/imgs/emonthlies/smallslide3.png" alt="" width="250" height="200" class="img-responsive"></li>
                    </ul>
                </div>
                <div class="clear25"></div>
                <%
                               }
                           } %>
            </div>
        </div>
        <div class="clear25"></div>
    </div>

    <%       
                }
            }
    %>
</asp:Content>
