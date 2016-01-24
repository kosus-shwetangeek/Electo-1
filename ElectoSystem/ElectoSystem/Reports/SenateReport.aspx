<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Staff.Master" AutoEventWireup="true" CodeBehind="SenateReport.aspx.cs" Inherits="ElectoSystem.Reports.SenateReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../dist/js/Graphs/d3.min.js"></script>
    <script src="../dist/js/Graphs/d3pie.min.js"></script>
    <script src="../dist/js/jquery-1.11.3.js"></script>
    <script src="../dist/js/jquery-ui.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Senate Reports</h1>
    <table class="CenterTableHN">
        <tr>
            <td>Select Election
            </td>
            <td>
                <asp:DropDownList ID="Drp_Election" AutoPostBack="true" OnSelectedIndexChanged="Drp_Election_SelectedIndexChanged" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
            <td>&nbsp;
            </td>
        </tr>
    </table>
    <%if (ReportElectionId > 0)
      {  %>
    <div class="chart-title">Senate Election Report</div>
    <%
          foreach (ElectoSystem.Common.DropDownDataSource lDesignation in ToDesignation)
          {
              if (Convert.ToInt32(lDesignation.Key) <= 0)
              {
                  continue;
              }
    %>
    <div class="col-md-12">

        <div class="sub-chart-title"><%= lDesignation.Value.ToUpper()  %></div>
        <div class="col-md-6 report-con">
            <div class="stud-table">
                <table cellpadding="0" cellspacing="0" border-collapse="colapse">
                    <tr>
                        <th>Profile Picture</th>
                        <th>Student Name</th>
                        <th>Class Section</th>
                        <th>Vote Count</th>
                    </tr>
                    <%
              if (ToNominee != null && ToNominee.Count > 0)
              {
                  var lNomineeList = ToNominee.Where(x => x.Nom_DesignationId == Convert.ToInt32(lDesignation.Key)).ToList();
                  if (lNomineeList != null && lNomineeList.Count > 0)
                  {
                      int lNomCount = lNomineeList.Count;
                      for (int k = 0; k < lNomCount; k++)
                      { 
                    %>
                    <tr>
                        <td style="background-color: <%=ColorCode.Where(x => x.Key == k).Select(x => x.Value).FirstOrDefault().ToString()%>;">
                            <img class="profile-pic" src="<%=lNomineeList.ElementAt(k).Nom_PhotoURL%>" width="50">
                        </td>
                        <td><%=lNomineeList.ElementAt(k).Nom_Name  %></td>
                        <td><%=lNomineeList.ElementAt(k).Nom_ClassSection  %></td>
                        <td><%=lNomineeList.ElementAt(k).Nom_VoteCount  %></td>
                    </tr>
                    <%           
                      }
                  }
                        
                    %>
                </table>
            </div>
        </div>
        <div id="pieChart<%=lDesignation.Key %>" class="col-md-6"></div>
    </div>
    <script>
        var $NoConflictNominee = jQuery.noConflict();

       <% var ChartDataList = lNomineeList.Select(o => new ElectoSystem.Common.PieChartData { Label = o.Nom_Name, Value = o.Nom_VoteCount.ToString(), Color = "" });
          %>
       
        var pie = new d3pie("pieChart<%=lDesignation.Key %>", {
            "header": {
                "title": {
                    "text": "",//Dynamic
                    "fontSize": 20,
                    "font": "verdana"
                },
                "subtitle": {
                    "color": "#999999",
                    "fontSize": 10,
                    "font": "verdana"
                },
                "titleSubtitlePadding": 50
            },
            "footer": {
                "text": "Election : <%=ReportElectionName%>",//Dynamic
                "color": "#999999",
                "fontSize": 11,
                "font": "open sans",
                "location": "bottom-center"
            },
            "size": {
                "canvasHeight": 300,
                "pieInnerRadius": "15%",
                "pieOuterRadius": "95%"
            },
            "data": {
                "content": [//Dynamic
                   <%
          int lCount = ChartDataList.Count();
          for (int i = 0; i < lCount; i++)
          {
                   %>
                       {
                           "label": "<%=ChartDataList.ElementAt(i).Label%>",
                           "value": <%=ChartDataList.ElementAt(i).Value%>,
                           "color": "<%=ColorCode.Where(x => x.Key == i).Select(x => x.Value).FirstOrDefault().ToString()%>"
                       },
                   <%
          }
                   %>
                ]
            },
            "labels": {
                "outer": {
                    "format": "label-value2",
                    "pieDistance": 25
                },
                "mainLabel": {
                    "font": "verdana"
                },
                "percentage": {
                    "color": "#e1e1e1",
                    "font": "verdana",
                    "decimalPlaces": 0
                },
                "value": {
                    "color": "#7b7777",
                    "font": "verdana"
                },
                "lines": {
                    "enabled": true
                },
                "truncation": {
                    "enabled": true,
                    "truncateLength": 10
                }
            },
            "tooltips": {
                "enabled": true,
                "type": "placeholder",
                "string": "{label}: {value}, {percentage}%"
            },
            "effects": {
                "pullOutSegmentOnClick": {
                    "speed": 400
                }
            }
        });
    </script>
    <% 
              }
          }
      }
    %>
</asp:Content>
