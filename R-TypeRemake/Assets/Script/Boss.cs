using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class Boss : MonoBehaviour
{
    enum BossState
    {
        SPAWN_ENEMIES,
        ROTATE,
        IDLE
    }
    public Animator anim;

    private BossState currentState;
    private Vector2 startPosition;
    private Vector2 movePosition;
    private Vector2 startrotation;
    public float rotationspeed;
    public int health = 100;


    public float spawnEnemiesDuration = 10.0f;
    public float rotateDuration = 5.0f;
    public float idleDuration = 5.0f;

    private float moveSpeed = 5.0f;
    private float timeInState = 0.0f;

    public GameObject[] randomenemies; 
    public float spawnInterval = 0.5f;
    private int currentPrefabIndex = 0;
    private float timeSinceLastSpawn = 0f;

    public GameObject levelwin;
    public bgScript bgmoving;
    public bgScript bgmoving2;
    public GameManager gm;
    public PlayerMovement playermov;




    void Start()
    {
        currentState = BossState.SPAWN_ENEMIES;
        startPosition = transform.position;
        movePosition = new Vector2(6.5f, 0);
        transform.rotation = Quaternion.Euler(startrotation);

    }
    private void OnEnable()
    {
        bgmoving.enabled = false;
        bgmoving2.enabled = false;



    }
    void Update()
    {
        if (gm.gamefinished == false)
        {
            switch (currentState)
            {
                case BossState.SPAWN_ENEMIES:
                    SpawnEnemies();
                    break;
                case BossState.ROTATE:
                    Rotate();
                    break;
                case BossState.IDLE:
                    Idle();
                    break;
            }


            timeInState += Time.deltaTime;
            if (timeInState >= spawnEnemiesDuration && currentState == BossState.SPAWN_ENEMIES)
            {
                currentState = BossState.ROTATE;
                timeInState = 0.0f;
            }
            else if (timeInState >= rotateDuration && currentState == BossState.ROTATE)
            {
                currentState = BossState.IDLE;
                timeInState = 0.0f;
            }
            else if (timeInState >= idleDuration && currentState == BossState.IDLE)
            {
                currentState = BossState.SPAWN_ENEMIES;
                timeInState = 0.0f;
            }
        }
    }

    void SpawnEnemies()
        {

            timeSinceLastSpawn += Time.deltaTime;


            if (timeSinceLastSpawn >= spawnInterval)
            {

                timeSinceLastSpawn = 0f;
                Vector2 spawnPosition = new Vector2(10.5f, Random.Range(4f, -4f));

                for (int i = 0; i < 5; i++)
                {

                    Instantiate(randomenemies[currentPrefabIndex], spawnPosition, Quaternion.identity);
                }


                currentPrefabIndex = (currentPrefabIndex + 1) % randomenemies.Length;
            }
        }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        


    }


    void Rotate()
    {
        // Ruota il boss su se stesso per 5 secondi e infligge danno se il player è troppo vicino
        //transform.Rotate(0, 0, rotationspeed);
        anim.SetBool("bossrotate", true);
    }

    private void OnDestroy()
    {
        levelwin.SetActive(true);
        
        
    }

    void Idle()
    {
        anim.SetBool("bossrotate", false);



    }

    void FixedUpdate()
    {
        if (currentState != BossState.IDLE)
        {
            transform.position = Vector3.MoveTowards(transform.position, movePosition, moveSpeed * Time.fixedDeltaTime);
        }
    }
    
    void Die()
    {
        
        
        gameObject.transform.position = new Vector2(26,0);
        gameObject.SetActive(false);
        levelwin.SetActive(true);
        playermov.enabled = false;
        gm.gamefinished = true;
        
    }
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {

            Die();
        
        }
    }
}
