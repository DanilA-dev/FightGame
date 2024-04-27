using System;
using UnityEngine;

namespace Systems.Interfaces
{
    public interface IUserInput
    {
        public event Action<Vector2> MoveDirection;
        public event Action Jump;

        public void ToggleInput(bool value);
        public void Tick();
    }
}