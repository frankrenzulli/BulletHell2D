using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Wave
{
    public string waveName;
    public int NumOfEnemies;
    public GameObject Enemy;
    public float spawnInterval;
    
}

public class WaveSpawner : MonoBehaviour
{

    [SerializeField] Wave[] waves;
    public Transform[] SpawnPoints;
    public Animator animator;
    public Text WaveName;

    private Wave CurrentWave;
    private int currentWaveNumber;
    private float nextSpawnTime;

    private bool canAnimate = false; 
    public bool canSpawn = true;


    


    private void Update()
    {
        
        CurrentWave = waves[currentWaveNumber];
        SpawnWave();
        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (totalEnemies.Length == 0 )
        {
            if( currentWaveNumber + 1 != waves.Length )
            {
                if (canAnimate) 
                {
                    WaveName.text = waves[currentWaveNumber + 1].waveName;
                    animator.SetTrigger("WaveComplete");
                    canAnimate = false;
                }
                
            }
            else
            {
                Debug.Log("Game Finished!");
            }


        }
        

    }

    void SpawnNextWave()
    {
        currentWaveNumber++;
        canSpawn = true;
    }


    void SpawnWave()
    {
        if (canSpawn && nextSpawnTime < Time.time)
        {
            GameObject WaveEnemy = CurrentWave.Enemy;
            Transform randomPoint = SpawnPoints[Random.Range(0, SpawnPoints.Length)];
            Instantiate(WaveEnemy, randomPoint.position, Quaternion.identity);
            CurrentWave.NumOfEnemies--;
            nextSpawnTime = Time.time + CurrentWave.spawnInterval;
            if (CurrentWave.NumOfEnemies == 0 )
            {
                canSpawn = false;
                canAnimate = true;
            }


        }

    }
}
