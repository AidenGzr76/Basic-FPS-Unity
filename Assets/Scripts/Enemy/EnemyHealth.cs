using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public Slider healthBar; // نوار سلامت بالای دشمن
    public Transform healthBarTransform; // نگه‌دارنده‌ی نوار سلامت

    public Animator enemyAnimator; // بهتره اسم جداگانه بذاریم برای وضوح

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;

        enemyAnimator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        // چرخش نوار سلامت به سمت دوربین
        if (healthBarTransform != null)
        {
            healthBarTransform.LookAt(Camera.main.transform);
        }
    }
    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.value = currentHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy Died!");
        enemyAnimator.SetBool("Killed", true); // انیمیشن مرگ رو فعال کن
        StartCoroutine(DestroyAfterDelay());  // بعد از چند ثانیه حذف بشه
    }

    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(5f);  // مثلا ۵ ثانیه بعد
        enemyAnimator.SetBool("Killed", false);
        Destroy(gameObject);
    }
}
