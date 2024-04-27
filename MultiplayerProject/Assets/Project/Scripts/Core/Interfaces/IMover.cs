using UnityEngine;

namespace Core.Interfaces
{
    public interface IMover
    {
        public Vector3 Direction { get; set; }
        public void Move(float speed);
    }
  
}