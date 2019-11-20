<%@ Page Title="emonthlies - Home page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="eMonthleys.Default" %>

<asp:Content ID="Header1" ContentPlaceHolderID="HeaderContent" runat="server">
    <style>
        body {
            padding-top: 50px;
            padding-bottom: 20px;
            background-color: #002664;
            background-image: url('data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAGQAAABkCAYAAABw4pVUAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAA2ZpVFh0WE1MOmNvbS5hZG9iZS54bXAAAAAAADw/eHBhY2tldCBiZWdpbj0i77u/IiBpZD0iVzVNME1wQ2VoaUh6cmVTek5UY3prYzlkIj8+IDx4OnhtcG1ldGEgeG1sbnM6eD0iYWRvYmU6bnM6bWV0YS8iIHg6eG1wdGs9IkFkb2JlIFhNUCBDb3JlIDUuMy1jMDExIDY2LjE0NTY2MSwgMjAxMi8wMi8wNi0xNDo1NjoyNyAgICAgICAgIj4gPHJkZjpSREYgeG1sbnM6cmRmPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjIj4gPHJkZjpEZXNjcmlwdGlvbiByZGY6YWJvdXQ9IiIgeG1sbnM6eG1wTU09Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9tbS8iIHhtbG5zOnN0UmVmPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvc1R5cGUvUmVzb3VyY2VSZWYjIiB4bWxuczp4bXA9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC8iIHhtcE1NOk9yaWdpbmFsRG9jdW1lbnRJRD0ieG1wLmRpZDo5NDJDNDIyQTc2RDlFMzExOUQyM0ZBQjc1RDQyOEUxQiIgeG1wTU06RG9jdW1lbnRJRD0ieG1wLmRpZDpBRTcyRjE4M0RFMTkxMUUzOEM1MUFCNEQzOTdBQjE1RSIgeG1wTU06SW5zdGFuY2VJRD0ieG1wLmlpZDpBRTcyRjE4MkRFMTkxMUUzOEM1MUFCNEQzOTdBQjE1RSIgeG1wOkNyZWF0b3JUb29sPSJBZG9iZSBQaG90b3Nob3AgQ1M2IChXaW5kb3dzKSI+IDx4bXBNTTpEZXJpdmVkRnJvbSBzdFJlZjppbnN0YW5jZUlEPSJ4bXAuaWlkOjE4NTY0OEYyMDNEQkUzMTE4Q0JFQjJBQkY3RkFCNDAyIiBzdFJlZjpkb2N1bWVudElEPSJ4bXAuZGlkOjk0MkM0MjJBNzZEOUUzMTE5RDIzRkFCNzVENDI4RTFCIi8+IDwvcmRmOkRlc2NyaXB0aW9uPiA8L3JkZjpSREY+IDwveDp4bXBtZXRhPiA8P3hwYWNrZXQgZW5kPSJyIj8++QUdbAAAAylJREFUeNrsnLlrFFEcx99kV6PE1SSIggcGRBsNUSy0EIP/QAob7VUkCIKdhQqaUgRtxE60iIh4VWJjgkW8EEE8UHFZwQNBt3BZvPbw+zJvcaIT18C8yWI+H/hAnN018D7MGfYX1Ot1A61DG0tAECAIQYAgBAGCEAQIQhAgCBCEIEAQggBBCAIEmcFkk/qPCoWCKZVKpq1tvHEgm/5tuFarmVwuZ3p6eiiRdBAbo1gsmkwmY/+5XG6VZ2PeukxukcPVapUCvg5Zds+wMZzv5V55XnZFtvfLMdnZ2Ob2KPB8DvkhL8odckRukvvkddklr7H06Z/Ub8ivsk/ekiflXHlTvmXp0w/ySD53P8+KbL/KsqcfpF0OyZUxr+2R61n69IL0ucPSQTkv5vWNckwOch/k8bLXsUEel4vlE2mva1fLOe71N/YK2e1BB1ywE+4iADwEeSEH5PfGvZ88JXe6EAPuPfZmZXYkFHgKUorZdsUFeSAfsuTTd5XV4K787O5BoAWCfHQ3gqMsd4qHLPug8C/PpobcCX0C9v32c+AhiH1qO77LxT+bejlZxMbnICTgG1Qz7xwCBCEIEIQgQBCCAEGAIAQBghAECEIQIAhBgCBAEIIAQQgCBCEIEIQgQBAgCEGAIAQBghAE/JFlCf6kXC6bSqVigiD458/YLz5ls1nT0dFBkKTJ5/PR2V+dJvxe/adJ3r5UvqtWq/Xu7m7T29vLISvx4/jE2V/t8oyb9WV+85DcJetJzf4iSHM+2KOYCb9nP+i2LZQX5FETznXhHJIywyYcxmbHhPTLNXKtCee53CdI+tgBbK/lCrk9sv2yCYe0cdmbMgvMr4E6URKfYkSQ5myTt+WqmNeOyNNyPkH8s8gt9iW5ZJL32BsVOyHvjtzMOcR/kGdytwnnflXkfrnOhEOij8lXJpwn2en2IDuC6gtB/PDYGcUuvJ2umpeH5TfOIdPLiNs7Rn3EIMjUeer0NoyNIFPDDgSzQz7v+foFnENiaDKM7ZwLM7FUQsPYmJcVw3Q+fidIi8E5hCBAEIIAQQgCBCEIEIQgQBAgCEGAIAQBgvzv/BRgAByXtBNn4sI+AAAAAElFTkSuQmCC') /*/images/stars3.png*/;
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

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="splash">
            <img src="/images/slogan.png" alt="the easy way to buy your next car" class="img-responsive imgcentered" />
            <div class="clear25"></div>
            <div class="centered">
                <div class="clear25"></div>
                <p class="white bold splashbg">Where Private Ads are always free!</p>
                <div class="clear25"></div>
                <button id="Btn" type="button" onclick="self.location='Search.aspx';" value="Continue" class="Btn Btn-default">Continue</button>
            </div>
                 <div class="clear25"></div>
       </div>
    </div>
</asp:Content>
