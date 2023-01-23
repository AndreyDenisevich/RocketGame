using UnityEngine;

namespace Data
{
    [CreateAssetMenu(order = 51, fileName = "PlayerData",menuName = "Game Data/Player Data")]
    public class PlayerData: ScriptableObject
    {
        [SerializeField] 
        private GameObject playerPrefab;

        [SerializeField] 
        private float speed;

        [SerializeField] 
        private float accelerationMultiplier;

        public GameObject PlayerPrefab => playerPrefab;

        public float Speed => speed;

        public float AccelerationMultiplier => accelerationMultiplier;
    }
}