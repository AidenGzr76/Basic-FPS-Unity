using TMPro;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public float floatSpeed = 0.5f;
    public float fadeDuration = 1.5f;
    private TextMeshPro textMesh;
    private float timer;

    void Start()
    {
        textMesh = GetComponent<TextMeshPro>();
    }

    void Update()
    {
        transform.position += Vector3.up * floatSpeed * Time.deltaTime;

        timer += Time.deltaTime;
        float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);

        textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, alpha);

        if (timer >= fadeDuration)
        {
            Destroy(gameObject);
        }
    }
}