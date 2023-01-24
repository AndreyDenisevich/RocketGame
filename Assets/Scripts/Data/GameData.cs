using UnityEngine;

namespace Data
{
    [CreateAssetMenu(order = 51,fileName = "GameData", menuName = "Game Data/Game Data")]
    public class GameData: ScriptableObject
    {
        [SerializeField] private PlayerData playerData;
        [SerializeField] private InputData inputData;
        [SerializeField] private ObstaclesVariants obstaclesVariants;

        public PlayerData PlayerData => playerData;

        public InputData InputData => inputData;

        public static GameData GetFromResources => Resources.Load<GameData>("GameData");

        public ObstaclesVariants ObstaclesVariants => obstaclesVariants;
    }
}