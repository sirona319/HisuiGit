using DG.Tweening;
using TMPro;
using UnityEngine;


//Canvasに配置するWorldSpace　HPの変化を表示するUI　テキストはDOFadeでフェードアウトさせる　
public class DOChangeHpUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textUI;

    void Start()
    {
        textUI.DOFade(0, 0);

    }

    void LateUpdate()
    {
        transform.rotation = Camera.main.transform.rotation;
    }


    public void DamegeView(int val)
    {
        //赤
        textUI.color = new Color(1, 0, 0, 1);
        textUI.text = "-" + val.ToString();

        textUI.DOFade(1, 0f);
        textUI.DOFade(0, 1f);

    }

    public void HealView(int val)
    {
        //緑
        textUI.color = new Color(0, 1, 0, 1);

        textUI.text = "+" + val.ToString();

        textUI.DOFade(1, 0f);
        textUI.DOFade(0, 1f);

    }
}
