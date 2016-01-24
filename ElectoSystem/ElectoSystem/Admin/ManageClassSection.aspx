<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Staff.Master" AutoEventWireup="true" CodeBehind="ManageClassSection.aspx.cs" Inherits="ElectoSystem.Admin.ManageClassSection" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../dist/css/jsgrid.css" />
    <link rel="stylesheet" type="text/css" href="../dist/css/theme.css" />
    <link href="../dist/css/jquery-ui.css" rel="stylesheet" />
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
    <h1>Class</h1>
    <div id="jsClassGrid" ></div>
    <br /><br /><br />
    <h1>Section</h1>
    <div id="jsSectionGrid"></div>
    <%--<div id="jsClassSectionGrid"></div>--%>

    <%--#region Class--%>
    <script>
        var $NoConflict = jQuery.noConflict();

        var ClassData = <%= JsonClassData.ToString()%>

        $NoConflict(function () {

            $NoConflict("#jsClassGrid").jsGrid({
                height: "auto",
                width: "100%",
                filtering: true,
                inserting: true,
                editing: true,
                sorting: true,
                paging: true,
                autoload: true,
                pageSize: 15,
                pageButtonCount: 5,
                deleteConfirm: function(item) {
                    if (item.Class_IsInUse == '#') {
                        Command: toastr["error"]("Cannot delete selected class. Reference has been used.");
                        this.preventDefault();
                    }
                    return "Are you sure ?" + "\n\""+item.DisplayClassName +"\" will be deleted permenently.";
                },

                rowClick: function(args) { 
                    this.preventDefault();
                },
                rowDoubleClick: function(args) { 
                    this.preventDefault();
                },

                onItemInserting: function(args) {
                    
                    var lValidationString = ValidateClass(args.item);

                    if(lValidationString != '')
                    {
                        Command: toastr["error"](lValidationString);
                        $NoConflict(this).jsGrid("reset");
                    }
                },

                onItemUpdating: function(args) {
                    
                    var lValidationString = ValidateClass(args.item);

                    if(lValidationString != '')
                    {
                        Command: toastr["error"](lValidationString);
                        $NoConflict(this).jsGrid("reset");
                    }
                },

                controller: {
                    loadData: function (filter) {
                        return $.grep(ClassData, function (classes) {
                            return (!filter.ClassId || classes.ClassId.toLowerCase().indexOf(filter.ClassId.toLowerCase()) > -1)
                               && (!filter.ClassName || classes.ClassName.toLowerCase().indexOf(filter.ClassName.toLowerCase()) > -1)
                               && (!filter.DisplayClassName || classes.DisplayClassName.toLowerCase().indexOf(filter.DisplayClassName.toLowerCase()) > -1)
                        });
                    },
                    deleteItem: function (item) {
                        DeleteClass(item);
                    },

                    insertItem: function (item) {
                        AddClass(item);
                    },

                    updateItem: function (item) {
                        UpdateClass(item);
                    }
                },
                fields: [
                   {
                       name: "ClassId", type: "text", width: 50, title: "ID", filtering: false, inserting: false, editing: false, sorting: false, css: "HideField",
                       headercss: "HideField",
                       filtercss: "HideField",
                       insertcss: "HideField",
                       editcss: "HideField",
                   },
                    { name: "Class_IsInUse", type: "text", width: 10, title: " ", inserting: false, editing: false, filtering: false },
                    { name: "ClassName", type: "text", width: 90, title: "Class Name", insertcss: "Mandatory", editcss: "Mandatory" },
                    { name: "DisplayClassName", type: "text", width: 90, title: "Display Class Name", insertcss: "Mandatory", editcss: "Mandatory" },
                    { type: "control", editButton: true, deleteButton: true },
                ]
            });
        });
        </script>

    <script type="text/javascript">
        function DeleteClass(item) {
            $.ajax({
                type: "POST",
                url: "ManageClassSection.aspx/DeleteClass",
                data: '{id: "' + item.ClassId + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.d == "1") {
                        Command: toastr["success"]("Class has been deleted successfully.");
                    }
                    else if (response.d == "0") {
                            Command: toastr["error"]("Could not add class...!!!");
                    }
                    else {
                        Command: toastr["warning"]("Could not complete operation. Please try later.");
                    }
                    setTimeout(function () { location.reload(); }, 5000);
                },
                failure: function (response) {
                    Command: toastr["error"](response.d);
                    setTimeout(function () { location.reload(); }, 5000);
                }
            });
        }

        function AddClass(item) {
            $.ajax({
                type: "POST",
                url: "ManageClassSection.aspx/AddClass",
                data: '{name: "' + item.ClassName + '", desc:"' + item.DisplayClassName + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.d == "1") {
                        Command: toastr["success"]("Class has been added successfully.");
                    }
                    else if (response.d == "0") {
                            Command: toastr["error"]("Could not add class...!!!");
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

        function UpdateClass(item) {
            $.ajax({
                type: "POST",
                url: "ManageClassSection.aspx/UpdateClass",
                data: '{id: "' + item.ClassId + '", name: "' + item.ClassName + '", desc: "' + item.DisplayClassName + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.d == "1") {
                        Command: toastr["success"]("Class has been updated successfully.");
                    }
                    else if (response.d == "0") {
                            Command: toastr["error"]("Could not update class...!!!");
                    }
                    else {
                        Command: toastr["warning"]("Could not complete operation. Please try later.");
                    }
                },
                failure: function (response) {
                    Command: toastr["warning"](response.d);
                }
            });
        }

        function ValidateClass(item) {
            var lValidationString = '';

            //First we will check for the empty fileds
            if (item.ClassName.trim() == '' || item.ClassName == null ||
                item.DisplayClassName.trim() == '' || item.DisplayClassName == null) {
                lValidationString = lValidationString + 'Please enter the required details and then click add/update icon';
            }

            //Check for house name text validation
            //if (item.ClassName != null &&
            //    item.ClassName.trim() != '') {

            //    var inputVal = item.ClassName;
            //    var characterReg = /^([0-9]{2,50})$/;
            //    if (!characterReg.test(inputVal)) {
            //        lValidationString = lValidationString + 'Please enter alphabates only in class name field with minimum 2 to 50 character. <br/>';
            //    }
            //}

            //Check for house description name text validation
            //if (item.DisplayClassName != null &&
            //    item.DisplayClassName.trim() != "") {
            //    var inputVal = item.DisplayClassName;
            //    var characterReg = /^([a-zA-Z- ]{2,50})$/;
            //    if (!characterReg.test(inputVal)) {
            //        lValidationString = lValidationString + 'Please enter alphabates only in display class name field with minimum 2 to 50 character. <br/>';
            //    }
            //}

            return lValidationString;
        }

        //toastr.options = {
        //    "closeButton": false,
        //    "debug": false,
        //    "newestOnTop": true,
        //    "progressBar": true,
        //    "positionClass": "toast-top-center",
        //    "preventDuplicates": true,
        //    "onclick": null,
        //    "showDuration": "500",
        //    "hideDuration": "1000",
        //    "timeOut": "5000",
        //    "extendedTimeOut": "1000",
        //    "showEasing": "swing",
        //    "hideEasing": "linear",
        //    "showMethod": "fadeIn",
        //    "hideMethod": "fadeOut"
        //}
    </script>

    <%--#region Section--%>
    <script type="text/javascript">
         var $NoConflict = jQuery.noConflict();
         var SectionData = <%= JsonSectionData.ToString()%>
        $NoConflict(function () {

            $NoConflict("#jsSectionGrid").jsGrid({
                height: "auto",
                width: "100%",
                filtering: true,
                inserting: true,
                editing: true,
                sorting: true,
                paging: true,
                autoload: true,
                pageSize: 15,
                pageButtonCount: 5,
                deleteConfirm: function(item) {
                    if (item.Section_IsInUse == '#') {
                        Command: toastr["error"]("Cannot delete selected section. Reference has been used.");
                        this.preventDefault();
                    }
                    return "Are you sure ?" + "\n\""+item.DisplaySectionName +"\" will be deleted permenently.";
                },

                rowClick: function(args) { 
                    this.preventDefault();
                },
                rowDoubleClick: function(args) { 
                    this.preventDefault();
                },

                onItemInserting: function(args) {
                    
                    var lValidationString = ValidateSection(args.item);

                    if(lValidationString != '')
                    {
                        Command: toastr["error"](lValidationString);
                        $NoConflict(this).jsGrid("reset");
                    }
                },

                onItemUpdating: function(args) {
                    
                    var lValidationString = ValidateSection(args.item);

                    if(lValidationString != '')
                    {
                        Command: toastr["error"](lValidationString);
                        $NoConflict(this).jsGrid("reset");
                    }
                },

                controller: {
                    loadData: function (filter) {
                        return $.grep(SectionData, function (sections) {
                            return (!filter.SectionId || sections.SectionId.toLowerCase().indexOf(filter.SectionId.toLowerCase()) > -1)
                               && (!filter.SectionName || sections.SectionName.toLowerCase().indexOf(filter.SectionName.toLowerCase()) > -1)
                               && (!filter.DisplaySectionName || sections.DisplaySectionName.toLowerCase().indexOf(filter.DisplaySectionName.toLowerCase()) > -1)
                        });
                    },
                    deleteItem: function (item) {
                        DeleteSection(item);
                    },

                    insertItem: function (item) {
                        AddSection(item);
                    },

                    updateItem: function (item) {
                        UpdateSection(item);
                    }
                },
                fields: [
                   {
                       name: "SectionId", type: "text", width: 50, title: "ID", filtering: false, inserting: false, editing: false, sorting: false, css: "HideField",
                       headercss: "HideField",
                       filtercss: "HideField",
                       insertcss: "HideField",
                       editcss: "HideField",
                   },
                    { name: "Section_IsInUse", type: "text", width: 10, title: " ", inserting: false, editing: false, filtering: false },
                    { name: "SectionName", type: "text", width: 90, title: "Section Name", insertcss: "Mandatory", editcss: "Mandatory" },
                    { name: "DisplaySectionName", type: "text", width: 90, title: "Display Section Name", insertcss: "Mandatory", editcss: "Mandatory" },
                    { type: "control", editButton: true, deleteButton: true },
                ]
            });
        });
    </script>

    <script type="text/javascript">
        function DeleteSection(item) {
            $.ajax({
                type: "POST",
                url: "ManageClassSection.aspx/DeleteSection",
                data: '{id: "' + item.SectionId + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.d == "1") {
                        alert(response.d);
                        Command: toastr["success"]("Section has been deleted successfully.");
                    }
                    else if (response.d == "0") {
                            Command: toastr["error"]("Could not add section...!!!");
                    }
                    else {
                        Command: toastr["warning"]("Could not complete operation. Please try later.");
                    }
                    setTimeout(function () { location.reload(); }, 5000);
                },
                failure: function (response) {
                    Command: toastr["error"](response.d);
                    setTimeout(function () { location.reload(); }, 5000);
                }
            });
        }

        function AddSection(item) {
            $.ajax({
                type: "POST",
                url: "ManageClassSection.aspx/AddSection",
                data: '{name: "' + item.SectionName + '", desc:"' + item.DisplaySectionName + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.d == "1") {
                        Command: toastr["success"]("Section has been added successfully.");
                    }
                    else if (response.d == "0") {
                            Command: toastr["error"]("Could not add section...!!!");
                    }
                    else {
                        Command: toastr["warning"]("Could not complete operation. Please try later.");
                    }
                    setTimeout(function () { location.reload(); }, 5000);
                    
                },
                failure: function (response) {
                    Command: toastr["error"](response.d);
                    setTimeout(function () { location.reload(); }, 5000);
                }
            });
        }

        function UpdateSection(item) {
            $.ajax({
                type: "POST",
                url: "ManageClassSection.aspx/UpdateSection",
                data: '{id: "' + item.SectionId + '", name: "' + item.SectionName + '", desc: "' + item.DisplaySectionName + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.d == "1") {
                        Command: toastr["success"]("Section has been updated successfully.");
                    }
                    else if (response.d == "0") {
                        Command: toastr["error"]("Could not update section...!!!");
                    }
                    else {
                        Command: toastr["warning"]("Could not complete operation. Please try later.");
                    }
                },
                failure: function (response) {
                    Command: toastr["warning"](response.d);
                }
            });
        }

        function ValidateSection(item) {
            var lValidationString = '';

            //First we will check for the empty fileds
            if (item.SectionName.trim() == '' || item.SectionName == null ||
                item.DisplaySectionName.trim() == '' || item.DisplaySectionName == null) {
                lValidationString = lValidationString + 'Please enter the required details and then click add/update icon';
            }

            //Check for house name text validation
            //if (item.SectionName != null &&
            //    item.SectionName.trim() != '') {

            //    var inputVal = item.SectionName;
            //    var characterReg = /^([0-9]{2,50})$/;
            //    if (!characterReg.test(inputVal)) {
            //        lValidationString = lValidationString + 'Please enter alphabates only in class name field with minimum 2 to 50 character. <br/>';
            //    }
            //}

            //Check for house description name text validation
            //if (item.DisplaySectionName != null &&
            //    item.DisplaySectionName.trim() != "") {
            //    var inputVal = item.DisplaySectionName;
            //    var characterReg = /^([a-zA-Z- ]{2,50})$/;
            //    if (!characterReg.test(inputVal)) {
            //        lValidationString = lValidationString + 'Please enter alphabates only in display class name field with minimum 2 to 50 character. <br/>';
            //    }
            //}

            return lValidationString;
        }

        //toastr.options = {
        //    "closeButton": false,
        //    "debug": false,
        //    "newestOnTop": true,
        //    "progressBar": true,
        //    "positionClass": "toast-top-center",
        //    "preventDuplicates": true,
        //    "onclick": null,
        //    "showDuration": "500",
        //    "hideDuration": "1000",
        //    "timeOut": "5000",
        //    "extendedTimeOut": "1000",
        //    "showEasing": "swing",
        //    "hideEasing": "linear",
        //    "showMethod": "fadeIn",
        //    "hideMethod": "fadeOut"
        //}
    </script>

    <%--#region Class Section--%>
    <%--<script type="text/javascript">
         var $NoConflict = jQuery.noConflict();
         var ClassSectionData = <%= JsonClassSectionData.ToString()%>
        $NoConflict(function () {

            $NoConflict("#jsClassSectionGrid").jsGrid({
                height: "auto",
                width: "100%",
                filtering: true,
                inserting: true,
                editing: true,
                sorting: true,
                paging: true,
                autoload: true,
                pageSize: 15,
                pageButtonCount: 5,
                deleteConfirm: function(item) {
                    if (item.ClassSection_IsInUse == '#') {
                        Command: toastr["error"]("Cannot delete selected class section. Reference has been used.");
                        this.preventDefault();
                    }
                    return "Are you sure ?" + "\n\"" + item.DisplayClassSectionName + "\" will be deleted permenently.";
                },

                rowClick: function(args) { 
                    this.preventDefault();
                },
                rowDoubleClick: function(args) { 
                    this.preventDefault();
                },

                onItemInserting: function(args) {
                    
                    var lValidationString = ValidateClassSection(args.item);

                    if(lValidationString != '')
                    {
                        Command: toastr["error"](lValidationString);
                        $NoConflict(this).jsGrid("reset");
                    }
                },

                onItemUpdating: function(args) {
                    
                    var lValidationString = ValidateClassSection(args.item);

                    if(lValidationString != '')
                    {
                        Command: toastr["error"](lValidationString);
                        $NoConflict(this).jsGrid("reset");
                    }
                },

                controller: {
                    loadData: function (filter) {
                        return $.grep(ClassSectionData, function (classsections) {
                            return (!filter.ClassSectionId || classsections.ClassSectionId.toLowerCase().indexOf(filter.ClassSectionId.toLowerCase()) > -1)
                               && (!filter.ClassSectionName || classsections.ClassSectionName.toLowerCase().indexOf(filter.ClassSectionName.toLowerCase()) > -1)
                               && (!filter.DisplayClassSectionName || classsections.DisplayClassSectionName.toLowerCase().indexOf(filter.DisplayClassSectionName.toLowerCase()) > -1)
                        });
                    },
                    deleteItem: function (item) {
                        DeleteClassSection(item);
                    },

                    insertItem: function (item) {
                        AddClassSection(item);
                    },

                    updateItem: function (item) {
                        UpdateClassSection(item);
                    }
                },
                fields: [
                   {
                       name: "ClassSectionId", type: "text", width: 50, title: "ID", filtering: false, inserting: false, editing: false, sorting: false, css: "HideField",
                       headercss: "HideField",
                       filtercss: "HideField",
                       insertcss: "HideField",
                       editcss: "HideField",
                   },
                    { name: "ClassSection_IsInUse", type: "text", width: 10, title: " ", inserting: false, editing: false, filtering: false },
                    { name: "ClassSectionName", type: "text", width: 90, title: "Class Section Name", insertcss: "Mandatory", editcss: "Mandatory" },
                    { name: "DisplayClassSectionName", type: "text", width: 90, title: "Display Class Section Name", insertcss: "Mandatory", editcss: "Mandatory" },
                    { type: "control", editButton: true, deleteButton: true },
                ]
            });
        });
    </script>

    <script type="text/javascript">
        function DeleteClassSection(item) {
            // alert('Delete Hit');
            $.ajax({
                type: "POST",
                url: "ManageClassSection.aspx/DeleteClassSection",
                data: '{id: "' + item.ClassSectionId + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.d == "1") {
                        Command: toastr["success"]("Class Section has been deleted successfully.");
                    }
                    else if (response.d == "0") {
                            Command: toastr["error"]("Could not add class section...!!!");
                    }
                    else {
                        Command: toastr["warning"]("Could not complete operation. Please try later.");
                    }
                    location.reload();
                },
                failure: function (response) {
                    Command: toastr["error"](response.d);
                    location.reload();
                    //alert(response.d);
                }
            });
        }

        function AddClassSection(item) {
            // alert('Add Stud');
            $.ajax({
                type: "POST",
                url: "ManageClassSection.aspx/AddClassSection",
                data: '{classid :"' + item.ClassId + '", sectionid :"' + item.SectionId + '", name: "' + item.ClassSectionName + '", desc:"' + item.DisplayClassSectionName + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.d == "1") {
                        Command: toastr["success"]("Class Section has been added successfully.");
                    }
                    else if (response.d == "0") {
                            Command: toastr["error"]("Could not add class section...!!!");
                    }
                    else {
                        Command: toastr["warning"]("Could not complete operation. Please try later.");
                    }
                    location.reload();
                },
                failure: function (response) {
                    //alert(response.d);
                    Command: toastr["error"](response.d);
                    location.reload();
                }
            });
        }

        function UpdateClassSection(item) {
            $.ajax({
                type: "POST",
                url: "ManageClassSection.aspx/UpdateClassSection",
                data: '{id: "' + item.ClassSectionId + '", classid :"' + item.ClassId + '", sectionid :"' + item.SectionId + '", name: "' + item.ClassSectionName + '", desc: "' + item.DisplayClassSectionName + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.d == "1") {
                        Command: toastr["success"]("Class Section has been updated successfully.");
                    }
                    else if (response.d == "0") {
                            Command: toastr["error"]("Could not update class section...!!!");
                    }
                    else {
                        Command: toastr["warning"]("Could not complete operation. Please try later.");
                    }
                },
                failure: function (response) {
                    //alert(response.d);
                    Command: toastr["warning"](response.d);
                }
            });
        }

        function ValidateClassSection(item) {
            var lValidationString = '';

            //First we will check for the empty fileds
            if (item.ClassSectionName.trim() == '' || item.ClassSectionName == null ||
                item.DisplayClassSectionName.trim() == '' || item.DisplayClassSectionName == null) {
                lValidationString = lValidationString + 'Please enter the required details and then click add/update icon';
            }

            //Check for house name text validation
            //if (item.ClassSectionName != null &&
            //    item.ClassSectionName.trim() != '') {

            //    var inputVal = item.ClassSectionName;
            //    var characterReg = /^([0-9]{2,50})$/;
            //    if (!characterReg.test(inputVal)) {
            //        lValidationString = lValidationString + 'Please enter alphabates only in class name field with minimum 2 to 50 character. <br/>';
            //    }
            //}

            //Check for house description name text validation
            //if (item.DisplayClassSectionName != null &&
            //    item.DisplayClassSectionName.trim() != "") {
            //    var inputVal = item.DisplayClassSectionName;
            //    var characterReg = /^([a-zA-Z- ]{2,50})$/;
            //    if (!characterReg.test(inputVal)) {
            //        lValidationString = lValidationString + 'Please enter alphabates only in display class name field with minimum 2 to 50 character. <br/>';
            //    }
            //}

            return lValidationString;
        }

        //toastr.options = {
        //    "closeButton": false,
        //    "debug": false,
        //    "newestOnTop": true,
        //    "progressBar": true,
        //    "positionClass": "toast-top-center",
        //    "preventDuplicates": true,
        //    "onclick": null,
        //    "showDuration": "500",
        //    "hideDuration": "1000",
        //    "timeOut": "5000",
        //    "extendedTimeOut": "1000",
        //    "showEasing": "swing",
        //    "hideEasing": "linear",
        //    "showMethod": "fadeIn",
        //    "hideMethod": "fadeOut"
        //}
    </script>--%>

    <%--#region Common--%>
    <script type="text/javascript">
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
