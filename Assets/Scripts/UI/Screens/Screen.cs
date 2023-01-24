using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class Screen: MonoBehaviour
    {
        [SerializeField] private Image _panel;

        public void Toggle(bool state)
        {
            _panel.gameObject.SetActive(state);
        }
    }
}