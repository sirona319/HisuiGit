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
        //if (isDead) return 0;

        Vector2 size = wpImage.rectTransform.sizeDelta;
        size.x -= damage;
        wpImage.rectTransform.sizeDelta = size;


        //if (size.x <= 0)
        //{
        //    //hpNum.text = "0%";
        //    //isUse = false;
        //}
        //else
        //{
        //    //hpNum.text = size.x.ToString() + "%";
        //}

        //Color hpColor = wpImage.color;
        //hpColor.g += damage / changeColorSpeed;
        //wpImage.color = hpColor;


        return size.x;
    }
    public void Heal()
    {
        Vector2 size = wpImage.rectTransform.sizeDelta;
        if (size.x >= wpUiMaxVal) return;


        //Color hpHealColor = wpImage.color;
        //hpHealColor.g -= returnSpeed + size.x / wpUiMaxVal;
        //if (hpHealColor.g <= 0) hpHealColor.g = 0;
        //wpImage.color = hpHealColor;

        size.x += returnSpeed;

        if(size.x >= wpUiMaxVal)
        {
            size.x = wpUiMaxVal;

            //Color hpColor = wpImage.color;
            //hpColor.r = 0;
            //wpImage.color = hpColor;

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

