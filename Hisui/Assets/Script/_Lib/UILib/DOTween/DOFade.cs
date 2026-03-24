using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DOFade : MonoBehaviour
{
    private TextMeshPro textUgui;

    [SerializeField] private bool InitShow;

    public bool IsShowEnd { get; private set; } = false;
    void Start()
    {
        textUgui = GetComponent<TextMeshPro>();
        //コルーチンの起動　フェード
        StartCoroutine(MyLib.DelayCoroutine(4f, () =>
        {

            if (textUgui.text == "START")
            {
                transform.GetComponent<TitleEvent>().enabled = true;
            }

            IsShowEnd = true;
            if (InitShow)
                ShowWindow();


        }));

    }

    public void ShowWindow(float duration = 10f)
    {
        var color = textUgui.color;
        color.a = 255;

        textUgui.DOColor(color, duration).SetEase(Ease.InSine);

    }

    public void Skip()
    {
        if (IsShowEnd) return;
        if (textUgui.text == "START")
        {
            transform.GetComponent<TitleEvent>().enabled = true;
        }

        IsShowEnd = true;
        ShowWindow();

        textUgui.DOComplete();
    }

    private void OnDestroy()
    {
        DOTween.Kill(this.transform);
        Debug.Log(this.GetType().FullName + "Destroy");
    }
}
