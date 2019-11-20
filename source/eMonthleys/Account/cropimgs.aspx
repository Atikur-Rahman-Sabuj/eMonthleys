<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cropimgs.aspx.cs" Inherits="eMonthleys.cropimgs" Title="Edit Images" %>

<%@ Register Assembly="Imazen.Crop" Namespace="Imazen.Crop" TagPrefix="ic" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" charset="UTF-8" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1" />
    <title>emonthlies - <%: Page.Title %></title>
    <script src="/Scripts/modernizr-2.8.3.js"></script>
    <link href="/Content/Site.css" rel="stylesheet" />
    <link href="/Content/bootstrap.css" rel="stylesheet" />
    <link href="/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <script src="/Scripts/jquery-1.11.1.min.js"></script>
    <script src="/Scripts/bootstrap.min.js"></script>
    <script type="text/javascript">
        function RefreshParent(adsize, id) {
            window.opener.location = "CheckOut.aspx?item=ad&size=" + adsize + "&id=" + id + "&promo=0";
            window.close();
        }

        function ImgRefresh(isrc) {
            var pic = document.getElementById("result");
            pic.src = isrc;
            d = new Date();
            $("#result").attr("src", isrc + "?" + d.getTime());
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="container-fluid mainpanel">
            <h1>Edit Images</h1>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Panel ID="pnlResult" runat="server" class="pad10  container mainpanel">
                        <asp:Literal ID="ltlErr" runat="server"></asp:Literal>
                        <p>Please select the area you would like to crop for your ad and click the "Crop" button under the picture. The cropped image will be automatically stored.</p>
                        <div class="centered">
                            <p>
                                <img id="result" src="" />
                            </p>
                            <p>
                                <asp:Label ID="message" runat="server" /><br />
                                <asp:HyperLink ID="cropped" runat="server" Target="_blank" />
                            </p>
                        </div>
                        <asp:Button ID="btnCheckout" runat="server" CssClass="btn btn-primary" CausesValidation="false" Text="Close & Check out" OnClick="btnCheckout_Click" Enabled="false" />
                    </asp:Panel>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="Button2" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="Button3" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="Button4" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
            <asp:Panel ID="pnlCrop1" runat="server" CssClass="container paddingtop10">
                <fieldset>
                    <legend>Image 1</legend>
                    <div class="centered">
                        <asp:Image ID="Image1" runat="server" />
                        <br />

                        <ic:CropImage ID="CropImage1" Image="Image1" runat="server" H="200" JpegQuality="100" />
                        <br />
                        <asp:Button ID="Button1" runat="server" Text="Crop" OnClick="btnCrop_Click" CssClass="btn btn-primary" CausesValidation="false" />
                    </div>
                </fieldset>
            </asp:Panel>
            <asp:Panel ID="pnlCrop2" runat="server" CssClass="container paddingtop10">
                <fieldset>
                    <legend>Image 2</legend>
                    <div class="centered">
                        <asp:Image ID="Image2" runat="server" />
                        <br />

                        <ic:CropImage ID="CropImage2" Image="Image2" runat="server" H="200" JpegQuality="100" />
                        <br />
                        <asp:Button ID="Button2" runat="server" Text="Crop" OnClick="btnCrop_Click" CssClass="btn btn-primary" CausesValidation="false" />
                    </div>
                </fieldset>
            </asp:Panel>
            <asp:Panel ID="pnlCrop3" runat="server" CssClass="container paddingtop10">
                <fieldset>
                    <legend>Image 3</legend>
                    <div class="centered">
                        <asp:Image ID="Image3" runat="server" />
                        <br />

                        <ic:CropImage ID="CropImage3" Image="Image3" runat="server" H="200" JpegQuality="100" />
                        <br />
                        <asp:Button ID="Button3" runat="server" Text="Crop" OnClick="btnCrop_Click" CssClass="btn btn-primary" CausesValidation="false" />
                    </div>
                </fieldset>
            </asp:Panel>
            <asp:Panel ID="pnlCrop4" runat="server" CssClass="container paddingtop10">
                <fieldset>
                    <legend>Image 4</legend>
                    <div class="centered">
                        <asp:Image ID="Image4" runat="server" />
                        <br />

                        <ic:CropImage ID="CropImage4" Image="Image4" runat="server" H="200" JpegQuality="100" />
                        <br />
                        <asp:Button ID="Button4" runat="server" Text="Crop" OnClick="btnCrop_Click" CssClass="btn btn-primary" CausesValidation="false" />
                    </div>
                </fieldset>
            </asp:Panel>
            <div class="pad10 centered">
            </div>
        </div>
    </form>
</body>
</html>
