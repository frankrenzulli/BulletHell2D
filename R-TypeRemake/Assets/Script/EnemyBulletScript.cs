using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Rigidbody2D rb;
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
        PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
        if (collision.tag == "Player" && player.immunity == false)
        {
            if(player != null)
            {
                player.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        if (collision.tag == "immunityAura")
        {
            Destroy(gameObject);
        }

        
    }
}
