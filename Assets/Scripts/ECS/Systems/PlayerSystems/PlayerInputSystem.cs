using Data;
using ECS.Components.Blocks;
using ECS.Components.InputComponents;
using ECS.Components.Tags;
using ECS.Components.TransformComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems.PlayerSystems
{
    public class PlayerInputSystem: IEcsRunSystem
    {
        private readonly InputData _inputData = null;
        private readonly EcsFilter<PlayerTag, DragComponent, DirectionComponent> _playerDirectionFilter = null;
        public void Run()
        {
            foreach (var i in _playerDirectionFilter)
            {
                ref var playerEntity = ref _playerDirectionFilter.GetEntity(i);
                ref var dragComponent = ref _playerDirectionFilter.Get2(i);
                ref var directionComponent = ref _playerDirectionFilter.Get3(i);

                switch (dragComponent.dragState)
                {
                    case DragState.Begin:
                        playerEntity.Del<MovementStopped>();
                        break;
                    case DragState.Dragging:
                        var dir = 
                            (dragComponent.currentTouchPosition - dragComponent.previousTouchPosition).normalized;
                        dir *= _inputData.Sensitivity;
                        dir.y = 1f;
                        directionComponent.direction = 
                            Vector3.Lerp(directionComponent.direction, 
                                (Vector3)dir.normalized, 0.2f);
                        break;
                    case DragState.End:
                        playerEntity.Get<MovementStopped>();
                        break;
                }
            }
        }
    }
}