using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour
{
    public bool CanDestroy { get; private set; }

    public float timeUntilCanDestroy = 5f;

    private Rigidbody2D _rb;
    
    private void Start()
    {
        CanDestroy = false;
        StartCoroutine(ChangeDestroy());

        _rb = gameObject.GetComponent<Rigidbody2D>();
        
        _rb.interpolation = RigidbodyInterpolation2D.Interpolate;
        _rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    IEnumerator ChangeDestroy()
    {
        yield return new WaitForSeconds(timeUntilCanDestroy);
        CanDestroy = true;
    }
}
