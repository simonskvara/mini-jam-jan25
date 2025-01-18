using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class ElementSpawner : MonoBehaviour
{
    [HideInInspector] public float rateOfSpawning;
    
    public float minSpawnRate;
    public float maxSpawnRate;

    public Transform spawnPoint;

    private Vector3 _spawnPosition;

    private GameObject _player;

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
        
        _player = GameObject.FindGameObjectWithTag("Player");

        rateOfSpawning = GetRandomSpawnRate();

    }

    private void Update()
    {
        if (Time.time > _lastTimeSpawned + rateOfSpawning)
        {
            SpawnElement();
            rateOfSpawning = GetRandomSpawnRate();
            _lastTimeSpawned = Time.time;
        }
    }

    private float GetRandomSpawnRate()
    {
        float randomTime = Random.Range(minSpawnRate, maxSpawnRate);
        return randomTime;
    }

    private void SpawnElement()
    {
        int randomIndex = Random.Range(0, elements.Count);
        GameObject spawnedElement = Instantiate(elements[randomIndex], _spawnPosition, Quaternion.identity);
        Rigidbody2D elementRb = spawnedElement.GetComponent<Rigidbody2D>();
        
        if (!elementRb)
        {
            elementRb = spawnedElement.AddComponent<Rigidbody2D>();
        }

        float randomForce = Random.Range(minSpawnForce, maxSpawnForce);
        float randomX = Random.Range(-0.8f, 0.8f);

        Vector2 direction = _player.transform.position - transform.position;
        
        elementRb.AddForce(/*new Vector2(randomX, 1)*/ direction * randomForce);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Element") && other.GetComponent<Element>().CanDestroy)
        {
            Destroy(other.gameObject);
        }
    }
}
