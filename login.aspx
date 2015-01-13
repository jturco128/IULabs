<%@ Page Language="C#"  AutoEventWireup="true" Inherits="WebAuthForm" Src="login.aspx.cs" Title="Login - Intra University Computer Labs - Colorado State University" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Intra University Computer Labs - Colorado State University</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
<link href="/iulabtest/support/css/style.css" rel="stylesheet" type="text/css" />
<link href="/iulabtest/support/css/Slider.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="/iulabtest/support/js/jquery.js"></script>
<script type="text/javascript" src="/iulabtest/support/js/easySlider1.5.js"></script>
<script type="text/javascript" charset="utf-8">
// <![CDATA[
$(document).ready(function(){	
	$("#slider").easySlider({
		controlsBefore:	'<p id="controls">',
		controlsAfter:	'</p>',
		auto: true, 
		continuous: true
	});	
});
// ]]>
</script>
</head>
<body>
<div class="main">
  <div class="blok_header">
    <div class="header">
      <div class="logo"><h1><a href="/">Intra-University Labs</a></h1></div>
      <div class="menu">
        <a href="http://www.colostate.edu"><img src="support/images/logo-linear.gif" alt="Colorado State University" /></a>
      </div>
      <div class="clr"></div>
    </div>
    <div class="clr"></div>
  </div>
  <div class="clr"></div>
  <div class="header_text_bg">
    <div class="header_text">
      <div class="div">
        <div class="left1">
          <h2>Welcome</h2>
          <p><%=DateTime.Now.ToLongDateString() %></p>
        </div>
      </div>
      <div class="gallery">
        <div id="slider">
          <ul>
            <li><img src="support/images/slider_img_1.jpg" alt="screen 1" width="263" height="165" border="0"  /></li>
            <li><img src="support/images/slider_img_2.jpg" alt="screen 1" width="263" height="165" border="0"  /></li>
            <li><img src="support/images/slider_img_3.jpg" alt="screen 1" width="263" height="165" border="0"  /></li>
            <li><img src="support/images/slider_img_4.jpg" alt="screen 1" width="263" height="165" border="0"  /></li>
          </ul>
        </div>
      </div>
      <div class="clr"></div>
    </div>
  </div>
  <div class="clr"></div>
  <div class="body">
    <div class="body_resize">
      <div class="side_left">

        <div class="left">
          <div class="left_top">
            <div class="left_bottom">
              <h2>eID Login Required</h2>
              <div style="text-align:center;">
                    <h3>Please Log In with your eID</h3>
                    <asp:Label id="login_form" runat="server"/>
                    <p><asp:Label ID="lblMessage" runat="server"></asp:Label></p>
                
                </div>
              <div class="clr"></div>
            </div>
          </div>
        </div>
    </div>
      <div class="side_right">
        <div class="right">
          <div class="right_top">
          <div class="right_bottom">
            <h2>More Info</h2>
            <img src="support/images/img_5.jpg" alt="picture" width="42" height="42" />
            <p><strong><a href="AssistTech.aspx" class="normal">Assistive Technology</a></strong></p>
            <p>Both labs offer a range of computer services for any student with special needs.</p>
            <div class="bg"></div>
            <img src="support/images/img_3.jpg" alt="picture" width="42" height="42" />
            <p><strong><a href="Software.aspx" class="normal">Software</a></strong></p>
            <p>The IU Labs has a wide range of software on the machines for students.</p>
            <div class="bg"></div>
            <img src="support/images/img_4.jpg" alt="picture" width="42" height="42" />
            <p><strong><a href="Equipment.aspx" class="normal">Equipment Checkout</a></strong></p>
            <p>Students can checkout laptop computers and headphones from the labs.</p>
            <div class="bg"></div>
            <img src="support/images/img_2.jpg" alt="picture" width="42" height="42" />
            <p><strong><a href="Contact.aspx" class="normal">Contact</a></strong></p>
            <p>If you have any questions, comments or concerns about the labs.</p>
            <div class="clr"></div>
          </div>
          </div>
        </div>
        <%--<div class="right">
          <div class="right_top">
          <div class="right_bottom">
            <h2>Search Site</h2>
            <div class="search">
              <form id="form2" name="form1" method="post" action="">
                <label>
                  <input name="q" type="text" class="keywords" id="textfield" maxlength="50" value="Search..." />
                  <input name="b" type="image" src="support/images/search.gif" class="button" />
                </label>
              </form>
            </div>
            <div class="clr"></div>
          </div>
          </div>
        </div>--%>
        <div class="right">
          <div class="right_top">
          <div class="right_bottom">
            <h2>Get in touch!</h2>
              <p><strong>Durrell Lab</strong><br />
                113 Durrell Basement<br />
                Fort Collins, CO<br />
                80521<br />
                Phone:(970)491-2846<br /><br />

                <strong>eCave</strong><br />
                23 Lory Student Center<br />
                Fort Collins, CO<br />
                80521<br />
                Phone:(970)491-5534</p>
            <div class="clr"></div>
          </div>
          </div>
        </div>
        <div class="clr"></div>
      </div>
      <div class="clr"></div>
    </div>
  </div>
  <div class="clr"></div>
</div>
<div class="footer">
  <div class="footer_resize">
    <p class="leftt">&copy; <%=DateTime.Now.Year %> Colorado State University</p>
    <p class="rightt">
            <a href="http://search.colostate.edu/index.asp">Search CSU</a> | 
            <a href="http://www.colostate.edu/info-disclaimer.aspx">Disclaimer</a> | 
            <a href="http://www.colostate.edu/info-privacy.aspx">Privacy Policy</a> | 
            <a href="http://www.colostate.edu/info-equalop.aspx">Equal Opportunity</a> | 
            <a href="http://www.mediarelations.colostate.edu/staff.aspx">Contact Us</a> | 
            <a href="Admin.aspx">Log In</a>
        </ul></p>
    <div class="clr"></div>
  </div>
  <div class="clr"></div>
</div>
</body>
</html>

