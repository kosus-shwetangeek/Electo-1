<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCandidate.aspx.cs" Inherits="ElectoSystem.Authenticate.RegisterCandidate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Electo | Registration Page</title>
    <meta content='width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no' name='viewport'>
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
</head>
<body class="register-page">
    <div class="register-box">
        <div class="register-logo">
            <a href="login.html"><b>Admin</b> ELECTO</a>
        </div>

        <div class="register-box-body">
            <p class="login-box-msg">Register a new membership</p>
            <form id="form1" runat="server">
                <div class="form-group has-feedback">
                    <select name="class-section" class="form-control">
                        <option value="0">Select Class</option>
                        <option value="1">1st</option>
                    </select>
                </div>
                <div class="form-group has-feedback">
                    <%--<input type="text" class="form-control" name="c_id" placeholder="Eneter Candidate ID"/>--%>
                    <asp:TextBox ID="Txt_CandidateId" class="form-control" name="c_id" placeholder="Eneter Candidate ID" runat="server"></asp:TextBox>
                </div>
                <div class="form-group has-feedback">
                    <%--<input type="text" class="form-control" name="f_name" placeholder="First Name"/>--%>
                    <asp:TextBox ID="Txt_FirstName" class="form-control" name="f_name" placeholder="First Name" runat="server"></asp:TextBox>
                </div>
                <div class="form-group has-feedback">
                    <%--<input type="text" class="form-control" name="m_name" placeholder="Middle Name"/>--%>
                    <asp:TextBox ID="Txt_MiddleName" class="form-control" name="m_name" placeholder="Middle Name" runat="server"></asp:TextBox>
                </div>
                <div class="form-group has-feedback">
                    <%--<input type="text" class="form-control" name="l_name" placeholder="Last Name"/>--%>
                    <asp:TextBox ID="Txt_LastName" class="form-control" name="l_name" placeholder="Last Name" runat="server"></asp:TextBox>
                </div>
                <div class="form-group has-feedback">
                    <asp:TextBox ID="txt_DOB" runat="server" class="form-control" placeholder="Date of Birth" autofocus required title="Date Format: MM/dd/yyyy" pattern="\d{1,2}/\d{1,2}/\d{4}"></asp:TextBox>
                </div>
                <div class="form-group has-feedback">
                    <select name="class-section" class="form-control">
                        <option value="0">Select Gender</option>
                        <option value="1">Female</option>
                        <option value="2">Male</option>
                    </select>
                </div>
                <div class="form-group has-feedback">
                    <asp:TextBox ID="txt_Password" runat="server" TextMode="Password" class="form-control" placeholder="Enter Password" autofocus required title="must be alphanumeric 6 chars, Special characters allowed: - and @" pattern="[a-zA-Z0-9_@]{6,8}"></asp:TextBox>
                </div>
                <div class="form-group has-feedback">
                    <asp:TextBox ID="txt_ConfirmPassword" runat="server" TextMode="Password" class="form-control" placeholder="Enter Confirm Password" autofocus required title="must be alphanumeric 6 chars, Special characters allowed: - and @" pattern="[a-zA-Z0-9_@]{6,8}"></asp:TextBox>
                </div>
                <div class="row">
                    <div class="col-xs-8">
                        <div class="checkbox icheck">
                            <label>
                                <input type="checkbox">
                                I agree to the <a href="#">terms</a>
                            </label>
                        </div>
                    </div>
                    <!-- /.col -->
                    <div class="col-xs-4">
                        <asp:Button ID="btn_Submit" runat="server" Text="Submit" class="btn btn-primary btn-block btn-flat" OnClick="btn_Submit_Click" />
                    </div>
                    <!-- /.col -->
                </div>
            </form>
            <a href="login.html" class="text-center">Already Registered?</a>
        </div>
        <!-- /.form-box -->
    </div>
    <!-- /.register-box -->
    <a href="login.html" class="text-center">Already Registered?</a>
    <!-- jQuery 2.1.3 -->
    <script src="../plugins/jQuery/jQuery-2.1.3.min.js"></script>
    <!-- Bootstrap 3.3.2 JS -->
    <script src="../bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <!-- iCheck -->
    <script src="../plugins/iCheck/icheck.min.js" type="text/javascript"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/jquery-ui.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var $NoConflict = jQuery.noConflict();
        var StudentData = JSON.stringify(<%= JsonData%>);
        alert(StudentData);

        $("#Txt_CandidateId").autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: "states_remote.php",
                    dataType: "json",
                    data: { term: request.term },
                    success: function (data) {
                        response($.map(data, function (item) {
                            return {
                                label: item.state,
                                id: item.id,
                                abbrev: item.abbrev
                            };
                        }));
                    }
                });
            },
            minLength: 2,
            select: function (event, ui) {
                $('#state_id').val(ui.item.id);
                $('#abbrev').val(ui.item.abbrev);
            }
        });

    </script>

    <script>
        $(function () {
            $('input').iCheck({
                checkboxClass: 'icheckbox_square-blue',
                radioClass: 'iradio_square-blue',
                increaseArea: '20%' // optional
            });
        });
    </script>
</body>
</html>
