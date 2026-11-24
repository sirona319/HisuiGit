using UnityEngine;

public class Contnue : MonoBehaviour
{

    int SceneNo = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    //{
    //    SceneNo=PlayerPrefs.GetInt("GameNo", 0);
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
    [SerializeField] DebugEvent debug;
    [SerializeField] GameObject secondWave;
    public void SetSceneNo()
    {

        SceneNo=PlayerPrefs.GetInt("GameNo", 0);
        if (SceneNo == 0) return;
        
        
        debug.enabled = true;

        debug.SWave = secondWave;
      //if(SceneNo)
    }
}
