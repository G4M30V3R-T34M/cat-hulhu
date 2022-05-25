using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public delegate void NoHealthAction();
    public event NoHealthAction NoHealth;

    private int maxHealth;
    private int currentHealth;

    public void SetUp(int health) {
        maxHealth = health;
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        if (currentHealth == 0 && NoHealth != null) {
            NoHealth.Invoke();
        }
    }
}
