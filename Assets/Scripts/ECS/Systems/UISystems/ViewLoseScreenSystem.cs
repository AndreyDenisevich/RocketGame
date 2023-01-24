using ECS.Components.GameEvents;
using Leopotam.Ecs;

namespace ECS.Systems.UISystems
{
    public class ViewLoseScreenSystem: IEcsRunSystem
    {
        private readonly UI.UI _ui = null;
        private readonly EcsFilter<LoseEvent> _loseFilter = null;
        public void Run()
        {
            foreach (var i in _loseFilter)
            {
                _ui.LoseScreen.Toggle(true);
            }
        }
    }
}