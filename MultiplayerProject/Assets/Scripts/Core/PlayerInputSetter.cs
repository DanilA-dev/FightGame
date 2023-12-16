using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    
    public class PlayerInputSetter : MonoBehaviour
    {
        public event Action<Vector2> OnMove;

        public void Move(InputAction.CallbackContext context)
        {
            OnMove?.Invoke(context.ReadValue<Vector2>());
        }
        

       
        
                
    }
}