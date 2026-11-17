//using TMPro;
//using UnityEngine;

//public class GameMgr : MonoBehaviour
//{
//    [SerializeField] TMP_Text vic;

//    [SerializeField] TMP_Text lose;

//    [SerializeField] float fadeStartTime = 2f;
//    [SerializeField] float fadeEndTime = 3f;

//    [SerializeField] EnumSceneNameSample.SceneNameType SceneName;

//    bool isCallEnd = false;


//    void Update()
//    {
//        //if (Input.GetKeyDown(KeyCode.Backspace))
//        //{
//        //    GameEnd(true);
//        //}
//    }
//    public void GameEnd(bool isVic)
//    {
//        if (isCallEnd) return;

//        var se = GameObject.FindGameObjectWithTag("SoundM").GetComponent<SoundManager>().se.gameObject;
//        var volume = .3f;
//        if (isVic)
//        {
//            vic.gameObject.SetActive(true);
//            MyLib.MyPlayOneSound("SE/victory", volume, se);
//        }
//        else
//        {
//            lose.gameObject.SetActive(true);
//            MyLib.MyPlayOneSound("SE/Gameover", volume, se); 

//        }
//        //const float time = 1.5f;
//        var fade = GameObject.FindGameObjectWithTag("Fade").GetComponent<FadeScene>();
//       // fade.fadeWaitTime = time;
//        fade.SceneFade(SceneName.ToString(), fadeStartTime, fadeEndTime);

//        isCallEnd = true;
//    }

//}