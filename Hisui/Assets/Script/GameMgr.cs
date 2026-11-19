using UnityEngine;

public class GameMgr : MonoBehaviour
{
    [SerializeField] GameObject player;




    [SerializeField] float fadeStartTime = 2f;
    [SerializeField] float fadeEndTime = 3f;

    [SerializeField] EnumSceneName.SceneNameType SceneName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player.GetComponent<BaseHP>().OnDead += GameOver;
    }

    void GameOver()
    {
        var fade = GameObject.FindWithTag("Fade").GetComponent<FadeScene>();
        fade.SceneFade(SceneName.ToString(), fadeStartTime, fadeEndTime);
    }
}
