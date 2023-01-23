using UnityEngine;

namespace Data
{
    [CreateAssetMenu(order = 51,fileName = "GameData", menuName = "Game Data/Game Data")]
    public class GameData: ScriptableObject
    {
        [SerializeField] private PlayerData playerData;

        public PlayerData PlayerData => playerData;

        public static GameData GetFromResources => Resources.Load<GameData>("GameData");
    }
}