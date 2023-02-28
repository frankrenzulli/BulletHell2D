using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float BulletVelocity = 20f;
    public Rigidbody2D rb;
    public int damage = 30;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * BulletVelocity;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D HitInfo)
    {
        if (HitInfo.tag == "Enemy")
        {
            Enemy enemy = HitInfo.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            Destroy(gameObject);
        }else if( HitInfo.tag == "BossShield")
        {
            Destroy(gameObject);
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
            // Se l'oggetto non è visibile nella finestra di gioco, distrugge l'oggetto
            Destroy(gameObject);
        }
    }
}
