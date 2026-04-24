using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    [SerializeField] GameObject[] spawnGoType;

    [SerializeField] int spawnNum;

    [SerializeField] float spawnRndRangeMax = 1;
    [SerializeField] float spawnRndTimeMax = 1;
    void Start()
    {

        //spawnNumの数だけ生成
        for (int i = 0; i < spawnNum; i++)
        {
            int rndType = Random.Range(0, spawnGoType.Length);
            Debug.Log(rndType);

            var rndTime = Random.Range(0, spawnRndTimeMax);
            Debug.Log(rndTime+"rndTime");

            Vector3 t = transform.position;
            Vector3 randPos = new Vector3
                (Random.Range(t.x + -spawnRndRangeMax, t.x + spawnRndRangeMax),
                Random.Range(t.y + -spawnRndRangeMax, t.y + spawnRndRangeMax),
                Random.Range(t.z + -spawnRndRangeMax, t.z + spawnRndRangeMax));


            StartCoroutine(DelaySpawnWave());
             IEnumerator DelaySpawnWave()
            {
                yield return new WaitForSeconds(rndTime);
                Instantiate(spawnGoType[rndType], randPos, transform.rotation);
            }
        }


    }



}
