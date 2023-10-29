function getMousePosition(canvas, event) {
    let rect = canvas.getBoundingClientRect();
    let x = event.clientX - rect.left;
    let y = event.clientY - rect.top;
    CanvasClicked(x, y);
    console.log("Coordinate x: " + x,
        "Coordinate y: " + y);
}

function hookMouseEvents(dotNetObject) {

    canvas = document.getElementById("gamesterCanvas");

    canvas.addEventListener('mousedown', function (evt) {
        dotNetObject.invokeMethod('eventMouseDown', evt.clientX, evt.clientY);
    }, false);

    canvas.addEventListener('mouseup', function (evt) {
        dotNetObject.invokeMethod('eventMouseUp', evt.clientX, evt.clientY);
    }, false);
};

//let canvasElem = document.querySelector("canvas");

//canvasElem.addEventListener("mousedown", function (e) {
//    getMousePosition(canvasElem, e);
//});