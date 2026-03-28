using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class PlayerHP : MonoBehaviour
{
    const int LIMITHP=10;

    [Range(1, 10)]
    [SerializeField]public int MAXHP = 3;

    public int hp { get; private set; }
    bool IsDeadHp()
    {
        return hp <=0;
    }

    public bool IsHpMax()
    {
        return hp >= MAXHP;
    }

    [SerializeField] Image[] lifeImage;

    //PlayerScr player;

    // Start is called before the first frame update
    void Start()
    {

        //ロード処理
        //if(Save.I.isLoad)
        //{
        //    hp = PlayerPrefs.GetInt("HP", 3); ;

        //    MAXHP = PlayerPrefs.GetInt("MAX", 3); ;
        //}
        //else
        //{
        //    hp = MAXHP;
        //}




        //UpdateLife();

        //player = GameObject.FindWithTag("Player").GetComponent<PlayerScr>();

        //lifeImage = GameObject.Find("LifePanel").GetComponentsInChildren<Image>();

        for (int i = LIMITHP - 1;  i> hp - 1; i--)
        {
            if (i < hp - 1) break;

            lifeImage[i].enabled = false;
            //hp--;
        }


    }

    //HPのダメージ表現
    public void DamageLife(int damage)
    {

        int saveValue = damage;

        const float DAMAGETIME = 0.3f;

        for (int i = hp - 1/*,j = 0*/; damage > 0; damage--,i--)
        {
            if (i < 0) break;


            const float POW = 5f;
            StartCoroutine(MyLib.DoShake(DAMAGETIME, POW, lifeImage[i].transform));

        }

        //成功
        StartCoroutine(MyLib.DelayCoroutine(DAMAGETIME, () =>
        {
            DamageUpdate(saveValue);
        }));

    }

    void DamageUpdate(int damage)
    {
        for (int i = hp - 1; damage > 0; damage--,i--)
        {
            if (i < 0) break;

            lifeImage[i].enabled = false;
            hp--;
        }

        //if (!IsDeadHp()) return;
        //player.PlayerDead();
    }

    public void HealLife(int heal)
    {

        for (int i = hp; heal > 0; heal--, i++)
        {
            if (i>MAXHP-1) break;

            lifeImage[i].enabled = true;

            if(hp<MAXHP)
            hp++;

        }


    }


}
