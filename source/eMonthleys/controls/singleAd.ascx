<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="singleAd.ascx.cs" Inherits="eMonthleys.controls.singleAd" %>
<%@ Import Namespace="System.Reflection" %>

<div class="container-fluid" id="bannerMiddle" style="cursor: pointer;">

    <%
        var ad = eMonthleys.BLL.CustomerAd.GetRandomSmallCustomersAd();
        if (ad == null)
        { %>
    <script>
        $(function () {
            $("#adMiddle").responsiveSlides({
                maxwidth: 250,
                speed: 800
            });
        });
    </script>
    <ul class="rslides" id="adMiddle">
        <li>
            <img src="/imgs/emonthlies/smallslide1.png" alt="" width="250" height="200"></li>
        <li>
            <img src="/imgs/emonthlies/smallslide2.png" alt="" width="250" height="200"></li>
        <li>
            <img src="/imgs/emonthlies/smallslide3.png" alt="" width="250" height="200"></li>
    </ul>
    <%}
        else
        { 
    %>
    <script>
        $(function () {
            $("#sliderMiddle").responsiveSlides({
                maxwidth: 250,
                speed: 800
            });
        });
    </script>
    <ul class="rslides" id="sliderMiddle">
        <%
        PropertyInfo[] props = ad.GetType().GetProperties();
        foreach (PropertyInfo p in props)
        {
            if (p.Name.Contains("Img"))
            {
                var img = p.GetValue(ad, null);
                if (img.ToString() != "")
                {
        %>
        <li>
            <img src="<%=img.ToString() %>" alt=""></li>
        <%
                }
            }
        } %>
    </ul>
    <script type="text/javascript">
        $(document).delegate('#bannerMiddle', "click", function () {
            window.open('<%=ad.URL%>', '_blank', 'toolbar=1, location=1, menubar=1, resizable=1, scrollbars=1');
        });
    </script>

    <%} %>
</div>
