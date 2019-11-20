<%@ Page Title="Privacy Policy" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Policy.aspx.cs" Inherits="eMonthleys.Policy" %>

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
                <h1><%: Page.Title %></h1>
                <p>
                    Emonthlies/JAMES WOOD LOGIX Inc&#8482; (hereinafter &ldquo;Emonthlies&rdquo;) is committed to protecting your privacy. This  Privacy Policy applies to Emonthlies website (hereinafter &ldquo;Website&rdquo;) and governs  data collection and usage of your personal information in any form by  Emonthlies and its affiliates; it does not apply to other online or offline  sites, products or services. The collection, use and disclosure of your  personal information are governed by the Personal Information Protection and  Electronic Documents Act (PIPEDA), and any applicable provincial legislation.  Should Emonthlies ask you to provide certain information by which you can be  identified when using this website, then you can be assured it will only be  used in accordance with this policy.
                    <br />
                    By accessing and using the  Website, you are indicating your acceptance to be bound by this terms and  conditions of this Privacy Policy. If you do not accept this Privacy Policy,  you must not access or use the Website. IF YOU ARE DISSATISFIED WITH THIS  PRIVACY POLICY, YOUR SOLE AND EXCLUSIVE REMEDY IS TO DISCONTINUE USING THE  WEBSITE.<br />
                    Emonthlies may, in its sole  discretion, update, modify or amend this Privacy Policy without notice. Use of  the Website after such changes are posted will signify your agreement to these  revised terms. You should visit this page periodically to review the Privacy  Policy.</p>
                <p class="bold">
                    By using this website (emonthlies) you consent to receive marketing communications (electronic and otherwise) from <em>emonthlies</em> to offer you their products and srevices by completing sales and service transactions with you and responding to your requests, services and information.<br />
                </p>
                <h3>Users under the age of 18</h3>
                <p>If you are under the age of 18,  be sure to obtain parental or guardian consent before providing any personal  information to Emonthlies, or anyone else for that matter. </p>

                <h3>Collection of your Personal Information</h3>

                Emonthlies may collect the  following information:
                <ul>
                    <li>Personal  contact information (name, address, email address, telephone numbers) if you:  register as a user to the Website; sign up for a newsletter; participate in a  research survey; enter a promotional contest held by Emonthlies or one of its  affiliates or agents; purchase any product or service from Emonthlies or its  agents; submit a request to advertise on market on the Website; or, provide it  to Emonthlies when you attend a trade or consumer show;</li>
                    <li>User  name and passwords for users of the Website; </li>
                    <li>Demographic  information, such as postal code, preferences, interests;</li>
                    <li>Purchase  history, transaction history on Website; </li>
                    <li>Anonymous  Website usage statistics, such as pages or services most visited and/or viewed;  and,</li>
                    <li>IP  (internet protocol) addresses; </li>
                    <li>Other  information relevant to customer services and/or offers. </li>
                </ul>
                <h3>Use of your Personal Information</h3>
                Emonthlies uses this  information to understand your needs and provide you with a better service, and  in particular for the following reasons:
                <ul>
                    <li>To  meet all relevant Canadian and international regulatory, legal, insurance,  audit, security and processing requirements; </li>
                    <li>For  internal record keeping; </li>
                    <li>To  respond to your inquiries, such as a forgotten password or customer service  inquiries;</li>
                    <li>To  improve our products and services offered to you, and determine your  eligibility for other products and services offered by Emonthlies; </li>
                    <li>To  periodically send promotional emails about special offers, products/services  specific to your interests, or other information Emonthlies thinks you may find  interesting; </li>
                    <li>For  market research purposes; </li>
                    <li>To  gather demographic and statistical information about our users that relates to diagnosing  server issues and administer the Website in a manner that limits errors; </li>
                    <li>To  contact you about changes, enhancements or other notices related to products or  services provided by Emonthlies; and,</li>
                    <li>To  inform our advertisers of anonymous Website data analytics to provide them with  more targeted advertising opportunities and to help users receive advertising  that is more likely to interest them.</li>
                </ul>
                <a name="dpi"></a><h3>Disclosure of your Personal Information</h3>
                Emonthlies may confidentially  disclose your information to the following parties:
                <ul>
                    <li>Emonthlies&rsquo;  affiliates for internal audit, security, management, billing or administrative  purposes; </li>
                    <li>Emonthlies&rsquo;  third party partners for marketing or promotional purposes; </li>
                    <li>Emonthlies  users on the website in the event that you are involved in a transaction on the  Website with them; </li>
                    <li>Third-parties  in the event that you have violated the Website&rsquo;s terms and conditions, or in  the event that Emonthlies must comply with applicable legislation, legal and  regulatory authorities and/or other legal reasons; </li>
                </ul>
                <p>Emonthlies will never sell  your confidential personal information.</p>

                <h3>Security of your Personal Information</h3>
                <p>Emonthlies is committed to  ensuring that your personal information is secure. With this in mind, we have  put in suitable and appropriate physical, electronic and managerial procedures  to safeguard and secure the information collected.</p>

                <h3>Controlling your Personal Information</h3>
                You may choose to restrict  the collection or use of your personal information in the following manners:
                <ul>
                    <li>When  filling out information on the Website, look for the box indicating the  opportunity to &ldquo;opt-out&rdquo; and indicate that you do not want the information to  be used by anybody for direct marketing purposes; or, </li>
                    <li>If you  have previously agreed to use this information for marketing purposes, you may  email us at <a href="mailto:info@emonthlies.com">info@emonthlies.com</a> notifying us of your desire to &ldquo;opt-out.&rdquo;</li>
                </ul>
                <p>
                    Emonthlies will not sell,  distribute or lease your personal information to third parties unless we have  your permission to do so or are required by law.
                </p>

                <h3>Cookies</h3>
                <p>
                    An internet cookie is a small  text file which asks permission to be placed on your computer&rsquo;s hard drive and  if permitted, collects and stores information such as your web traffic or when  you visit The Website. Cookies allow web applications to respond to you like an  individual – it can tailor its operations to your needs, likes and dislikes by  gathering and remembering information about your preferences.
                </p>
                <p>
                    Cookies provide us with a  better website and user experience by enabling us to monitor which pages you  find useful and which you do not. A cookie in no way gives us access to your  computer or any information about you beyond the data that you choose to share  with us.
                </p>
                <p>
                    You can choose to accept or  decline cookies. Most web browsers automatically accept cookies, but you can  usually modify your browser setting to decline cookies if you prefer. However,  this may prevent you from taking full advantage of the Website.
                </p>

                <h3>Links</h3>
                <p>The Website may contain links  to enable you to visit other websites. However, once you have left the Website,  Emonthlies has no control over that other website and is not responsible for  the protection and privacy of any information which you provide at that  website. Links taking you off the Website are not governed by this Privacy  Policy. You should exercise caution and look at the applicable privacy  statement to the website in question before disclosing any personal  information.</p>

                <h3>Concerns regarding your Personal Information</h3>
                <p>Emonthlies works hard to  protect your privacy. We want you to know that we are committed to safeguarding  your privacy to our online and Internet activities and we welcome the  opportunity to hear from you if you have a question regarding our privacy  policy. You can send any questions regarding our privacy policy to&nbsp;<a href="mailto:info@emonthlies.com">info@emonthlies.com</a>. We value your comments but may not able to implement your ideas but we are interested.</p>
                <p>We are not liable in any event of unauthorized access to/or involuntary disclosure of your personal information.</p>
                <p></p>
            </article>
            <article class="col-md-3">
                <uc1:adsRight runat="server" ID="adsRight" />
            </article>
            <div class="clear"></div>
        </div>
    </section>
</asp:Content>
