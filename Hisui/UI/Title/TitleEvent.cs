using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//using static System.Net.Mime.MediaTypeNames;
//using Image = UnityEngine.UI.Image;

public class TitleEvent : MonoBehaviour
{
    [SerializeField]private GManager.SceneNameType sceneName;

    [SerializeField] private TextMeshProUGUI textMeshPro;

    //[SerializeField] private Image img;

    //[SerializeField] private bool m_islight;

    //private const float duration = 1.0f;

   // private Color32 textStartColor;

   // private Color32 textEndColor;

   // private Color32 imgStartColor;

    //private Color32 imgEndColor;

    [System.Obsolete]
    void Start()
    {
        //textMeshPro = textMeshPro != null ? textMeshPro : GetComponent<TextMeshProUGUI>();

        //img = img != null ? img : GetComponent<Image>();

        if (textMeshPro == null)
            textMeshPro = GetComponent<TextMeshProUGUI>();

        //if (img == null)
        //    img = GetComponent<Image>();


        ////テキスト色情報の保存
        //if (textMeshPro != null)
        //{
        //    textStartColor = textMeshPro.color;
        //    textEndColor = textMeshPro.color;
        //    textEndColor.a = 64;
        //}

        ////画像色情報の保存
        //if (img != null)
        //{
        //    imgStartColor = img.color;
        //    imgEndColor = img.color;
        //    imgEndColor.a = 64;
        //}


        var clickEvent = new EventTrigger.Entry { eventID = EventTriggerType.PointerClick };
       // var enterEvent = new EventTrigger.Entry { eventID = EventTriggerType.PointerEnter };
       // //var exitEvent = new EventTrigger.Entry { eventID = EventTriggerType.PointerExit };

        clickEvent.callback.AddListener((eventData) => { GManager.I.SceneChangeUseSoundTitle(sceneName.ToString()); });
        //clickEvent.callback.AddListener((eventData) => { TitleControl.I.MoveSelect(); });
        // enterEvent.callback.AddListener((eventData) => { PointerEnter(); });
        // exitEvent.callback.AddListener((eventData) => { PointerExit();});

        var trigger = GetComponent<EventTrigger>();
        trigger.triggers.Add(clickEvent);
       // trigger.triggers.Add(enterEvent);
       // trigger.triggers.Add(exitEvent);
    }

    // Update is called once per frame
    //void Update()
    //{
    //    //if (m_islight)
    //    //{
    //    //    //https://johobase.com/csharp-null-operator/
    //    //    //「someObject.SomeProperty == null」が条件を判断する式になります。「?」の後の値（式）が条件を満たす場合に、
    //    //    //「:」の後の値（式）が条件を満たさない場合に返す値（式）になります。
    //    //    //textMeshPro.color = textMeshPro? Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time / duration, 1.0f)) : Color.yellow;


    //    //    if (textMeshPro != null)
    //    //    {
    //    //        textMeshPro.color = Color.Lerp(textStartColor, textEndColor, Mathf.PingPong(Time.time / duration, 1.0f));
    //    //    }

    //    //    if (img!=null)
    //    //    {
    //    //        img.color = Color.Lerp(imgStartColor, imgEndColor, Mathf.PingPong(Time.time / duration, 1.0f));
    //    //    }
    //    //}

    //    //img.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time / duration, 1.0f));
    //}

    //void PointerEnter()
    //{
    //    transform.DOScale(1.2f, 0.24f).SetEase(Ease.OutCubic).SetLink(gameObject);
    //    //image.color = new Color(1f, 0f, 0f);
    //    textMeshPro.color = Color.yellow;
    //}

    //void PointerExit()
    //{
    //    transform.DOScale(1f, 0.24f).SetEase(Ease.OutCubic).SetLink(gameObject);
    //    //image.color = new Color(1f, 0f, 0f);
    //    textMeshPro.color = textStartColor;
    //}

}
