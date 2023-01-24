using ECS.Components.Events;
using ECS.Components.GameEvents;
using ECS.Components.Tags;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems.PlayerSystems
{
    public class PlayerCollisionSystem: IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, OnCollisionEnter> _collisionFilter = null;

        public void Run()
        {
            foreach (var i in _collisionFilter)
            {
                ref var playerEntity = ref _collisionFilter.GetEntity(i);
                playerEntity.Del<OnCollisionEnter>();
                playerEntity.Get<LoseEvent>();
            }
        }
    }
}