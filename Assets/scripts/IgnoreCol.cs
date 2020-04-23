using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCol : MonoBehaviour
{

    public void OnCollisionEnter2D(Collision2D collision)
    {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);      
    }

}
