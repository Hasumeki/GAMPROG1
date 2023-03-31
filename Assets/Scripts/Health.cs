using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public Slider slider;
    public float maxHealth;
    private float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
       if(currentHealth < 1)
        {
            this.gameObject.SetActive(false);
        }
            
    }

    public void takeDamage(float Damage)
    {
        currentHealth = currentHealth - Damage;
        slider.value = currentHealth;
    }
  
}
