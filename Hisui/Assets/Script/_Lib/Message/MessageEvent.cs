using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class MessageEvent : MonoBehaviour
{
    const float fadeSpeed = 1;
    Image textBackImage;
    Image readIcon;
    TextMeshProUGUI messageUI;

    private void Start()
    {
        var me = GameObject.FindGameObjectWithTag("Message");
        if (me == null) return;
        
        textBackImage = me.GetComponent<Image>();
        readIcon = me.transform.Find("ReadImage").GetComponent<Image>();
        messageUI = me.transform.Find("TalkText").GetComponent<TextMeshProUGUI>();
        

    }

    #region　アニメーションイベント

    public void MessageStart()
    {

        messageUI.enabled = true;
        readIcon.enabled = true;
        textBackImage.enabled = true;



        var mColor= messageUI.color;
        mColor.a = 1f;
        messageUI.DOColor(mColor, fadeSpeed).SetEase(Ease.Linear);

        const float targetAlpha = 0.7f;
        var tColor = textBackImage.color;
        tColor.a = targetAlpha;
        //endValue　フェード目標カラー
        textBackImage.DOColor(tColor, fadeSpeed).SetEase(Ease.Linear);
        Debug.Log("メッセージ開始" + GetType().FullName);
    }

    public void MessageEnd()
    {

        //messageUI.enabled = false;
        readIcon.enabled = false;



        var mColor = messageUI.color;
        mColor.a = 0f;
        //テキストフェードアウト
        messageUI.DOColor(mColor, fadeSpeed).SetEase(Ease.Linear);

        const float targetAlpha = 0;
        var tColor = textBackImage.color;
        tColor.a = targetAlpha;
        //endValue　フェード目標カラー
        textBackImage.DOColor(tColor, fadeSpeed).SetEase(Ease.Linear);


        Debug.Log("メッセージ終了" + GetType().FullName);
         

    }

    #endregion
}
