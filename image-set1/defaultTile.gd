extends Area2D

var result: Dictionary
var raycastNodeUp: RayCast2D
var raycastNodeLeft: RayCast2D
var raycastNodeRight: RayCast2D
var raycastNodeDown: RayCast2D
var objCollidedUp: Object
var objCollidedDown: Object
var objCollidedLeft: Object
var objCollidedRight: Object


func _ready():
    raycastNodeUp = get_node("RayCastUp")
    raycastNodeDown = get_node("RayCastDown")
    raycastNodeLeft = get_node("RayCastLeft")
    raycastNodeRight = get_node("RayCastRight")
    
func _process(_delta):
    update_raycastnodes()

func _input(event) -> void:
    if event is InputEventMouseButton:
        if event.pressed:
            if (event.get_position() - self.get_position()).length() < 32:
                if objCollidedUp == null:
                    position = Vector2(global_position.x, global_position.y - 64)
                elif objCollidedDown == null:
                    position = Vector2(global_position.x, global_position.y + 64)
                elif objCollidedLeft == null:
                    position = Vector2(global_position.x - 64, global_position.y)
                elif objCollidedRight == null:
                    position = Vector2(global_position.x + 64, global_position.y)

func update_raycastnodes() -> void:
    if raycastNodeUp.is_colliding():
        objCollidedUp = raycastNodeUp.get_collider()
    else:
        objCollidedUp = null
    if raycastNodeDown.is_colliding():
        objCollidedDown = raycastNodeDown.get_collider()
    else:
        objCollidedDown = null
    if raycastNodeLeft.is_colliding():
        objCollidedLeft = raycastNodeLeft.get_collider()
    else:
        objCollidedLeft = null
    if raycastNodeRight.is_colliding():
        objCollidedRight = raycastNodeRight.get_collider()
    else:
        objCollidedRight = null


