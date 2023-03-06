using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed = 5;

    private void Update()
    {
        Movement();
    }

    void Die()
    {
        Destroy(gameObject);
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    void Movement()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        Vector3 screenPos = Camera.main.WorldToViewportPoint(transform.position);
        if (screenPos.x < 0f)
        {
            // distruggi l'oggetto
            Destroy(gameObject);
        }
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
