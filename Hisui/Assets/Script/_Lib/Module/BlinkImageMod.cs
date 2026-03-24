using UnityEngine;
using UnityEngine.UI;

public class BlinkImageMod : MonoBehaviour
{
    //点滅処理
    [SerializeField] float duration = 0.07f;
    Color32 startColor = new(255, 255, 255, 255);
    Color32 endColor = new(255, 255, 255, 0);

    //画像
    [SerializeField] Image Image;
    bool isEnable = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startColor = Image.color;
    }

    // Update is called once per frame
    void Update()
    {
        if(isEnable)
            Image.color =Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time / duration, 1f));
    }

    private void OnEnable()
    {
        isEnable = true;
    }

    private void OnDisable()
    {
        isEnable = false;
        Image.color = startColor;
    }

    //public void BlinkOff()
    //{
    //    isEnable = false;
    //    Image.color = startColor;
    //}
}
