using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public bool immunity;

    [SerializeField] float speed = 5.0f;
    public float fireRate = 0.5f;
    public GameObject bulletPrefab;
    [SerializeField] private GameObject chargedBulletprefab;
    public Transform FirePoint;
    public int lives = 3;
    public int MaxHealth = 100;
    public int currentHealth;
    public GameObject immunityaura;

    public HealthBar healthBar;


    private float nextFire = 0.01f;

    public GameManager GM;
    public bool isDead;
    public GameObject[] life;
    public int lifeindex;

    [SerializeField] private float chargeSpeed = 1;
    [SerializeField] private float chargeTime = 0;
    private bool isCharging;
    

    private void Start()
    {
        currentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);

        
        lifeindex = 0;
    }


    private void Update()
    {
        if (!GameManager.isPaused)
        {

            if (Input.GetKey(KeyCode.C) && chargeTime < 2)
            {
                isCharging = true;
                if(isCharging == true)
                {
                    chargeTime += chargeSpeed * Time.deltaTime;

                }
                
            }
            if (Input.GetKeyUp(KeyCode.C) && chargeTime >=2)
            {
                PiercingShoot();
            }

            Movement();

            if (Input.GetButton("Jump") && Time.time > nextFire)
            {
                Shoot();

            }



            if (currentHealth <= 0)
            {
                currentHealth = MaxHealth; 
                healthBar.SetMaxHealth(MaxHealth);
                lives--;
                life[lifeindex].gameObject.SetActive(false);
                lifeindex ++;
                ImmunityState();
                Debug.Log(lives);
            }
            if(lives == 0 && !isDead)
            {
                isDead = true;
                GM.GameOver();
                immunityaura.SetActive(false);
                healthBar.SetHealth(0);
            }

        }
    }

    void Shoot()
    {
        nextFire = Time.time + fireRate;
        Instantiate(bulletPrefab, FirePoint.position, transform.rotation);
    }


    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");  
        float verticalInput = Input.GetAxis("Vertical");      

        Vector2 newPosition = (Vector2)transform.position + new Vector2(horizontalInput, verticalInput) * speed * Time.deltaTime;

        float minX = -6.4f;
        float maxX = 3.5f;
        float minY = -4.5f;
        float maxY = 4.5f;
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);


        transform.position = newPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy" && immunity == false)
        {
            
            lives--;
            life[lifeindex].gameObject.SetActive(false);
            lifeindex++;
            ImmunityState();
            Destroy(collision.gameObject);
        }
    }

    public void TakeDamage(int damage)
    {

        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    void PiercingShoot()
    {
        Instantiate(chargedBulletprefab, FirePoint.position, transform.rotation);
        isCharging = false;
        chargeTime = 0;
    }
    void ImmunityState()
    {
        immunityaura.SetActive(true);
        immunity = true;
        Invoke("ResetImmunity", 3f);
    }

    void ResetImmunity()
    {
        immunity = false;
        immunityaura.SetActive(false);
    }
    

}
