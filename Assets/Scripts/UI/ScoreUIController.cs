using TMPro;
using UnityEngine;

public class ScoreUIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;

    void Start()
    {
        scoreText.text = GameManager.Instance.score.ToString() + " pontos";
        highScoreText.text = "Recorde de " + PlayerPrefs.GetInt("HighScore", 0).ToString() + " pontos";
    }
}
