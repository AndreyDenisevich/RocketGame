using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems.InitSystems
{
    public class GameInitSystem: IEcsInitSystem
    {
        public void Init()
        {
            Screen.orientation = ScreenOrientation.Portrait;
            Application.targetFrameRate = 60;
            QualitySettings.vSyncCount = 0;
        }
    }
}