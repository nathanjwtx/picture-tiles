extends Node2D


# Declare member variables here. Examples:
# var a: int = 2
# var b: String = "text"

var initialPos: = []
var tileNames:= []


# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	for t in get_node("Tiles").get_children():
		initialPos.append(t.get_position())
		if t.name != "Tile1":
			tileNames.append(t)
		else:
			t.queue_free()

	set_starting_position()

# Called every frame. 'delta' is the elapsed time since the previous frame.
# func _process(delta: float) -> void:
# 	update_raycastnodes()

# func _input(event: InputEvent) -> void:
# 	if event is InputEventMouseButton:
# 		print("click")
		
func set_starting_position() -> void:
	randomize()
	initialPos.shuffle()
	tileNames.shuffle()
	for t in range(0, tileNames.size()):
		if tileNames[t].name != "Tile1":
			tileNames[t].position = initialPos[t]
			# print(tileNames[t].position)
		# print(tileNames[t].raycastNodeUp.global_position)

# func update_raycastnodes() -> void:
#     for t in range(0, tileNames.size()):
		
		# if tileNames[t].raycastNodeUp.is_colliding():
		# 	tileNames[t].objCollidedUp = tileNames[t].raycastNodeUp.get_collider()
		# if tileNames[t].raycastNodeDown.is_colliding():
		# 	tileNames[t].objCollidedDown = tileNames[t].raycastNodeDown.get_collider()
		# if tileNames[t].raycastNodeLeft.is_colliding():
		# 	tileNames[t].objCollidedLeft = tileNames[t].raycastNodeLeft.get_collider()
		# if tileNames[t].raycastNodeRight.is_colliding():
		# 	tileNames[t].objCollidedRight = tileNames[t].raycastNodeRight.get_collider()
