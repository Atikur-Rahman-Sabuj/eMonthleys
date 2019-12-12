<%@ Page Title="Sell Your Car or Item" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="sellitem.aspx.cs" Inherits="eMonthleys.sellitem" %>

<%@ Register Src="~/controls/adsLeft.ascx" TagPrefix="uc1" TagName="adsLeft" %>
<%@ Register Src="~/controls/adsRight.ascx" TagPrefix="uc1" TagName="adsRight" %>

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
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="withads">
        <div class="row">
            <article class="col-md-3">
                <uc1:adsLeft runat="server" ID="adsLeft" />
            </article>
            <article class="col-md-6 mainpanel">
                <h2>Sell Your Car or Item</h2>
                <div class="pricing bold white">
                    <h3 class="white">Ad pricing</h3>
                    <p>Private Ads are free</p>
                    <p>$19.99 including tax for 1 months (Business)</p>
                    <p></p>
                </div>
                <p>
                    You can upload upto twenty pictures for your vehicle.<br />
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
                <p>
                    <%if (!Page.User.Identity.IsAuthenticated)
                        {  %>
                    <a href="~/account/AddVehicle.aspx" runat="server" id="Adlink" class="btn btn-primary">Please sign in to place your ad.</a>
                    <%
                        }
                        else
                        { %>
                    <a href="~/account/AddVehicle.aspx" runat="server" id="A1" class="btn btn-primary">Place your ad</a>
                    <%} %>
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
