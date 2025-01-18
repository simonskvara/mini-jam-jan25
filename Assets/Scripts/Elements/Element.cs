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
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (_rb != null)
            {
                
                Vector2 normal = collision.contacts[0].normal;
                float velAlongNormal = Vector2.Dot(_rb.velocity, normal);
                if (velAlongNormal > 0)
                {
                    Vector2 bounceVelocity = velAlongNormal * normal;
                    _rb.velocity -= bounceVelocity;
                }
            }
        }
    }

}
