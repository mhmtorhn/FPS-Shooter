using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Data;

public class PlayerHealth : MonoBehaviour
{
    public Image HealthBar;
    public float CurrentHealth;
    public float MaxHealth = 100f;
    CharachterMovement karakter;

    public Vector3 startPosition;

    

    void Start()
    {
        karakter = GetComponent<CharachterMovement>();
        CurrentHealth = 100f;

    }

    void Update()
    {
        CurrentHealth = karakter.Health;
        HealthBar.fillAmount = CurrentHealth / MaxHealth;
    }

    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Apple"))
        {
            CurrentHealth -= 10f;
            
        }

        if (CurrentHealth <= 0)
        {
            CurrentHealth = 100f;
            SceneManager.LoadScene("GameOver");
            
        }

      }

    }
