<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="tes2.aspx.vb" Inherits="TCRCWebV2.tes2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>tes 2</title>
    <style>
        /* Ganti warna latar belakang sesuai kebutuhan */
        body {
          background-color: #f1f1f1;
        }

        /* Mengatur tata letak grid */
        .grid-container {
          display: grid;
          grid-template-columns: repeat(auto-fit, minmax(200px, 1fr));
          grid-gap: 10px;
          padding: 10px;
        }

        /* Mengatur tampilan tile */
        .grid-item {
          background-color: #ffffff;
          padding: 20px;
          text-align: center;
        }

        /* Mengatur responsivitas tile */
        @media screen and (max-width: 600px) {
          .grid-item {
            font-size: 14px;
          }
        }
  </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="grid-container">
            <div class="grid-item">Tile 1</div>
            <div class="grid-item">Tile 2</div>
            <div class="grid-item">Tile 3</div>
            <div class="grid-item">Tile 4</div>
            <div class="grid-item">Tile 5</div>
            <div class="grid-item">Tile 6</div>
            <div class="grid-item">Tile 7</div>
            <div class="grid-item">Tile 8</div>
            <div class="grid-item">Tile 9</div>
          </div>
    </form>
</body>
</html>
