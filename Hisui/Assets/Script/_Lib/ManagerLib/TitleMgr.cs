using UnityEngine;

public class TitleMgr : MonoBehaviour
{
    [SerializeField] EnumSceneName.SceneNameType SceneName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            var seAudio = GameObject.FindWithTag("SoundM").GetComponent<SoundMgr>().se.gameObject;
            MyLib.MyPlayOneSound("Sound/SE/wave/決定ボタンを押す12", 1f, seAudio);

            //var gMgr = GameObject.FindWithTag(TagName.GameController).GetComponent<GameMgr>();

            //gMgr.isChangePlayer = true;
            //gMgr.playerHp = GameObject.FindWithTag(TagName.Player).GetComponent<PlayerHp>().hp;


            //シーン遷移　プレイヤー座標の設定　効果音　プレイヤーのみと分ける
            const float sceneChangeTime = 2f;
            GameObject.FindWithTag("Fade").GetComponent<FadeScene>().SceneFade
                (SceneName.ToString(), 0f, sceneChangeTime);
        }
    }
}
