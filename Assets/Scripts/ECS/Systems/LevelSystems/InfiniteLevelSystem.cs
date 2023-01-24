using System.Collections.Generic;
using Data;
using ECS.Components.GameEvents;
using ECS.Components.LevelComponents;
using ECS.Components.Tags;
using ECS.Components.TransformComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems.LevelSystems
{
    public class InfiniteLevelSystem: IEcsInitSystem, IEcsRunSystem
    {
        private readonly ObstaclesVariants _obstaclesVariants = null;
        private readonly EcsWorld _world = null;
        
        private readonly EcsFilter<PlayerTag, TransformComponent> _playerFilter;
        private readonly EcsFilter<LevelOffsetComponent> _levelFilter;

        public void Init()
        {
            var levelEntity = _world.NewEntity();
            ref var activeObstaclesComponent = ref levelEntity.Get<ActiveObstaclesComponent>();
            levelEntity.Get<LevelOffsetComponent>().currentOffset = 0f;
             
            var startObstacle = Object.Instantiate(_obstaclesVariants.GetStartObstaclePrefab,
                Vector3.zero, Quaternion.identity);
            activeObstaclesComponent.activeObstacles = new Queue<GameObject>();
            activeObstaclesComponent.activeObstacles.Enqueue(startObstacle);
        }

        public void Run()
        {
            foreach (var i in _levelFilter)
            {
                var transform = _playerFilter.Get2(0).transform;
                ref var levelOffsetComponent = ref _levelFilter.Get1(i);
                
                
                if (transform.position.y + _obstaclesVariants.ObstaclesLength >= levelOffsetComponent.currentOffset)
                {
                    levelOffsetComponent.currentOffset += _obstaclesVariants.ObstaclesLength;
                    _levelFilter.GetEntity(i).Get<SpawnObstacle>();
                }
            }
        }
    }
}