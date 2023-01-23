using ECS.Components.MoveComponents;
using ECS.Components.Tags;
using ECS.Components.TransformComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems.CameraSystems
{
    public class CameraInitSystem: IEcsInitSystem
    {
        private readonly Camera _camera = null;
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<PlayerTag,TransformComponent> _playerFilter = null;
        
        public void Init()
        {
            var cameraEntity = _world.NewEntity();
            cameraEntity.Get<CameraTag>();
            ref var transformComponent = ref cameraEntity.Get<TransformComponent>();
            ref var followComponent = ref cameraEntity.Get<FollowComponent>();
            ref var offsetComponent = ref cameraEntity.Get<OffsetComponent>();

            transformComponent.transform = _camera.transform;

            followComponent.target = _playerFilter.GetEntity(0).Get<TransformComponent>().transform;
            followComponent.followSmoothness = 0.5f;

            offsetComponent.offset = _camera.transform.position - followComponent.target.position;
        }
    }
}