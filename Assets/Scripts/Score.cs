using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;
    public static Score instance;

    int scoreCount = 0;

    private void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score.text = scoreCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoint()
    {
        scoreCount += 100;
        score.text = scoreCount.ToString();
    }
}
