using Leopotam.Ecs;

namespace ECS.Systems.CameraSystems
{
    public class CameraInitSystem: IEcsInitSystem
    {
        private readonly EcsWorld _world = null;
        
        public void Init()
        {
            var cameraEntity = _world.NewEntity();
        }
    }
}