<%@ Page Title="" Language="C#" MasterPageFile="~/Voting/Voating.Master" AutoEventWireup="true" CodeBehind="~/Voting/SenateElection.aspx.cs" Inherits="ElectoSystem.Voting.SenateElection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../dist/js/tinybox.js" type="text/javascript"></script>
    <script src="../dist/js/jquery-1.8.3.js" type="text/javascript"></script>
    <link href="../dist/css/TinyBox.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../dist/css/toastr.min.css" />
    <link rel="stylesheet" type="text/css" href="../dist/css/toastr.css" />
    <script src="../dist/js/toastr.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="chart-title">School Senate Election</div>
    </div>

    <div class="prefect-div">
        <% foreach (ElectoSystem.Entities.Designation deg in AllDesignation)
           {
               var DesignationList = AllSenateList.Where(x => x.Nom_DesignationCode.ToUpper() == deg.DesignationCode).ToList();

               if (DesignationList == null || DesignationList.Count <= 0)
                   break; 
        %>
        <div class="sub-chart-title"><%= deg.DesignationText.ToUpper()%> </div>
        <div class="HeadBoyRow">
            <% 
               
               foreach (ElectoSystem.Entities.NomineesEntity nom in DesignationList)
               { %>
            <div class="senate-con">
                <div class="senate-profile">
                    <img src="<%= nom.Nom_PhotoURL.ToString()%>" width="150" />
                </div>
                <div class="senate-name"><%= nom.Nom_Name.ToString()%></div>
                <div class="senate-about" onclick="javascript:TINY.box.show({url:'NomineeDetails.aspx?id=<%=nom.Nom_Key.ToString()%>&electtype=s',post:'id=<%=nom.Nom_Key.ToString()%>',width:450,height:250,opacity:20,topsplit:2})">About Me</div>
                <%--<div id="headBoySenate-vote" class="senate-vote"><a href="javascript:void(0);" onclick="javascript:TINY.box.show({url:'Voteted.aspx?id=<%=nom.Nom_Key.ToString()%>&electtype=s&columnname=<%=ElectoSystem.Common.UIConstants.HB %>',post:'id=<%=nom.Nom_Key.ToString()%>',width:300,height:200,opacity:20,topsplit:2,closejs:function(){closeJS()}})"">VOTE</a></div>--%>
                <div id="prefect-vote" class="senate-vote">
                    <label class="lblrdvote" for="rdvote">Vote: </label>
                    <input type="radio" name="<%= deg.DesignationText%>" value="<%= nom.Nom_Key%>" id="rdvote" />
                </div>
            </div>
            <% } %>
        </div>
   
    <% } %>
        </div>
    <div width="100%">
        <input id="imgSubmit" type="image" src="../dist/img/SubmitVote.gif" style="margin-left: 49%;" alt="Submit" onclick="return ValidateVoteSelection()" />
    </div>

    <script type="text/javascript">
        if (<%= IsVoted.ToString().ToLower() %>)
        {
            $('#imgSubmit').hide();
            $('.HeadBoyRow').each(function (index) {
                $(this).find('input[type="radio"]').hide();
                $(this).find('.lblrdvote').hide();
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
                    VotedNominees = VotedNominees + selectedNominee.val();
                    if (index === total - 1) {
                        
                    }
                    else {
                        VotedNominees = VotedNominees + ','
                    }
                }
                else {
                    isValidate = false;
                }
            });
            var $NoConflict = jQuery.noConflict();
            if (isValidate == true)
            {
                $NoConflict.ajax({
                    type: "POST",
                    url: "SenateElection.aspx/UpdateVotes",
                    data: '{xiNominees: "' + VotedNominees + '" }',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccess,
                    failure: function (response) {
                        Command: toastr["error"]("Vote has been failed. Please try again later.");
                    }
                });
            }
            else if(isValidate == false)
            {
                Command: toastr["warning"]("Oops...! You have missed out some of nominee(s) to vote. Please check your votes.");
                return false;
            }
            return false;
        }

        function OnSuccess(response) {
            
            if(response.d == "0")
            {
                Command: toastr["error"]("Vote has been failed. Please try again later.");
            }
            else
            {
                $('#imgSubmit').hide();
                Command: toastr["success"]("Thank You. Your vote has been submited successfully.");
            }
        }

        toastr.options = {
            "closeButton": false,
            "debug": false,
            "newestOnTop": true,
            "progressBar": false,
            "positionClass": "toast-top-center",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "500",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }
    </script>
    </script>
</asp:Content>
