using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class ElementSpawner : MonoBehaviour
{
    public float rateOfSpawning;

    public Transform spawnPoint;

    private Vector3 _spawnPosition;
    

    private float _lastTimeSpawned;
    

    [Header("Spawner")] 
    public List<GameObject> elements;
    
    public float minSpawnForce;
    public float maxSpawnForce;

    private void Start()
    {
        if (spawnPoint == null)
        {
            _spawnPosition = transform.position;
        }
        else
        {
            _spawnPosition = spawnPoint.position;
        }
    }

    private void Update()
    {
        if (Time.time > _lastTimeSpawned + rateOfSpawning)
        {
            SpawnElement();
            _lastTimeSpawned = Time.time;
        }
    }


    private void SpawnElement()
    {
        int randomIndex = Random.Range(0, elements.Count);
        GameObject spawnedElement = Instantiate(elements[randomIndex], transform.position, Quaternion.identity);
        Rigidbody2D elementRb = spawnedElement.GetComponent<Rigidbody2D>();
        
        if (!elementRb)
        {
            elementRb = spawnedElement.AddComponent<Rigidbody2D>();
        }

        float randomForce = Random.Range(minSpawnForce, maxSpawnForce);
        float randomY = Random.Range(-0.8f, 0.8f);
        
        elementRb.AddForce(new Vector2(-1, randomY) * randomForce);
        
    }
}
