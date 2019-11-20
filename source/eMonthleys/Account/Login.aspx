<%@ Page Title="Sign in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="eMonthleys.Login" Async="true" %>

<%@ Register Src="~/controls/adsLeft.ascx" TagPrefix="uc1" TagName="adsLeft" %>
<%@ Register Src="~/controls/adsRight.ascx" TagPrefix="uc1" TagName="adsRight" %>

<asp:Content ID="Header1" ContentPlaceHolderID="HeaderContent" runat="server">
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

                if (currentRowStart !== topPostion) {
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

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <section class="withads">
    <div class="row">
        <article class="col-md-3">
            <uc1:adsLeft runat="server" ID="adsLeft" />
        </article>
        <article class="col-md-6 mainpanel">
            <h2><%: Title %></h2>

            <section id="loginForm">
                <div class="form-horizontal">
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <fieldset>
                        <legend></legend>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="txtUserId" CssClass="col-md-3 control-label">Email:</asp:Label>
                            <div class="col-md-8">
                                <asp:TextBox runat="server" ID="txtUserId" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUserId"
                                    CssClass="text-danger" ErrorMessage="The user name field is required." />
                            </div>
                            <div class="clear"></div>
                            <asp:Label runat="server" AssociatedControlID="txtPassword" CssClass="col-md-3 control-label">Password:</asp:Label>
                            <div class="col-md-8">
                                <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword" CssClass="text-danger" ErrorMessage="The Password field is required." />
                            </div>
                        </div>
                    </fieldset>
                    <div class="form-group centered paddingtop10">
                        <asp:Button ID="BtnLogin" runat="server" OnClick="BtnLogin_Click" Text="Sign in" CssClass="btn btn-primary" />
                    </div>
                </div>
                <p>
                    <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled" NavigateUrl="~/Account/Register.aspx">
                        Register</asp:HyperLink>&nbsp;if you don't have an account. 
                    I&nbsp;<asp:HyperLink runat="server" ID="HyperLink1" ViewStateMode="Disabled" NavigateUrl="~/Account/PasswordHelp.aspx">forgot</asp:HyperLink>&nbsp;my password!
                </p>
            </section>
        </article>
        <article class="col-md-3">
            <uc1:adsRight runat="server" ID="adsRight" />
        </article>
        <div class="clear"></div>
    </div>
        </section>
</asp:Content>
