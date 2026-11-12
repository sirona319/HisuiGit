using DG.Tweening;
using TMPro;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class DOFadeText : MonoBehaviour
{

    //TextMeshProUGUIはCanvas用
    TextMeshProUGUI textUgui;

    [Range(0, 100f)]
    [SerializeField] float duration = 1f;
    [SerializeField] Ease easeType;

    [Range(0,255f)]
    [SerializeField] float targetAlpha = 255f;

    [SerializeField] bool isStart = true;

    //public bool IsShowEnd { get; private set; } = false;
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

    void ShowWindow()
    {
        var color = textUgui.color;
        color.a = targetAlpha;

        textUgui.DOColor(color, duration).SetEase(easeType);

    }

    //public void Skip()
    //{
    //    if (IsShowEnd) return;

    //    IsShowEnd = true;
    //    ShowWindow();

    //    textUgui.DOComplete();
    //}

    private void OnDestroy()
    {
        DOTween.Kill(this.transform);
        Debug.Log(this.GetType().FullName + "Destroy");
    }
}
