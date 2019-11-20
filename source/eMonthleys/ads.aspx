<%@ Page Title="Advertise With Us" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ads.aspx.cs" Inherits="eMonthleys.ads" %>

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
                <h2>Advertise With Us</h2>
                <p>
                    Large ads appear as rotating banners in the top section of the website for $199.00.<br />
                    Small ads appear rotating on either left or right side of the page for $99.00.<br />
                    All ads are randomly picked to accomodate volume.
                </p>
                <div class="alert alert-info">
                    <p>Please note the size and file format for the ads <strong>must</strong> be as follows:</p>
                    <ul>
                        <li>Large ad: 1130 x 200 pixels (maximum file size 200 Kb per image)</li>
                        <li>Small ad: 250 x 200 pixels (maximum file size 200 Kb per image)</li>
                        <li>Allowed image formats are: GIF, JPEG, JPG, PNG</li>
                    </ul>
                    <p class="bold">
                        If your pictures do not conform to the correct size as prescribed above you may have to resize the pictures before uploading. We recommend you review our <a href="/TermsOfUse.aspx">terms of use</a> prior to placing any business ads.
                    </p>
                    <p>
                        We also provide graphics services at an added cost. Please contact <a href="mailto:sales@emonthlies.com">sales@emonthlies.com</a>.
                    </p>
                </div>
                <p>
                    <a href="~/account/Advertise.aspx" runat="server" id="Adlink" class="btn btn-primary">Place Your Ad With Us</a>
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
