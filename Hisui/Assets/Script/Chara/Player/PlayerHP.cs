using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class PlayerHP : BaseHP
{

    [SerializeField] Image[] lifeImage;

    PlayerScr2D playerScr;

    void Start()
    {
        lifeImage.ToList().ForEach(x => x.enabled=false);
        for (int i = 0; i < lifeImage.Length; i++)
        {
            lifeImage[i].enabled = i < HP;//iがHPより小さいときはenabledをtrueにしている AI
        }

        OnHPChanged += DamageLife;

        playerScr=GetComponent<PlayerScr2D>();
    }

    //HPのダメージ表現
    public void DamageLife(int damage)
    {

        int saveValue = damage;
        const float volume = 0.3f;
        MyLib.MyPlaySound("Sound/SE/damaged1", volume, gameObject);
        playerScr.dmgTime = playerScr.dmgTimeMax;

        for (int i = HP - 1; damage > 0; damage--, i--)
        {
            if (i < 0) break;


            const float POW = 5f;
            StartCoroutine(MyLib.DoShake(playerScr.dmgTime, POW, lifeImage[i].transform));

        }

        //成功
        StartCoroutine(MyLib.DelayCoroutine(playerScr.dmgTime, () =>
        {
            DamageUpdate(saveValue);
        }));

    }


    void DamageUpdate(int damage)
    {
        for (int i = HP - 1; damage > 0; damage--,i--)
        {
            if (i < 0) break;

            lifeImage[i].enabled = false;

        }
       
    }

    //public void HealLife(int heal)
    //{

    //    for (int i = hp; heal > 0; heal--, i++)
    //    {
    //        if (i>MAXHP-1) break;

    //        lifeImage[i].enabled = true;

    //        if(hp<MAXHP)
    //        hp++;

    //    }


    //}
    //float blinkTimer = 0f;
    //void MatBlink()
    //{
    //    if (!IsDamage) return;
    //    Debug.Log("点滅");
    //    Debug.Log(pSprite);
    //    blinkTimer += Time.deltaTime;
    //    //点滅処理
    //    if (dmgTime > 0)
    //    {
    //        const float duration = 0.1f;
    //        float t = Mathf.PingPong(blinkTimer / duration, 1f);
    //        pSprite.color = Color.Lerp(startColor, endColor, t);

    //        dmgTime -= Time.deltaTime;

    //    }
    //    else
    //    {
    //        pSprite.color = startColor;
    //        IsDamage = false;
    //        blinkTimer = 0f;
    //    }
    //}

    //void MatNoise()
    //{
    //    if (!IsDamage) return;
    //    Debug.Log("ノイズ");
    //    //点滅処理
    //    if (dmgTime > 0)
    //    {
    //        GetComponent<NoiseEnable>().enabled = true;

    //        dmgTime -= Time.deltaTime;

    //    }
    //    else
    //    {
    //        GetComponent<NoiseEnable>().enabled = false;
    //        IsDamage = false;
    //    }
    //}
}
