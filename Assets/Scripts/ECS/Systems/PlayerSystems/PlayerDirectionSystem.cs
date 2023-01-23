using ECS.Components.Blocks;
using ECS.Components.Tags;
using ECS.Components.TransformComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems.PlayerSystems
{
    public class PlayerDirectionSystem: IEcsRunSystem
    {
        private readonly
            EcsFilter<PlayerTag, TransformComponent, DirectionComponent>.Exclude<MovementStopped>
            _playerMoveFilter;
        
        public void Run()
        {
            foreach (var i in _playerMoveFilter)
            {
                ref var transformComponent = ref _playerMoveFilter.Get2(i);
                ref var directionComponent = ref _playerMoveFilter.Get3(i);

                transformComponent.transform.up = 
                    Vector3.Lerp(transformComponent.transform.up, directionComponent.direction, 0.04f);
            }
        }
    }
}