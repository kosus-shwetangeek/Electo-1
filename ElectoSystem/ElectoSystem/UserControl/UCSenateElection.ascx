<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSenateElection.ascx.cs" Inherits="ElectoSystem.UserControl.UCSenateElection" %>

<script src="../dist/js/tinybox.js" type="text/javascript"></script>
<script src="../dist/js/jquery-1.8.3.js" type="text/javascript"></script>
<link href="../dist/css/TinyBox.css" rel="stylesheet" type="text/css" />

<div>
    <div class="chart-title">School Senate Election</div>
</div>

<div class="prefect-div">
     <% foreach (ElectoSystem.Entities.Designation deg in AllDesignation)
       {%>
     <% Response.Write(deg.DesignationText);%> 
    <div class="sub-chart-title"><%= deg.DesignationText.ToUpper()%> </div>
        <div class="HeadBoyRow">
             <% 
           var DesignationList = AllSenateList.Where(x => x.Nom_DesignationCode.ToUpper() == deg.DesignationCode).ToList();
           foreach (ElectoSystem.Entities.NomineesEntity nom in DesignationList)
              { %>
            <div class="senate-con">
                <div class="senate-profile"><img src="<%= nom.Nom_PhotoURL.ToString()%>" width="150"/></div>
                <div class="senate-name"><%= nom.Nom_Name.ToString()%></div>
                <div class="senate-about" onclick="javascript:TINY.box.show({url:'NomineeDetails.aspx?id=<%=nom.Nom_Key.ToString()%>&electtype=s',post:'id=<%=nom.Nom_Key.ToString()%>',width:450,height:250,opacity:20,topsplit:2})">About Me</div>
                <%--<div id="headBoySenate-vote" class="senate-vote"><a href="javascript:void(0);" onclick="javascript:TINY.box.show({url:'Voteted.aspx?id=<%=nom.Nom_Key.ToString()%>&electtype=s&columnname=<%=ElectoSystem.Common.UIConstants.HB %>',post:'id=<%=nom.Nom_Key.ToString()%>',width:300,height:200,opacity:20,topsplit:2,closejs:function(){closeJS()}})"">VOTE</a></div>--%>
                <div id="prefect-vote" class="senate-vote"><input type="radio" name="<%= deg.DesignationText%>" value="<%= nom.Nom_Key%>" id="rdvote"/></div>
            </div>
            <% } %>
            
        </div>  
    </div>
   <% } %>
    <div>
        <input id="imgSubmit" type="image" src="../dist/img/SubmitVote.gif" alt="Submit" onclick="return ValidateVoteSelection()"/> 
    </div>

<script type="text/javascript">
    if (<%= IsVoted %>)
    {
        $('#imgSubmit').hide();
    $('.HeadBoyRow').each(function (index) {
        $(this).find('input[type="radio"]').hide();
    });
    }

    function closeJS() {
        location.reload(true);
    };

    function ValidateVoteSelection(e)
    {

        var isValidate = true;
        var VotedNominees = '';
        var total = $('.HeadBoyRow').length;
        $('.HeadBoyRow').each(function (index) {
            var selectedNominee = $(this).find('input[type="radio"]:checked');
            if (selectedNominee.length > 0) {
                //alert("checked");
                VotedNominees = VotedNominees + selectedNominee.val();
                if (index === total - 1) {
                        
                }
                else {
                    VotedNominees = VotedNominees + ','
                }
            }
            else {
                //alert("not checked");
                isValidate = false;
            }
        });
        var $NoConflict = jQuery.noConflict();

        if (isValidate)
        {
            $NoConflict.ajax({
                type: "POST",
                url: "HouseElection.aspx/UpdateVotes",
                data: '{xiNominees: "' + VotedNominees + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response.d); 
                }
            });
        }
        return false;
    }

    function OnSuccess(response) {
        $('#imgSubmit').hide();
        alert(response.d);
    }
    </script>