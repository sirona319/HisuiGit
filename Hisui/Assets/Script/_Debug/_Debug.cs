using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class _Debug : MonoBehaviour
{
    //
    [SerializeField] List<GameObject> erases;
    [SerializeField] Canvas canvas;


    //
    [SerializeField] GameObject startWave;
    [SerializeField] BackScroll bcSc;

    //
    [SerializeField] PlayerScr2D player;
    [SerializeField] bool DEBUGPLAYERHP = false;
    [SerializeField] Vector3 pPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (DEBUGPLAYERHP)
            player.DEBUGNODAMAGE = true;

        player.transform.position = pPos;
        player.GetComponent<Animator>().enabled = false;
        canvas.gameObject.SetActive(false);


        erases.ToList().ForEach(x => { Destroy(x); });


        player.gameObject.SetActive(true);
        player.enabled = true;



        startWave.SetActive(true);
        bcSc.enabled = true;

    }

    void EnWaveAct()
    {
        if(startWave != null)
        {
            startWave.SetActive(true);
        }
    }


}
