using UnityEngine;
using UnityEngine.UI;

public class BlinkSpriteMod : MonoBehaviour
{
    //点滅処理
    [SerializeField] float duration = 0.07f;
    Color32 startColor = new(255, 255, 255, 255);
    Color32 endColor = new(255, 255, 255, 0);

    //画像
    [SerializeField] SpriteRenderer sprite;
    bool isEnable = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        startColor = sprite.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnable)
            sprite.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time / duration, 1f));
    }

    private void OnEnable()
    {
        isEnable = true;
    }

    private void OnDisable()
    {
        isEnable = false;
        sprite.color = startColor;
    }

    //public void BlinkOff()
    //{
    //    isEnable = false;
    //    Image.color = startColor;
    //}
}
