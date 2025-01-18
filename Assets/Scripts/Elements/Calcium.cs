using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calcium : MonoBehaviour
{
    public bool OnFire { get; private set; }

    private Rigidbody2D _rb;
    
    [SerializeField] private float targetTorque = 1000f;
    [SerializeField] private float duration = 2f;

    public Sprite normalSprite;
    public Sprite onFireSprite;
    
    private void Start()
    {
        OnFire = false;
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Oxygen") && !OnFire)
        {
            SetOnFire();
        }

        if (other.gameObject.CompareTag("Water") && OnFire)
        {
            StopFire();
        }
    }

    public void SetOnFire()
    {
        OnFire = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = onFireSprite;
        StartCoroutine(SpinRoutine());
    }

    public void StopFire()
    {
        OnFire = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = normalSprite;
        StopAllCoroutines();
        _rb.angularVelocity = 0f;
    }
    
    
    private IEnumerator SpinRoutine()
    {
        float elapsed = 0f;
        float initialSpeed = _rb.angularVelocity;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            
            float currentSpeed = Mathf.Lerp(initialSpeed, targetTorque, t);

            _rb.angularVelocity = currentSpeed;

            yield return null;
        }

        while (elapsed > duration)
        {
            _rb.angularVelocity = targetTorque;
            yield return null;
        }
        
    }
    
    
}
