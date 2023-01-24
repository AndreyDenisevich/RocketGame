using Data;
using ECS.Components.Blocks;
using ECS.Components.InputComponents;
using ECS.Components.MoveComponents;
using ECS.Components.Reference;
using ECS.Components.Tags;
using ECS.Components.TransformComponents;
using Leopotam.Ecs;
using Physics;
using UnityEngine;

namespace ECS.Systems.InitSystems
{
    public class PlayerInitSystem: IEcsInitSystem
    {
        private readonly PlayerData _playerData = null;
        private readonly EcsWorld _world = null;
        public void Init()
        {
            var playerEntity = _world.NewEntity();
            playerEntity.Get<PlayerTag>();
            playerEntity.Get<DragComponent>();
            playerEntity.Get<MovementStopped>();
            playerEntity.Get<DirectionComponent>();
            ref var entityReference = ref playerEntity.Get<EntityReference>();
            ref var moveComponent = ref playerEntity.Get<MoveComponent>();
            ref var rigidbodyComponent = ref playerEntity.Get<RigidbodyComponent>();
            ref var transformComponent = ref playerEntity.Get<TransformComponent>();

            entityReference.entity = playerEntity;
            moveComponent.speed = _playerData.Speed;
            moveComponent.accelerationMultiplier = _playerData.AccelerationMultiplier;

            var playerInstance = InstantiatePlayer();
            transformComponent.transform = playerInstance.transform;
            rigidbodyComponent.rigidbody = playerInstance.GetComponent<Rigidbody>();
            rigidbodyComponent.rigidbody.centerOfMass += Vector3.up*2f;
            playerInstance.GetComponent<PlayerCollisionChecker>().Init(entityReference);
        }

        private GameObject InstantiatePlayer()
        {
            var playerInstance = Object.Instantiate(_playerData.PlayerPrefab,Vector3.zero, Quaternion.identity);
            return playerInstance;
        }
    }
}