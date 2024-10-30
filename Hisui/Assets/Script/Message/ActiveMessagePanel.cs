using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEditor.VersionControl;
using UnityEngine;

public class ActiveMessagePanel : MonoBehaviour
{
    //テスト用スクリプト　おそらく人物　場所などに設定する
    //位置や場所　範囲の設定ができるように変更が必要になるかもしれない


    [SerializeField]
    private Message messageScript;

    public string message;

    public string[] messageAry;

    int messageNo = 0;

    //public GameObject messagePanel;

    // Start is called before the first frame update
    void Start()
    {
       // messageAry = new string[messageAry.Length];
    }

    // Update is called once per frame
    void Update()
    {
        //右クリックでテスト用のメッセージを表示
        if(Input.GetMouseButtonDown(1))
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

        if (Input.GetKey(KeyCode.F))
        {
            messageScript.transform.GetChild(0).gameObject.SetActive(true);


            //allMessage = "今回はRPGでよく使われるメッセージ表示機能を作りたいと思います。\n"
            //+ "メッセージが表示されるスピードの調節も可能であり、改行にも対応します。\n"
            //+ "改善の余地がかなりありますが、               最低限の機能は備えていると思われます。\n"
            //+ "ぜひ活用してみてください。\n<>";

            message = "翡翠";

            messageScript.SetMessagePanel(message);
        }


        if (Input.GetKey(KeyCode.M))
        {
            messageScript.SetEndMessage();
            //bool isSelf = transform.GetChild(0).gameObject.activeInHierarchy;
            //transform.GetChild(0).gameObject.SetActive(!isSelf);
        }
           
    }
}
