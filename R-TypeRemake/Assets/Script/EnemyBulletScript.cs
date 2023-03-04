using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force;
    public int damage;
   


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector2 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
    }


    // Update is called once per frame
    void Update()
    {

        Vector3 screenPos = Camera.main.WorldToViewportPoint(transform.position);
        if (screenPos.x < 0f)
        {
            // distruggi l'oggetto
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerMovement playerhealth = collision.gameObject.GetComponent<PlayerMovement>();
            if(playerhealth != null)
            {
                playerhealth.TakeDamage(damage);
            }
            Destroy(gameObject);
        }

        
    }
}
