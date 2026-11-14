using DG.Tweening;
using TMPro;
using UnityEngine;

public class DOFadeText : MonoBehaviour
{

    //TextMeshProUGUIはCanvas用
    TextMeshProUGUI textUgui;

    [Range(0, 100f)]
    [SerializeField] float duration = 1f;
    [SerializeField] Ease easeType;

    [Range(0,1f)]
    [SerializeField] float targetAlpha = 1f;

    [SerializeField] bool isStart = true;

     bool IsShowEnd = false;
    void Start()
    {
        textUgui = GetComponent<TextMeshProUGUI>();
        //コルーチンの起動　フェード
        //StartCoroutine(MyLib.DelayCoroutine(4f, () =>
        //{

        //    //if (textUgui.text == "START")
        //   // {
        //   //     transform.GetComponent<TitleEvent>().enabled = true;
        //   // }

        //    IsShowEnd = true;
         if(isStart)
            ShowWindow();


        //}));

    }

    public void ShowWindow()
    {
        var color = textUgui.color;
        color.a = targetAlpha;

        textUgui.DOColor(color, duration)
            .SetEase(easeType)
            .SetLink(gameObject)
            .OnComplete(() => {
                this.enabled = false;
                IsShowEnd = true;



            });

            
    }

    public void Skip()
    {
        if (IsShowEnd) return;

        IsShowEnd = true;
        ShowWindow();

        textUgui.DOComplete();

        this.enabled = false;
    }

    //private void OnDestroy()
    //{
    //    DOTween.Kill(this.transform);
    //    Debug.Log(this.GetType().FullName + "Destroy");
    //}
}
