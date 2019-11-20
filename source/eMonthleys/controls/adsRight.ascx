<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="adsRight.ascx.cs" Inherits="eMonthleys.adsRight" %>
<%@ Import Namespace="System.Reflection" %>

<div class="col-md-3">

    <%
        if (!eMonthleys.Utils.Helpers.isMobileBrowser())
        {
            var adsRight = eMonthleys.BLL.CustomerAd.GetAllCustomersAdsByType("S");
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
                <img src="<%=img.ToString() %>" alt="" width="250" height="200"></li>
            <%
                            }
                    }
                } %>
        </ul>
    </div>
    <script type="text/javascript">
        $(document).delegate('#<%=rdivid%>', "click", function () {
            var url = '<%=adsRight[i].URL%>';
            if (url != '')
                window.open(url, '_blank', 'toolbar=1, location=1, menubar=1, resizable=1, scrollbars=1');
        });
    </script>
    <div class="clear25"></div>
    <%}
                var remaining = 3 - adsRight.Count;
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
                <img src="/imgs/emonthlies/smallslide1.png" alt="" width="250" height="200"></li>
            <li>
                <img src="/imgs/emonthlies/smallslide2.png" alt="" width="250" height="200"></li>
        </ul>
    </div>
    <div class="clear25"></div>
    <%
                }
            }
            }
            else
            {
                for (int i = 0; i < 3; i++)
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
                <img src="/imgs/emonthlies/smallslide1.png" alt="" width="250" height="200"></li>
            <li>
                <img src="/imgs/emonthlies/smallslide2.png" alt="" width="250" height="200"></li>
            <li>
                <img src="/imgs/emonthlies/smallslide3.png" alt="" width="250" height="200"></li>
        </ul>
    </div>
    <div class="clear25"></div>
    <%
            }
        }
        } %>
</div>
