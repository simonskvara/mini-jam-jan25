using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class DustyLandmine : MonoBehaviour
{
    public GameObject explosion;

    public int decreaseScore;

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
        int currentValue = Variables.ActiveScene.Get<int>("High Score");
        
        currentValue -= decreaseScore;
        
        Variables.ActiveScene.Set("High Score", currentValue);
        
        Instantiate(explosion, transform.position, Quaternion.identity);
    }
    
}
