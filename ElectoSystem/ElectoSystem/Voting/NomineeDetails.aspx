<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NomineeDetails.aspx.cs" Inherits="ElectoSystem.Voting.NomineeDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="100%">
            <div class="stud-profile-pic">
                <img src="<%= Nominee.Nom_PhotoURL.ToString()%>"/><%--<%= Nominee.Nom_PhotoURL %>--%>
                <div class="sub-img"><img src="../dist/img/logo.png" /></div>
            </div>
                    <div class="info-container">
                                <div class="title">Student Id: </div>
                                <div class="info"><%= Nominee.Nom_Key %></div>
                            
                                <div class="title">Name: </div>
                                <div class="info"><%= Nominee.Nom_Name %></div>
                            
                                <div class="title">Class Section:</div>
                                <div class="info"><%= Nominee.Nom_ClassSection %></div>
                           
                                <div class="title">Designation:</div>
                                <div class="info"><%= Nominee.Nom_DesignationKey %></div>
                        </div>
                           
                            <%--<div class="title">About Me: </div>
                                <div class="title"><%= Nominee.Nom_AboutNominee %></div>
                            --%>
        </div>
    </form>
</body>
</html>
