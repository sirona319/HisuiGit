using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Drawing;
using Color = UnityEngine.Color;

public class HPUIControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int MAXHP;

    [SerializeField] int hp;

    [SerializeField] GameObject HPUI;

    Slider hpSlider;

    [SerializeField] bool isChangeColorMode;
    [SerializeField] Material fillMat;
    float changeColorValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        hp = MAXHP;
        hpSlider = HPUI.transform.Find("HPBar").GetComponent<Slider>();
        hpSlider.value = MAXHP;


        if (isChangeColorMode)
        {
            //const float intensity = 1f;
            //var color = Color.green * intensity;
            fillMat.SetColor("_EmissionColor", Color.green);
        }

    }

    // Update is called once per frame
    //void Update()
    //{

    //}

    public void SetHp(int hp)
    {
        if (isChangeColorMode)
        {
            const float intensity = 3f;
            const float changeAdd = 1.5f;
            changeColorValue += ((this.hp - hp) * changeAdd) / 100f;

            //1‚ð’´‚¦‚é‚ÆUI‚Ì–¾‚é‚³‚ª•Ï‚í‚Á‚Ä‚µ‚Ü‚¤‚½‚ßŽ~‚ß‚é
            if (changeColorValue > 1)
                changeColorValue = 1f;

            var color = new Color(changeColorValue, 1 - changeColorValue, 0, 1);
            fillMat.SetColor("_EmissionColor", color * intensity);
        }

        this.hp = hp;
        UpdateHPValue();

        //if (hp <= 0)
        //{
        //    HideStatusUI();
        //}
    }
    public int GetHp()
    {
        return hp;
    }

    public int GetMaxHp()
    {
        return MAXHP;
    }

    //@Ž€‚ñ‚¾‚çHPUI‚ð”ñ•\Ž¦‚É‚·‚é
    public void HideStatusUI()
    {
        HPUI.SetActive(false);
    }

    public void UpdateHPValue()
    {

        hpSlider.DOValue(((float)GetHp() / (float)GetMaxHp()), 1f);


    }
}
