using UnityEngine;
using static UnityEngine.ParticleSystem;

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

    void Start()
    {
        wpParticle = MyLib.GetComponentLoad<ParticleSystem>("prefab/Particle/Wp");
    }

    private void Update()
    {
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
                pAlpha = 0;
                //return;
            }


            //プレイヤーの透明化
            GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, pAlpha);//(r,g,b,a);
        }
        else if (!playerFade)
        {
            pAlpha += pFadeSpeed;//Time.deltaTime;
            if (pAlpha > 1)
            {
                pAlpha = 1;
                isWarpMove = false;
                //return;
            }


            //プレイヤーの透明化
            GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, pAlpha);//(r,g,b,a);
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

        if (!warpUi.EnableWarpCheck()) return;

        //ワープ開始
        isWarpMove = true;

        playerFade = true;

        warpUi.Change(25);
        /////////////





        //ワープパーティクル生成　プレイヤーの子階層へ
        wpObj = Instantiate(wpParticle, transform.position, Quaternion.identity, transform);

        //pFadeSpeedAdd = pFadeSpeed;
        //pFadeSpeedSubtract = 0f;

        //StartCoroutine(MyLib.LoopDelayCoroutineIf(Time.deltaTime, pAlpha > 0 || !isWarpMove, () =>
        //{
        //    pAlpha -= 0.6f;//Time.deltaTime;
        //    if (pAlpha <= 0)
        //    {
        //        pAlpha = 0;
        //        //return;
        //    }


        //    //プレイヤーの透明化
        //    GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, pAlpha);//(r,g,b,a);
        //},
        //"GetKeyDownプレイヤーフェード終了"));



        
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

        /////////////
        //pAlpha = 0;
        //wpPtAlpha = 1;

        //pFadeSpeedAdd = 0f;
        //pFadeSpeedSubtract = pFadeSpeed;
        ////Playerのスプライトのフェード出現
        //StartCoroutine(MyLib.LoopDelayCoroutineIf(Time.deltaTime, pAlpha < 1 || !isWarpMove, () =>
        //{
        //    pAlpha += pFadeSpeedSubtract;//Time.deltaTime;

        //    if (pAlpha >= 1)
        //        pAlpha = 1;

        //    //プレイヤーの透明化
        //    GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, pAlpha);//(r,g,b,a);
        //}));

        //GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1f);//(r,g,b,a);

        //パーティクルのフェード消去
        //if (wpObj.gameObject != null)
        //{

        //    wpObj.colorOverLifetime.color.gradient.SetKeys
        //        (new GradientColorKey[] { new GradientColorKey(Color.blue, 0.0f), new GradientColorKey(Color.red, 1.0f) },
        //        new GradientAlphaKey[] { new GradientAlphaKey(0.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) });


        //    var ringPt = wpObj.gameObject.transform.Find("Ring").GetComponent<ParticleSystem>();

        //    ringPt.colorOverLifetime.color.gradient.SetKeys
        //        (new GradientColorKey[] { new GradientColorKey(Color.blue, 0.0f) },
        //        new GradientAlphaKey[] { new GradientAlphaKey(0.0f, .5f) });





        //    StartCoroutine(MyLib.LoopDelayCoroutineIf
        //        (Time.deltaTime, wpPtAlpha > 0 || !isWarpMove || wpObj == null, () =>
        //        {
        //            wpPtAlpha -= pFadeSpeedSubtract;//Time.deltaTime;


        //            if (wpPtAlpha <= 0)
        //            {
        //                wpObj.gameObject.SetActive(false);
        //                //Destroy(wpObj.gameObject);
        //                wpPtAlpha = 0;
        //                isWarpMove = false;



        //                //return;
        //            }


        //            if (wpObj != null)
        //            {


        //                wpObj.colorOverLifetime.color.gradient.SetKeys
        //                    (new GradientColorKey[] { new GradientColorKey(Color.blue, 0.0f), new GradientColorKey(Color.red, 1.0f) },
        //                    new GradientAlphaKey[] { new GradientAlphaKey(wpPtAlpha, 0.0f), new GradientAlphaKey(wpPtAlpha, 1.0f) });


        //                var ringPt = wpObj.gameObject.transform.Find("Ring").GetComponent<ParticleSystem>();
        //                float ringPtKeyPosition = .5f;

        //                ringPt.colorOverLifetime.color.gradient.SetKeys
        //                    (new GradientColorKey[] { new GradientColorKey(Color.blue, 0.0f) },
        //                    new GradientAlphaKey[] { new GradientAlphaKey(wpPtAlpha, ringPtKeyPosition) });

        //            }

        //        }));


            //wpInterval = wpIntervalMax;







            //Gradient grad = new Gradient();
            // grad.SetKeys(new GradientColorKey[] { new GradientColorKey(Color.blue, 0.0f), new GradientColorKey(Color.red, 1.0f) },
            //    new GradientAlphaKey[] { new GradientAlphaKey(0.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) });

            //col.color = grad;

            //Destroy(wpObj.gameObject);
        //}


        
    }
}
