<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Staff.Master" AutoEventWireup="true" CodeBehind="HouseNomination.aspx.cs" Inherits="ElectoSystem.Admin.HouseNomination" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../dist/css/jsgrid.css" />
    <link rel="stylesheet" type="text/css" href="../dist/css/theme.css" />
    <link rel="stylesheet" type="text/css" href="../dist/css/toastr.min.css" />
    <link rel="stylesheet" type="text/css" href="../dist/css/toastr.css" />

    <script src="../dist/js/jquery-1.8.3.js"></script>
    <script src="../dist/js/JSGrid/jsgrid.core.js"></script>
    <script src="../dist/js/JSGrid/jsgrid.load-indicator.js"></script>
    <script src="../dist/js/JSGrid/jsgrid.load-strategies.js"></script>
    <script src="../dist/js/JSGrid/jsgrid.sort-strategies.js"></script>
    <script src="../dist/js/JSGrid/jsgrid.field.js"></script>
    <script src="../dist/js/JSGrid/jsgrid.field.text.js"></script>
    <script src="../dist/js/JSGrid/jsgrid.field.number.js"></script>
    <script src="../dist/js/JSGrid/jsgrid.field.select.js"></script>
    <script src="../dist/js/JSGrid/jsgrid.field.checkbox.js"></script>
    <script src="../dist/js/JSGrid/jsgrid.field.control.js"></script>
    <script src="../dist/js/toastr.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>House Nomination</h1>
    <table class="CenterTableHN">
        <tr>
            <td>Select House
            </td>
            <td>
                <asp:DropDownList ID="DrpD_Houses" runat="server" OnSelectedIndexChanged="DrpD_Houses_SelectedIndexChanged" AutoPostBack="True" Width="115px"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td>Select Designation
            </td>
            <td>
                <asp:DropDownList ID="DrpD_Designation" runat="server" OnSelectedIndexChanged="DrpD_Designation_SelectedIndexChanged" AutoPostBack="False" Width="115px"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td>Select Election
            </td>
            <td>
                <asp:DropDownList ID="DrpD_Election" runat="server" AutoPostBack="False" Width="115px"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
            <td>&nbsp;
            </td>
        </tr>
    </table>

    <div id="jsGrid"></div>
    <br />
    <br />
    <div id="jsGridNominee"></div>
    <script>
        var $NoConflict = jQuery.noConflict();
        var $NoConflictNominee = jQuery.noConflict();

        var Data = <%= StudentData.ToString()%>

        var NomineeData = <%= Nominees.ToString()%>

        var DesignationData = $NoConflictNominee.parseJSON('<%= JDesignation%>');

        var ClassSectionDropdownData = $NoConflict.parseJSON('<%= JClassSectionData%>');

        var HouseDropdownData = $NoConflict.parseJSON('<%= JHouseData%>');

        var ElectionDropdownData = $NoConflict.parseJSON('<%= JElectionsData%>');

        $NoConflict(function () {
            $NoConflict("#jsGrid").jsGrid({
                height: "auto",
                width: "100%",
                filtering: true,
                inserting: false,
                editing: false,
                sorting: true,
                paging: true,
                autoload: true,
                pageSize: 10,
                pageButtonCount: 5,
                deleteConfirm: function(item) {
                    return "Are you sure ?" + "\n\""+item.Stud_FName +" " + item.Stud_LName + "\" will be deleted permenently.";
                },
                controller: {
                    loadData: function (filter) {
                        return $.grep(Data, function (student) {
                            return (!filter.Stud_Key || student.Stud_Key.toLowerCase().indexOf(filter.Stud_Key.toLowerCase()) > -1)
                                && (!filter.Stud_FName || student.Stud_FName.toLowerCase().indexOf(filter.Stud_FName.toLowerCase()) > -1)
                                && (!filter.Stud_MName || student.Stud_MName.toLowerCase().indexOf(filter.Stud_MName.toLowerCase()) > -1)
                                && (!filter.Stud_LName || student.Stud_LName.toLowerCase().indexOf(filter.Stud_LName.toLowerCase()) > -1)
                                && (!filter.Stud_GenderId || student.Stud_GenderId === filter.Stud_GenderId)
                                && (!filter.Stud_ClassSectionId || student.Stud_ClassSectionId === filter.Stud_ClassSectionId)
                                && (!filter.Stud_HouseId || student.Stud_HouseId === filter.Stud_HouseId)
                        });
                    },
                    deleteItem: function (item) {
                        DeleteStudent(item);
                    },
                },
                fields: [
                    {
                        headerTemplate: function() {
                            return $("<button>").attr("type", "button").text("Nominate")
                                    .on("click", function () {
                                        AddSelectedNominee();
                                    });
                        },
                        itemTemplate: function(_, item) {
                            return $("<input>").attr("type", "checkbox")
                                    .on("change", function () {
                                        $(this).is(":checked") ? selectItem(item) : unselectItem(item);
                                    });
                        },
                        align: "center",
                        width: 40,
                        sorting: false,
                    },
                    { name: "Stud_Key", type: "text", width: 50, title: "Election ID", editing: false, inserting: false },
                    { name: "Stud_FName", type: "text", width: 60, title: "First Name" },
                    { name: "Stud_MName", type: "text", width: 60, title: "Middle Name"  },
                    { name: "Stud_LName", type: "text", width: 60, sorting: true , title: "Last Name" },
                    {
                        name: "Stud_GenderId",
                        type: "select",
                        items: [
                             { Name: "", Id: 0 },
                             { Name: "Boy", Id: 1 },
                             { Name: "Girl", Id: 2 }
                        ],
                        valueField: "Id",
                        textField: "Name",
                        title: "Gender",
                        width: 30,
                    },
                    {
                        name: "Stud_ClassSectionId",
                        type: "select",
                        items: ClassSectionDropdownData,
                        valueField: "Key",
                        textField: "Value",
                        title: "ClassSection",
                        width: 60,
                    },
                    { type: "control", editButton: false, deleteButton: false, width:20 }
                ]
            });

            var selectedItems = [];
 
            var selectItem = function(item) {
                selectedItems.push(item);
            };
 
            var unselectItem = function(item) {
                selectedItems = $.grep(selectedItems, function(i) {
                    return i !== item;
                });
            };
 
            var AddSelectedNominee = function() {
                if($('select[id$=DrpD_Designation]').val() == '0')
                {
                    Command: toastr["error"]("Please select designation.");
                    //alert('Please select designation.');
                    return;
                }

                if($('select[id$=DrpD_Election]').val() == '0')
                {
                    Command: toastr["error"]("Please select election.");
                    //alert('Please select election.');
                    return;
                }
                
                if(!selectedItems.length)
                {
                    Command: toastr["error"]("Please select student to nominate.");
                    //alert('Please select student to nominate');
                    return;
                }

                if(!confirm("Are you sure?"))
                    return;
 
                var $grid = $NoConflict("#jsGrid");
 
                $.each(selectedItems, function(_, item) {
                    //$grid.jsGrid("deleteItem", item);
                    AddNominee(item);
                });
 
                selectedItems = [];
            };
        });

        //Nominee Grid

        $NoConflictNominee(function () {
            $NoConflictNominee("#jsGridNominee").jsGrid({
                height: "auto",
                width: "100%",
                filtering: true,
                inserting: false,
                editing: false,
                sorting: true,
                paging: true,
                autoload: true,
                pageSize: 15,
                pageButtonCount: 5,
                deleteConfirm: function(item) {
                    return "Are you sure ?" + "\n\""+item.Nom_Name+ "\" will be deleted permenently.";
                },

                controller: {
                    loadData: function (filter) {
                        return $.grep(NomineeData, function (student) {
                            return (!filter.Nom_Key || student.Nom_Key.toLowerCase().indexOf(filter.Nom_Key.toLowerCase()) > -1)
                                && (!filter.Nom_Name || student.Nom_Name.toLowerCase().indexOf(filter.Nom_Name.toLowerCase()) > -1)
                                && (!filter.Nom_ClassSection || student.Nom_ClassSection.toLowerCase().indexOf(filter.Nom_ClassSection.toLowerCase()) > -1)
                                && (!filter.Nom_DesignationId || student.Nom_DesignationId === filter.Nom_DesignationId)
                                && (!filter.Stud_HouseId || student.Stud_HouseId === filter.Stud_HouseId)
                                && (!filter.Nom_ElectionId || student.Nom_ElectionId === filter.Nom_ElectionId)
                        });
                    },
                    deleteItem: function (item) {
                        DeleteNominee(item);
                    },
                },
                fields: [
                   
                    { name: "Nom_Id", type: "text", width: 50, title: "ID", editing: false, inserting: false, css: "HideField",
                        headercss: "HideField",
                        filtercss: "HideField",
                        insertcss: "HideField",
                        editcss: "HideField", },
                    { name: "Nom_Key", type: "text", width: 50, title: "Election Id", editing: false, inserting: false },
                    { name: "Nom_Name", type: "text", width: 60, title: "Full Name" },
                    { name: "Nom_ClassSection", type: "text", width: 60, title: "Class Section"  },
                    {
                        name: "Nom_DesignationId",
                        type: "select",
                        items: DesignationData,
                        valueField: "Key",
                        textField: "Value",
                        title: "Designation",
                        width: 60,
                        align:"left",
                    },
                    {
                        name: "Nom_ElectionId",
                        type: "select",
                        items: ElectionDropdownData,
                        valueField: "Key",
                        textField: "Value",
                        title: "Election",
                        width: 60,
                        align:"left",
                    },
                    //{ name: "Nom_DesignationKey", type: "text", width: 60, sorting: true , title: "Designation" },
                    { type: "control", editButton: false, deleteButton: true, width:20 }
                ]
            });
        });
    </script>

    <script type="text/javascript">
        function DeleteNominee(item) {
            $.ajax({
                type: "POST",
                url: "HouseNomination.aspx/DeleteNominee",
                data: '{xiNomId: "' + item.Nom_Id +'"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if(response.d == "1")
                    {
                        Command: toastr["success"]("Nominee has been deleted successfully");
                    }
                    else if(response.d == "0")
                    {
                        Command: toastr["error"]("Nominee has not deleted. Please try later");
                    }
                    else
                    {
                        Command: toastr["warning"]("Cannot delete nominee. Please try later.");
                    }
                    setTimeout(function () { location.reload(); }, 5000);
                },
                failure: function (response) {
                    Command: toastr["warning"]("Cannot delete nominee. Please try later.");
                    setTimeout(function () { location.reload(); }, 5000);
                }

            }); 
        }

        function AddNominee(item) {
            $.ajax({
                type: "POST",
                url: "HouseNomination.aspx/AddNominee",
                data: '{xiClassSectionId: "' + item.Stud_ClassSectionId +'", xiStudKey: "' + item.Stud_Key +'", xiHouseDrp: "' + $('select[id$=DrpD_Houses]').val() +'", xiDesignationDrp: "' + $('select[id$=DrpD_Designation]').val() +'", xiElectionDrp: "' + $('select[id$=DrpD_Election]').val() +'" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if(response.d == "1")
                    {
                        Command: toastr["success"]("Nominee " + item.Nom_Id + " has been added successfully");
                    }
                    else if(response.d == "0")
                    {
                        Command: toastr["error"]("Nominee " + item.Nom_Id + " has not added. Please try later");
                    }
                    else
                    {
                        Command: toastr["warning"]("Cannot add nominee. Please try later.");
                    }
                    setTimeout(function () { location.reload(); }, 5000);
                },
                failure: function (response) {
                    Command: toastr["warning"]("Cannot add nominee. Please try later.");
                    setTimeout(function () { location.reload(); }, 5000);
                }
            }); 
        }

        toastr.options = {
            "closeButton": false,
            "debug": false,
            "newestOnTop": true,
            "progressBar": true,
            "positionClass": "toast-top-center",
            "preventDuplicates": true,
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
    <style>
        .HideField {
            display: none;
        }
    </style>
</asp:Content>
