using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class ChargedBullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    public int damage = 80;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            
        }
        else if (collision.tag == "BossShield")
        {
            Destroy(gameObject);
        }
        if (collision.tag == "boss")
        {
            Boss bosshealth = collision.GetComponent<Boss>();
            if (bosshealth != null)
            {
                bosshealth.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
    private void OnGUI()
    {
        
        Camera camera = Camera.main;
        Vector3 screenPosition = camera.WorldToScreenPoint(transform.position);
        if (screenPosition.x < 0 || screenPosition.x > Screen.width || screenPosition.y < 0 || screenPosition.y > Screen.height)
        {
            Destroy(gameObject);
        }
    }
}
