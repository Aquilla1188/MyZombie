using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnsScript : MonoBehaviour
{
    private static   BtnsScript instance;
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private int collectedCoins;
    [SerializeField] private Text coinsTxt;

    public static BtnsScript Instance {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<BtnsScript>();
            }

            return instance;

        }
    }

    public GameObject CoinPrefab { get => coinPrefab;  }
    public int CollectedCoins { get => collectedCoins; set { coinsTxt.text = value.ToString(); collectedCoins = value; } }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void  pause()
    {
        Time.timeScale = Mathf.Abs(Time.timeScale-1);
        
    }
}
