using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private float invincibilityDuration = 1f;
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private TextMeshProUGUI healthText;

    private int currentHealth;
    private bool isInvincible = false;
    private float invincibilityTimer = 0f;
    private bool isDead = false;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Start()
    {
        UpdateHealthText();
    }

    private void Update()
    {
        if (isInvincible)
        {
            invincibilityTimer -= Time.deltaTime;
            if (invincibilityTimer <= 0f)
            {
                isInvincible = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }
    }

    private void TakeDamage(int amount)
    {
        if (isInvincible || isDead) return;

        currentHealth -= amount;
        UpdateHealthText();

        isInvincible = true;
        invincibilityTimer = invincibilityDuration;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        Respawn();
    }

    private void Respawn()
    {
        transform.position = respawnPoint.position;
        currentHealth = maxHealth;
        isDead = false;
        UpdateHealthText();
    }

    private void UpdateHealthText()
    {
        healthText.text = "Health: " + currentHealth;
    }
}