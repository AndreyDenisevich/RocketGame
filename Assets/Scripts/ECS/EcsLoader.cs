using System;
using Data;
using ECS.Systems.InitSystems;
using ECS.Systems.InputSystems;
using ECS.Systems.PlayerSystems;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS
{
    public class EcsLoader : MonoBehaviour
    {
        private GameData _gameData;
        private EcsWorld _world;
        private EcsSystems _initSystems;
        private EcsSystems _updateSystems;
        private EcsSystems _fixedUpdateSystems;
        void Start()
        {
            _gameData = GameData.GetFromResources;
            _world = new EcsWorld();
            _initSystems = new EcsSystems(_world);
            _updateSystems = new EcsSystems(_world);
            _fixedUpdateSystems = new EcsSystems(_world);
            
            InjectToInitSystems();
            InitSystems();
            
            InitUpdateSystems();
            
            InitFixedUpdateSystems();
        }

        private void InitSystems()
        {
            _initSystems.
                Add(new GameInitSystem()).
                Add(new PlayerInitSystem());
            
            _initSystems.Init();
        }
        private void InitUpdateSystems()
        {
            _updateSystems.
                Add(new InputSystem()).
                Add(new PlayerInputSystem()).
                Add(new PlayerDirectionSystem());
            
            _updateSystems.Init();
        }
        
        private void InitFixedUpdateSystems()
        {
            _fixedUpdateSystems.
                Add(new PlayerMoveSystem());
            
            _fixedUpdateSystems.Init();
        }

        private void InjectToInitSystems()
        {
            _initSystems.
                Inject(_gameData.PlayerData);
        }
        
        void Update()
        {
            _updateSystems.Run();
        }

        private void FixedUpdate()
        {
            _fixedUpdateSystems.Run();
        }

        private void OnDestroy()
        {
            _initSystems.Destroy();
            _updateSystems.Destroy();
            _fixedUpdateSystems.Destroy();
            _world.Destroy();
        }
    }
}
