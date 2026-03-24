using UnityEngine;
using UnityEngine.UI;

public class ActiveMessagePanel : MonoBehaviour
{
    //テスト用スクリプト　おそらく人物　場所などに設定する
    //位置や場所　範囲の設定ができるように変更が必要になるかもしれない


    [SerializeField]
    private Message messageScript;
    [SerializeField] Image TextBack;


    public string message;

    public string[] messageAry;

    int messageNo = 0;

    // float IntensityVal = 1;
    //const float TrailEndSpeed = 0.02f;

    //const float fadeSpeed = 300;

    //public GameObject messagePanel;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(gameObject.name);
        // messageAry = new string[messageAry.Length];
    }

    // Update is called once per frame
    void Update()
    {
        //デバッグ用
        //右クリックでテスト用のメッセージを表示
        if (Input.GetMouseButtonDown(1))
        {
            if (messageNo >= messageAry.Length)
            {
                messageNo = 0;
                messageScript.MesseageEndCheck();
                return;
            }
            message = messageAry[messageNo];
            messageNo++;


            messageScript.transform.GetChild(0).gameObject.SetActive(true);


            //message = "鯨"+ "end\n"+"end\n";

            messageScript.SetMessagePanel(message);
        }


        //デバッグ用
        //if (Input.GetKey(KeyCode.F))
        //{
        //    messageScript.transform.GetChild(0).gameObject.SetActive(true);


        //    //allMessage = "今回はRPGでよく使われるメッセージ表示機能を作りたいと思います。\n"
        //    //+ "メッセージが表示されるスピードの調節も可能であり、改行にも対応します。\n"
        //    //+ "改善の余地がかなりありますが、               最低限の機能は備えていると思われます。\n"
        //    //+ "ぜひ活用してみてください。\n<>";

        //    message = "翡翠";

        //    messageScript.SetMessagePanel(message);
        //}

        ////デバッグ用

        //if (Input.GetKey(KeyCode.M))
        //{
        //    messageScript.SetEndMessage();
        //    //bool isSelf = transform.GetChild(0).gameObject.activeInHierarchy;
        //    //transform.GetChild(0).gameObject.SetActive(!isSelf);
        //}
           
    }

    //public void MessageEnd()
    //{
    //    messageScript.messageText.enabled = false;


    //    const float targetAlpha = 0;
    //    var tColor = TextBack.color;
    //    tColor.a = targetAlpha;

    //    //endValue　フェード目標カラー
    //    TextBack.DOColor(tColor, Time.deltaTime * fadeSpeed).SetEase(Ease.Linear);

    //}

    //public void MessageStart()
    //{
    //    messageScript.messageText.enabled = true;
    //    TextBack.enabled = true;


    //    const float targetAlpha = 0.7f;
    //    var tColor = TextBack.color;
    //    tColor.a = targetAlpha;

    //    //endValue　フェード目標カラー
    //    TextBack.DOColor(tColor, Time.deltaTime* fadeSpeed).SetEase(Ease.Linear);

    //}
}
