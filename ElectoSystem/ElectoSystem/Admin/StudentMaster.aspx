<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Staff.Master" AutoEventWireup="true" CodeBehind="StudentMaster.aspx.cs" Inherits="ElectoSystem.Admin.StudentMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<link rel="stylesheet" type="text/css" href="../dist/css/JSGridDemo.css" />--%>

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
    <h1>Student Master</h1>
    <div id="jsGrid"></div>
    <script>
        var $NoConflict = jQuery.noConflict();

        var Data = <%= JsonData.ToString()%>

        var ClassSectionDropdownData = $NoConflict.parseJSON('<%= JClassSectionData%>');

        var HouseDropdownData = $NoConflict.parseJSON('<%= JHouseData%>');

        $NoConflict(function () {

            var MyDateField = function(config) {
                jsGrid.Field.call(this, config);
            };
            MyDateField.prototype = new jsGrid.Field({
                sorter: function(date1, date2) {
                    return new Date(date1) - new Date(date2);
                },
                itemTemplate: function(value) {
                    var lDate = new Date(value);
                    var curr_date = lDate.getDate();
                    var curr_month = lDate.getMonth() + 1; //Months are zero based
                    var curr_year = lDate.getFullYear();
                    return(curr_date + "-" + ("0" + (curr_month)).slice(-2)+ "-" + curr_year);
                    //return new Date(value).toDateString();
                },
                insertTemplate: function(value) {
                    return this._insertPicker = $NoConflict("<input>").datepicker({changeMonth: true, changeYear: true, defaultDate: new Date(), maxDate: "+0m +0w", minDate:new Date(1995, 1 - 1, 26), yearRange: '1995:<%= DateTime.Now.Year%>', dateFormat: 'dd-mm-yy' });
                },
                editTemplate: function(value) {
                    return this._editPicker = $NoConflict("<input>").datepicker({changeMonth: true, changeYear: true, maxDate: "+0m +0w", dateFormat: 'dd-mm-yy'}).datepicker("setDate", new Date(value));
                },
                insertValue: function() {
                    if(this._insertPicker.datepicker("getDate") != null)
                    {
                        return this._insertPicker.datepicker("getDate").toISOString();
                    }
                    else
                    {
                        return '';
                    }
                },
                editValue: function() {
                    if(this._editPicker.datepicker("getDate") != null)
                    {
                        return this._editPicker.datepicker("getDate").toISOString();
                    }
                    else
                    {
                        return '';
                    }
                }
            });
            
            jsGrid.fields.myDateField = MyDateField;

            $NoConflict("#jsGrid").jsGrid({
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
                    if (item.Stud_IsInUse == '#') {
                        Command: toastr["error"]("Cannot delete selected student. Reference has been used.");
                        this.preventDefault();
                    }
                    return "Are you sure ?" + "\n\""+item.Stud_FName +" " + item.Stud_LName + "\" will be deleted permenently.";
                },

                rowClick: function(args) { 
                    this.preventDefault();
                },
                rowDoubleClick: function(args) { 
                    this.preventDefault();
                },

                onItemInserting: function(args) {
                    
                    var lValidationString = ValidateItem(args.item);

                    if(lValidationString != '')
                    {
                        Command: toastr["error"](lValidationString);
                        $NoConflict(this).jsGrid("reset");
                    }
                },

                onItemUpdating: function(args) {
                    
                    var lValidationString = ValidateItem(args.item);

                    if(lValidationString != '')
                    {
                        Command: toastr["error"](lValidationString);
                        $NoConflict(this).jsGrid("reset");
                    }
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

                    insertItem: function (item) {
                        AddStudent(item);
                    },

                    updateItem: function (item) {
                        UpdateStudent(item);
                    }
                },
                fields: [
                    { name: "Stud_IsInUse", type: "text", width: 10, title: " ", inserting: false, editing: false, filtering: false },
                    { name: "Stud_Key", type: "text", title: "Election ID", editing: false, inserting: false },
                    { name: "Stud_FName", type: "text", title: "First Name" , insertcss: "Mandatory", editcss: "Mandatory"},
                    { name: "Stud_MName", type: "text", title: "Middle Name", insertcss: "Mandatory", editcss: "Mandatory"},
                    { name: "Stud_LName", type: "text", sorting: true , title: "Last Name", insertcss: "Mandatory", editcss: "Mandatory"},
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
                        insertcss: "Mandatory", 
                        editcss: "Mandatory"
                        
                    },
                    {
                        name: "Stud_ClassSectionId",
                        type: "select",
                        items: ClassSectionDropdownData,
                        valueField: "Key",
                        textField: "Value",
                        title: "ClassSection",
                        insertcss: "Mandatory", 
                        editcss: "Mandatory"
                    },
                    {
                        name: "Stud_HouseId",
                        type: "select",
                        items: HouseDropdownData,
                        valueField: "Key",
                        textField: "Value",
                        title: "House",
                        insertcss: "Mandatory", 
                        editcss: "Mandatory"
                    },
                    { name: "Stud_Password", type: "text", sorting: false, title: "Password", insertcss: "Mandatory", editcss: "Mandatory"},
                    { name: "Stud_DoB", type: "myDateField", align: "center", title: "DoB" ,insertcss: "Mandatory", editcss: "Mandatory"},
                    { type: "control", editButton: true, deleteButton: true  }
                ]
            });
        });
    </script>

    <script type="text/javascript">
        function DeleteStudent(item) {
            alert('Delete Hit');
            $.ajax({
                type: "POST",
                url: "StudentMaster.aspx/DeleteStudent",
                data: '{id: "' + item.Stud_Key + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.d == "1") {
                        Command: toastr["success"]("Student has been deleted successfully.");
                    }
                    else if (response.d == "0") {
                        Command: toastr["error"]("Could not add student...!!!");
                    }
                    else {
                        Command: toastr["warning"]("Could not complete operation. Please try later.");
                    }
                    setTimeout(function () { location.reload(); }, 5000);
                },
                failure: function (response) {
                    Command: toastr["error"](response.d);
                    setTimeout(function () { location.reload(); }, 5000);
                    //alert(response.d);
                }
            });
        }

        function AddStudent(item) {
            alert('Add Stud');
            $.ajax({
                type: "POST",
                url: "StudentMaster.aspx/AddStudent",
                data: '{xiFName: "' + item.Stud_FName + '", xiMName: "' + item.Stud_MName + '", xiLName: "' + item.Stud_LName + '", xiGenderId: "' + item.Stud_GenderId + '", xiClassSectionId: "' + item.Stud_ClassSectionId +'", xiHouseId: "' + item.Stud_HouseId +'", xiPasswod: "' + item.Stud_Password +'", xiDoB: "' + item.Stud_DoB +'" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.d == "1") {
                        Command: toastr["success"]("Student has been added successfully.");
                    }
                    else if (response.d == "0") {
                        Command: toastr["error"]("Could not add student...!!!");
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

        function UpdateStudent(item) {
            $.ajax({
                type: "POST",
                url: "StudentMaster.aspx/UpdateStudent",
                data: '{xiKey: "' + item.Stud_Key + '", xiFName: "' + item.Stud_FName + '", xiMName: "' + item.Stud_MName + '", xiLName: "' + item.Stud_LName + '", xiGenderId: "' + item.Stud_GenderId + '", xiClassSectionId: "' + item.Stud_ClassSectionId +'", xiHouseId: "' + item.Stud_HouseId +'", xiPasswod: "' + item.Stud_Password +'", xiDoB: "' + item.Stud_DoB +'" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.d == "1") {
                        Command: toastr["success"]("Student has been updated successfully.");
                    }
                    else if (response.d == "0") {
                        Command: toastr["error"]("Could not update student...!!!");
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

        function ValidateItem(item)
        {
            var lValidationString = '';
                    

            if(item.Stud_FName.trim() == '' || item.Stud_FName === null ||
                item.Stud_MName.trim() == '' || item.Stud_MName === null ||
                item.Stud_LName.trim() == '' || item.Stud_LName === null ||
                item.Stud_GenderId == '0' || item.Stud_GenderId === null ||
                item.Stud_ClassSectionId == '0' || item.Stud_ClassSectionId === null ||
                item.Stud_HouseId == '0' || item.Stud_HouseId === null ||
                item.Stud_Password.trim() == '' || item.Stud_Password === null ||
                item.Stud_DoB.trim() == '' || item.Stud_DoB === null)
            {
                lValidationString = lValidationString + 'Please enter the required details and then click add/update icon.<br/><br/>';
            }
            else
            {
                var inputVal = item.Stud_FName ;
                var characterReg = /^([a-zA-Z]{2,50})$/;
                if(!characterReg.test(inputVal)) {
                    lValidationString = lValidationString + 'Please enter alphabates only in first name field with minimum 2 to 50 character. <br/><br/>';
                }
            }

            if(item.Stud_MName == '' || item.Stud_MName === null)
            {
                //Do Nothing
            }
            else
            {
                var inputVal = item.Stud_MName;
                var characterReg = /^([a-zA-Z]{2,50})$/;
                if(!characterReg.test(inputVal)) {
                    lValidationString = lValidationString + 'Please enter alphabates only in middle name field with minimum 2 to 50 character. <br/><br/>';
                }
            }

            if(item.Stud_LName == '' || item.Stud_LName === null)
            {
                //Do Nothing
            }
            else
            {
                var inputVal = item.Stud_LName;
                var characterReg = /^([a-zA-Z]{2,50})$/;
                if(!characterReg.test(inputVal)) {
                    lValidationString = lValidationString + 'Please enter alphabates only in last name field with minimum 2 to 50 character. <br/><br/>';
                }
            }

            if(item.Stud_GenderId == '0' || item.Stud_GenderId === null)
            {
                //Do Nothing
            }

            if(item.Stud_ClassSectionId == '0' || item.Stud_ClassSectionId === null)
            {
                //Do Nothing
            }

            if(item.Stud_HouseId == '0' || item.Stud_HouseId === null)
            {
                //lValidationString = lValidationString + 'Please select house for student. <br/>';
            }

            if(item.Stud_Password == '' || item.Stud_Password === null)
            {
                //lValidationString = lValidationString + 'Please enter password for student login. <br/>';
            }
            else
            {
                var inputVal = item.Stud_Password;
                var characterReg = /^([a-zA-Z0-9@]{6,25})$/;
                if(!characterReg.test(inputVal)) {
                    lValidationString = lValidationString + 'Please enter alphanumeric character only in password with minimum 6 to 25 character. <br/><br/>';
                }
            }

            if(item.Stud_DoB == '' || item.Stud_DoB === null)
            {
                //lValidationString = lValidationString + 'Please select date of birth for student. <br/>';
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
