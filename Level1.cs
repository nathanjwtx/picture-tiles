using System;
using System.Collections.Generic;
using Godot;

namespace PictureTiles
{
    public class Level1 : Node2D
    {
        private bool _startShuffle;
        private string _lastTileMoved;
        private int _shuffleCounter;
        private Random _rnd;
        private Dictionary<string, Vector2> _initialPositions;

        public override void _Ready()
        {
            AutoloadClicked.Instance.Connect("ShuffleTiles", this, "_on_HUD_shuffleTiles");
            _startShuffle = false;
            _lastTileMoved = String.Empty;
            _shuffleCounter = 5;
            _rnd = new Random();
            _initialPositions = new Dictionary<string, Vector2>();

            // setting dictionary of initial tile locations for checking if puzzle solved
            foreach (Node child in GetNode<Node>("Tiles").GetChildren())
            {
                Area2D temp = (Area2D) child;
                _initialPositions.Add(temp.Name, temp.Position);
            }
        }

        public override void _PhysicsProcess(float delta)
        {
            base._PhysicsProcess(delta);
            if (_startShuffle && _shuffleCounter >= 0)
            {
                SetStartingPosition();
            }

            if (_shuffleCounter == -1 && CheckForSolved())
            {
                GetParent().GetNode<CenterContainer>("HUD/SolvedContainer").Visible = true;
            }
        }

        private bool CheckForSolved()
        {
            foreach (Node child in GetNode<Node>("Tiles").GetChildren())
            {
                Area2D temp = (Area2D) child;
                if (_initialPositions[temp.Name] != temp.Position)
                {
                    return false;
                }
            }

            // stops the tiles from being clicked once solved
            AutoloadClicked.Solved = true;
            return true;
        }

        private void SetStartingPosition()
        {
            List<Tuple<string, Vector2>> mt = new List<Tuple<string, Vector2>>();
                
            foreach (Node child in GetNode<Node>("Tiles").GetChildren())
            {
                if (child.Name != _lastTileMoved)
                {
                    var down = child.GetNode<RayCast2D>("RayCastDown").GetCollider();
                    var up = child.GetNode<RayCast2D>("RayCastUp").GetCollider();
                    var left = child.GetNode<RayCast2D>("RayCastLeft").GetCollider();
                    var right = child.GetNode<RayCast2D>("RayCastRight").GetCollider();

                    if (up == null)
                    {
                        mt.Add(new Tuple<string, Vector2>(child.Name, new Vector2(0, -64)));
                    }
                    else if (down == null)
                    {
                        mt.Add(new Tuple<string, Vector2>(child.Name, new Vector2(0, 64)));
                    }
                    else if (left == null)
                    {
                        mt.Add(new Tuple<string, Vector2>(child.Name, new Vector2(-64, 0)));
                    }
                    else if (right == null)
                    {
                        mt.Add(new Tuple<string, Vector2>(child.Name, new Vector2(64, 0)));
                    }
                }
            }

            var selectedTile = mt[_rnd.Next(0, mt.Count)];
            Area2D tempNode = GetNode<Area2D>($"Tiles/{selectedTile.Item1}");
            tempNode.Position += selectedTile.Item2;
            _lastTileMoved = selectedTile.Item1;
            _shuffleCounter--;
        }

        #region Signals

        private void _on_HUD_shuffleTiles()
        {
            _startShuffle = true;
        }

        #endregion
    }
}
