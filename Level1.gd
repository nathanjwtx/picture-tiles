extends Node2D


var initialPos:= []
var tileNames:= []

func _ready() -> void:
	for t in get_node("Tiles").get_children():
		initialPos.append(t.get_position())
		tileNames.append(t)
		
	var hudNode = get_tree().get_root().find_node("HUD", true, false)
	hudNode.connect("shuffleTiles", self, "_on_HUD_shuffleTiles")

# signal received from start button
func _on_HUD_shuffleTiles() -> void:
	print("hello")
	set_starting_position()
	test_solvability()

func set_starting_position() -> void:
	randomize()
	initialPos.shuffle()
	tileNames.shuffle()
	for t in range(0, tileNames.size()):
		tileNames[t].position = initialPos[t]
		
func test_solvability() -> void:
	var _grid_width:= 3
	var count:= 0
	var tile:= 0
	
	for i in range(0, tileNames.size()):
		# print("i: ", tileNames[i].name)
		tile += 1
		for j in range(tile, tileNames.size()):
			# print("j: ", tileNames[j].name)
			if tileNames[i].name > tileNames[j].name:
				count += 1
			
	if count % 2 == 0:
		print("solvable: ", count)
	else:
		print("not solvable: ", count)
		test_solvability()
