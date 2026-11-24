using UnityEngine;

public class GameMgr : MonoBehaviour
{

    [SerializeField] float fadeStartTime = 2f;
    [SerializeField] float fadeEndTime = 3f;


    [SerializeField] GameObject player;
    [SerializeField] GameObject boss;

    [SerializeField] EnumSceneName.SceneNameType SceneNameOver;

    [SerializeField] EnumSceneName.SceneNameType SceneNameNext;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       // PlayerPrefs.SetInt("GameNo", 0);

      //  PlayerPrefs.Save();
        player.GetComponent<CharaBase>().OnDead += GameOver;

        boss.GetComponent<CharaBase>().OnDead += Next;

    }

    void GameOver()
    {
        var fade = GameObject.FindWithTag("Fade").GetComponent<FadeScene>();
        fade.SceneFade(SceneNameOver.ToString(), fadeStartTime, fadeEndTime);
        Debug.Log("FadeTITLE");
    }

    void Next()
    {

        //セーブ

        PlayerPrefs.SetInt("GameNo", 1);

        PlayerPrefs.Save();

        Debug.Log("セーブ　１//");

    }
}
