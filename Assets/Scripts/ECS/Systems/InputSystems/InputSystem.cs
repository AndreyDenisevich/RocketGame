using Data;
using ECS.Components;
using ECS.Components.InputComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems.InputSystems
{
    public class InputSystem: IEcsRunSystem
    {
        private readonly InputData _inputData = null;
        private readonly EcsFilter<DragComponent> _dragFilter = null;
        
        public void Run()
        {
            foreach (var i in _dragFilter)
            {
                ref var dragComponent = ref _dragFilter.Get1(i);
                if (Input.GetMouseButtonDown(0))
                {
                    dragComponent.startTouchPosition = 
                        dragComponent.previousTouchPosition = 
                            dragComponent.currentTouchPosition = Input.mousePosition;
                    dragComponent.dragState = DragState.Begin;

                }
                else if (Input.GetMouseButtonUp(0))
                {
                    dragComponent.startTouchPosition = 
                        dragComponent.previousTouchPosition = 
                            dragComponent.currentTouchPosition = Vector2.zero;
                    dragComponent.dragState = DragState.End;
                }
                else if (Input.GetMouseButton(0))
                {
                    dragComponent.previousTouchPosition = dragComponent.currentTouchPosition;
                    dragComponent.currentTouchPosition = Input.mousePosition * _inputData.Sensitivity;
                    dragComponent.dragState = DragState.Dragging;
                }
                else
                {
                    dragComponent.dragState = DragState.Idle;
                }
            }
        }
    }
}