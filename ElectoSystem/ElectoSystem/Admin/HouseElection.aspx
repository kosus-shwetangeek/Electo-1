<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Staff.Master" AutoEventWireup="true" CodeBehind="HouseElection.aspx.cs" Inherits="ElectoSystem.Admin.HouseElection" %>

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
    <h1>Configure House Election</h1>
    <div id="jsGrid"></div>
    <script>
        var $NoConflict = jQuery.noConflict();

        var Data = <%= JsonData.ToString()%>
        $NoConflict(function () {


            var StartDateField = function (config) {
                jsGrid.Field.call(this, config);
            };
            StartDateField.prototype = new jsGrid.Field({
                sorter: function (date1, date2) {
                    return new Date(date1) - new Date(date2);
                },
                itemTemplate: function (value) {
                    var lDate = new Date(value);
                    var curr_date = lDate.getDate();
                    var curr_month = lDate.getMonth() + 1; //Months are zero based
                    var curr_year = lDate.getFullYear();
                    return (curr_date + "-" + ("0" + (curr_month)).slice(-2) + "-" + curr_year);
                    //return new Date(value).toDateString();
                },
                insertTemplate: function (value) {
                    return this._insertPicker = $NoConflict("<input>").datepicker({ changeMonth: true, changeYear: true, defaultDate: new Date(), maxDate: "+12m +0w", minDate: "+0m +0w", yearRange: '<%= DateTime.Now.Year%>:<%= DateTime.Now.Year + 1%>', dateFormat: 'dd-mm-yy' });
                },
                <%--editTemplate: function (value) {
                    return this._editPicker = $NoConflict("<input>").datepicker({ changeMonth: true, changeYear: true, defaultDate: new Date(), maxDate: "+12m +0w", minDate: "+0m +0w", yearRange: '<%= DateTime.Now.Year%>:<%= DateTime.Now.Year + 1%>', dateFormat: 'dd-mm-yy' }).datepicker("setDate", new Date(value));
                },--%>
                insertValue: function () {
                    if (this._insertPicker.datepicker("getDate") != null) {
                        return this._insertPicker.datepicker("getDate").toISOString();
                    }
                    else {
                        return '';
                    }
                },
                //editValue: function () {
                //    if (this._editPicker.datepicker("getDate") != null) {
                //        return this._editPicker.datepicker("getDate").toISOString();
                //    }
                //    else {
                //        return '';
                //    }
                //}
            });

            var EndDateField = function (config) {
                jsGrid.Field.call(this, config);
            };
            EndDateField.prototype = new jsGrid.Field({
                sorter: function (date1, date2) {
                    return new Date(date1) - new Date(date2);
                },
                itemTemplate: function (value) {
                    var lDate = new Date(value);
                    var curr_date = lDate.getDate();
                    var curr_month = lDate.getMonth() + 1; //Months are zero based
                    var curr_year = lDate.getFullYear();
                    return (curr_date + "-" + ("0" + (curr_month)).slice(-2) + "-" + curr_year);
                    //return new Date(value).toDateString();
                },
                insertTemplate: function (value) {
                    return this._insertPicker = $NoConflict("<input>").datepicker({ changeMonth: true, changeYear: true, defaultDate: new Date(), maxDate: "+12m +0w", minDate: "+0m +0w", yearRange: '<%= DateTime.Now.Year%>:<%= DateTime.Now.Year + 1%>', dateFormat: 'dd-mm-yy' });
                },
                editTemplate: function (value) {
                    return this._editPicker = $NoConflict("<input>").datepicker({ changeMonth: true, changeYear: true, maxDate: "+12m +0w", minDate: "+0m +0w", yearRange: '<%= DateTime.Now.Year%>:<%= DateTime.Now.Year + 1%>', dateFormat: 'dd-mm-yy' });
                },
                insertValue: function () {
                    if (this._insertPicker.datepicker("getDate") != null) {
                        return this._insertPicker.datepicker("getDate").toISOString();
                    }
                    else {
                        return '';
                    }
                },
                editValue: function () {
                    if (this._editPicker.datepicker("getDate") != null) {
                        return this._editPicker.datepicker("getDate").toISOString();
                    }
                    else {
                        return '';
                    }
                }
            });

            jsGrid.fields.StartDate = StartDateField;
            jsGrid.fields.EndDate = EndDateField;

            $NoConflict("#jsGrid").jsGrid({
                height: "auto",
                width: "100%",
                filtering: false,
                editing: true,
                inserting: true,
                sorting: true,
                paging: true,
                autoload: true,
                pageSize: 10,
                pageButtonCount: 5,
                deleteConfirm: function (item) {
                    if (item.IsInUse == '#') {
                        Command: toastr["error"]("Cannot delete selected election. Reference has been used.");
                        this.preventDefault();
                    }
                    return "Are you sure ?" + "\n\"" + item.Description + "\" will be deleted permenently.";
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
                        Command: toastr["error"](lValidationString);
                        $NoConflict(this).jsGrid("reset");
                    }
                },

                controller: {
                    loadData: function (filter) {
                        return $.grep(Data, function (house) {
                            return (!filter.Description || house.Description.toLowerCase().indexOf(filter.Description.toLowerCase()) > -1)
                                && (!filter.Status || house.Status.toLowerCase().indexOf(filter.Status.toLowerCase()) > -1)
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
                        name: "ElectionId", type: "text", width: 50, title: "ID", filtering: false, inserting: false, editing: false, sorting: false, css: "HideField",
                        headercss: "HideField",
                        filtercss: "HideField",
                        insertcss: "HideField",
                        editcss: "HideField",
                    },
                    { name: "IsInUse", type: "text", width: 10, title: " ", inserting: false, editing: false, filtering: false },
                    { name: "StartDate", width: 90, title: "Start Date", type: "StartDate", editing: false, insertcss: "Mandatory" },
                    { name: "EndDate", type: "EndDate", width: 90, title: "End Date", insertcss: "Mandatory", editcss: "Mandatory" },
                    { name: "Description", type: "text", width: 90, title: "Description", insertcss: "Mandatory", editcss: "Mandatory" },
                    { name: "Status", type: "text", width: 90, title: "Status", inserting: false, editing: false },
                    { type: "control", editButton: true, deleteButton: true },
                ]
            });

        });
    </script>
    <script type="text/javascript">
        function DeleteItem(item) {
            $.ajax({
                type: "POST",
                url: "HouseElection.aspx/DeleteItem",
                data: '{id: "' + item.ElectionId + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.d == "1") {
                        Command: toastr["success"]("Election has been deleted successfully.");
                    }
                    else if (response.d == "0") {
                            Command: toastr["error"]("Could not delete election...!!!");
                    }
                    else {
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

        function AddItem(item) {
            $.ajax({
                type: "POST",
                url: "HouseElection.aspx/AddItem",
                data: '{startdate: "' + item.StartDate + '", enddate: "' + item.EndDate + '", description: "' + item.Description + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.d == "1") {
                        Command: toastr["success"]("Election has been added successfully.");
                    }
                    else if (response.d == "0") {
                            Command: toastr["error"]("Could not add election...!!!");
                    }
                    else {
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

        function UpdateItem(item) {
            $.ajax({
                type: "POST",
                url: "HouseElection.aspx/UpdateItem",
                data: '{id: "' + item.ElectionId + '", enddate: "' + item.EndDate + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.d == "1") {
                        Command: toastr["success"]("Election has been updated successfully.");
                    }
                    else if (response.d == "0") {
                            Command: toastr["error"]("Could not update election...!!!");
                    }
                    else {
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

        function ValidateItem(item) {
            var lValidationString = '';

            if (item.StartDate == '' || item.StartDate == null ||
                item.EndDate == '' || item.EndDate == null ||
                item.Description == '' || item.Description == null
                ) {
                lValidationString = lValidationString + 'Please enter the required details and then click add/update icon';
            }

                //if (item.StartDate == '' || item.StartDate == null) {
                //    lValidationString = lValidationString + 'Please select correct start date. <br/>';
                //    //Command: toastr["error"]("Please select correct start date.");
                //}

                //if (item.EndDate == '' || item.EndDate == null) {
                //    lValidationString = lValidationString + 'Please select correct end date. <br/>';
                //    //Command: toastr["error"]("Please select correct end date.");
                //}

                //if (item.Description == '' || item.Description == null) {
                //    lValidationString = lValidationString + 'Please enter election description. <br/>';
                //    //Command: toastr["error"]("Please enter election description.");
                //}
            else {
                var inputVal = item.Description;
                var characterReg = /^([a-zA-Z-0-9 ]{2,50})$/;
                if (!characterReg.test(inputVal)) {
                    //Command: toastr["error"]("Please enter alphanumeric only in description field with minimum 2 to 50 character.");
                    lValidationString = lValidationString + 'Please enter alphanumeric only in description field with minimum 2 to 50 character. <br/>';
                }
            }
            //alert(lValidationString);
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
