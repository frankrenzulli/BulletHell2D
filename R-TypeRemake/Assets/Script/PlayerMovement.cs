using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float fireRate = 0.5f;
    public GameObject bulletPrefab;
    public GameObject piercingBullet;
    public Transform FirePoint;
    public int lives = 3;
    public int MaxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    private float nextFire = 0.01f;

    private void Start()
    {
        currentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
        
    }


    private void Update()
    {
        if (!PauseMenu.isPaused)
        {


            Movement();

            if (Input.GetButton("Jump") && Time.time > nextFire)
            {
                Shoot();

            }



            if (currentHealth <= 0)
            {
                lives--;
                currentHealth = MaxHealth;
                Debug.Log(lives);
            }
            Gameover();

        }
    }

    void Shoot()
    {
        //shooting logic
        nextFire = Time.time + fireRate;
        Instantiate(bulletPrefab, FirePoint.position, transform.rotation);
    }


    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");  //movimento orizzontale
        float verticalInput = Input.GetAxis("Vertical");      //movimento verticale

        Vector2 newPosition = (Vector2)transform.position + new Vector2(horizontalInput, verticalInput) * speed * Time.deltaTime;

        float minX = -6.4f;
        float maxX = 9.5f;
        float minY = -4.5f;
        float maxY = 4.5f;
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        // Aggiorna la posizione del player
        transform.position = newPosition;
    }
    void Gameover()
    {
        if(lives == 0)
        {
            Debug.Log("Sei morto");
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            
            lives--;
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
        //shooting logic
        nextFire = Time.time + fireRate;
        Instantiate(piercingBullet, FirePoint.position, transform.rotation);
    }
}
