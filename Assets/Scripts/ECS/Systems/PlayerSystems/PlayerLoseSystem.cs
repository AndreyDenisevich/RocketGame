using ECS.Components.GameEvents;
using ECS.Components.Tags;
using ECS.Components.TransformComponents;
using Leopotam.Ecs;

namespace ECS.Systems.PlayerSystems
{
    public class PlayerLoseSystem: IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag,RigidbodyComponent, LoseEvent> _playerLose;

        public void Run()
        {
            foreach (var i in _playerLose)
            {
                _playerLose.Get2(i).rigidbody.isKinematic = true;
            }
        }
    }
}