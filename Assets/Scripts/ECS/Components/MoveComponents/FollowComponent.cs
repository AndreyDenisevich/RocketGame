using UnityEngine;

namespace ECS.Components.MoveComponents
{
    public struct FollowComponent
    {
        public Transform target;
        public float followSmoothness;
    }
}