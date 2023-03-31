using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile1 : MonoBehaviour
{
    Health health;
    public Rigidbody2D rb;
    [SerializeField] float lifetime = 5.0f;
    [SerializeField] float damage = 25.0f;
    float life = 0;
    bool flip = false;
  
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    void Update()
    {
      life += Time.deltaTime;
        if(life >= lifetime)
        {
            Destroy(gameObject, 1);
        }
        if(rb.velocity.x < 0 && !flip)
        {
            this.transform.localScale = new Vector3(this.transform.localScale.x * -1, this.transform.localScale.y, this.transform.localScale.z);
            flip = true;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject other = collision.gameObject;
        Destroy(gameObject);
        if (other.gameObject.layer == 6)
        {
            health = other.GetComponent<Health>();
            health.takeDamage(damage);
        }
    }
}
