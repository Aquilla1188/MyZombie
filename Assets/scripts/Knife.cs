using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Knife : MonoBehaviour
{
    
    private float speed=20;
    private Rigidbody2D myRigidbody;
    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        myRigidbody.velocity = direction * speed;
    }
    public void Initialize(Vector2 dir)
    {
        this.direction = dir;   
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
