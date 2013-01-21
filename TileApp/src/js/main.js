// Generated by CoffeeScript 1.4.0
(function() {
  var Game,
    __bind = function(fn, me){ return function(){ return fn.apply(me, arguments); }; },
    __slice = [].slice;

  Game = (function() {
    var Camera, Map;

    Game.prototype.self_game = [];

    Game.prototype.tickLenght = 1;

    Game.prototype.canvas = null;

    Game.prototype.drawingContext = null;

    Game.prototype.curCursorPos = [
      {
        x: null,
        y: null
      }
    ];

    Game.prototype.map = null;

    function Game() {
      this.tick = __bind(this.tick, this);

      this.resizeCanvas = __bind(this.resizeCanvas, this);

      var self_game,
        _this = this;
      self_game = this;
      console.log(this);
      this.createCanvas();
      this.resizeCanvas();
      this.createDrawingContext();
      this.camera = new Camera();
      this.map = new Map();
      this.map.generateRandomMap(64, 64);
      this.map.loadImages();
      this.startTime = new Date().getTime();
      window.onresize = function(evt) {
        return _this.resizeCanvas();
      };
      alert("gameCreated");
      this.tick();
    }

    Game.prototype.createCanvas = function() {
      var _this = this;
      this.canvas = document.createElement('canvas');
      document.body.appendChild(this.canvas);
      this.canvas.onmousemove = function(evt) {
        _this.curCursorPos.x = evt.clientX;
        return _this.curCursorPos.y = evt.clientY;
      };
      return console.log("canvas created");
    };

    Game.prototype.resizeCanvas = function() {
      this.canvas.height = window.innerHeight;
      return this.canvas.width = window.innerWidth;
    };

    Game.prototype.createDrawingContext = function() {
      this.drawingContext = this.canvas.getContext('2d');
      return console.log("context created");
    };

    Game.prototype.revealDisplay = function() {
      var offset;
      offset = this.camera.moveCamera(this.curCursorPos, this.canvas.height, this.canvas.width);
      console.log(offset);
      this.drawingContext.clearRect(0, 0, 2000, 2000);
      if (Map.loadedCounter === this.map.tileDictionary.length) {
        return this.map.drawMap(this.drawingContext, offset.x, offset.y);
      }
    };

    Game.prototype.tick = function() {
      var fps, startFrame;
      startFrame = new Date().getTime();
      setTimeout(this.tick, this.tickLenght);
      this.revealDisplay();
      this.elapsed = (new Date().getTime() - this.startTime) / 100;
      fps = 100 / (new Date().getTime() - startFrame);
      return this.systemInfoDraw(fps, this.getMousePos(), this.getScreenSize());
    };

    Game.prototype.getMousePos = function() {
      return "X: " + this.curCursorPos.x + " Y: " + this.curCursorPos.y;
    };

    Game.prototype.getScreenSize = function() {
      return " Height: " + this.canvas.height + " Width: " + this.canvas.width;
    };

    Game.prototype.systemInfoDraw = function() {
      var messages, part, resultMessage, _i, _ref;
      messages = 1 <= arguments.length ? __slice.call(arguments, 0) : [];
      this.drawingContext.font = "bold 12px sans-serif";
      resultMessage = "";
      for (part = _i = 0, _ref = messages.length; 0 <= _ref ? _i < _ref : _i > _ref; part = 0 <= _ref ? ++_i : --_i) {
        resultMessage += " " + messages[part] + " ";
      }
      this.drawingContext.fillText(resultMessage, 10, 10);
      return this.infoMessage = "";
    };

    Camera = (function() {

      function Camera() {}

      Camera.prototype.offsetX = 0;

      Camera.prototype.offsetY = 0;

      Camera.prototype.moveCamera = function(cursorPos, scrWidth, scrHeight) {
        var offsetCoeff;
        offsetCoeff = 5;
        if (cursorPos.x > scrHeight - offsetCoeff) {
          this.offsetX += -offsetCoeff;
        }
        if (cursorPos.x < offsetCoeff) {
          this.offsetX += offsetCoeff;
        }
        if (cursorPos.y > scrWidth - offsetCoeff) {
          this.offsetY += -offsetCoeff;
        }
        if (cursorPos.y < offsetCoeff) {
          this.offsetY += offsetCoeff;
        }
        console.log(cursorPos.x + " " + cursorPos.y + " " + this.offsetX + " " + this.offsetY);
        return new Object({
          x: this.offsetX,
          y: this.offsetY
        });
      };

      return Camera;

    })();

    Map = (function() {

      function Map() {}

      Map.prototype.heightMap = Array([0, 0, 1, 0, 0], [0, 0, 2, 0, 0], [0, 0, 0, 0, 0], [0, 0, 0, 0, 0]);

      Map.prototype.tileDictionary = ["res/img/boxLvl0.png", "res/img/boxLvl1.png", "res/img/boxLvl2.png", "res/img/boxLvl3.png", "res/img/boxLvl4.png", "res/img/boxLvl5.png"];

      Map.prototype.tileImages = new Array();

      Map.loadedCounter = 0;

      Map.prototype.loadImages = function() {
        var index, tileImages, _i, _ref, _results;
        tileImages = new Array();
        _results = [];
        for (index = _i = 0, _ref = this.tileDictionary.length; 0 <= _ref ? _i < _ref : _i > _ref; index = 0 <= _ref ? ++_i : --_i) {
          console.log("loading images");
          this.tileImages[index] = new Image();
          this.tileImages[index].src = this.tileDictionary[index];
          _results.push(this.tileImages[index].onload = function() {
            Map.loadedCounter++;
            return console.log(Map.loadedCounter);
          });
        }
        return _results;
      };

      Map.prototype.drawMap = function(drawingContext, offsetX, offsetY) {
        var drawTile, indexX, indexY, mapX, mapY, tileHeight, tileWidth, xPos, yPos, _i, _ref, _results;
        tileHeight = 150;
        tileWidth = 100;
        mapX = offsetX;
        mapY = offsetY;
        _results = [];
        for (indexX = _i = 0, _ref = this.heightMap.length; 0 <= _ref ? _i < _ref : _i > _ref; indexX = 0 <= _ref ? ++_i : --_i) {
          _results.push((function() {
            var _j, _ref1, _results1;
            _results1 = [];
            for (indexY = _j = 0, _ref1 = this.heightMap[indexY].length; 0 <= _ref1 ? _j < _ref1 : _j > _ref1; indexY = 0 <= _ref1 ? ++_j : --_j) {
              drawTile = this.heightMap[indexX][indexY];
              xPos = (indexX - indexY) * tileWidth / 2 + mapX;
              yPos = (indexX + indexY) * tileHeight / 6 + mapY;
              _results1.push(drawingContext.drawImage(this.tileImages[drawTile], xPos, yPos));
            }
            return _results1;
          }).call(this));
        }
        return _results;
      };

      Map.prototype.generateRandomMap = function(x, y) {
        var indexX, indexY, result, _i, _j;
        result = new Array();
        for (indexX = _i = 0; 0 <= x ? _i < x : _i > x; indexX = 0 <= x ? ++_i : --_i) {
          result[indexX] = new Array();
          for (indexY = _j = 0; 0 <= y ? _j < y : _j > y; indexY = 0 <= y ? ++_j : --_j) {
            result[indexX][indexY] = Math.floor(Math.random() * (5 + 1));
          }
        }
        return this.heightMap = result;
      };

      return Map;

    })();

    return Game;

  }).call(this);

  window.Game = Game;

}).call(this);
