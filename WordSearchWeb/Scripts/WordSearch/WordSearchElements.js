
var maximumWords;
var directions = [
    { name: "UP", rowIncrement: -1, colIncrement: 0 },
    { name: "UPRIGHT", rowIncrement: 1, colIncrement: 1 },
    { name: "RIGHT", rowIncrement: 0, colIncrement: 1 },
    { name: "DOWNRIGHT", rowIncrement: 1, colIncrement: 1 },
    { name: "DOWN", rowIncrement: 1, colIncrement: 0 },
    { name: "DOWNLEFT", rowIncrement: 1, colIncrement: -1 },
    { name: "LEFT", rowIncrement: 0, colIncrement: -1 },
    { name: "UPLEFT", rowIncrement: -1, colIncrement: -1 }
];

var highlightColors = [
    { backgroundColour: "#e6194B", color: "white" },
    { backgroundColour: "#f58231", color: "white" },
    { backgroundColour: "#ffe119", color: "black" },
    { backgroundColour: "#bfef45", color: "black" },
    { backgroundColour: "#3cb44b", color: "white" },
    { backgroundColour: "#42d4f4", color: "black" },
    { backgroundColour: "#4363d8", color: "white" },
    { backgroundColour: "#911eb4", color: "white" },
    { backgroundColour: "#f032e6", color: "white" },
    { backgroundColour: "#a9a9a9", color: "white" }
];

$("#showSolution").click(function () {   
    //console.log("got here");
    //console.log("number of words: " + wordSearch.data.HiddenWords.length);
    $("li.hiddenWord").each(function() {
        showHiddenWord($(this));
    })
});

$("li.hiddenWord").click(function () {
    showHiddenWord($(this));
});

function getDirectionDelta(word) {
    var delta;
    var direction = word.attr("data-direction");
    direction = direction.trim().toUpperCase();
    directions.forEach(function (d, idx) {        
        if (direction === d.name) {
            delta = d;
            return;
        }
    })

    return delta;
}

function getStartCell(word) {
    return {
        row: Number(word.attr("data-start-row")),
        col: Number(word.attr("data-start-col"))
    };
}

function highlightHiddenWord(startCell, delta, wordLength, color) {  

    var row = startCell.row;
    var col = startCell.col;

    for (var l = 0; l < wordLength; l++) {     
        var letterId = row.toString() + "_" + col.toString();
        $("#" + letterId).css("background-color", color.backgroundColour).css("color", color.color);
        row += delta.rowIncrement;
        col += delta.colIncrement;
    }
}

function getColor(wordElement) {
    var wordNo = wordElement.attr("data-wordNo");
    var colorNo = wordNo % highlightColors.length;
    var color = highlightColors[colorNo];

    return color;
}

function showHiddenWord(wordElement) {
    var startCell = getStartCell(wordElement);
    var length = wordElement.text().length;    
    var directionDelta = getDirectionDelta(wordElement);
    var color = getColor(wordElement);

    highlightHiddenWord(startCell, directionDelta, length, color);
}
