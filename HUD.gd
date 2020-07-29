extends CanvasLayer


signal shuffleTiles

var counter: int
var counterNode: Node
var tileNode: Node


# Called when the node enters the scene tree for the first time.
func _ready():
    pass
    counterNode = get_node("VBoxContainer/HBoxContainer/Moves")

    my_signals.connect("tile_clicked", self, "update_move_counter")


func _on_Start_pressed():
    print("start")
    counter = 0
    emit_signal("shuffleTiles")

func update_move_counter() -> void:
    counter += 1
    print(counter)
    counterNode.text = str(counter)
    
