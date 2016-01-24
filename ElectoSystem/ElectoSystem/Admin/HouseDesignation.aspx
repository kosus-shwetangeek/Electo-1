<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Staff.Master" AutoEventWireup="true" CodeBehind="HouseDesignation.aspx.cs" Inherits="ElectoSystem.Admin.HouseDesignation" %>

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
    <h1>House Designation</h1>
    <div id="jsGrid"></div>
    <script>
        var $NoConflict = jQuery.noConflict();

        var Data = <%= JsonData.ToString()%>
        <%--var HouseNameList='<%= HouseName %>'
        var elements = jQuery.parseJSON(HouseNameList);--%>

        var HouseDropdownData = $NoConflict.parseJSON('<%= JHouseData%>');

        $NoConflict(function () {

            $NoConflict("#jsGrid").jsGrid({
                height: "auto",
                width: "100%",
                filtering: true,
                editing: true,
                inserting: true,
                sorting: true,
                paging: true,
                autoload: true,
                pageSize: 10,
                pageButtonCount: 5,
                deleteConfirm: function (item) {
                    if (item.Stud_IsInUse == '#') {
                        Command: toastr["error"]("Cannot delete selected designation. Reference has been used.");
                        this.preventDefault();
                    }
                    return "Are you sure ?" + "\n\"" + item.Stud_HouseDesignation + "\" will permenently deleted.";
                },

                rowClick: function(args) { 
                    this.preventDefault();
                },
                rowDoubleClick: function(args) { 
                    this.preventDefault();
                },

                onItemInserting: function (args) {
                    var lValidationString = ValidateItem(args.item);
                    if (lValidationString != '') {
                        Command: toastr["error"](lValidationString);
                        this.preventDefault();
                    }
                },

                onItemUpdating: function (args) {
                    var lValidationString = ValidateItem(args.item);
                    if (lValidationString != '') {
                        Command: toastr["error"](lValidationString);
                        this.preventDefault();
                    }
                },

                controller: {
                    loadData: function (filter) {
                        return $.grep(Data, function (houseDesignation) {
                            return (!filter.Stud_HouseId || houseDesignation.Stud_HouseId == filter.Stud_HouseId)
                                && (!filter.Stud_HouseDesignationId || houseDesignation.Stud_HouseDesignationId.toLowerCase().indexOf(filter.Stud_HouseDesignationId.toLowerCase()) > -1)
                                && (!filter.Stud_HouseDesignation || houseDesignation.Stud_HouseDesignation.toLowerCase().indexOf(filter.Stud_HouseDesignation.toLowerCase()) > -1)
                                && (!filter.Stud_HouseDesignationCode || houseDesignation.Stud_HouseDesignationCode.toLowerCase().indexOf(filter.Stud_HouseDesignationCode.toLowerCase()) > -1)
                                && (!filter.Stud_HouseDesignationDescription || houseDesignation.Stud_HouseDesignationDescription.toLowerCase().indexOf(filter.Stud_HouseDesignationDescription.toLowerCase()) > -1)
                                && (!filter.Stud_GenderId || houseDesignation.Stud_GenderId == filter.Stud_GenderId)
                        });
                    },
                    deleteItem: function (houseDesignation) {
                        DeleteHouseDesignation(houseDesignation);
                    },

                    insertItem: function (houseDesignation) {
                        AddHouseDesignation(houseDesignation);
                    },

                    updateItem: function (houseDesignation) {
                        UpdateHouseDesignation(houseDesignation);
                    },
                },
                fields: [
                    { name: "", type: "text", width: 30, title: "Sr. No.", inserting: false, editing: false, filtering: false },
                    {
                        name: "Stud_HouseDesignationId", type: "text", title: "ID", filtering: false, inserting: false, editing: false, sorting: false, 
                        css: "HideField",
                        headercss: "HideField",
                        filtercss: "HideField",
                        insertcss: "HideField",
                        editcss: "HideField",
                    },
                    { name: "Stud_IsInUse", type: "text", width: 10, title: " ", inserting: false, editing: false, filtering: false },
                    {
                        name: "Stud_HouseId",
                        type: "select",
                        items: HouseDropdownData,
                        valueField: "Key",
                        textField: "Value",
                        title: "House Name",
                        insertcss: "Mandatory", 
                        editcss: "Mandatory"
                    },
                        { name: "Stud_HouseDesignation", type: "text", title: "House Designation", insertcss: "Mandatory", editcss: "Mandatory" },
                        { name: "Stud_HouseDesignationDescription", type: "text", title: "Designation Description", insertcss: "Mandatory", editcss: "Mandatory" },
                        {
                            name: "Stud_GenderId",
                            type: "select",
                            items: [
                                { Name: "", Id: 0 },
                                { Name: "Girl/Boy", Id: 3 },
                                { Name: "Girl", Id: 1 },
                                { Name: "Boy", Id: 2 }
                            ],
                            valueField: "Id",
                            textField: "Name",
                            title: "Gender",
                            insertcss: "Mandatory", 
                            editcss: "Mandatory"
                        },
                    { type: "control", editButton: true, deleteButton: true },
                ]
            });

        });
    </script>

    <script type="text/javascript">
        var $NoConf = jQuery.noConflict();
        function DeleteHouseDesignation(houseDesignation) {
            $.ajax({
                type: "POST",
                url: "HouseDesignation.aspx/DeleteHouseDesignation",
                data: '{housedesignatioid: "' + houseDesignation.Stud_HouseDesignationId + '", housedesignation: "' + houseDesignation.Stud_HouseDesignation+ '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if(response.d == "1")
                    {
                        Command: toastr["success"]("House designation has been deleted successfully.");
                    }
                    else if(response.d == "0")
                    {
                        Command: toastr["error"]("House designation is not deleted.");
                    }
                    else
                    {
                        Command: toastr["warning"]("Could not complete operation. Please try later.");
                    }
                    setTimeout(function () { location.reload(); }, 5000);
                },
                failure: function (response) {
                    //alert(response.d);
                    Command: toastr["error"](response.d);
                    setTimeout(function () { location.reload(); }, 5000);
                }
            });
        }

        function AddHouseDesignation(houseDesignation) {
            $.ajax({
                type: "POST",
                url: "HouseDesignation.aspx/AddHouseDesignation",
                data: '{houseid: "' + houseDesignation.Stud_HouseId + '", housedesignation: "' + houseDesignation.Stud_HouseDesignation + '", housedesignationdescription: "' + houseDesignation.Stud_HouseDesignationDescription + '", genderid: "' + houseDesignation.Stud_GenderId + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if(response.d == "1")
                    {
                        Command: toastr["success"]("House designation has been added successfully.");
                    }
                    else if(response.d == "0")
                    {
                        Command: toastr["error"]("House designation is not added");
                    }
                    else
                    {
                        Command: toastr["warning"]("Could not complete operation. Please try later.");
                    }
                    setTimeout(function () { location.reload(); }, 5000);
                },
                failure: function (response) {
                    //alert(response.d);
                    Command: toastr["error"](response.d);
                    setTimeout(function () { location.reload(); }, 5000);
                }
            });
        }

        function UpdateHouseDesignation(houseDesignation) {
            $.ajax({
                type: "POST",
                url: "HouseDesignation.aspx/UpdateHouseDesignation",
                data: '{housedesignatioid: "' + houseDesignation.Stud_HouseDesignationId + '", houseid: "' + houseDesignation.Stud_HouseId + '", housedesignation: "' + houseDesignation.Stud_HouseDesignation + '", housedesignationdescription: "' + houseDesignation.Stud_HouseDesignationDescription + '", genderid: "' + houseDesignation.Stud_GenderId + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if(response.d == "1")
                    {
                        Command: toastr["success"]("House designation has been updated successfully.");
                    }
                    else if(response.d == "0")
                    {
                        Command: toastr["error"]("House designation is not updated.");
                    }
                    else
                    {
                        Command: toastr["warning"]("Could not complete operation. Please try later.");
                    }
                    setTimeout(function () { location.reload(); }, 5000);
                },
                failure: function (response) {
                    //alert(response.d);
                    Command: toastr["error"](response.d);
                    setTimeout(function () { location.reload(); }, 5000);
                }
            });
        }

        function OnSuccess(response) {
            alert(response.d);
        }

        function ValidateItem(item) {
            var lValidationString = '';

            if (item.Stud_HouseId == '0' || item.Stud_HouseId == null ||
                item.Stud_HouseDesignation == '' || item.Stud_HouseDesignation == null ||
                item.Stud_HouseDesignationDescription == '' || item.Stud_HouseDesignationDescription == null ||
                item.Stud_GenderId == '0' || item.Stud_GenderId == null) {
                //Command: toastr["error"]("Please select house.");
                lValidationString = lValidationString + 'Please enter the required details and then click add/update icon.<br/><br/>';
            }

            if (item.Stud_HouseDesignation == '' || item.Stud_HouseDesignation == null) {
                //Do Nothing
            }
            else {
                var inputVal = item.Stud_HouseDesignation;
                var characterReg = /^([a-zA-Z- ]{2,50})$/;
                if (!characterReg.test(inputVal)) {
                    //Command: toastr["error"]("Please enter alphabates only in designation field with minimum 2 to 50 character.");
                    lValidationString = lValidationString + 'Please enter alphabates only in designation field with minimum 2 to 50 character. <br/><br/>';
                }
            }

            if (item.Stud_HouseDesignationDescription == '' || item.Stud_HouseDesignationDescription == null) {
                //Do Nothing
            }
            else {
                var inputVal = item.Stud_HouseDesignationDescription;
                var characterReg = /^([a-zA-Z- ]{2,50})$/;
                if (!characterReg.test(inputVal)) {
                    //Command: toastr["error"]("Please enter alphabates only in description field with minimum 2 to 50 character.");
                    lValidationString = lValidationString + 'Please enter alphabates only in description field with minimum 2 to 50 character. <br/><br/>';
                }
            }

            return lValidationString;
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

        $NoConf(document).ready(function(){
            //use a special class name or id for the table
            //using find I'm getting all tr elements in the table
            //using not(':eq(0)') I'm ignoring the first tr element
            //using each I'm iterating through the selected elements
            $NoConf('.jsgrid-grid-body').find('.jsgrid-table').find('tr').each(function(i){
                //using children('td:eq(0)') I'm getting the first td element inside the tr
                $NoConf(this).children('td:eq(0)').addClass('sno').text(i+1);
            });
        });

    </script>
    <style>
        /*JS Grid Related classes*/
        /*To make column hidden*/
        .HideField {
            display: none;
        }
        /*To Make column mendetory*/
        .Mandatory {
            white-space: nowrap;
        }

            .Mandatory:after {
                content: url(../dist/img/mandatory16x16.svg);
            }
    </style>
</asp:Content>
