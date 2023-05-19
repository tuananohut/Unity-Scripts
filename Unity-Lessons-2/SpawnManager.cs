using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefab;
    private float spawnRangeX = 10;
    private float spawnPosZ = 20;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", 2, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {/*
        if (Input.GetKeyDown(KeyCode.S))
        {
            SpawnRandomAnimal();   
        }
        */
    }

    void SpawnRandomAnimal()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ); //x'i -20 ve 20 arasında, y'si 0, z'si 20 olacak
        int animalIndex = Random.Range(0, animalPrefab.Length); // animalPrefab arrayinden bir eleman seç rastgele
        Instantiate(animalPrefab[animalIndex], spawnPos, animalPrefab[animalIndex].transform.rotation); // Örneklendir; kimi -> animalPrefab[animalIndex], nerede -> spawnPos, 
    }


}
