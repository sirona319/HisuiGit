using UnityEngine;

public class _Debug : MonoBehaviour
{

    [SerializeField]bool StartEventSkip = false;

    [SerializeField] GameObject startWave;
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
            if (startWave != null)
            {
                startWave.SetActive(true);
            }
            StartEventSkip = false;
            //isStartEventSkip = true;
        }

    }

    void EnWaveAct()
    {
        if(startWave != null)
        {
            startWave.SetActive(true);
        }
    }
}
