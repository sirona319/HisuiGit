using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class WarpUi : MonoBehaviour
{
    [SerializeField] Image wpImage;

    float wpUiMaxVal;

    [SerializeField, TooltipAttribute("ワープで消費するエネルギー")] float wpUiUseVal = 10;
    [SerializeField, TooltipAttribute("回復する速度")] float returnSpeed = .15f;
    [SerializeField, TooltipAttribute("減衰する速度")] float minusSpeed = .30f;

    // Start is called before the first frame update
    void Start()
    {
        wpUiMaxVal = wpImage.rectTransform.sizeDelta.x;

    }

    public bool EnableWarpCheck()
    {
        Vector2 size = wpImage.rectTransform.sizeDelta;
        if (size.x < wpUiUseVal)
            return false;
        else
            return true;
    }

    public float Change(int damage)
    {

        Vector2 size = wpImage.rectTransform.sizeDelta;
        size.x -= damage;
        wpImage.rectTransform.sizeDelta = size;


        return size.x;
    }
    public void Heal()
    {
        Vector2 size = wpImage.rectTransform.sizeDelta;
        if (size.x >= wpUiMaxVal) return;

        size.x += returnSpeed;

        if(size.x >= wpUiMaxVal)
        {
            size.x = wpUiMaxVal;

            wpImage.rectTransform.sizeDelta = size;
            return;
        }

        wpImage.rectTransform.sizeDelta = size;
    }


    public bool Sub()
    {
        Vector2 size = wpImage.rectTransform.sizeDelta;
        if (size.x <= 0){ return false; }

        size.x -= minusSpeed;

        wpImage.rectTransform.sizeDelta = size;

        return true;
    }

}

