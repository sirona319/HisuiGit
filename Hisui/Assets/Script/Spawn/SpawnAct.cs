using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnAct : MonoBehaviour
{
    [SerializeField] SpawnAct spawnAct = null;

    [SerializeField] float spawnTimer = 0f;

    public List<Transform> spawnGos;//子の敵設定する

    List<Transform> _spawnGos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // spawnGosを変えても_spawnGosは変わらない  
        _spawnGos = new List<Transform>(spawnGos);


        //spawnTimer　早い順に並び替えする？
    }

    // Update is called once per frame
    void Update()
    {
        NextSpawn();

        Spawn();

    }

    void Spawn()
    {
        if(spawnGos.Count <= 0) return;

        spawnTimer += Time.deltaTime;

        spawnGos.ToList().ForEach(x =>
        {
            //if (x.tag == "Enemy")
            if (x.GetComponent<EnemyBase>().SpawnTime < spawnTimer)
            {
                //if(!x.transform.gameObject.activeSelf)
                x.transform.gameObject.SetActive(true);

                spawnGos.Remove(x);
                x.parent = null;
            }
            Debug.Log(x.name);
        });
    }

    void NextSpawn()
    {
        if (spawnAct == null) return;

        int deadCount = 0;
        _spawnGos.ToList().ForEach(x =>
        {
            if (x.GetComponent<EnemyBase>().isDead)
                deadCount++;

        });

        //Debug.Log(deadCount);
        //Debug.Log(_spawnGos.Count);
        if (deadCount >= _spawnGos.Count)
        {
            spawnAct.gameObject.SetActive(true);
            Destroy(gameObject);
            return;
        }


    }


    //シグナルで呼び出す関数
    //public void TimerStart()
    //{
    //    isEnable = true;
    //}
}
