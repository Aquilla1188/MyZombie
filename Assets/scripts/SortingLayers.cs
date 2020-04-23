using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingLayers : MonoBehaviour
{
    [SerializeField]
    private int sortingOrderBase = 0;

    private Renderer myRenderer;
    private float timer;
    private float timerMax = 0.1f;

    // Start is called before the first frame update
    void Awake()
    {
        myRenderer = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = timerMax;
            myRenderer.sortingOrder = (int)(sortingOrderBase - (transform.position.y*100 ));
        }

         
    }
}
