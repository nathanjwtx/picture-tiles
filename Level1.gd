extends Node2D


var initialPos: = []
var tileNames:= []

func _ready() -> void:
	for t in get_node("Tiles").get_children():
		initialPos.append(t.get_position())
		# if t.name != "Tile1":
		tileNames.append(t)
		# else:
			# t.queue_free()

	set_starting_position()

func set_starting_position() -> void:
	randomize()
	initialPos.shuffle()
	tileNames.shuffle()
	for t in range(0, tileNames.size()):
		# if tileNames[t].name != "Tile1":
		tileNames[t].position = initialPos[t]
