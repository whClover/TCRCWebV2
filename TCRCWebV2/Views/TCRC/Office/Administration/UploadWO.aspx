<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="UploadWO.aspx.vb" Inherits="TCRCWebV2.UploadWO1" %>

<!DOCTYPE html>
<html>
<head>
  <meta charset="UTF-8">
  <title>Import TSV File into Table</title>


</head>
<body>
  <input type="file" id="fileInput">
  <button onclick="importFile()">Import</button>
  <div id="tableContainer"></div>
  
  <script>
      function importFile() {
          var fileInput = document.getElementById('fileInput');
          var table = document.createElement('table');
          table.className = 'myTable'; // add class to table
          table.border = 1; // add border to table

          var CHUNK_SIZE = 1024 * 1024; // 1MB chunk size
          var offset = 0;
          var fileSize = fileInput.files[0].size;
          var fileReader = new FileReader();

          fileReader.onload = function () {
              var content = fileReader.result;
              var rows = content.split('\n');
              for (var i = 0; i < rows.length; i++) {
                  var row = rows[i].split('\t');
                  var newRow = table.insertRow();
                  for (var j = 0; j < row.length; j++) {
                      var newCell = newRow.insertCell();
                      newCell.innerHTML = row[j];
                  }
              }
              offset += CHUNK_SIZE;
              if (offset < fileSize) {
                  readChunk(offset);
              } else {
                  var tableContainer = document.getElementById('tableContainer');
                  tableContainer.innerHTML = '';
                  tableContainer.appendChild(table);
              }
          };

          function readChunk(startOffset) {
              var blob = fileInput.files[0].slice(startOffset, startOffset + CHUNK_SIZE);
              fileReader.readAsText(blob);
          }

          readChunk(offset);
      }
  </script>
</body>
</html>