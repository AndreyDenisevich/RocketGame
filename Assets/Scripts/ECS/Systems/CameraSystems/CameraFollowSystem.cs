﻿using ECS.Components.MoveComponents;
using ECS.Components.Tags;
using ECS.Components.TransformComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems.CameraSystems
{
    public class CameraFollowSystem: IEcsRunSystem
    {
        private readonly EcsFilter<CameraTag, FollowComponent,OffsetComponent, TransformComponent>
            _cameraFollowFilter = null;
        public void Run()
        {
            foreach (var i in _cameraFollowFilter)
            {
                ref var followComponent = ref _cameraFollowFilter.Get2(i);
                ref var offsetComponent = ref _cameraFollowFilter.Get3(i);
                var transform = _cameraFollowFilter.Get4(i).transform;

                var destinationPosition = followComponent.target.position + offsetComponent.offset;
                destinationPosition.x = transform.position.x;
                
                var smoothedPosition = Vector3.Lerp(transform.position, destinationPosition,
                    followComponent.followSmoothness);

                transform.position = smoothedPosition;
            }
        }
    }
}