using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform SpawnPoint;
    [SerializeField] private Transform PlayerPoint;
    [SerializeField] public float fireRate = 1.0f;
    public GameObject Circle;
    public GameObject Beer;
    public float horizontal;
    public float timer = 0.0f;
  private  bool CanShoot = true;


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (CanShoot)
        {
            ShootBeer();
            ShootFire();
        }
  
           Reset();
    }
    void ShootFire()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //do a thing
            GameObject ProjInstance = Instantiate(Circle, transform.position, Quaternion.identity);

            if (transform.root.localScale.x < 0)
            {
                horizontal = -1;
            }
            else
                horizontal = 1;
            ProjInstance.GetComponent<Rigidbody2D>().velocity = new Vector3(15 * horizontal, 10, 0);
            CanShoot = false;
        }
    }
    void ShootBeer()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            //do a thing
            GameObject ProjInstance = Instantiate(Beer, transform.position, Quaternion.identity);
            if (transform.root.localScale.x < 0)
            {
                horizontal = -1;
            }
            else
                horizontal = 1;
            ProjInstance.GetComponent<Rigidbody2D>().velocity = new Vector3(50.0f * horizontal, 0, 0);
            CanShoot = false;
        }
       
    }
    void Reset()
    {
        if(timer > fireRate)
        {
            timer = 0.0f;
            CanShoot = true;
        }
    }
}

