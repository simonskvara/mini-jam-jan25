using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour
{
    public bool CanDestroy { get; private set; }

    public float timeUntilCanDestroy = 5f;

    private void Start()
    {
        CanDestroy = false;
        StartCoroutine(ChangeDestroy());
    }

    IEnumerator ChangeDestroy()
    {
        yield return new WaitForSeconds(timeUntilCanDestroy);
        CanDestroy = true;
    }
}
