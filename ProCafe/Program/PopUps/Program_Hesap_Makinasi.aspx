<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Program_Hesap_Makinasi.aspx.cs" Inherits="ProCafe.Program.PopUps.Program_Hesap_Makinasi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../Script/Calculator/jquery-1.7.2.min.js"> </script>
    <script src="../../Script/Calculator/jquery.blackcalculator.src.js"> </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.calculator').blackCalculator({ type: 'advanced', allowKeyboard: true, css: '../../Script/Calculator/' });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="calculator"></div>
    </form>
</body>
</html>
