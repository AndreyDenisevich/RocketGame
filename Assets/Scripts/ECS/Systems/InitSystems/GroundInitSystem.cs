using Data;
using ECS.Components.MoveComponents;
using ECS.Components.Tags;
using ECS.Components.TransformComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems.InitSystems
{
    public class GroundInitSystem: IEcsInitSystem
    {
        private readonly ObstaclesVariants _obstaclesVariants;
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<PlayerTag,TransformComponent> _playerFilter = null;
        
        public void Init()
        {
            var groundEntity = _world.NewEntity();
            groundEntity.Get<FollowPlayerTag>();
            ref var transformComponent = ref groundEntity.Get<TransformComponent>();
            ref var followComponent = ref groundEntity.Get<FollowComponent>();
            ref var offsetComponent = ref groundEntity.Get<OffsetComponent>();

            var groundObj = Object.Instantiate(_obstaclesVariants.GroundPrefab);
            
            transformComponent.transform = groundObj.transform;

            followComponent.target = _playerFilter.GetEntity(0).Get<TransformComponent>().transform;
            followComponent.followSmoothness = 0.25f;

            offsetComponent.offset = groundObj.transform.position - followComponent.target.position;

        }
    }
}