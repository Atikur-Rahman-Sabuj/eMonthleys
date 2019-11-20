<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="adsLeft.ascx.cs" Inherits="eMonthleys.adsLeft" %>

<%@ Import Namespace="System.Reflection" %>

<div class="col-md-3">

    <%
        if (!eMonthleys.Utils.Helpers.isMobileBrowser())
        {
            var adsLeft = eMonthleys.BLL.CustomerAd.GetAllCustomersAdsByType("S");
            if (adsLeft != null)
            {
                for (int i = 0; i < adsLeft.Count; i++)
                {
                    string ldivid = string.Concat("ldiv", i);
                    
    %>
    <div class="adsingle" id="<%=ldivid %>" style="cursor: pointer;">
        <script>
            $(function () {
                $("#sliderLeft<%=i%>").responsiveSlides({
                    maxwidth: 250,
                    speed: 800
                });
            });
        </script>
        <ul class="rslides" id="sliderLeft<%=i%>">
            <%
                    PropertyInfo[] props = adsLeft[i].GetType().GetProperties();
                    foreach (PropertyInfo p in props)
                    {
                        if (p.Name.Contains("Img"))
                        {
                            object img = p.GetValue(adsLeft[i], null);
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
        $(document).delegate('#<%=ldivid%>', "click", function () {
            var url = '<%=adsLeft[i].URL%>';
            if (url != '')
                window.open(url, '_blank', 'toolbar=1, location=1, menubar=1, resizable=1, scrollbars=1');
        });
    </script>
    <div class="clear25"></div>
    <%}
                var remaining = 3 - adsLeft.Count;
                if (remaining > 0)
                {
                    for (int i = 0; i < remaining; i++)
                    {
    %>
    <div class="adsingle">
        <script>
            $(function () {
                $("#sliderLeftrem<%=i%>").responsiveSlides({
                    maxwidth: 250,
                    speed: 800
                });
            });
        </script>
        <ul class="rslides" id="sliderLeftrem<%=i%>">
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
                $("#sliderLeft<%=i%>").responsiveSlides({
                    maxwidth: 250,
                    speed: 800
                });
            });
        </script>
        <ul class="rslides" id="sliderLeft<%=i%>">
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
