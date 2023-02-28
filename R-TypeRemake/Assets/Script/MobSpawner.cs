using UnityEngine;
using System.Collections;

public class MobSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public int numberOfObjects = 5;
    public float minY = 0f;
    public float maxY = 10f;
    public float spawnInterval = 2f;
    public float timeBetweenSpawns = 0.5f;

    private float nextSpawnTime;
    private Vector3 spawnPosition;

    void Start()
    {
        // Inizializza la posizione di spawn
        spawnPosition = transform.position;

        // Spawn il primo gruppo di oggetti
        StartCoroutine(SpawnObjects());
    }

    void Update()
    {
        // Verifica se è il momento di preparare il prossimo spawn
        if (Time.time >= nextSpawnTime)
        {
            // Sposta la posizione di spawn in una nuova posizione casuale tra minY e maxY
            spawnPosition = new Vector3(transform.position.x, Random.Range(minY, maxY), transform.position.z);

            // Resetta il timer per il prossimo spawn
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    IEnumerator SpawnObjects()
    {
        // Spawn il gruppo di oggetti nella posizione di spawn
        for (int i = 0; i < numberOfObjects; i++)
        {
            // Seleziona un oggetto casuale dall'array di oggetti da spawnare
            GameObject objectToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];

            // Istanza l'oggetto nella posizione di spawn
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

            // Aspetta per il tempo specificato tra uno spawn e l'altro
            yield return new WaitForSeconds(timeBetweenSpawns);
        }

        // Attendi per il tempo specificato tra un gruppo di oggetti e l'altro
        yield return new WaitForSeconds(spawnInterval - (numberOfObjects * timeBetweenSpawns));

        // Spawn il prossimo gruppo di oggetti
        StartCoroutine(SpawnObjects());
    }
}