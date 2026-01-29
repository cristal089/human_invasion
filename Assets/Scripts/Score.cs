using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;
    public static Score instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score.text = GameManager.Instance.score.ToString();
    }

    public void AddPoint()
    {
        GameManager.Instance.AddScore(10);
        score.text = GameManager.Instance.score.ToString();
    }
}
