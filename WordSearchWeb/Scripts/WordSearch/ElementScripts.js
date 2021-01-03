// To do - create namespace with property for Url

var size = 14;
$("#buttonAdd").click(function () {
    var wordList = $("#wordList");
    var newWord = $("#inputWord").val();
    newWord = $.trim(newWord);        
    var newWordElement = '<li class="list-group-item addedWord">' + newWord + '</li>';
    wordList.append(newWordElement);
});

$(".addedWord").dblclick(function () {  
    $(this).remove();
});

$(document).ready(function () {   
    // getGrid(); 
})

$("#buttonCreateWordSearch").click(function () {
    //console.log("create word search");
    //var wordsArray = [];
    //$("li.addedWord").each(function (i, word) {
    //    console.log(word.innerHTML);
    //    wordsArray.push(word.innerHTML);
    //});   

    createWordSeach();  

});

function createGrid(data) {
    console.log("Returned: " + data);
    console.log("Rows: " + data.Rows); 5
    console.log("Cols: " + data.Columns);
    console.log("HiddenWords: " + data.HiddenWords.length);
    console.log("Grid: " + data.Grid.length);
    styleCanvas(data);
    populateGrid(data);
}

function styleCanvas(data) {    
    // calculate size of canvas to display
    var canvasWidth = (data.Columns + 0.5) * size;
    var canvasHeight = (data.Rows + 0.5) * size;

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
    ctx.font = "11px Comic Sans MS";
}

function populateGrid(data) {
    var canvas = document.getElementById("canvasGrid");
    var ctx = canvas.getContext("2d");
    var row = 0, col = 0;
    var x, y;
    var maxCols = $("#inputCols").val();

    console.log("populateGrid: Start");
    data.Grid.forEach(function (i, item) {
        x = (size * col) + (size / 2.0);
        y = (size * row) + size;

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