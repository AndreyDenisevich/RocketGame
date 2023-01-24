using System.Collections.Generic;
using UnityEngine;

namespace ECS.Components.LevelComponents
{
    public struct ActiveObstaclesComponent
    {
        public Queue<GameObject> activeObstacles;
    }
}