using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]    private float fillAmount;
    [SerializeField]    private Image Content;
    [SerializeField]    private float lerpSpeed=2;
    public float MaxValue { get; set; }
    public float value
    {
        set
        {
            fillAmount = Map(value, 0, MaxValue, 0, 1);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleBar();
    }
    void HandleBar()
    {
        if (fillAmount != Content.fillAmount)
        {
            Content.fillAmount =  Mathf.Lerp(Content.fillAmount,fillAmount,Time.deltaTime*lerpSpeed);
        }
        
    }

    private float Map (float value, float inMin,float inMax,float outMin,float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
