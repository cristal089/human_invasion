using UnityEngine;
using UnityEngine.SceneManagement;

namespace Story
{
    public class MainUIController : MonoBehaviour
    {
        public void StartGame()
        {
            SceneManager.LoadScene("GameScene");
        }
        
    }

}
