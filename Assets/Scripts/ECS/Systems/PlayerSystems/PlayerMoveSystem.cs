using ECS.Components.Blocks;
using ECS.Components.MoveComponents;
using ECS.Components.Tags;
using ECS.Components.TransformComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems.PlayerSystems
{
    public class PlayerMoveSystem: IEcsRunSystem
    {
        private readonly
            EcsFilter<PlayerTag, RigidbodyComponent, MoveComponent>.Exclude<MovementStopped>
            _playerMoveFilter = null;
        public void Run()
        {
            foreach (var i in _playerMoveFilter)
            {
                ref var rigidbodyComponent = ref _playerMoveFilter.Get2(i);
                ref var moveComponent = ref _playerMoveFilter.Get3(i);

                var dir = rigidbodyComponent.rigidbody.transform.up;
                
                rigidbodyComponent.rigidbody.
                    AddForce(dir * moveComponent.speed * moveComponent.accelerationMultiplier,
                        ForceMode.Force); 
                
                rigidbodyComponent.rigidbody.velocity = 
                    Vector3.ClampMagnitude(rigidbodyComponent.rigidbody.velocity,moveComponent.speed);
                
                //rigidbodyComponent.rigidbody.velocity = dir * moveComponent.speed;
            }
        }
    }
}