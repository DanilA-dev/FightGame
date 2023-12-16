using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIPlayerJoinPanel : MonoBehaviour
    {
        [SerializeField] private int _userId;
        [SerializeField] private Toggle _toggle;

        
        private void Start()
        {
            _toggle.isOn = false;
        }

        public void JoinPlayer(int id)
        {
            if (_userId == id)
                _toggle.isOn = true;
        }
    }
}