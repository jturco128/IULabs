<%@ Page Title="" Language="C#" MasterPageFile="~/support/MasterPage.master" AutoEventWireup="true" CodeFile="admin-logonreport.aspx.cs" Inherits="admin_logonreport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="support/js/raphael.js" type="text/javascript"></script>
    <script src="support/js/g.raphael-min.js" type="text/javascript"></script>
    <script src="support/js/g.pie-min.js" type="text/javascript"></script>
    <script src="support/js/g.bar.js" type="text/javascript"></script>
    <script type="text/javascript" charset="utf-8">
        window.onload = function () {
            var r = Raphael("holder");
            r.g.txtattr.font = "12px 'Fontin Sans', Fontin-Sans, sans-serif";

            var pie = r.g.piechart(220, 150, 100, [<%=Charting.getNumber("SELECT COUNT(computerName) FROM LabLogon WHERE dateLoggedIn > CAST('2010-08-23 06:00' AS DATETIME) AND computerName LIKE 'LORY%'") %>, <%=Charting.getNumber("SELECT COUNT(computerName) FROM LabLogon WHERE dateLoggedIn > CAST('2010-08-23 06:00' AS DATETIME) AND computerName LIKE 'DURRELL%'") %>], {
                legend: ["%%.%% – eCave ", "%%.%% - Durrell "],
                legendpos: "east" 
            });
            pie.hover(function () {
                this.sector.stop();
                this.sector.scale(1.1, 1.1, this.cx, this.cy);
                if (this.label) {
                    this.label[0].stop();
                    this.label[0].scale(1.5);
                    this.label[1].attr({ "font-weight": 800 });
                }
            }, function () {
                this.sector.animate({ scale: [1, 1, this.cx, this.cy] }, 500, "bounce");
                if (this.label) {
                    this.label[0].animate({ scale: 1 }, 500, "bounce");
                    this.label[1].attr({ "font-weight": 400 });
                }
            });
            var labels = [<%=Charting.getColumn1("SELECT datepart(hh, dateloggedin) AS Expr1, count(dateLoggedIn) FROM LabLogon WHERE dateLoggedIn > CAST('2010-08-23 06:00' AS DATETIME) group by datepart(hh,dateLoggedIn) ORDER BY Expr1") %>];
            var data = [<%=Charting.getColumn2("SELECT datepart(hh, dateloggedin) AS Expr1, count(dateLoggedIn) FROM LabLogon WHERE dateLoggedIn > CAST('2010-08-23 06:00' AS DATETIME) group by datepart(hh,dateLoggedIn) ORDER BY Expr1") %>];
            drawChart("holder1", labels, data);

            var labels2 = [<%=Charting.getColumn1("SELECT datepart(hh, dateloggedin) AS Expr1, count(dateLoggedIn) FROM LabLogon WHERE dateLoggedIn > CAST('2010-08-23 06:00' AS DATETIME) AND computerName LIKE 'LORY%' group by datepart(hh,dateLoggedIn) ORDER BY Expr1") %>];
            var data2 = [<%=Charting.getColumn2("SELECT datepart(hh, dateloggedin) AS Expr1, count(dateLoggedIn) FROM LabLogon WHERE dateLoggedIn > CAST('2010-08-23 06:00' AS DATETIME) AND computerName LIKE 'LORY%' group by datepart(hh,dateLoggedIn) ORDER BY Expr1") %>];
            drawChart("holder2", labels2, data2);

            var labels3 = [<%=Charting.getColumn1("SELECT datepart(hh, dateloggedin) AS Expr1, count(dateLoggedIn) FROM LabLogon WHERE dateLoggedIn > CAST('2010-08-23 06:00' AS DATETIME) AND computerName LIKE 'DURRELL%' group by datepart(hh,dateLoggedIn) ORDER BY Expr1") %>];
            var data3 = [<%=Charting.getColumn2("SELECT datepart(hh, dateloggedin) AS Expr1, count(dateLoggedIn) FROM LabLogon WHERE dateLoggedIn > CAST('2010-08-23 06:00' AS DATETIME) AND computerName LIKE 'DURRELL%' group by datepart(hh,dateLoggedIn) ORDER BY Expr1") %>];
            drawChart("holder3", labels3, data3);

        };

        function drawChart(div,labels, data) {
            /* 
             * Create an instance of raphael and specify:
             * the ID of the div where to insert the graph
             * the width
             * the height
             */
            var r = Raphael(div, 550, 300);
            
            /*
             * Create the chart at the position with the parameters:
             * * pos on the x axis where the drawing start
             * * pos on the y axis where is drawing start
             * * width
             * * height
             * * the values: it needs to be a list of list since you can have multiple data
             * * extra parameters:
             *      stacked: Putting stacked to false seems to create a problem with the labels
             *      type: the end of the bar, it can be: round sharp soft
             */
            var chart = r.g.barchart(0, 0, 550, 300, [data], {stacked: true, type: "soft"});
            
            /*
             * Create an hover effect to display the value when the mouse is over the graph.
             */
            chart.hover(function() {
                // Create a popup element on top of the bar
                this.flag = r.g.popup(this.bar.x, this.bar.y, (this.bar.value || "0") + " logins").insertBefore(this);
            }, function() {
                // hide the popup element with an animation and remove the popup element at the end
                this.flag.animate({opacity: 0}, 300, function () {this.remove();});
            });
            
            /*
             * Define the default text attributes before writing the labels
             * you can find pore information about the available attributes at:
             *   http://raphaeljs.com/reference.html#attr
             * and in the SVG specification:
             *   http://www.w3.org/TR/SVG/
             */ 
            r.g.txtattr = {font:"9px Fontin-Sans, Arial, sans-serif", fill:"#000", "font-weight": "bold"};
            
            /*
             * We write the labels.
             * There is a bug not fixed at the time of writing this article. We added a patch to 
             * g.bar.js : http://github.com/DmitryBaranovskiy/g.raphael/issues#issue/11
             */
            chart.label(labels);  
        }

        </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="left">
          <div class="left_top">
            <div class="left_bottom">
              <h2>eCave vs Durrell Usage</h2>
              <div id="holder"></div>
              <div class="clr"></div>
            </div>
          </div>
          <div class="left_top">
          <div class="left_bottom">
              <h2>Cumulative Usage by Time</h2>
              <div id="holder1"></div>
              <div class="clr"></div>
            </div>
        </div>
        <div class="left_top">
          <div class="left_bottom">
              <h2>eCave Usage by Time</h2>
              <div id="holder2"></div>
              <div class="clr"></div>
            </div>
        </div>
        <div class="left_top">
          <div class="left_bottom">
              <h2>Durrell Usage by Time</h2>
              <div id="holder3"></div>
              <div class="clr"></div>
            </div>
        </div>
</div>


</asp:Content>

