using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Hydrogen : MonoBehaviour
{
    public GameObject water;
    public GameObject dustyLandmine;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Oxygen"))
        {
            CreateWater((other.gameObject.transform.position + gameObject.transform.position) / 2f);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Calcium"))
        {
            SpawnDustyLandmine((other.gameObject.transform.position + gameObject.transform.position) / 2f);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    private void CreateWater(Vector2 position)
    {
        GameObject spawnedWater = Instantiate(water, position, Quaternion.identity);
    }

    private void SpawnDustyLandmine(Vector2 position)
    {
        GameObject spawnedLandmine = Instantiate(dustyLandmine, position, Quaternion.identity);
    }
}
