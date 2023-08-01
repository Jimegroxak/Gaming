using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] public Image healthbar;

    private const int MAX_HEALTH = 1000;
    private int health;
    // Start is called before the first frame update
    private void Start() 
    {
        health = MAX_HEALTH;  
        healthbar.fillAmount = health / MAX_HEALTH;  
    }

    private void Update() 
    {
        CheckHealth();    
    }

    public void SetHealth(int damage)
    {
        health -= damage;
        if (health <= MAX_HEALTH)
        {
            healthbar.fillAmount = (float)health / MAX_HEALTH;
        }
    }

    private void CheckHealth()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
