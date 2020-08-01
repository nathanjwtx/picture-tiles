using System;
using System.Collections.Generic;
using Godot;

namespace PictureTiles
{
    public class Level1 : Node2D
    {
        private List<Vector2> _initialPos;

        private List<int> _tileNames;
    
        // Called when the node enters the scene tree for the first time.
        public override void _Ready()
        {
            Console.WriteLine("level 1");
            _initialPos = new List<Vector2>();
            _tileNames = new List<int>();
        }

        private void _on_HUD_shuffleTiles()
        {
            _setStartingPosition();
            // _testSolvability();
        }

        private void _setStartingPosition()
        {
        
        }
    }
}
