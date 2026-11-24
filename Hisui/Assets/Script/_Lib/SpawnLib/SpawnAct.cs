using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnAct : MonoBehaviour
{
    [Range(0f, 100f)]
    [SerializeField] float DEBUGtimer = 0f;



    [SerializeField] float spawnTimer = 0f;
    [SerializeField] SpawnAct spawnActNext = null;
    [SerializeField] List<CharaBase> spawnGos;
    [Range(0f, 20f)]
    [SerializeField] List<float> spawnTimes;


    List<CharaBase> _spawnGos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // spawnGosを変えても_spawnGosは変わらない  
        _spawnGos = new List<CharaBase>(spawnGos);

        spawnTimer = DEBUGtimer;
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

        if (spawnTimes.Count == 0 || spawnGos.Count == 0)
            return;

        if (spawnTimer >= spawnTimes[0])
        {
            spawnGos[0].gameObject.SetActive(true);

            spawnTimes.RemoveAt(0);
            spawnGos.RemoveAt(0);
        }

    }

    //AI
    void NextSpawn()
    {
        if (!_spawnGos.All(x => x.IsDead))return;

        //全ての敵が死んでいたら　次のスポーンアクションを有効にする

        _spawnGos.ForEach(x =>
        {
            Destroy(x.gameObject);
        });

        Destroy(gameObject);

        if (spawnActNext == null) return;
        spawnActNext.gameObject.SetActive(true);

        

    }

}
