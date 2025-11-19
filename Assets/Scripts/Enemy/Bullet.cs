using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10;
    public GameObject shooter; // نگه داشتن کسی که شلیک کرده

    private void OnCollisionEnter(Collision collision)
    {
        // اگر گلوله به خود شلیک‌کننده بخوره، نادیده گرفته بشه
        if (collision.gameObject == shooter)
        {
            return;
        }

        Transform hitTransform = collision.transform;

        if (hitTransform.CompareTag("Player"))
        {
            Debug.Log("Hit Player");
            hitTransform.GetComponent<PlayerHealth>().TakeDamage(damage);
        }

        if (hitTransform.CompareTag("Enemy"))
        {
            hitTransform.GetComponent<EnemyHealth>().TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
