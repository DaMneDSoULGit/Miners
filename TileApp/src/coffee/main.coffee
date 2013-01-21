# Class game
class Game
	self_game: []
	tickLenght: 1
	# Mb delete
	canvas: null
	# Mb delete
	drawingContext: null

	curCursorPos: [x: null, y: null]

	# Mb delete 
	map: null

	constructor: ->
		self_game = @
		console.log @
		@createCanvas()
		@resizeCanvas()
		@createDrawingContext()

		@camera = new Camera()

		@map = new Map()
		@map.generateRandomMap(64,64)
		@map.loadImages()

		@startTime = new Date().getTime()

		# resize window event listener
		window.onresize = (evt)=>
			@resizeCanvas()

		alert("gameCreated")
		@tick()


	createCanvas: ->
		@canvas = document.createElement 'canvas'
		document.body.appendChild @canvas

		# Mouse move event listener
		@canvas.onmousemove = (evt)=>
			@curCursorPos.x = evt.clientX
			@curCursorPos.y = evt.clientY

		console.log "canvas created"


	resizeCanvas: =>
		# @canvas.height = 800
		@canvas.height = window.innerHeight
		# @canvas.width = 600
		@canvas.width = window.innerWidth


	createDrawingContext: ->
		@drawingContext = @canvas.getContext '2d'
		console.log "context created"


	# Method to reveal all objects on the screen
	# Put here draw Map and Game objects
	revealDisplay: ->
		# console.log "Draw"
		offset = @camera.moveCamera(@curCursorPos, @canvas.height, @canvas.width)
		console.log offset

		# TODO: find why bad work with canvas params
		# @drawingContext.clearRect( 0, 0, @canvas.height, @canvas.width)
		@drawingContext.clearRect( 0, 0, 2000, 2000)
		
		if (Map.loadedCounter == @map.tileDictionary.length)
			@map.drawMap(@drawingContext, offset.x , offset.y )


	# Game loop method
	tick: =>
		startFrame = new Date().getTime()
		
		setTimeout(@tick, @tickLenght)
		@revealDisplay()

		@elapsed = (new Date().getTime() - @startTime) / 100 
		# console.log  @elapsed
		fps = 100 / (new Date().getTime() - startFrame)
		@systemInfoDraw(fps, @getMousePos(), @getScreenSize())


	# System info section
	getMousePos: ->
		"X: " + @curCursorPos.x + " Y: " + @curCursorPos.y

	getScreenSize: ->
		" Height: " + @canvas.height + " Width: " + @canvas.width

	systemInfoDraw: (messages...)->
		@drawingContext.font = "bold 12px sans-serif";
		resultMessage = ""
		for part in [0...messages.length]
			resultMessage += " " + messages[part] + " "
		@drawingContext.fillText(resultMessage, 10, 10);
		@infoMessage = ""


	# Class for work with camera 
	class Camera
		offsetX: 0
		offsetY: 0

		moveCamera: (cursorPos, scrWidth, scrHeight)->
			offsetCoeff = 5
			if (cursorPos.x > scrHeight - offsetCoeff)
				@offsetX += -offsetCoeff

			if (cursorPos.x < offsetCoeff)
				@offsetX += offsetCoeff

			if (cursorPos.y > scrWidth - offsetCoeff)
				@offsetY += -offsetCoeff

			if (cursorPos.y < offsetCoeff)
				@offsetY += offsetCoeff
				
			console.log cursorPos.x + " " + cursorPos.y + " " + @offsetX + " " + @offsetY
			
			return new Object(x: @offsetX, y: @offsetY)


	# Class for work with game map	
	class Map
		# Map data
		heightMap: Array(	[0,0,1,0,0]
							[0,0,2,0,0]
							[0,0,0,0,0]
							[0,0,0,0,0] )

		tileDictionary: ["res/img/boxLvl0.png","res/img/boxLvl1.png","res/img/boxLvl2.png",
						"res/img/boxLvl3.png","res/img/boxLvl4.png","res/img/boxLvl5.png"]
		
		tileImages: new Array()

		# TODO: check! find way make local
		@loadedCounter: 0

		# Convert image files to html objects
		loadImages: ->
			tileImages = new Array()
			for index in [0...@tileDictionary.length]
				console.log "loading images"
				@tileImages[index] = new Image()
				@tileImages[index].src = @tileDictionary[index]
				@tileImages[index].onload = ->
					Map.loadedCounter++
					console.log Map.loadedCounter
		

		drawMap: (drawingContext, offsetX, offsetY)->
			tileHeight = 150
			tileWidth = 100
			mapX = offsetX
			mapY = offsetY

			for indexX in [0...@heightMap.length]
				for indexY in [0...@heightMap[indexY].length]
					drawTile = @heightMap[indexX][indexY]
					xPos = (indexX - indexY) * tileWidth/2 + mapX
					yPos = (indexX + indexY) * tileHeight/6 + mapY
					drawingContext.drawImage @tileImages[drawTile], xPos, yPos

		generateRandomMap: (x,y)->
			result = new Array()
			for indexX in [0...x]
				result[indexX] = new Array()
				for indexY in [0...y]
					result[indexX][indexY] = Math.floor(Math.random() * (5 + 1))
			
			@heightMap = result



window.Game = Game