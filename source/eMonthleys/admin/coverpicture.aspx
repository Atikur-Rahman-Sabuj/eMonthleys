<%@ Page Title="Cover Picture" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="coverpicture.aspx.cs" Inherits="eMonthleys.admin.coverpicture" %>



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
        .sa-label, .sa-cover-div{
            margin-top:5px;
        }
    </style>

    

</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="background:white;padding:20px; padding-bottom:33px">
        <div class="form-group">
            <asp:Label ID="Label1"    runat="server" AssociatedControlID="FileUpload1" CssClass="col-md-3 control-label sa-label">Upload new cover:</asp:Label>
            <div class="col-md-8 sa-cover-div">
                <asp:FileUpload ID="FileUpload1" runat="server" Width="95%" />
            </div>
            <div class="col-md-1">
                <asp:Button runat="server" CommandName="SaveButton" OnClientClick="preventMultipleSubmissions();" OnClick="OnSave_Click"  Text="Save" CssClass="btn btn-primary" />
            </div>
        </div>
    </div>
    <div>
        <img src="/images/cover/image.png" alt="cover picture" class="img-responsive imgcentered" />
    </div>
</asp:Content>
    
