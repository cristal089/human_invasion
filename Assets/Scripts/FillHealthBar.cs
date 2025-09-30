using UnityEngine;
using UnityEngine.UI;

public class FillHealthBar : MonoBehaviour
{
    public static FillHealthBar instance;

    [SerializeField] int maxValue;
    [SerializeField] Image fill;

    int currentValue;
    private void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentValue = maxValue;
        fill.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void Add(int value)
    //{
    //    currentValue += value;

    //    if (currentValue > maxValue)
    //    {
    //        currentValue = maxValue;
    //    }
    //    fill.fillAmount = (float)currentValue / maxValue;

    //}

    public void Remove(int value)
    {
        currentValue -= value;

        if (currentValue < 0)
        {
            currentValue = 0;
        }

        fill.fillAmount = (float)currentValue / maxValue;
    }
}
