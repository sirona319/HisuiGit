using UnityEngine;

public class メモ : MonoBehaviour
{

    [TextArea(3, 20)]
    public string memo;
    
    public LayerMask mask;
    /* 
     *     インスペクター 数式表現
     *     https://www.youtube.com/watch?v=-PgHkiVbnL4
     *     https://www.google.com/search?q=%E3%81%86%E3%81%AB%EF%BD%94%EF%BD%99+%E6%95%B0%E5%BC%8F%E8%A1%A8%E7%8F%BE%E3%80%80%E3%82%A4%E3%83%B3%E3%82%B9%E3%83%9A%E3%82%AF%E3%82%BF%E3%83%BC&sca_esv=e084c0a5ee5ec119&hl=ja&sxsrf=AKL5yDgPeehcv4iqCYtFecJ0zKbv95x6iA%3A1794836608550&source=hp&ei=gAj7asroHrm4rfcP7uCwyAU&iflsig=AHSINFcAAAAAavsWkNtB9_uucV1hxmO1BeBsP_fmjN9q&uact=5&oq=%E3%81%86%E3%81%AB%EF%BD%94%EF%BD%99+%E6%95%B0%E5%BC%8F%E8%A1%A8%E7%8F%BE%E3%80%80%E3%82%A4%E3%83%B3%E3%82%B9%E3%83%9A%E3%82%AF%E3%82%BF%E3%83%BC&gs_lp=Egdnd3Mtd2l6IjHjgYbjgavvvZTvvZkg5pWw5byP6KGo54--44CA44Kk44Oz44K544Oa44Kv44K_44O8MgUQABjvBTIFEAAY7wUyBRAAGO8FMggQABiJBRiiBDIFEAAY7wVI_mVQkQhYuWJwAngAkAEAmAGCAaAByguqAQM5LjawAQC4AQPIAQD4AQL4AQGYAhCgAqILqAIKwgIHECMY6gIYJ8ICDRAjGPAFGMkCGOoCGCfCAg0QIxjJAhjwBRjqAhgnwgIHECMYsAIYJ8ICCRAhGAoYoAEYKsICBxAhGAoYoAGYAwfiAwQYACBd4gMEGAAgXuIDBBgAIF_iAwQYACBg4gMEGAAgYeIDBBgAIGLiAwUSATEgQPEFj8xuby1DmFWSBwM4LjigB_kwsgcDNi44uAeYC8IHBjMuMTIuMcgHGIAIAQ&sclient=gws-wiz
      
      
      NaughtyAttributes
      https://zenn.dev/m_mikan12/articles/0cb0750c74c96e
      
      
      イベント実行順序　関数
      https://www.google.com/search?q=%E3%81%86%E3%81%AB%EF%BD%94%EF%BD%99+%E5%AE%9F%E8%A1%8C%E9%A0%86+%E9%96%A2%E6%95%B0&oq=%E3%81%86%E3%81%AB%EF%BD%94%EF%BD%99%E3%80%80%E5%AE%9F%E8%A1%8C%E9%A0%86%E3%80%80%E9%96%A2%E6%95%B0&gs_lcrp=EgZjaHJvbWUyBggAEEUYOTIKCAEQABgEGAgYHjIKCAIQABiiBBiJBTIHCAMQABjvBdIBCjE4MTQ5ajBqMTWoAgCwAgA&sourceid=chrome&source=chrome.rb&ie=UTF-8
      
     パラメーターなど説明
     https://x.gd/vUvxo
        ステータスは状態
        パラメータは数値



    soundMgr SEは別にする？　オブジェクトごと



    GameObject.FindGameObjectsWithTag("MoveErea").ToList().ForEach(x => x.SetActive(false));

    MyLib.MyPlayOneSound("SE/Gameover", 0.3f, GameObject.FindGameObjectWithTag("SoundM").GetComponent<SoundManager>().se.gameObject);

    □◇□◇□◇□◇□
    ◇　◇　◇　◇　◇　
    □◇□◇□◇□◇□　
    ◇　◇　◇　◇　◇
    □◇□◇□◇□◇□　
    ◇　◇　◇　◇　◇　
    □◇□◇□◇□◇□



        ////EventSystemの存在: ヒエラルキー上に「EventSystem」オブジェクトが必要
        ////Raycast対象の設定: スクリプトをアタッチしているオブジェクトにGraphic（ImageやTextなど）があり、
        ////Raycast Targetがオンになっている必要があります。
        //var clickEvent = new EventTrigger.Entry { eventID = EventTriggerType.PointerClick };
        //clickEvent.callback.AddListener((eventData) => { Debug.Log("test"); });
        //var trigger = GetComponent<EventTrigger>();
        //trigger.triggers.Add(clickEvent);




        回転させる　
        public float targetZAngle = 90f; // 目標のZ角度
        public float rotationSpeed = 100f; // 回転速度 (度/秒)

        void Update()
        {
            // 1. 目標となる回転（Quaternion）を作成
            Quaternion targetRotation = Quaternion.Euler(0, 0, targetZAngle);

            // 2. 現在の回転から目標の回転へ、速度に合わせて徐々に回転させる
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation, 
                targetRotation, 
                rotationSpeed * Time.deltaTime
            );
        }




        const float ROLLSPEED = 7f;
        var rot = Quaternion.AngleAxis(ROLLSPEED, Vector3.right);

        transform.rotation = transform.rotation * rot;

     
     */

}
