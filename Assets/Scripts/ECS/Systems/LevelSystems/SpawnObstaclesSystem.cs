using Data;
using ECS.Components.GameEvents;
using ECS.Components.LevelComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems.LevelSystems
{
    public class SpawnObstaclesSystem: IEcsRunSystem
    {
        private readonly ObstaclesVariants _obstaclesVariants = null;
        private readonly EcsFilter<ActiveObstaclesComponent, LevelOffsetComponent, SpawnObstacle> _spawnObstacleFilter = null;

        public void Run()
        {
            foreach (var i in _spawnObstacleFilter)
            {
                ref var activeObstaclesComponent = ref _spawnObstacleFilter.Get1(i);
                ref var levelOffsetComponent = ref _spawnObstacleFilter.Get2(i);
                if (activeObstaclesComponent.activeObstacles.Count > 3)
                {
                    var objToDestroy = activeObstaclesComponent.activeObstacles.Dequeue();
                    Object.Destroy(objToDestroy);
                }
                var instantiatedObj = Object.Instantiate(_obstaclesVariants.GetRandomObstaclePrefab,
                    new Vector3(0f, levelOffsetComponent.currentOffset, 0f), Quaternion.identity);
                activeObstaclesComponent.activeObstacles.Enqueue(instantiatedObj);
            }
        }
    }
}