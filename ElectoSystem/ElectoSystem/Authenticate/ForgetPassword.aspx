<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs" Inherits="ElectoSystem.Reports.ForgetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <title>Electo | Reset Password</title>
    <meta content='width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no' name='viewport' />
    <!-- Bootstrap 3.3.2 -->
    <link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- Font Awesome Icons -->
    <link href="../bootstrap/css/font-awesome-min.css" rel="stylesheet" type="text/css" />
    <!-- Ionicons 2.0.0 -->
    <link href="../bootstrap/css/ionicons.min.css" rel="stylesheet" type="text/css" />
    <!-- Theme style -->
    <link href="../dist/css/AdminLTE.min.css" rel="stylesheet" type="text/css" />
    <!-- iCheck -->
    <link href="../plugins/iCheck/square/blue.css" rel="stylesheet" type="text/css" />

    <link href="../dist/css/style.css" rel="stylesheet" type="text/css" />

    <link href="../dist/css/jquery-ui.css" rel="stylesheet" />
     <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>
    <![endif]-->
</head>
<body class="login-page">
    <%--<form id="form1" runat="server">--%>
    <div class="">
        <div class="login-box-body">
           <%-- <h1>Forget Password</h1>--%>
            <%-- <form action="login.html" method="post">--%>
            <form id="form1" class="forgot-pass" runat="server">
                <%--                <div class="form-group has-feedback">
                    <asp:DropDownList ID="ddl_ClassSection" runat="server" class="form-control"></asp:DropDownList>
                    <select name="class-section" class="form-control">
                        <option value="0">Select Class</option>
                        <option value="1">1st</option>
                    </select>
                </div>--%>
                <div class="form-body">
                    <div class="form-group has-feedback">
                        <asp:TextBox ID="txt_CandidateId" runat="server" class="form-control" placeholder="Enter Candidate ID" autofocus required title="must be alphanumeric 6 chars" pattern="[a-zA-Z0-9]{6,8}"></asp:TextBox>
                        <%--<input type="text" class="form-control" name="c_id" placeholder="Eneter Candidate ID" />--%>
                    </div>
                    <div id="dob" class="form-group has-feedback">
                        <asp:TextBox ID="txt_DOB" runat="server" class="form-control" placeholder="Date of Birth" autofocus required title="Date Format: MM/dd/yyyy" pattern="\d{1,2}/\d{1,2}/\d{4}"></asp:TextBox>
                        <%--<input type="date" class="form-control" placeholder="Date of Birth" />--%>
                    </div>
                    <div class="form-group has-feedback">
                        <asp:TextBox ID="txt_Password" runat="server" TextMode="Password" class="form-control" placeholder="Enter Password" autofocus required title="must be alphanumeric 6 chars, Special characters allowed: - and @" pattern="[a-zA-Z0-9_@]{6,8}"></asp:TextBox>
                        <%--<input type="password" class="form-control" placeholder="Password" />--%>
                    </div>
                    <div class="form-group has-feedback">
                        <asp:TextBox ID="txt_ConfirmPassword" runat="server" TextMode="Password" class="form-control" placeholder="Enter Confirm Password" autofocus required title="must be alphanumeric 6 chars, Special characters allowed: - and @" pattern="[a-zA-Z0-9_@]{6,8}"></asp:TextBox>
                        <%--<input type="password" class="form-control" placeholder="Confirm Password" />--%>
                    </div>
                    </div>
                        <div class="login-button forgot">
                            <asp:Button ID="btn_Submit" runat="server" Text="Submit" class="btn btn-primary btn-block btn-flat" OnClick="btn_Submit_Click" />
                            <%--<button type="submit" class="btn btn-primary btn-block btn-flat">Sign In</button>--%>
                        
                            <div class="login-back"style="text-align: center;">
                              <a href="Login.aspx" class="text-center">Back To Login</a><br />
                            </div>
                  </div>      <!-- /.col -->
            </form>
           
        </div>
    </div>
    <!-- /.login-box-body -->
    <%--</form>--%>
</body>
</html>
<!-- jQuery 2.1.3 -->
<script src="../plugins/jQuery/jQuery-2.1.3.min.js"></script>
<!-- Bootstrap 3.3.2 JS -->
<script src="../bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
<!-- iCheck -->
<script src="../plugins/iCheck/icheck.min.js" type="text/javascript"></script>

<script src="../dist/js/jquery-ui.min.js" type="text/javascript"></script>


<script>
    $(function () {
        $("#txt_DOB").datepicker({
            showOn: "button",
            changeMonth: true,
            changeYear: true,
            buttonImage: "../dist/img/calender.png",
            buttonImageOnly: true,
            buttonText: "Select date"
        });
    });

    var password = document.getElementById("txt_Password")
      , confirm_password = document.getElementById("txt_ConfirmPassword")
    , DoB = document.getElementById("txt_DOB");

    function validatePassword() {
        if (password != null && confirm_password != null) {
            if (password.value != confirm_password.value) {
                confirm_password.setCustomValidity("Password & Confirm Password Don't Match");
            } else {
                confirm_password.setCustomValidity('');
            }
        }

        //if (DoB != null)
        //{
        //    if (DoB.value == '') {
        //        DoB.setCustomValidity("Please Select Birth Date");
        //    }
        //    else {
        //        DoB.setCustomValidity('');
        //    }
        //}
    }
    password.onchange = validatePassword;
    confirm_password.onkeyup = validatePassword;
</script>
