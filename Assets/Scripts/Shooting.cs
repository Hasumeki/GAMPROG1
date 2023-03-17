using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject Circle;
    Vector3 offset;
    Vector3 speed;
    void Start()
    {
        Vector3 offset = new Vector3(10, 10, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //do a thing
            Instantiate(Circle, transform.position, Quaternion.identity);
          
        }
    }
}
