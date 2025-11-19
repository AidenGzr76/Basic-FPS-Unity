using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerShoot : Gun
{
    // public GameObject bulletPrefab;
    public Transform gunBarrel; // محل خروج گلوله
    public float bulletSpeed = 60f; // سرعت گلوله
    public float spread = 3f; // پخش شدن گلوله

    public int maxAmmo = 30;
    public int currentAmmo;


    public Animator gunAnimator; // تنظیمش از Inspector

    public AudioSource audioSource;   // منبع پخش صدا
    public AudioClip shootSound;      // صدای شلیک
    public AudioClip reloadSound;     // صدای تعویض خشاب

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && currentAmmo < maxAmmo)
        {
            Reload();
        }


        if (Input.GetMouseButtonDown(0)) // وقتی کلیک شد
        {
            Shoot();
        }
        else
        {
            gunAnimator.SetBool("isShooting", false); // وقتی شلیک نمیکنیم انیمیشن رو متوقف میکنیم
        }
    }

    public void Shoot()
    {
        if (currentAmmo > 0)
        {
            audioSource.PlayOneShot(shootSound);

            currentAmmo--;
            UpdateAmmoUI();
            
            // تیراندازی انجام بده
            gunAnimator.SetBool("isShooting", true);
            // gunAnimator.SetTrigger("Shoot");

            GameObject bullet = Instantiate(Resources.Load("Prefabs/Bullet") as GameObject, gunBarrel.position, transform.rotation);
            bullet.GetComponent<Bullet>().shooter = gameObject; // تنظیم بازیکن به عنوان شلیک‌کننده
            // محاسبه جهت شلیک (همون چیزی که برای دشمن داشتی)
            Vector3 shootDirection = (Camera.main.transform.forward).normalized;
            bullet.GetComponent<Rigidbody>().linearVelocity = Quaternion.AngleAxis(Random.Range(-spread, spread), Vector3.up) * shootDirection * bulletSpeed;
        }
        else
        {
            ShowReloadMessage(); // اگه تیر تموم شد پیام بده
        }
    }


    public TMP_Text ammoText;

    void UpdateAmmoUI()
    {
        ammoText.text = currentAmmo.ToString();
        // gunAnimator.SetBool("Reloading", false);
    }


    public GameObject reloadMessage;

    void ShowReloadMessage()
    {
        reloadMessage.SetActive(true);
        // reloadMessage.text = "Press R to Reload";
    }

    void HideReloadMessage()
    {
        reloadMessage.SetActive(false);
        // reloadMessage.text = "";
    }

    // public Animator gunAnimator;

    void Reload()
    {
        if (currentAmmo < maxAmmo)
        {
            // gunAnimator.SetTrigger("Shoot");
            gunAnimator.SetBool("Reloading", true);
            HideReloadMessage();
            StartCoroutine(ReloadDelay());
        }
        // else
        // {
        //     gunAnimator.SetBool("Reloading", false);
        // }
    }

    IEnumerator ReloadDelay()
    {
        // gunAnimator.SetBool("Reloading", false);
        yield return new WaitForSeconds(1.0f); // مدت زمان انیمیشن Reload
        audioSource.PlayOneShot(reloadSound);
        gunAnimator.SetBool("Reloading", false);
        currentAmmo = maxAmmo;
        UpdateAmmoUI();
    }

}