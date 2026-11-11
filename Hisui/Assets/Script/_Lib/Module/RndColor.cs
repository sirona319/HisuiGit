//using UnityEngine;

//public class RndColor : MonoBehaviour
//{
//    [Header("色相 (Hue)")]
//    [Range(0f, 1f)]
//    [SerializeField] private float minHue = 0f;
//    [Range(0f, 1f)]
//    [SerializeField] private float maxHue = 1f;

//    [Header("彩度 (Saturation)")]
//    [Range(0f, 1f)]
//    [SerializeField] private float minSaturation = 0.5f;
//    [Range(0f, 1f)]
//    [SerializeField] private float maxSaturation = 1f;

//    [Header("明度 (Value)")]
//    [Range(0f, 1f)]
//    [SerializeField] private float minValue = 0.5f;
//    [Range(0f, 1f)]
//    [SerializeField] private float maxValue = 0.8f;

//    [Header("透明度 (Alpha)")]
//    [Range(0f, 1f)]
//    [SerializeField] private float minAlpha = 1f;
//    [Range(0f, 1f)]
//    [SerializeField] private float maxAlpha = 1f;

//    private SpriteRenderer spriteRenderer;

//    void Start()
//    {
//        spriteRenderer = GetComponent<SpriteRenderer>();
//        spriteRenderer.color = GetRandomColor();
//    }

//    private Color GetRandomColor()
//    {
//        float h = Random.Range(minHue, maxHue);
//        float s = Random.Range(minSaturation, maxSaturation);
//        float v = Random.Range(minValue, maxValue);
//        float a = Random.Range(minAlpha, maxAlpha);

//        Color color = Color.HSVToRGB(h, s, v);
//        color.a = a;

//        return color;
//    }
//}


using UnityEngine;

public class RndColor : MonoBehaviour
{
    [Header("色相 (Hue)")]
    [Range(0f, 1f)]
    [SerializeField] private float minHue = 0f;
    [Range(0f, 1f)]
    [SerializeField] private float maxHue = 1f;

    [Header("彩度 (Saturation)")]
    [Range(0f, 1f)]
    [SerializeField] private float minSaturation = 0.6f;
    [Range(0f, 1f)]
    [SerializeField] private float maxSaturation = 1f;

    [Tooltip("BLOOM 適用")]
    [Header("明度 (Value)")]
    [SerializeField] private float minValue = 1.5f;
    [Tooltip("BLOOM 適用")]
    [SerializeField] private float maxValue = 3f;

    [Header("透明度 (Alpha)")]
    [Range(0f, 1f)]
    [SerializeField] private float minAlpha = 0.8f;
    [Range(0f, 1f)]
    [SerializeField] private float maxAlpha = 1f;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = GetRandomColor();
    }

    private Color GetRandomColor()
    {
        float h = Random.Range(minHue, maxHue);
        float s = Random.Range(minSaturation, maxSaturation);
        float v = Random.Range(minValue, maxValue);
        float a = Random.Range(minAlpha, maxAlpha);

        Color color = Color.HSVToRGB(h, s, 1f, true) * v;
        color.a = a;

        return color;
    }
}