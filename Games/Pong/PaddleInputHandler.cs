using Godot;
using System;

namespace Pong
{
    public partial class PaddleInputHandler : Node2D
    {
        public Vector2 GetInput(string up, string down)
        {
            return Input.GetVector("nullInputs", "nullInputs", up, down);
        }
    }
}
