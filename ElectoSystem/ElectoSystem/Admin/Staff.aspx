<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Staff.Master" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="ElectoSystem.Admin.Staff1" %>
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
    <h1>Staff Master</h1>
    <script>
    <div id="jsGrid"></div>
if (studentHelper.Staff(Convert.ToInt32(xiStaffId),0,0,"","",0,"","D",1))
 controller: {
                    loadData: function (filter) {
                        return $.grep(Data, function (Staff) {
                            return (!filter.stf_UserId || Staff.stf_UserId.toLowerCase().indexOf(filter.stf_UserId.toLowerCase()) > -1)
                                && (!filter.stf_UserName || Staff.stf_UserName.toLowerCase().indexOf(filter.stf_UserName.toLowerCase()) > -1)
                                && (!filter.stf_FirstName || Staff.Stf_FirstName.toLowerCase().indexOf(filter.stf_FirstName.toLowerCase()) > -1)
                                && (!filter.stf_MiddleName || Staff.stf_MiddleName.toLowerCase().indexOf(filter.stf_MiddleName.toLowerCase()) > -1)
                                && (!filter.stf_LastName || Staff.stf_LastName.toLowerCase().indexOf(filter.stf_LastName.toLowerCase()) > -1)
                                && (!filter.stf_DOB|| Staff.stf_DOB === filter.stf_DOB)
                                && (!filter.stf_EmailId || Staff.stf_EmailId === filter.stf_EmailId)
                                && (!filter.stf_ContactNo || Staff.stf_ContactNo === filter.stf_ContactNo)
                                && (!filter.stf_GenderId || Staff.stf_GenderId === filter.stf_GenderId)
                                && (!filter.stf_AddressId|| Staff.stf_AddressIdId === filter.stf_AddressIdId)
                                && (!filter.stf_Password|| Staff.stf_Password === filter.stf_Password)
                                && (!filter.stf_CretatedDate|| Staff.stf_CreatedDate === filter.stf_CreatedDate)
                               

                        });
                    },
                    deleteItem: function (item) {
                        DeleteStaff(item);
                    },

                    insertItem: function (item) {
                        AddStaff(item);
                    },

                    updateItem: function (item) {
                        UpdateStaff(item);
                    }
                },
                fields: [
                    { name: "stf_IsInUse", type: "text", width: 10, title: " ", inserting: false, editing: false, filtering: false },
                    { name: "stf_UserId", type: "text", title: "Election ID", editing:false, inserting: false },
                    { name: "stf_UserName", type: "text", title: "User Name", editing:false, inserting: false },
                    { name: "stf_FirstName", type: "text", title: "First Name" , insertcss: "Mandatory", editcss: "Mandatory"},
                    { name: "stf_MiddleName", type: "text", title: "Middle Name", insertcss: "Mandatory", editcss: "Mandatory"},
                    { name: "stf_LastName", type: "text", sorting: true , title: "Last Name", insertcss: "Mandatory", editcss: "Mandatory"},
                     { name: "stf_DoB", type: "myDateField", align: "center", title: "DoB" ,insertcss: "Mandatory", editcss: "Mandatory"},
                    { name: "stf_EmailId", type: "text", sorting: true , title: "EmailId", insertcss: "Mandatory", editcss: "Mandatory"},
                    {
                        name: "stf_ContactNo",
                        valueField: "Key",
                        textField: "Value",
                        title: "ContactNo",
                        insertcss: "Mandatory", 
                        editcss: "Mandatory"
                    },

                    {
                        name: "stf_GenderId",
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
             { name: "stf_AddressId", type: "text", sorting: true , title: "EmailId", insertcss: "Mandatory", editcss: "Mandatory"},
                    
                { name: "stf_Address", type: "text", sorting: true , title: "EmailId", insertcss: "Mandatory", editcss: "Mandatory"},        
                    
                    { name: "stf_Password", type: "text", sorting: false, title: "Password", insertcss: "Mandatory", editcss: "Mandatory"},
                   { name: "stf_CreatedDate", type: "text", sorting: false, title: "Password", insertcss: "Mandatory", editcss: "Mandatory"},
                    { type: "control", editButton: true, deleteButton: true  }
                ]
            //});
        //});
    </script>

    <script type="text/javascript">
        function DeleteStaff(item) {
            alert('Delete Hit');
            $.ajax({
                type: "POST",
                url: "Staff.aspx/DeleteStaff",
                data: '{id: "' + item.stf_UserId + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.d == "1") {
                        Command: toastr["success"]("Staff has been deleted successfully.");
                    }
                    else if (response.d == "0") {
                            Command: toastr["error"]("Could not add staff...!!!");
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

        function AddStaff(item) {
            alert('Add Staff');
            $.ajax({
                type: "POST",
                url: "StudentMaster.aspx/AddStudent",
                data: '{xiFName: "' + item.stf_FirstName + '", xiMName: "' + item.stf_MidleName + '", xiLName: "' + item.stf_LastName + '",xiDOB: "' + item.stf_DOB + '",xiEmailId: "' + item.stf_EmailId + '",xiContactNo: "' + item.stf_ContactNo + '", xiGenderId: "' + item.Stud_GenderId + '", xiAddressId: "' + item.stf_AddressId +'",  xiPasswod: "' + item.Stud_Password +'", xiCreateDate: "' + item.CreateDate +'" }',
                
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.d == "1") {
                        Command: toastr["success"]("Staff has been added successfully.");
                    }
                    else if (response.d == "0") {
                            Command: toastr["error"]("Could not add staff...!!!");
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

        function UpdateStaff(item) {
            $.ajax({
                type: "POST",
                url: "Staff.aspx/UpdateStaff",
                data: 
                    contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                if (response.d == "1") {
                    Command: toastr["success"]("Staff has been updated successfully.");
                }
                else if (response.d == "0") {
                        Command: toastr["error"]("Could not update staff...!!!");
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
                    

            if(item.stf_FirstName.trim() == '' || item.stf_FirstName === null ||
                item.stf_MiddleName.trim() == '' || item.stf_MiddleName === null ||
                item.stf_LastName.trim() == '' || item.stf_LastName === null ||
                item.stf_DOB.trim() == '' || item.stf_DOB === null ||
                item.stf_EmailId.trim() == '' || item.stf_EmailId === null ||
                item.stf_ContactNo.trim() == '' || item.stf_ContactNo === null ||
                item.stf_GenderId == '0' || item.stf_GenderId === null ||
                item.stf_AddressId == '0' || item.stf_AddressId === null ||
                item.stf_Password.trim() == '' || item.stf_Password === null ||
                item.stf_CreatedDate.trim() == '' || item.stf_CreatedDate=== null ||
               
            {
                lValidationString = lValidationString + 'Please enter the required details and then click add/update icon.<br/><br/>';
            }
        else
        {
                var inputVal = item.stf_FirstName ;
        var characterReg = /^([a-zA-Z]{2,50})$/;
        if(!characterReg.test(inputVal)) {
            lValidationString = lValidationString + 'Please enter alphabates only in first name field with minimum 2 to 50 character. <br/><br/>';
        }
        }

        if(item.stf_MiddleName == '' || item.stf_MiddleName === null)
        {
            //Do Nothing
        }
        else
        {
            var inputVal = item.stf_MiddleName;
            var characterReg = /^([a-zA-Z]{2,50})$/;
            if(!characterReg.test(inputVal)) {
                lValidationString = lValidationString + 'Please enter alphabates only in middle name field with minimum 2 to 50 character. <br/><br/>';
            }
        }

        if(item.stf_LastName == '' || item.stf_LastName === null)
        {
            //Do Nothing
        }
        else
        {
            var inputVal = item.stf_LastName;
            var characterReg = /^([a-zA-Z]{2,50})$/;
            if(!characterReg.test(inputVal)) {
                lValidationString = lValidationString + 'Please enter alphabates only in last name field with minimum 2 to 50 character. <br/><br/>';
            }
        }
        if(item.stf_DOB== '0' || item.stf_DOB=== null)
        {
            //Do Nothing
        }
        if(item.stf_EmailId == '0' || item.stf_EmailId=== null)
        {
            //Do Nothing
        }
        if(item.stf_ContactNo == '0' || item.stf_ContactNo === null)
        {
            //Do Nothing
        }

        if(item.stf_GenderId == '0' || item.Stud_GenderId === null)
        {
            //Do Nothing
        }

        if(item.stf_AddressId == '0' || item.stf_AddressId === null)
        {
            //Do Nothing
        }

        if(item.stf_Password == '' || item.stf_Password === null)
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

        if(item.stf_createdDate == '' || item.CreatedDate === null)
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
