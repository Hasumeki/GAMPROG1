using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile1 : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] float lifetime = 5.0f;
    float life = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(15, 5, 0);
    }
    void Update()
    {
      life += Time.deltaTime;
        if(life >= lifetime)
        {
            Destroy(gameObject, 1);
        }
    }
    void OnCollisionEnter2D()
    {
        Destroy(gameObject);
    }
}
