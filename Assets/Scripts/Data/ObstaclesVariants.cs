using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(order = 51,fileName = "ObstacleVariants",menuName = "Game Data/Obstacle Variants")]
    public class ObstaclesVariants: ScriptableObject
    {
        [SerializeField] private float obstaclesLength;
        [SerializeField] private List<GameObject> obstaclesPrefabs;
        [SerializeField] private GameObject _groundPrefab;
        
        public GameObject GetStartObstaclePrefab => obstaclesPrefabs[0];

        public GameObject GetRandomObstaclePrefab => obstaclesPrefabs[Random.Range(1, obstaclesPrefabs.Count)];

        public float ObstaclesLength => obstaclesLength;

        public GameObject GroundPrefab => _groundPrefab;
    }
}