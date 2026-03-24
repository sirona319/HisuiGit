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
        if (me != null)
        {
            textBackImage = me.GetComponent<Image>();
            readIcon = me.transform.Find("ReadImage").GetComponent<Image>();
            messageUI = me.transform.Find("TalkText").GetComponent<TextMeshProUGUI>();
        }

        //var test = GetComponent<SignalReceiver>();
        ///////////////デバッグ
        //messageUI.enabled = true;
        //readIcon.enabled = true;
        //textBackImage.enabled = true;

        //var p = GameObject.FindGameObjectWithTag(TagName.Player);
        //if (p != null)
        //    p.GetComponent<PlayerMove>().MoveStop();


        //const float targetAlpha = 0.7f;
        //var tColor = textBackImage.color;
        //tColor.a = targetAlpha;

        ////endValue　フェード目標カラー
        //textBackImage.DOColor(tColor, fadeSpeed).SetEase(Ease.Linear);
        ///////////////

    }

    #region　アニメーションイベント

    public void MessageStart()
    {

        messageUI.enabled = true;
        readIcon.enabled = true;
        textBackImage.enabled = true;

        //var p = GameObject.FindGameObjectWithTag("Player");
        //if (p != null)
        //    p.GetComponent<PlayerMove>().MoveStop();


        const float targetAlpha = 0.7f;
        var tColor = textBackImage.color;
        tColor.a = targetAlpha;

        //endValue　フェード目標カラー
        textBackImage.DOColor(tColor, fadeSpeed).SetEase(Ease.Linear);
        
    }

    public void MessageEnd()
    {

        
        messageUI.enabled = false;
        readIcon.enabled = false;


        const float targetAlpha = 0;
        var tColor = textBackImage.color;
        tColor.a = targetAlpha;

        //endValue　フェード目標カラー
        textBackImage.DOColor(tColor, fadeSpeed).SetEase(Ease.Linear);

        //プレイヤーの移動制限解除
        //if (GameObject.FindGameObjectWithTag("Player") != null)
        //    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>().MoveActive();

        //p.isLimitMove = false;
        //p.moveSpeed = p.maxMoveSpeed;
        Debug.Log("メッセージ終了" + GetType().FullName);
         

    }

    #endregion
}
