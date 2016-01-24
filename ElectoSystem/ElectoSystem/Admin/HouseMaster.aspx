<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Staff.Master" AutoEventWireup="true" CodeBehind="HouseMaster.aspx.cs" Inherits="ElectoSystem.Admin.HouseMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../dist/css/jsgrid.css" />
    <link rel="stylesheet" type="text/css" href="../dist/css/theme.css" />
    <link rel="stylesheet" type="text/css" href="../dist/css/toastr.min.css" />
    <link rel="stylesheet" type="text/css" href="../dist/css/toastr.css" />
    <link href="../dist/css/jquery-ui.css" rel="stylesheet" />

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
    <script src="../dist/js/jquery-ui.min.js"></script>

    <script src="../dist/js/toastr.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Configure House</h1>
    <div id="jsGrid"></div>
    <script>
        var $NoConflict = jQuery.noConflict();

        var Data = <%= JsonData.ToString()%>
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
                        Command: toastr["error"]("Cannot delete selected house. Reference has been used.");
                        this.preventDefault();
                    }
                    return "Are you sure ?" + "\n\"" + item.Stud_HouseName + "\" will be deleted permenently.";
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
                        //alert(lValidationString);
                        Command: toastr["error"](lValidationString);
                        $NoConflict(this).jsGrid("reset");
                    }
                },

                onItemUpdating: function (args) {

                    var lValidationString = ValidateItem(args.item);

                    if (lValidationString != '') {
                        //alert(lValidationString);
                        Command: toastr["error"](lValidationString);
                        //$NoConflict(args.jsGrid).jsGrid("reset");
                        $NoConflict(this).jsGrid("reset");
                    }
                },

                controller: {
                    loadData: function (filter) {
                        return $.grep(Data, function (house) {
                            return (!filter.Stud_HouseId || house.Stud_HouseId.toLowerCase().indexOf(filter.Stud_HouseId.toLowerCase()) > -1)
                                && (!filter.Stud_HouseName || house.Stud_HouseName.toLowerCase().indexOf(filter.Stud_HouseName.toLowerCase()) > -1)
                                && (!filter.Stud_HouseDescription || house.Stud_HouseDescription.toLowerCase().indexOf(filter.Stud_HouseDescription.toLowerCase()) > -1)
                                && (!filter.Stud_HouseCode || house.Stud_HouseCode.toLowerCase().indexOf(filter.Stud_HouseCode.toLowerCase()) > -1)
                        });
                    },

                    deleteItem: function (item) {
                        DeleteItem(item);
                    },

                    insertItem: function (item) {
                        AddItem(item);
                    },

                    updateItem: function (item) {
                        UpdateItem(item);
                    },
                },
                fields: [
                    {
                        name: "Stud_HouseId", type: "text", width: 50, title: "ID", filtering: false, inserting: false, editing: false, sorting: false, css: "HideField",
                        headercss: "HideField",
                        filtercss: "HideField",
                        insertcss: "HideField",
                        editcss: "HideField",
                    },
                    { name: "Stud_IsInUse", type: "text", width: 10, title: " ", inserting: false, editing: false, filtering: false },
                    { name: "Stud_HouseName", type: "text", width: 90, title: "House Name", insertcss: "Mandatory", editcss: "Mandatory" },
                    { name: "Stud_HouseDescription", type: "text", width: 90, title: "House Description", insertcss: "Mandatory", editcss: "Mandatory" },
                    { type: "control", editButton: true, deleteButton: true },
                ]
            });

        });
    </script>
    <script type="text/javascript">
        function DeleteItem(item) {
            $.ajax({
                type: "POST",
                url: "HouseMaster.aspx/DeleteItem",
                data: '{id: "' + item.Stud_HouseId + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.d == "1") {
                        Command: toastr["success"]("House has been deleted successfully.");
                    }
                    else if (response.d == "0") {
                        Command: toastr["error"]("Could not delete house...!!!");
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

        function AddItem(item) {
            $.ajax({
                type: "POST",
                url: "HouseMaster.aspx/AddItem",
                data: '{name: "' + item.Stud_HouseName + '", desc: "' + item.Stud_HouseDescription + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.d == "1") {
                        Command: toastr["success"]("House has been added successfully.");
                    }
                    else if (response.d == "0") {
                        Command: toastr["error"]("Could not add house...!!!");
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

        function UpdateItem(item) {
            $.ajax({
                type: "POST",
                url: "HouseMaster.aspx/UpdateItem",
                data: '{id: "' + item.Stud_HouseId + '", name: "' + item.Stud_HouseName + '", desc: "' + item.Stud_HouseDescription + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.d == "1") {
                        Command: toastr["success"]("House has been updated successfully.");
                    }
                    else if (response.d == "0") {
                        Command: toastr["error"]("Could not update house...!!!");
                    }
                    else {
                        Command: toastr["warning"]("Could not complete operation. Please try later.");
                    }
                    setTimeout(function () { location.reload(); }, 5000);
                },
                failure: function (response) {
                    //alert(response.d);
                    Command: toastr["warning"](response.d);
                    setTimeout(function () { location.reload(); }, 5000);
                }
            });
        }

        function OnSuccess(response) {
            alert(response.d);
        }
        function ValidateItem(item) {
            var lValidationString = '';

            //First we will check for the empty fileds
            if (item.Stud_HouseName.trim() == '' || item.Stud_HouseName == null ||
                item.Stud_HouseDescription.trim() == '' || item.Stud_HouseDescription == null) {
                lValidationString = lValidationString + 'Please enter the required details and then click add/update icon';
            }
            
            //Check for house name text validation
            if (item.Stud_HouseName != null && 
                item.Stud_HouseName.trim() != '') {

                var inputVal = item.Stud_HouseName;
                var characterReg = /^([a-zA-Z- ]{2,50})$/;
                if (!characterReg.test(inputVal)) {
                    lValidationString = lValidationString + 'Please enter alphabates only in house name field with minimum 2 to 50 character. <br/>';
                }
            }

            //Check for house description name text validation
            if (item.Stud_HouseDescription != null && 
                item.Stud_HouseDescription.trim() != "") {
                var inputVal = item.Stud_HouseDescription;
                var characterReg = /^([a-zA-Z- ]{2,50})$/;
                if (!characterReg.test(inputVal)) {
                    lValidationString = lValidationString + 'Please enter alphabates only in description field with minimum 2 to 50 character. <br/>';
                }
            }

            return lValidationString;
        }

        toastr.options = {
            "closeButton": false,
            "debug": false,
            "newestOnTop": true,
            "progressBar": false,
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
