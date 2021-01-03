var wordSearchClass = function () {
    //var privateVar;
    //var privateFn = function () {
    //}
    //this.someProperty = 5;
    //this.anotherProperty = false;
    //this.publicFunction = function () {
    //}

    var charSize = 12;
    var rows = 20;
    var columns = 20;

    this.StyleGrid = function () {
        var gridWidth = rows * charSize;
        var gridHeight = columns * charSize;
        var grid = document.getElementById("canvasGrid");
        grid.style.width = gridWidth;
        grid.style.height = gridHeight;
        grid.style.border = "1px solid black";

    }
}