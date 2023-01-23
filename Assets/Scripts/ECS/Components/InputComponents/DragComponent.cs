using UnityEngine;

namespace ECS.Components.InputComponents
{
    public struct DragComponent
    {
        public Vector2 startTouchPosition;
        public Vector2 previousTouchPosition;
        public Vector2 currentTouchPosition;
        public DragState dragState;
    }

    public enum DragState
    {
        Idle,
        Begin,
        Dragging,
        End
    }
}