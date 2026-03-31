using UnityEngine;

public class _Debug : MonoBehaviour
{

    [SerializeField]bool StartEventSkip = false;

    //bool isStartEventSkip = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(StartEventSkip)
        {

            GameObject.Find("StartEvent").SetActive(false);
            GameObject.Find("WaveActSpawn").GetComponent<SpawnAct>().isEnable = true;
            StartEventSkip = false;
            //isStartEventSkip = true;
        }


    }
}
