using UnityEngine;

public class メモ : MonoBehaviour
{

    [TextArea(3, 20)]
    public string memo;

    public LayerMask mask;
    /*
    パラメーターなど説明
    https://x.gd/vUvxo




        GameObject.FindGameObjectsWithTag("MoveErea").ToList().ForEach(x => x.SetActive(false));

                MyLib.MyPlayOneSound("SE/Gameover", 0.3f, GameObject.FindGameObjectWithTag("SoundM").GetComponent<SoundManager>().se.gameObject);

    □◇□◇□◇□◇□
    ◇　◇　◇　◇　◇　
    □◇□◇□◇□◇□　
    ◇　◇　◇　◇　◇
    □◇□◇□◇□◇□　
    ◇　◇　◇　◇　◇　
    □◇□◇□◇□◇□






    ・パッケージ
    FadeCamera2.unitypackage
        https://x.gd/97tTw

    DOTween (HOTween v2)

    ・UIサイト
    https://icon-rainbow.com/?s=%E6%9C%AC



    ・フォント
    https://booth.pm/ja/items/3308018　クラフト
    https://booth.pm/ja/items/4927023　マルミーニャ
    https://ymnk-design.booth.pm/items/7748814　カラメルポップ
    https://booth.pm/ja/items/7801932　ナイトシェーダー

    https://cgbox.jp/2023/07/27/unity-font/











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
