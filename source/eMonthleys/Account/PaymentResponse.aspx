<%@ Page Title="Transaction receipt" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaymentResponse.aspx.cs" Inherits="eMonthleys.PaymentResponse" %>
<%@ Import Namespace="PayPal.PayPalAPIInterfaceService.Model" %>

<%@ Register Src="~/controls/adsLeft.ascx" TagPrefix="uc1" TagName="adsLeft" %>
<%@ Register Src="~/controls/adsRight.ascx" TagPrefix="uc1" TagName="adsRight" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <style>
        body {
            padding-top: 50px;
            padding-bottom: 20px;
            background-color: #002664;
            background-image: url('data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAGQAAABkCAMAAABHPGVmAAABGlBMVEX///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////9y/ChlAAAAXXRSTlMAAQIDBQYHCAkLDQ4PEBETFBYXGxwdHiUsLS4vMTM2ODw9P0tNUlNaXl9hYmRmaWprbm91dnt9f4KDiZicoqeoqbGyv8DFyMrP0NHT1Nba3N3g4eLj5fHy8/b3+v7/lRU/AAAA+UlEQVR4Xu3KWTcCARyG8TelYixRsmXLHiKRpcW+RMmuxvy//9cwczruXXgdF+/v5rl58D+IiIhICHxIryOQWgVR5KY2BGRftsFUtPpcodNOgmnKtU+zM3DVzZcDU/Sobb7rDHimr6zLzfeAZOay1bhzzV6bj8/FCDj6nVist2IfmT4nkYqAaNEuQJd43wNfdRZ843H8BhEREREREZHB4W6TIfCMnmeDlA7AVOvkkTi1BTAtmZ3cWyMGpoEn8x2CKv1gvhKYlt8s4JUdsIyU7VtzHiQTu5sba7fmHW/t7OfiICpYKwq2Sa8CunBjBXy5MfCFf/CIiIjIF5F2KYKWviR7AAAAAElFTkSuQmCC') /*/images/stars2.png*/;
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
    </script>
    <script type="text/javascript">
        function printdiv(printpage) {
            var cssStr = "<style>.col-md-4{width: 33.33333333%;} .col-md-8 {width: 66.66666667%;} .clear{clear: both; display: block; height: 5px; margin: 0; padding: 0;}</style>";
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
    <section class="withads">
        <div class="row">
            <article class="col-md-4">
                <uc1:adsLeft runat="server" ID="adsLeft" />
            </article>
            <article class="col-md-6 mainpanel">
                <h2><%: Title %></h2>
                <div>
                    <div>
                        <div id="response">
                            <%
                                DoDirectPaymentResponseType reply = (DoDirectPaymentResponseType)Session["Reply"] as DoDirectPaymentResponseType;
                                if (reply != null)
                              {
                                  CreditCardDetailsType item = (CreditCardDetailsType)Session["PaymentInfo"] as CreditCardDetailsType;
                            %>
                            <p>
                                <strong>Please print this receipt for your records.</strong><br />
                                An email has been sent out to you for verification of the ad. Please allow 12-24 hours for processing. 
                        You will receive another email with confirmation shorly. If you do not receive any email from emonthlies.com, 
                        please check your junk mail box and emonthlies.com to your white list.
                            </p>
                            <div id="div_print">
                                <fieldset>
                                    <legend>Payment details</legend>
                                    <div class="col-md-4">
                                        Product:
                                    </div>
                                    <div class="col-md-7">
                                        <%=Session["AdType"].ToString() %>
                                    </div>
                                    <%if (Request.QueryString["adtype"] != "Private")
                                      { %>
                                    <div class="clear"></div>
                                    <div class="col-md-4">
                                        Net amount:
                                    </div>
                                    <div class="col-md-7">
                                        <%=(Convert.ToDouble(reply.Amount.value) / 1.13).ToString(@"$#,##0.00;($#,##0.00\)") %>
                                    </div>
                                    <div class="clear"></div>
                                    <div class="col-md-4">
                                        Plus HST:
                                    </div>
                                    <div class="col-md-7">
                                        <%
                                          var hst = Convert.ToDouble(reply.Amount.value) - (Convert.ToDouble(reply.Amount.value) / 1.13);
                                  Response.Write (hst.ToString(@"$#,##0.00;($#,##0.00\)"));
                                  %>
                                    </div>
                                    <%} %>
                                    <div class="clear"></div>
                                    <div class="col-md-4">
                                        Payment amount:
                                    </div>
                                    <div class="col-md-7">
                                        <%=Convert.ToDouble(reply.Amount.value).ToString(@"$#,##0.00;($#,##0.00\)") %>
                                    </div>
                                    <div class="clear"></div>
                                    <div class="col-md-4">
                                        Purchase Date:
                                    </div>
                                    <div class="col-md-7">
                                        <%=DateTime.Parse(reply.Timestamp).ToShortDateString()%>
                                    </div>
                                    <div class="clear"></div>
                                 <div class="col-md-4">
                                    Credit Card Type:
                                </div>
                                <div class="col-md-7">
                                    <%=item.CreditCardType %>
                                </div>
                                <div class="clear"></div>
                                <div class="col-md-4">
                                    Last 4 digits of credit card number:
                                </div>
                                <div class="col-md-7">
                                    <%=item.CreditCardNumber.Remove(0, item.CreditCardNumber.Length - 4) %>
                                </div>
                                <div class="clear"></div>
                                <div class="col-md-4">
                                    Expiring:
                                </div>
                                <div class="col-md-7">
                                    <%= string.Concat(item.ExpMonth, "/", item.ExpYear)%>
                                </div>
                                <div class="clear"></div>
                                <div class="col-md-4">
                                    Payment Id:
                                </div>
                                <div class="col-md-7">
                                    <%= reply.TransactionID%>
                                </div>
                                <div class="clear"></div>
                                </fieldset>
                                <div class="clear25"></div>
                            </div>
                            <div class="pad10 centered">
                                <input name="b_print" type="button" class="btn btn-primary" onclick="printdiv('div_print');" value=" Print ">
                            </div>
                            <%
                              }
                              else
                              { %>
                            <p>There was error processing your payment. A transaction was not made.</p>
                            <%} %>
                        </div>
                    </div>
                </div>

                <br />

                <br />

            </article>
            <article class="col-md-4">
                <uc1:adsRight runat="server" ID="adsRight" />
            </article>
            <div class="clear"></div>
        </div>
    </section>
</asp:Content>
