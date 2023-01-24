using UnityEngine.SceneManagement;

namespace UI.Screens
{
    public class LoseScreen: Screen
    {
        public void OnRestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}