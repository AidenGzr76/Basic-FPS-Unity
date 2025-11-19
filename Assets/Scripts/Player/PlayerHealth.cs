using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float health;
    private float lerpTimer;

    [Header("Health Bar")]
    public float maxHealth = 100;
    public float chipSpeed = 2f;
    public Image frontHealthBar;
    public Image backHealthBar;

    [Header("Damage overlay")]
    public Image overlay;
    public float duration;
    public float fadeSpeed;

    private float durationTimer;

    public AudioClip healSound;
    public AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();

        if (overlay.color.a > 0)
        {
            if (health < 30)
                return;
                
            durationTimer += Time.deltaTime;
            if (durationTimer > duration)
            {
                // fade image
                float tempAlpha = overlay.color.a - (fadeSpeed * Time.deltaTime);
                overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, tempAlpha);
            }
        }

        // if (Input.GetMouseButtonDown(0))
        // {
        //     TakeDamage(Random.Range(5, 10));
        // }
        // if (Input.GetMouseButtonDown(1))
        // {
        //     RestoreHealth(Random.Range(5, 10));
        // }
    }
    public void UpdateHealthUI()
    {
        float fillF = frontHealthBar.fillAmount;
        float fillB = backHealthBar.fillAmount;
        float hFraction = health / maxHealth;
        if (fillB > hFraction)
        {
            frontHealthBar.fillAmount = hFraction;
            backHealthBar.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            backHealthBar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
        }
        if (fillF < hFraction)
        {
            backHealthBar.fillAmount = hFraction;
            backHealthBar.color = Color.green;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            frontHealthBar.fillAmount = Mathf.Lerp(fillF, hFraction, percentComplete);
        }
    }
    public void TakeDamage(float damage)
    {
        Debug.Log("OKeyeKEEE");
        health -= damage;
        lerpTimer = 0f;
        durationTimer = 0f;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 1);

        if(health <= 0)
        {
            // Handle player death here (e.g., show game over screen, respawn, etc.)
            Debug.Log("Player Died!");
            FindFirstObjectByType<GameManager>().ShowDeathMenu();
        }
    }

    public void RestoreHealth(float healAmount)
    {
        audioSource.PlayOneShot(healSound);
        Debug.Log("inam OKeyeKEEE");
        health += healAmount;
        lerpTimer = 0f;
    }
}
