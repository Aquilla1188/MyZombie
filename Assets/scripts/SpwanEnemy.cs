using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanEnemy : MonoBehaviour
{
    [SerializeField] private bool CanSpwanEnemy=true;
    [SerializeField] private GameObject[] enemys;

    float randY;
    float  randX=20;
    Vector2 WhereToSpwan;
    public float spawnRate = 2f;
    float nextSpwan = 2f;
 
    // Update is called once per frame
    void Update()
    {
        if (CanSpwanEnemy)
        {
            if (Time.time > nextSpwan)
            {
                nextSpwan = Time.time + spawnRate;
                randY = Random.Range(-10, 1);
                randX *= -1;
                WhereToSpwan = new Vector2(randX, randY);
                Instantiate(enemys[Random.Range(0, 2)], WhereToSpwan, Quaternion.identity);
            }
        }
    }
}
