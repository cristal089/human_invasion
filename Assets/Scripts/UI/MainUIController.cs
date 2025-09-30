using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MainUIController : MonoBehaviour
    {
        public void StartGame()
        {
            SceneManager.LoadScene("GameScene");
        }

        public void GameCredits()
        {
            SceneManager.LoadScene("GameCredits");
        }
        public void ExitGame()
        {
            Application.Quit();
        }
    }

}
