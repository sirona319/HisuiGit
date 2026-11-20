using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class BossHP : BaseHP
{

    //[SerializeField] Image[] lifeImage;

    //BaseDmg dmg;

    //void Start()
    //{
    //    for (int i = 0; i < lifeImage.Length; i++)
    //    {
    //        lifeImage[i].enabled = i < HP;//iがHPより小さいときはenabledをtrueにしている AI
    //    }

    //    OnHPChanged += DamageLife;

    //    dmg = GetComponent<BaseDmg>();
    //}

    ////HPのダメージ表現
    //public void DamageLife(int damage)
    //{

    //    int saveValue = damage;
    //    const float volume = 0.3f;
    //    MyLib.MyPlaySound("Sound/SE/damaged1", volume, gameObject);
    //    // bossDamage.dmgTime = bossDamage.dmgTimeMax;

    //    for (int i = HP; i >= 0 && damage > 0; i--, damage--)
    //    {
    //        if (i >= lifeImage.Length || lifeImage[i] == null)
    //            continue;


    //        const float POW = 5f;
    //        StartCoroutine(MyLib.DoShake(dmg.dmgTime, POW, lifeImage[i].transform));

    //    }

    //    //成功
    //    StartCoroutine(MyLib.DelayCoroutine(dmg.dmgTime, () =>
    //    {
    //        DamageUpdate(saveValue);
    //    }));

    //}


    //void DamageUpdate(int damage)
    //{
    //    for (int i = HP; i >= 0 && damage > 0; i--, damage--)
    //    {
    //        if (i >= lifeImage.Length || lifeImage[i] == null)
    //            continue;

    //        lifeImage[i].enabled = false;
    //    }

    //}


}
