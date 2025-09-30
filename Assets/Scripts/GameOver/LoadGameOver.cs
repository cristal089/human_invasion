using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameOver
{
    public class LoadGameOver : MonoBehaviour
    {
        public void RestartGame()
        {
            SceneManager.LoadScene("GameScene");
        }

        public void MainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
        public void ExitGame()
        {
            Application.Quit();
        }
    }

}
