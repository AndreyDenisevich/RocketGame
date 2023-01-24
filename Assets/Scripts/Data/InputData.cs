using UnityEngine;

namespace Data
{
    [CreateAssetMenu(order = 51,fileName = "InputData",menuName = "Game Data/Input Data")]
    public class InputData: ScriptableObject
    {
        [SerializeField] 
        private float sensitivity;

        public float Sensitivity => sensitivity;
    }
}