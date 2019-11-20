<%@ Page Title="Oops!" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="eMonthleys.Error" %>
<%@ Register Src="~/controls/adsLeft.ascx" TagPrefix="uc1" TagName="adsLeft" %>
<%@ Register Src="~/controls/adsRight.ascx" TagPrefix="uc1" TagName="adsRight" %>

<asp:Content ID="Header1" ContentPlaceHolderID="HeaderContent" runat="server">
    <style>
        body {
            padding-top: 50px;
            padding-bottom: 20px;
            background-color: #002664;
            background-image: url("/images/stars2.png");
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
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section class="withads">
        <div class="row">
            <article class="col-md-3">
                <uc1:adsLeft runat="server" ID="adsLeft" />
            </article>
            <article class="col-md-6 mainpanel">
                <h2><%: Title %></h2>
                <p>
                    Lets start over again.
                </p>
                <div class="clear25"></div>
            </article>
            <article class="col-md-3">
                <uc1:adsRight runat="server" ID="adsRight" />
            </article>
            <div class="clear"></div>
        </div>
    </section>
</asp:Content>
