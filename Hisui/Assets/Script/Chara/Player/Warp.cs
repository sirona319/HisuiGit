using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

[DisallowMultipleComponent]
public class Warp : MonoBehaviour
{
    #region ワープ
    ParticleSystem wpParticle;//ワープパーティクル
    ParticleSystem wpObj;

    [SerializeField] float pFadeSpeed = 0.06f;
    //float pFadeSpeedAdd = 0f;
    //float pFadeSpeedSubtract = 0;

    //[SerializeField] float wpPtFadeSpeed= 0;

    bool isWarpMove = false;


    //float wpPtAlpha = 1f;
    bool playerFade = false;
    float pAlpha = 1f;

    bool ptFade = false;
    float wpPtAlpha = 1f;

    [SerializeField] float wpIntervalMax = 1f;
    [SerializeField] float wpInterval = 0;

    [SerializeField] WarpUi warpUi;
    #endregion

    [SerializeField] string ptChildName= "Ring";

    CircleCollider2D circleCol2D;

    SpriteRenderer sr;


    private void Awake()
    {
        circleCol2D = GetComponent<CircleCollider2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        wpParticle = Resources.Load("prefab/Particle/Wp").GetComponent<ParticleSystem>();
    }

    private void Update()
    {

        if (Keyboard.current.leftShiftKey.wasPressedThisFrame)
        {
            WarpStart();
        }

        else if (Keyboard.current.leftShiftKey.wasReleasedThisFrame)
        {
            WarpEnd();
        }

        if (!isWarpMove)
            warpUi.Heal();//回復
        else
        {
            bool useCheck = warpUi.Sub();//減衰
            if (!useCheck)
                WarpEnd();
        }


        if (wpInterval > 0)
            wpInterval -= Time.deltaTime;


        PlayerFadeUpdate();

        WarpFadeUpdate();

    }

    void PlayerFadeUpdate()
    {
        if (playerFade)
        {
            pAlpha -= pFadeSpeed;//Time.deltaTime;
            if (pAlpha <= 0)
            {
                circleCol2D.enabled = false;
                pAlpha = 0;
                //return;
            }


            //プレイヤーの透明化
            sr.material.color = new Color(1.0f, 1.0f, 1.0f, pAlpha);//(r,g,b,a);
        }
        else if (!playerFade)
        {
            pAlpha += pFadeSpeed;//Time.deltaTime;
            if (pAlpha > 1)
            {
                pAlpha = 1;
                isWarpMove = false;
                circleCol2D.enabled = true;
                //return;
            }


            //プレイヤーの透明化
            sr.material.color = new Color(1.0f, 1.0f, 1.0f, pAlpha);//(r,g,b,a);
        }
    }

    void WarpFadeUpdate()
    {
        if (wpObj == null) return;
        if (!ptFade) return;

        wpPtAlpha -= pFadeSpeed;

        if (wpPtAlpha <= 0)
        {
            wpPtAlpha = 1;

            SetGradiendKeys();

            Destroy(wpObj.gameObject);
            ptFade = false;
            return;
        }

        SetGradiendKeys();

    }

    void SetGradiendKeys()
    {
        wpObj.colorOverLifetime.color.gradient.SetKeys
            (new GradientColorKey[] { new GradientColorKey(Color.blue, 0.0f), new GradientColorKey(Color.red, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(wpPtAlpha, 0.0f), new GradientAlphaKey(wpPtAlpha, 1.0f) });


        var ringPt = wpObj.gameObject.transform.Find(ptChildName).GetComponent<ParticleSystem>();
        float ringPtKeyPosition = .5f;

        ringPt.colorOverLifetime.color.gradient.SetKeys
            (new GradientColorKey[] { new GradientColorKey(Color.blue, 0.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(wpPtAlpha, ringPtKeyPosition) });
    }

    public void WarpStart()
    {
        if (wpInterval > 0) return;
        if (isWarpMove) return;

        //ワープ開始
        isWarpMove = true;

        playerFade = true;


        //ワープパーティクル生成　プレイヤーの子階層へ
        wpObj = Instantiate(wpParticle, transform.position, Quaternion.identity, transform);
  
    }

    public void WarpEnd()
    {
        if (wpInterval > 0) return;
        if (!isWarpMove) return;

        //ワープ終了   フェード開始のほうを　終了させたい　bool?
        playerFade = false;
        ptFade = true;

        isWarpMove = false;
        wpInterval = wpIntervalMax;

    }
}
