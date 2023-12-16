using UnityEngine;

namespace InputOperations
{
    [CreateAssetMenu(menuName = "Custom Devices/Device")]
    public class CustomInputDevice : ScriptableObject
    {
        [field: SerializeField] public int DeviceId { get; private set; }
    }
}