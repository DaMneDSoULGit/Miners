var map = Array([0,0,0,0],[0,1,1,0],[0,1,1,0],[0,2,2,0]);
var tileDict = Array( "boxTile0.png", "boxTile1.png", "boxTile2.png");
var tileImg = new Array();
var loaded = 0;
var loadTimer;

function loadImg() {
    for(var index = 0; index < tileDict.length; index++) {
        tileImg[index] = new Image();
        tileImg[index].src = tileDict[index];
        tileImg[index].onload = function() {
            loaded++;
        }
    }
}

function drawMap() {
    var tileHeight = 18;
    var tileWidth = 50;
    var mapX = 200;
    var mapY = 20;

    for(var indexX = 0; indexX < map.length; indexX++){
        for(var indexY = 0; indexY < map[indexX].length; indexY++) {
            var drawTile = map[indexX][indexY];
            var xPos = (indexX - indexY) *  tileWidth + mapX;
            var yPos = (indexX + indexY) * tileHeight/2 + mapY;
            ctx.drawImage(tileImg[drawTile], xPos, yPos);
        }
    }
}

function loadAll() {
    if(loaded == tileDict.length) {
        clearInterval(loadTimer);
        drawMap();
    }
}

function init() {
    ctx = document.getElementById("gameScreen").getContext("2d");
//    ctx.canvas.width  = window.innerWidth;
    ctx.canvas.width  = 800;
//    ctx.canvas.height = window.innerHeight;
    ctx.canvas.height = 600;
    loadImg();
    loadTimer = setInterval(loadAll, 100);
}

init();