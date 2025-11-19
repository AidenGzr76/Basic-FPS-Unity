using UnityEngine;

public class FirstAid : MonoBehaviour
{
    // public AudioClip healSound;
    // public AudioSource audioSource;

    public GameObject healTextPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyAid()
    {
        // Instantiate متن در محل فعلی
        Instantiate(healTextPrefab, gameObject.transform.position - Camera.main.transform.forward * 0.3f, Quaternion.LookRotation(Camera.main.transform.forward));
        // audioSource.PlayOneShot(healSound);
        Destroy(gameObject);
    }
}
