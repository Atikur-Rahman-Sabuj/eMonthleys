<%@ Page Title="Terms and Conditions" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TermsOfUse.aspx.cs" Inherits="eMonthleys.TermsOfUse" %>

<%@ Register Src="~/controls/adsLeft.ascx" TagPrefix="uc1" TagName="adsLeft" %>
<%@ Register Src="~/controls/adsRight.ascx" TagPrefix="uc1" TagName="adsRight" %>

<asp:Content ID="Header1" ContentPlaceHolderID="HeaderContent" runat="server">
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

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section class="withads">
        <div class="row">
            <article class="col-md-3">
                <uc1:adsLeft runat="server" ID="adsLeft" />
            </article>
            <article class="col-md-6 mainpanel">
                <h1><%: Page.Title %></h1>
                <h2>Acceptance  of Terms of Use</h2>
                <p>
                    IT IS IMPORTANT THAT YOU READ  ALL THE TERMS AND CONDITIONS CAREFULLY. emonthlies/JAMES WOOD LOGIX Inc&#8482; (hereinafter  the &ldquo;Company&rdquo;) owns and operates www.emonthlies.com (hereinafter the  &ldquo;Website&rdquo;). These terms of use of the Website (hereinafter the &ldquo;Agreement&rdquo;)  contain the terms and conditions under which you may access and use the  Website. By accessing and using the Website, you are indicating your acceptance  to be bound by this Agreement. If you do not accept these terms and conditions,  you must not access or use the Website. IF YOU ARE DISSATISFIED WITH THIS  AGREEMENT, YOUR SOLE AND EXCLUSIVE REMEDY IS TO DISCONTINUE USING THE WEBSITE.
                <br />
                    The Company may, in its sole  discretion, update, modify or amend this Agreement without notice. Use of the  Website after such changes are posted will signify your Agreement to these  revised terms. You should visit this page periodically to review this  Agreement.
                <br />
                </p>
                <h3>Ownership</h3>

                <p>
                    Unless otherwise stated, the  Company and/or its licensors and third party providers (hereinafter &ldquo;Third-Parties&rdquo;)  own the copyright and intellectual property rights to this Website, its design,  text, content, material, media, video, audio, forms and layout.<br />
                    You may view, access, print,  cache and/or download the materials located on the Website only for personal,  non-commercial use. You may not reproduce this material on your own personal  website, blog, social network or any other online source.<br />
                    Any and all content (including  user and visitor generated content) submitted to the Website or its content  aggregation systems become the property of the Company. The Company reserves  the right to alter, remove, re-post, re-purpose, market or trade any such  content.
                <br />
                    &ldquo;emonthlies.com&rdquo;, and all  other related trademarks and design marks displayed on the Website are owned by  the Company and/or the Third Parties. Other trademarks and designs are  trademarks of the respective owners. You may not construe, either implicitly or  otherwise, the use of the Website as permission to license, sub-license or the  right to use any of the intellectual property contained on the Website, unless  you obtain express written consent of the Company or any such other party that  may own the applicable trademarks.<br />
                </p>
                <h3>Website Use</h3>
                <p>
                    The Website and/or its  content must not be, in whole or in part, reproduced, republished,  retransmitted, distributed, sold, licensed, sub-licensed, mirrored without the  written consent of the Company. You may view, access, print, cache and/or  download the materials located on the Website only for personal, non-commercial  use. You may not reproduce this material on your own personal website, blog,  social network or any other online source. Unauthorized use of the Website  and/or the content contained on the Website may violate applicable laws, and  you may be held liable for these violations. The use of such content on any  other website or in any environment of networked computers is prohibited.
                <br />
                    You must not use this website in any way  that causes, or may cause, damage or adverse impact to the Website or  impairment of the availability or accessibility of the Website, or in any way  which is unlawful, illegal, fraudulent, or harmful, or in connection with any  unlawful, illegal, fraudulent or harmful purpose or activity.
                <br />
                    You must not use this website to copy,  store, host, transmit, send, use, publish or distribute any material which  consists of (or is linked to) any spyware, computer virus, Trojan horse, worm,  keystroke logger, rootkit or other malicious computer software.
                <br />
                    You must not conduct any systemic or  automated data collection activities (including without limitation scraping,  data mining, data extraction and data harvesting) on or in relation to this  website without the Company&rsquo;s express written consent.
                <br />
                    Unless otherwise stated, you must not use this website for  any purposes related to marketing without the Company&rsquo;s express written  consent.
                <br />
                    In its sole discretion, in addition to any other rights or  remedies available to the Company and without any liability whatsoever, the  Company at any time and without notice may terminate or restrict your access to  any component of the Website.
                <br />
                </p>
                <h3>Our Rights to Remove or Reproduce any User-Generated  Material</h3>
                <p>
                    For the purposes of this  condition, the term &ldquo;user-generated material&rdquo; refers to any information,  content or any other media uploaded, posted, emailed, submitted or other  communicated to the Company via any method at any page on the Website or any  other content communication or submission medium or forum.
                <br />
                    By sharing any contribution  or user-generated material (including any text, photography, graphics, video or  any other type of media or content) on the Website, you agree to grant the  Company worldwide, irrevocable, non-exclusive and royalty-free permission to  use the material in any way deemed fit (including the modification,  reproduction, repurposing or deletion of it). You also grant the Company the  right to sub-license these rights, and the right to bring an action for  infringement of these rights.<br />
                    You hereby confirm that your  contribution or user-generated material is your own original work, is not  defamatory and does not infringe upon any laws of the country from which you  are utilizing this site, nor any federal laws of Canada or the United States of  America and their laws of their respective provinces, territories, or states,  and that you have the full rights to accept this condition. You also confirm  that your contribution or user-generated material does not infringe any  third-party legal rights, and must not be capable of giving rise to legal  action against you, the Company or a third party, in each case under any  applicable law.<br />
                </p>
                <h3>User  Name and Password</h3>
                <p>
                    Your Website account may be  accessed only by use of your login name and password. You are solely  responsible and liable for any use a misuse of your login name and password and  for all activities that occur under your login name and password.
                <br />
                    All login names and passwords  remain the property of the Company and may be cancelled or suspended at any  time by the Company without any notice or consent to you or any other person.  The Company is under no obligation to verify the actual identity or authority  of the user of any login name or password.
                <br />
                    You must immediately notify  the Company of any unauthorized use of your login name or password, of if you  know or suspect that your login name or password has been lost or stolen, has  became known to any other person, or has been otherwise compromised.<br />
                </p>
                <h3>Privacy
                </h3>
                <p>
                    You have read and agree to  the Company&rsquo;s privacy policy, the terms of which appear on the Website and are  incorporated into these Terms and Conditions.
                <br />
                    You consent to the  collection, use and disclosure of your personal information by the Company  and/or Third Parties in accordance with the terms of and for the purposes set  out in the Company&rsquo;s Privacy Policy.
                <br />
                </p>
                <h3>Frames and Website
                </h3>
                <p>
                    Framing of the Website or any  of its content in any form and by any method is strictly prohibited. Links to  the Website must result in a new, fully functional, full-screen browser  occupied solely by the pages created by the Website.
                <br />
                </p>

                <h3>Business Ads</h3>
                <p>
                    If your pictures do not conform to the correct size as prescribed you may have to resize the pictures before uploading.
                    </p>
                <p>We reserve the right to remove or not approve business ads that do not
                    comply with James Wood Logix Inc's (emonthlies) advertising policies.
                </p>

                <h3>Charges and Services</h3>
                <p>
                    The use of this website may require some fees. You will be able to review and accept these charges. Our fees are not refundable and are due upon placing the ad. 
                    If you are unable to make a payment and/or the account is past due, we may limit the use of this website.<br />
                    From time to time we may change our fees or have special promotions of new services. These promotional services will be announced by emonthlies.
                    </p>


                <h3>Limited Liability - General</h3>
                <p>
                    Users and visitors who use the Website and rely on any  information available on the website do so at their own risk. The Website is  provided &ldquo;as is&rdquo; without any representations or warranties, express or implied.
                <br />
                    Though the Company makes a reasonable effort to maintain  the resources of the Website, they will, from time to time, become out of date,  be incorrect, erroneous, or otherwise inappropriate, and the Company makes no  warranties or representations that the Website will be constantly available or  available at all, without error and/or accurate.
                <br />
                    The Website is a venue, among other things, for sellers to  submit vehicles available for sale and potential buyers to post  contact information signaling interest in purchasing a vehicle. The Company and/or  its Third-Parties do not independently verify the user-generated content in a  posting. The Company and Third-Parties do not warrant or represent that the  information on the Website is complete, true, accurate, reliable, suitable or  non-misleading. Furthermore, you assume all risks associated with dealing with  other users with whom you come in contact with through the Website. 
                <br />
                    The Company makes no warranties or representations in  respect to the Website, its content or data, including implied warranties and  conditions of merchantability, fitness for a particular purpose, title and  non-infringement, and those arising by statute or otherwise in law or from a  course of dealing or usage of trade.
                <br />
                    The Website, its Company, and its officers, employees,  contractors or content providers shall not be held liable for any loss, claim  or damage (be it special, punitive, general, incidental or consequential or any  other kind) arising from or otherwise in connection with your use of any  content, information, function, operation or service of the Website at any  location within <a href="http://www.emonthlies.com">www.emonthlies.com</a> or  other related location (such as content feeds, links, emails, letters,  documents or other company products or correspondence).
                    The services or subject matter of this agreement under any contract, negligence, strict <span lang="EN-US">liability</span> or other legal claims will not exceed and aggregate greater than $100.00 or the fees paid by the services during a three month period preceding the claim.<br />
                </p>
                <h3>Limited  Liability – Links</h3>
                <p>
                    The Company is not responsible for the contents or  reliability of any other websites to which the Website provides a link and the  Company does not, expressly or otherwise, endorse the views and/or content  expressed within those sites.
                <br />
                </p>
                <h3>Indemnification</h3>
                <p>
                    You hereby indemnify the Company and the Third-Parties and  their respective officers, directors, employees, consultants, representatives  and agents and undertake to keep the Company, its Third-Parties and their  respective officers, directors, employees, consultants, representatives and  agents indemnified against any losses, damages, costs, liabilities and expenses  (including, without limitation, legal expenses and any amounts paid by the  Company to a third party in settlement of a claim or dispute on the advice of  the Company&rsquo;s legal advisors) incurred or suffered arising out of any breach by  you of any provision of this Agreement, or arising out of any claim by a  third-party that you have breached any provision of this Agreement.<br />
                </p>
                <h3>Breaches of this Agreement</h3>
                <p>
                    Without prejudice to the Company&rsquo;s  other rights under this Agreement, if you breach this Agreement in any way, the  Company may take such action as it deems appropriate to deal with the breach,  including suspending your access to the website, prohibiting you from accessing  the website, blocking computers using your IP address from accessing the  website, contacting your internet service provider to request that they block  your access to the website and/or initiating legal proceedings against you.<br />
                </p>
                <h3>Assignment</h3>
                <p>
                    The Company may transfer, sub-contract  or otherwise deal with the Company&rsquo;s rights and/or obligations under this  Agreement without notifying you or obtaining your consent.<br />
                    You may not transfer, sub-contract or  otherwise deal with your rights and/or obligations under this Agreement.<br />
                </p>
                <h3>Severability</h3>
                <p>
                    If a provision of this Agreement is  determined by any court or other competent authority to be invalid, unlawful,  void and/or unenforceable, the other provisions will continue in effect. If any  invalid, unlawful, void and/or unenforceable provision would be valid, lawful  or enforceable if part of it were deleted, that part will be deemed to be  deleted, and the rest of the provision will continue in effect.<br />
                </p>
                <h3>Entire Agreement</h3>
                <p>
                    This Agreement, together with any  other documentation referred to in the Agreement (such as the Company&rsquo;s Privacy  Policy) constitute the entire agreement between you and the Company in relation  to your use of the Website, and supersede all previous agreements in respect of  your use of the Website.<br />
                </p>
                <h3>Jurisdiction</h3>
                <p>
                    The Company is registered under the provincial laws of  Ontario and the Website is physically maintained and operated in the Province  of Ontario in the Country of Canada.
                <br />
                    This Agreement will be governed by and construed in  accordance with the federal laws of Canada and provincial laws of Ontario, and  any disputes arising from or connection to this Website will be subject to the  exclusive jurisdiction of the courts of the Province of Ontario.<br />
                </p>
                <h3>Miscellaneous</h3>
                <p>
                    The Company reserves the right to refuse to post and/or  remove any information, content or material, in whole or in part, that, in its  sole discretion, is unacceptable, undesirable, or in violation of this  Agreement.
                <br />
                    The Company&rsquo;s failure to insist and rely upon or enforce  strict performance of any of this Agreement shall not be construed as a waiver  of any provision or right set out in this Agreement.
                </p>

                <h2>Taxes Included Advertising</h2>
                <h3>Section A</h3>
                <p>If a dealer&rsquo;s ad includes a price for a vehicle, that price must include <strong>all</strong> charges related to the sale of the vehicle. This includes freight and inspection charges, administration fees, other fees/charges, levies and taxes. Dealers don&rsquo;t have to include taxes in the advertised price so int as the ad indicates in a <strong>clear, comprehensible and prominent manner</strong> that taxes are not included in the price. However emonthlies recommends and encourages taxes to be included in the purchase price.</p>
                <p>Note: The following are more detailed explanations and examples of OMVIC&rsquo;s expectations for meeting certain requirements set out in Section 36 of the <a href="http://www.e-laws.gov.on.ca/html/regs/english/elaws_regs_080333_e.htm" target="_blank">General Regulations</a> under the MVDA including &ldquo;all-in pricing.&rdquo; Where there is a requirement for information/disclosure to be set out in a &ldquo;clear, comprehensible and prominent&rdquo; (CCP) manner, OMVIC will consider the size and proximity of this disclosure relative to the advertised price.</p>
                <p>
                    Section 36(7) states,
                    <br />
                    &ldquo;If an advertisement indicates the price of a motor vehicle, the price shall be set out in a clear, comprehensible and prominent manner and shall be set out as the total of,
                </p>
                <ol>
                    <li>The amount the buyer would be required to pay for the vehicle; and</li>
                    <li>Subject to subsections (9) and (10), for all other charges related to the trade in the vehicle, including, if any, charges for freight, charges for inspection before delivery of the vehicle, fees, levies and taxes.&rdquo;</li>
                </ol>
                <p>&ldquo;All other charges&rdquo; includes any charge treated as mandatory by the dealer. A charge is deemed to be mandatory if:</p>
                <ul>
                    <li>The customer is not given an express opportunity to decline the charge during the negotiation process; or</li>
                    <li>It pertains to features or additions referred to in the advertisement or during negotiations (unless they are described as optional extras in the advertisement or during negotiations).</li>
                </ul>
                <p>For instance, if a customer is expected to pay an administration fee, documentation fee, fee for a safety standards certificate or for a window-etching product, those amounts must be included in the all-in price. (These are examples only and are not intended to be a complete list of all fees.)</p>
                <p>
                    Section 36(8) states,
                    <br />
                    &quot;If an advertisement that indicates a price for a motor vehicle is placed jointly by two or more registered motor vehicle dealers, the advertisement shall state that the price for the vehicle in an actual trade may be less than the price set out in the advertisement.&quot;
                </p>
                <p>If the ad is placed by more than one dealer, words such as &ldquo;Dealer may sell for less&rdquo; must be used.</p>
                <p>
                    Section 36(9) states,<br />
                    &ldquo;Subject to subsection (10), if an advertisement that indicates a price for a motor vehicle is placed jointly by two or more registered motor vehicle dealers and if an amount of a charge mentioned in clause (7)(b) varies as between the dealers, the advertisement shall indicate, in a clear, comprehensible and prominent manner,
                </p>
                <ol>
                    <li>That a buyer of the vehicle may be requested to pay that amount in addition to the price indicated in the advertisement; and</li>
                    <li>What the charge is for.</li>
                </ol>
                <p>If the ad has been placed by two or more dealers, and there is a fee that varies from one dealer to another, that fee may be excluded from the all-in price, but the amount of the fee must be disclosed along with a description of what the fee is for in a CCP manner. For instance, &ldquo;The above price does not include administration fees which vary from $199 to $499, depending on the dealer.&rdquo;</p>
                <p>
                    Section 36(10) states,
                    <br />
                    &ldquo;Clause 7(b) and subsection (9) do not apply to amounts under the Retail Sales Tax Act or to the federal goods and services tax if the advertisement indicates in a clear, comprehensible and prominent manner that those amounts are not included in the price indicated in the advertisement.&rdquo;
                </p>
                <p>Section 36(10) allows dealers to exclude HST from the advertised price as int as this fact is disclosed in a CCP manner in the advertisement.</p>
                <p>
                    Section 36(11) states,
                    <br />
                    &ldquo;If an advertisement that indicates a price for a motor vehicle is placed jointly by two or more registered motor vehicle dealers, each of the dealers shall ensure that the advertisement complies with subsection (7), (8), (9) and (10).&rdquo;
                </p>
                <p>Section 36(11) requires each dealer involved in placing an advertisement ensures it complies with the Act.</p>
                <h3>Section B</h3>
                <p>Advertisements must include the registered name and phone number of the selling dealer in a clear, comprehensible and prominent manner. Where there are space or time limitations (e.g., a billboard or radio/TV ad), the ad must, at a minimum, state that it has been placed by a registered dealer.</p>
                <p>An advertisement must indicate in a clear, comprehensible and prominent manner if the vehicle:</p>
                <ul>
                    <li>Was previously a daily rental (unless subsequently owned by a non-dealer).</li>
                    <li>Was previously a police vehicle or emergency services vehicle.</li>
                    <li>Was previously a taxi or limousine.</li>
                    <li>Is a used car and, if that is the case, of the current model year or the immediate previous model year.</li>
                </ul>
                <p>Vehicle advertisements that state the inclusion of an extended warranty must clearly, comprehensibly and prominently include the term of the warranty and maximum claim limits, if any.</p>
                <h3>Section C</h3>
                <p>If an ad includes a price for a vehicle that is not certified and/or e-tested, the ad must state in a clear, comprehensible and prominent manner:</p>
                <p><em>&ldquo;This vehicle is not drivable, not certified and not e-tested. Certification and e-testing are available for $XXX.&rdquo;</em></p>
                <p>Note: If a dealer intends to offer certification and e-testing, the fee MUST be disclosed in the above statement. Certification and e-testing CANNOT be mandatory charges. Vehicles advertised unfit may not be sold at or above the advertised price using the &ldquo;as is&rdquo; clause on the bill of sale.</p>
                <h3>Section D</h3>
                <p>If an ad includes a price for a vehicle being sold &ldquo;as is,&rdquo; the ad must include in a clear, comprehensible and prominent manner the following statement:</p>
                <p><em>&ldquo;This vehicle is being sold &ldquo;as is,&rdquo; unfit, not e-tested and is not represented as being in road worthy condition, mechanically sound or maintained at any guaranteed level of quality. The vehicle may not be fit for use as a means of transportation and may require substantial repairs at the purchaser&rsquo;s expense. It may not be possible to register the vehicle to be driven in its current condition.&rdquo;</em></p>
                <p>It is NOT sufficient to simply state the vehicle is being sold &ldquo;as is.&rdquo;</p>



                <!-- last -->
                <div>
                    <img src="/images/eMonthleys.png" alt="the easy way to buy your next car" class="img-rounded" />&nbsp;<em>&quot;the easy way to buy your next car&quot;</em>
                </div>
                <div class="clear25"></div>
            </article>
            <article class="col-md-3">
                <uc1:adsRight runat="server" ID="adsRight" />
            </article>
            <div class="clear"></div>
        </div>
    </section>
</asp:Content>
