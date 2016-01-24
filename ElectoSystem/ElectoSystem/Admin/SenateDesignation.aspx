<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Staff.Master" AutoEventWireup="true" CodeBehind="SenateDesignation.aspx.cs" Inherits="ElectoSystem.Admin.SenateDesignation" %>

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
    <h1>Senate Designation</h1>
    <div id="jsGrid"></div>
    <script>
        var $NoConflict = jQuery.noConflict();

        var Data =<%= JsonData.ToString() %>
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
                    return "Are you sure ?" + "\n\"" + item.Stud_SenateDesignation + "\" will permenently deleted.";
                },

                rowClick: function (args) {
                    this.preventDefault();
                },
                rowDoubleClick: function (args) {
                    this.preventDefault();
                },

                onItemInserting: function (args) {

                    var lValidationString = ValidateItem(args.item);

                    if (lValidationString != '') {
                        Command: toastr["error"](lValidationString);
                        $NoConflict(this).jsGrid("reset");
                    }
                },

                onItemUpdating: function (args) {

                    var lValidationString = ValidateItem(args.item);

                    if (lValidationString != '') {
                        Command: toastr["error"](lValidationString);
                        $NoConflict(this).jsGrid("reset");
                    }
                },
                controller: {
                    loadData: function (filter) {
                        return $.grep(Data, function (senateDesignation) {
                            return (!filter.Stud_SenateId || senateDesignation.Stud_SenateId.toLowerCase().indexOf(filter.Stud_SenateId.toLowerCase()) > -1)
                                && (!filter.Stud_SenateDesignation || senateDesignation.Stud_SenateDesignation.toLowerCase().indexOf(filter.Stud_SenateDesignation.toLowerCase()) > -1)
                                && (!filter.Stud_SenateDesignationDescription || senateDesignation.Stud_SenateDesignationDescription.toLowerCase().indexOf(filter.Stud_SenateDesignationDescription.toLowerCase()) > -1)
                                && (!filter.Stud_SenateDesignationCode || senateDesignation.Stud_SenateDesignationCode.toLowerCase().indexOf(filter.Stud_SenateDesignationCode.toLowerCase()) > -1)
                                && (!filter.Stud_GenderId || senateDesignation.Stud_GenderId == filter.Stud_GenderId)
                        });
                    },

                    deleteItem: function (senateDesignation) {
                        DeleteSenateDesignation(senateDesignation);
                    },

                    insertItem: function (senateDesignation) {
                        AddSenateDesignation(senateDesignation);
                    },

                    updateItem: function (senateDesignation) {
                        UpdateSenateDesignation(senateDesignation);
                    },
                },
                fields: [
                    { name: "Stud_IsInUse", type: "text", width: 10, title: " ", inserting: false, editing: false, filtering: false },
                        {
                            name: "Stud_SenateId", type: "text", width: 10, title: "ID", filtering: false, inserting: false, editing: false, sorting: false, css: "HideField",
                            headercss: "HideField",
                            filtercss: "HideField",
                            insertcss: "HideField",
                            editcss: "HideField",
                        },
                        { name: "Stud_SenateDesignation", type: "text", width: 90, title: "Senate Designation", insertcss: "Mandatory",editcss: "Mandatory"},
                        { name: "Stud_SenateDesignationDescription", type: "text", width: 90, title: "Designation Description", insertcss: "Mandatory", editcss: "Mandatory" },
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
                            width: 30,
                            align: "left",
                            insertcss: "Mandatory",
                            editcss: "Mandatory"
                        },
                    { type: "control", editButton: true, deleteButton: true },
                ]
            });

        });
    </script>

    <script type="text/javascript">

        function DeleteSenateDesignation(senateDesignation) {
            $.ajax({
                type: "POST",
                url: "SenateDesignation.aspx/DeleteSenateDesignation",
                data: '{senatedesignatioid: "' + senateDesignation.Stud_SenateId + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.d == "1") {
                        Command: toastr["success"]("Senate designation has been deleted successfully.");
                    }
                    else if (response.d == "0") {
                            Command: toastr["error"]("Could not delete senate designation...!!!");
                    }
                    else {
                        Command: toastr["warning"]("Could not complete operation. Please try later.");
                    }
                    setTimeout(function () { location.reload(); }, 5000);
                },
                failure: function (response) {
                    Command: toastr["warning"](response.d);
                    setTimeout(function () { location.reload(); }, 5000);
                }
            });
        }

        function AddSenateDesignation(senateDesignation) {
            $.ajax({
                type: "POST",
                url: "SenateDesignation.aspx/AddSenateDesignation",
                data: '{senatedesignation: "' + senateDesignation.Stud_SenateDesignation + '", senatedesignationdescription: "' + senateDesignation.Stud_SenateDesignationDescription + '", genderid: "' + senateDesignation.Stud_GenderId + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.d == "1") {
                        Command: toastr["success"]("Senate designation has been added successfully.");
                    }
                    else if (response.d == "0") {
                            Command: toastr["error"]("Could not add senate designation...!!!");
                    }
                    else {
                        Command: toastr["warning"]("Could not complete operation. Please try later.");
                    }
                    setTimeout(function () { location.reload(); }, 5000);
                },
                failure: function (response) {
                    Command: toastr["warning"]("Could not complete operation. Please try later.");
                    setTimeout(function () { location.reload(); }, 5000);
                }
            });
        }

        function UpdateSenateDesignation(senateDesignation) {
            $.ajax({
                type: "POST",
                url: "SenateDesignation.aspx/UpdateSenateDesignation",
                data: '{senatedesignatioid: "' + senateDesignation.Stud_SenateId + '", senatedesignation: "' + senateDesignation.Stud_SenateDesignation + '", senatedesignationdescription: "' + senateDesignation.Stud_SenateDesignationDescription + '", genderid: "' + senateDesignation.Stud_GenderId + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.d == "1") {
                        Command: toastr["success"]("Senate designation has been updated successfully.");
                    }
                    else if (response.d == "0") {
                            Command: toastr["error"]("Could not update senate designation...!!!");
                    }
                    else {
                        Command: toastr["warning"]("Could not complete operation. Please try later.");
                    }
                    setTimeout(function () { location.reload(); }, 5000);
                },
                failure: function (response) {
                    Command: toastr["warning"]("Could not complete operation. Please try later.");
                    setTimeout(function () { location.reload(); }, 5000);
                }
            });
        }

        function ValidateItem(item) {
            var lValidationString = '';

            if (item.Stud_SenateDesignation == '' || item.Stud_SenateDesignation == null ||
                item.Stud_SenateDesignationDescription == '' || item.Stud_SenateDesignationDescription == null ||
                item.Stud_GenderId == '0' || item.Stud_GenderId == null
                ) {
                //Command: toastr["error"]("Please select house.");
                lValidationString = lValidationString + 'Please enter the required details and then click add/update icon.<br/><br/>';
            }

            if (item.Stud_SenateDesignation == '' || item.Stud_SenateDesignation == null) {
                //lValidationString = lValidationString + 'Please enter senate designation. <br/>';
                //Command: toastr["error"]("Please enter senate designation.");
            }
            else {
                var inputVal = item.Stud_SenateDesignation;
                var characterReg = /^([a-zA-Z- ]{2,50})$/;
                if (!characterReg.test(inputVal)) {
                    lValidationString = lValidationString + 'Please enter alphabates only in desination field with minimum 2 to 50 character. <br/>';
                    //Command: toastr["error"]("Please enter alphabates only in desination field with minimum 2 to 50 character.");
                }
            }

            if (item.Stud_SenateDesignationDescription == '' || item.Stud_SenateDesignationDescription == null) {
               // lValidationString = lValidationString + 'Please enter designation description. <br/>';
                //Command: toastr["error"]("Please enter designation description.");
            }
            else {
                var inputVal = item.Stud_SenateDesignationDescription;
                var characterReg = /^([a-zA-Z- ]{2,50})$/;
                if (!characterReg.test(inputVal)) {
                    lValidationString = lValidationString + 'Please enter alphabates only in description field with minimum 2 to 50 character. <br/>';
                    //Command: toastr["error"]("Please enter alphabates only in description field with minimum 2 to 50 character.");
                }
            }

            if (item.Stud_GenderId == '0' || item.Stud_GenderId == null) {
                //lValidationString = lValidationString + 'Please select gender. <br/>';
                //Command: toastr["error"]("Please select gender.");
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
