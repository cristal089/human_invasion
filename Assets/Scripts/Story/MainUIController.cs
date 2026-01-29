using UnityEngine;
using UnityEngine.SceneManagement;

namespace Story
{
    public class MainUIController : MonoBehaviour
    {
        public void StartGame()
        {
            GameManager.Instance.ResetScore();
            SceneManager.LoadScene("GameScene");
        }
        
    }

}
