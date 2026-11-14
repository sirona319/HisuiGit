using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class PlayerHP : MonoBehaviour
{
    int LIMITHP=10;

    [Range(1, 10)]
    [SerializeField]int MAXHP = 3;

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

    //点滅処理
    [SerializeField]SpriteRenderer pSprite;

    Color32 startColor = new(255, 255, 255, 255);
    Color32 endColor = new(255, 255, 255, 0);

    [SerializeField] float damageTimeMax = 1f;
    [SerializeField] float damageTime = 0;
    public bool IsDamage { get; set; } = false;

    // Start is called before the first frame update
    void Start()
    {
       // pSprite = GetComponent<SpriteRenderer>();
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


        hp = MAXHP;
        for (int i = LIMITHP - 1; i > hp - 1; i--)
        {
            if (i < hp - 1) break;

            lifeImage[i].enabled = false;

        }


    }

    void Update()
    {
        //float t = Mathf.PingPong(Time.time * 5f, 1f);
        //pSprite.color = Color.Lerp(startColor, endColor, t);

        MatBlink();
        //MatNoise();
    }

    //HPのダメージ表現
    public void DamageLife(int damage)
    {

        int saveValue = damage;
        const float volume = 0.3f;
        MyLib.MyPlaySound("Sound/SE/damaged1", volume, gameObject);

        IsDamage = true;
        damageTime = damageTimeMax;
        blinkTimer = 0f;

        for (int i = hp - 1/*,j = 0*/; damage > 0; damage--, i--)
        {
            if (i < 0) break;


            const float POW = 5f;
            StartCoroutine(MyLib.DoShake(damageTime, POW, lifeImage[i].transform));

        }

        //成功
        StartCoroutine(MyLib.DelayCoroutine(damageTime, () =>
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

        if (!IsDeadHp()) return;

        GameObject.FindWithTag("GameMgr").GetComponent<GameMgr>().GameEnd(false);

        Destroy(this.gameObject);
            //GetComponent<PlayerScr2D>().enabled = false;
            //GetComponent<NoiseEnable>().enabled = true;

        
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
    float blinkTimer = 0f;
    void MatBlink()
    {
        if (!IsDamage) return;
        Debug.Log("点滅");
        Debug.Log(pSprite);
        blinkTimer += Time.deltaTime;
        //点滅処理
        if (damageTime > 0)
        {
            const float duration = 0.1f;
            float t = Mathf.PingPong(blinkTimer / duration, 1f);
            pSprite.color = Color.Lerp(startColor, endColor, t);

            damageTime -= Time.deltaTime;

        }
        else
        {
            pSprite.color = startColor;
            IsDamage = false;
            blinkTimer = 0f;
        }
    }

    void MatNoise()
    {
        if (!IsDamage) return;
        Debug.Log("ノイズ");
        //点滅処理
        if (damageTime > 0)
        {
            GetComponent<NoiseEnable>().enabled = true;

            damageTime -= Time.deltaTime;

        }
        else
        {
            GetComponent<NoiseEnable>().enabled = false;
            IsDamage = false;
        }
    }
}
