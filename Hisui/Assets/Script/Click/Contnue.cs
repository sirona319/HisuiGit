using UnityEngine;

public class Contnue : MonoBehaviour
{

    int SceneNo = 0;

    [SerializeField] DebugEvent debug;
    [SerializeField] GameObject secondWave;
    public void SetSceneNo()
    {

        SceneNo=PlayerPrefs.GetInt("GameNo", 0);
        if (SceneNo == 0) return;


        GameObject.FindWithTag("GameMgr").GetComponent<GameMgr>().SWave= secondWave;

    }
}
