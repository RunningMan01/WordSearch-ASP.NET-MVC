(function (wordSearch, $, undefined) {
    //Private Property
    var characterSize = 14;    

    wordSearch.data = null;

    wordSearch.createGrid = function (data) {
        var row = 0, col = 0;
        var x, y;
        
        // var maxCols = $("#inputCols").val();       
        wordSearch.data = data;
        // clear out any existing grid
        $("#grid").remove();

        // create grid table with first row      
        var $grid = $("<table>");
        $grid.attr("id", "grid");
        $("#gridParent").append($grid);

        var $row = $("<tr>");
        //$("#grid").add($row);

        data.Grid.forEach(function (item) {
            //console.log("data.rows: " + data.Rows);
            console.log(item);
            var $cell = $("<td>")
            $cell.html(item);
            $row.append($cell);
            
            col++;
            if (col >= wordSearch.data.Rows) {
                $grid.append($row);
                console.log("adding " + JSON.stringify($row));
                $row = $("<tr>");

                col = 0;
                row++;
            }
        })
    }

    wordSearch.styleCanvas = function (data) {
        // calculate size of canvas to display
        var canvasWidth = (data.Columns + 1) * characterSize;
        var canvasHeight = (data.Rows + 1) * characterSize;

        // remove existing canvas and create a new one
        $("#canvasGrid").remove();

        var $newCanvas = $("<canvas>");
        $newCanvas.attr("height", canvasHeight);
        $newCanvas.attr("width", canvasWidth);
        $newCanvas.attr("id", "canvasGrid");

        $("#canvasParent").append($newCanvas);

        var canvas = document.getElementById("canvasGrid");
        var ctx = canvas.getContext("2d");

        console.log("cW: " + canvasWidth);
        console.log("cH: " + canvasHeight);

        window.devicePixelRatio = 4;
        canvas.style.width = canvasWidth;
        canvas.style.height = canvasHeight;
        var scale = window.devicePixelRatio;

        canvas.width = Math.floor(canvasWidth * scale);
        canvas.height = Math.floor(canvasHeight * scale);

        ctx.scale(scale, scale);
        ctx.font = "14px Comic Sans MS";
    }

    wordSearch.populateGrid = function (data) {
        var canvas = document.getElementById("canvasGrid");
        var ctx = canvas.getContext("2d");
        var row = 0, col = 0;
        var x, y;
        var maxCols = $("#inputCols").val();

        console.log("populateGrid: Start");
        data.Grid.forEach(function (i, item) {
            x = (characterSize * col) + characterSize;
            y = (characterSize * row) + characterSize;

            // console.log(i);
            col++;
            if (col >= maxCols) {
                col = 0;
                row++;
            }
            ctx.fillText(i, x, y);
        })
        console.log("populateGrid: End");
    }

    wordSearch.createWordSeach = function() {
        var url = wordSearch.url; //'@Url.Action("GenerateWordSearchGrid")';

        var wordsArray = [];
        $("li.addedWord").each(function (i, word) {
            console.log(word.innerHTML);
            wordsArray.push(word.innerHTML);
        });

        var rows = $("#inputRows").val();
        var cols = $("#inputCols").val();

        console.log("rows: " + rows);

        dataToSend = JSON.stringify({
            words: wordsArray,
            row: rows,
            col: cols
        });

        $.ajax({
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            type: 'POST',
            url: url,
            data: dataToSend,
            success: function (data) {
                // wordSearch.data = data;
                wordSearch.createGrid(data);
            }
        })
    }

    wordSearch.showSolution = function () {
        var canvas = document.getElementById("canvasGrid"); // $("#canvasGrid");
        var ctx = canvas.getContext("2d");

        // this is temporary
        var startRow = 1;
        var startCol = 1;
        var endRow = 9;
        var endCol = 1;

        //var startX = ((startRow - 1) * characterSize) + (characterSize / 2.0);
        //var startY = ((startCol - 1) * characterSize) + (characterSize / 2.0);
        var startX = (startRow * characterSize) + 5; // - 5;
        var startY = (startCol * characterSize) - 5;
        var endX = ((endRow) * characterSize); // - characterSize / 2.0;
        var endY = ((endCol) * characterSize); // - characterSize / 2.0;

        ctx.beginPath();
        ctx.moveTo(startX, startY);
        ctx.lineTo(endX, endY);
        ctx.strokeStyle = "red";
        ctx.stroke();
    }
}(window.wordSearch = window.wordSearch || {}, jQuery));
