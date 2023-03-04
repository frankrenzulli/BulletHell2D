using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiercingBullet : MonoBehaviour
{
    public float BulletVelocity = 20f;
    public Rigidbody2D rb;


    public int power;
    private int powerincrements = 10;
    private int maxPower = 200;

    float timer = 0f;
    float delay = 0.1f;
    public GameObject firepoint;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * BulletVelocity;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            timer += Time.deltaTime;
            if (timer >= delay)
            {

                power += powerincrements;
                if (power > maxPower)
                {
                    power = maxPower;
                }
                timer = 0f;
            }

        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            Debug.Log("Hai rilasciato c");
            piercingshoot();

        }
    }

    private void OnTriggerEnter2D(Collider2D HitInfo)
    {
        if (HitInfo.tag == "Enemy")
        {
            Enemy enemy = HitInfo.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(power);
                
            }
        }
        else if (HitInfo.tag == "BossShield")
        {
            gameObject.SetActive(false);
            gameObject.transform.position = firepoint.transform.position;
        }
    }

    private void OnGUI()
    {
        // Recupera la camera principale della scena
        Camera camera = Camera.main;

        // Converte la posizione dell'oggetto in coordinate schermo utilizzando la camera principale
        Vector3 screenPosition = camera.WorldToScreenPoint(transform.position);

        // Verifica se le coordinate schermo sono fuori dai limiti della finestra di gioco
        if (screenPosition.x < 0 || screenPosition.x > Screen.width || screenPosition.y < 0 || screenPosition.y > Screen.height)
        {
            gameObject.SetActive(false);
            // Se l'oggetto non è visibile nella finestra di gioco, distrugge l'oggetto
            gameObject.transform.position = firepoint.transform.position;
        }
    }
    void piercingshoot()
    {
        rb.velocity = transform.right * BulletVelocity;
        gameObject.SetActive(true);
        

    }


}
