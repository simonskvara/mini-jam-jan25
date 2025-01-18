using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxygen : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Calcium") && !other.gameObject.GetComponent<Calcium>().OnFire)
        {
            Destroy(gameObject);
        }
    }
}
