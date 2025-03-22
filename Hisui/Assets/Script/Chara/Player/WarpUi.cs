using UnityEngine;
using UnityEngine.UI;

public class WarpUi : MonoBehaviour
{
    [SerializeField] Image hpImage;
    //private TextMeshProUGUI hpNum;
    //bool isUse = false;
    //bool UseCheck  
    //{  
    //    get { return isUse; }  
    //}
    //const float changeColorSpeed = 100f;

    float wpUiMaxVal;

    [SerializeField, TooltipAttribute("ワープで消費するエネルギー")] float wpUiUseVal = 10;
    [SerializeField, TooltipAttribute("回復する速度")] float returnSpeed = .15f;
    [SerializeField, TooltipAttribute("減衰する速度")] float minusSpeed = .30f;

    // Start is called before the first frame update
    void Start()
    {
        wpUiMaxVal = hpImage.rectTransform.sizeDelta.x;

        //Debug.Log(hpImage.rectTransform.sizeDelta.x);
        //hpImage=GameObject.Find("HpImage").GetComponent<Image>();
        //hpNum=GameObject.Find("HpNum").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        //カラーRを増やす　Gを減らす
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    ChangeHp(10);
        //}

       // WarpHeal();
    }

    public bool EnableWarpCheck()
    {
        Vector2 size = hpImage.rectTransform.sizeDelta;
        if (size.x < wpUiUseVal)
            return false;
        else
            return true;
    }

    public float Change(int damage)
    {
        //if (isDead) return 0;

        Vector2 size = hpImage.rectTransform.sizeDelta;
        size.x -= damage;
        hpImage.rectTransform.sizeDelta = size;


        //if (size.x <= 0)
        //{
        //    //hpNum.text = "0%";
        //    //isUse = false;
        //}
        //else
        //{
        //    //hpNum.text = size.x.ToString() + "%";
        //}

        //Color hpColor = hpImage.color;
        //hpColor.g += damage / changeColorSpeed;
        //hpImage.color = hpColor;


        return size.x;
    }
    public void Heal()
    {
        Vector2 size = hpImage.rectTransform.sizeDelta;
        if (size.x >= wpUiMaxVal) return;


        //Color hpHealColor = hpImage.color;
        //hpHealColor.g -= returnSpeed + size.x / wpUiMaxVal;
        //if (hpHealColor.g <= 0) hpHealColor.g = 0;
        //hpImage.color = hpHealColor;

        size.x += returnSpeed;

        if(size.x >= wpUiMaxVal)
        {
            size.x = wpUiMaxVal;

            //Color hpColor = hpImage.color;
            //hpColor.r = 0;
            //hpImage.color = hpColor;

            hpImage.rectTransform.sizeDelta = size;
            return;
        }

        hpImage.rectTransform.sizeDelta = size;
    }


    public bool Sub()
    {
        Vector2 size = hpImage.rectTransform.sizeDelta;
        if (size.x <= 0){ return false; }

        size.x -= minusSpeed;

        hpImage.rectTransform.sizeDelta = size;

        return true;
    }

}

