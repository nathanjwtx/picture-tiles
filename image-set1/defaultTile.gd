extends KinematicBody2D


# Declare member variables here. Examples:
# var a = 2
# var b = "text"


# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(_delta):
	pass

func _input(event) -> void:
	if event is InputEventMouseButton:
		if event.pressed:
			if (event.get_position() - self.get_position()).length() < 32:
				print(self.name)

			# move_and_slide(Vector2(1, 1), Vector2(0, 1))
