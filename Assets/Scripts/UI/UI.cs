using UI.Screens;
using UnityEngine;

namespace UI
{
    public class UI : MonoBehaviour
    {
        [SerializeField] private LoseScreen _loseScreen;

        public LoseScreen LoseScreen => _loseScreen;
    }
}
