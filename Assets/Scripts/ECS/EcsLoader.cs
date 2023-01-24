using Data;
using ECS.Components.GameEvents;
using ECS.Systems.FollowSystems;
using ECS.Systems.InitSystems;
using ECS.Systems.InputSystems;
using ECS.Systems.LevelSystems;
using ECS.Systems.PlayerSystems;
using ECS.Systems.UISystems;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS
{
    public class EcsLoader : MonoBehaviour
    {
        [SerializeField] 
        private UI.UI ui;
        
        private Camera _mainCamera;
        private GameData _gameData;
        private EcsWorld _world;
        private EcsSystems _initSystems;
        private EcsSystems _updateSystems;
        private EcsSystems _fixedUpdateSystems;
        void Start()
        {
            _mainCamera = Camera.main;
            _gameData = GameData.GetFromResources;
            _world = new EcsWorld();
            _initSystems = new EcsSystems(_world);
            _updateSystems = new EcsSystems(_world);
            _fixedUpdateSystems = new EcsSystems(_world);
            
            InjectToInitSystems();
            InitSystems();
            
            InjectToUpdateSystems();
            AddOneFramesToUpdateSystems();
            InitUpdateSystems();
            
            InitFixedUpdateSystems();
        }

        private void InitSystems()
        {
            _initSystems.
                Add(new GameInitSystem()).
                Add(new PlayerInitSystem()).
                Add(new CameraInitSystem()).
                Add(new GroundInitSystem());
            
            _initSystems.Init();
        }
        private void InitUpdateSystems()
        {
            _updateSystems.
                Add(new InfiniteLevelSystem()).
                Add(new SpawnObstaclesSystem()).
                Add(new InputSystem()).
                Add(new PlayerInputSystem()).
                Add(new PlayerDirectionSystem()).
                Add(new PlayerLoseSystem()).
                Add(new ViewLoseScreenSystem());
            
            _updateSystems.Init();
        }
        
        private void InitFixedUpdateSystems()
        {
            _fixedUpdateSystems.
                Add(new PlayerMoveSystem()).
                Add(new PlayerCollisionSystem()).
                Add(new FollowPlayerSystem());
            
            _fixedUpdateSystems.Init();
        }

        private void InjectToInitSystems()
        {
            _initSystems.
                Inject(_gameData.PlayerData).
                Inject(_mainCamera).
                Inject(_gameData.ObstaclesVariants);
        }
        private void InjectToUpdateSystems()
        {
            _updateSystems.
                Inject(ui).
                Inject(_gameData.ObstaclesVariants);
        }
        
        private void AddOneFramesToUpdateSystems()
        {
            _updateSystems.
                OneFrame<SpawnObstacle>();
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
