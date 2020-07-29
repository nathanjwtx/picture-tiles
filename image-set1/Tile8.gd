extends "defaultTile.gd"

var entered: bool = false


# Called when the node enters the scene tree for the first time.
func _ready():
    connect("mouse_entered", self, "_on_Tile8_mouse_entered")
    connect("mouse_exited", self, "_on_Tile8_mouse_exited")


# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass

func _input(event) -> void:
    if event is InputEventMouseButton and event.pressed and entered:
        print("self.name: ", self.name)
        if self.name == str(8):
            my_signals.emit_signal("tile_clicked")


func _on_Tile8_mouse_entered():
    print("entered tile 8")
    entered = true


func _on_Tile8_mouse_exited():
    print("exited tile 8")
    entered = false
