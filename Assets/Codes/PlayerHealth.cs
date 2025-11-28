using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth = 100f;

    public void TakeDamage(float damage, Vector2 knockbackDirection, float knockbackForce)
    {
        currentHealth -= damage;
        
    }
}

