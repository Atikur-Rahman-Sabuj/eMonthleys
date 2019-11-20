<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="topBanner.ascx.cs" Inherits="eMonthleys.topBanner" %>

<%@ Import Namespace="System.Reflection" %>

<div class="container-fluid" id="bannertop" style="cursor: pointer;">

    <%
        var ad = eMonthleys.BLL.CustomerAd.GetRandomLargeCustomersAd();
        if (ad == null)
        { %>
    <script>
        $(function () {
            $("#sliderTopE").responsiveSlides({
                maxwidth: 1130,
                speed: 800
            });
        });
    </script>
    <ul class="rslides" id="sliderTopE">
        <li>
            <img src="/imgs/emonthlies/slide2.png" alt=""></li>
        <li>
            <img src="/imgs/emonthlies/slide3.png" alt=""></li>
        <li>
            <img src="/imgs/emonthlies/slide4.png" alt=""></li>
    </ul>
    <%}
    else
    { 
    %>
    <script>
        $(function () {
            $("#sliderTop").responsiveSlides({
                maxwidth: 1130,
                speed: 800
            });
        });
    </script>
    <ul class="rslides" id="sliderTop">
        <%
        PropertyInfo[] props = ad.GetType().GetProperties();
        foreach (PropertyInfo p in props)
        {
            if (p.Name.Contains("Img"))
            {
                object img = p.GetValue(ad, null);
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
        $(document).delegate('#bannertop', "click", function () {
            window.open('<%=ad.URL%>', '_blank', 'toolbar=1, location=1, menubar=1, resizable=1, scrollbars=1');
    });
    </script>

    <%} %>
</div>
