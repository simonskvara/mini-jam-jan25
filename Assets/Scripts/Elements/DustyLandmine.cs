using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustyLandmine : MonoBehaviour
{
    public GameObject explosion;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Water"))
        {
            Kaboom();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    private void Kaboom()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
    }
    
}
