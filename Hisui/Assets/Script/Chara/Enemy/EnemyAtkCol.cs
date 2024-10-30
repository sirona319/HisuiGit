using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtkCol : MonoBehaviour
{
    [SerializeField] Collider col;
    //[SerializeField] bool isEnter = false;

    [SerializeField] bool hitErase = true;

    [SerializeField] int ATKVAL;//攻撃力
    //攻撃用のコリジョンの設定　無い敵もいる
    private void OnTriggerStay(Collider other)
    {



        //Debug.Log("EnemyAtkCol");
        if (!other.transform.CompareTag("Player"))
            return;

        // Debug.Log("EnemyAtkCol LatePlayer");
        if (col == null)
            col = GetComponent<BoxCollider>();


        //プレイヤーへのダメージ処理
        other.transform.GetComponent<PlayerScr>().PlayerDamage(ATKVAL);

        if (hitErase)
            col.enabled = false;
        //else
        //    col.enabled = true;

        //Debug.Log("EnemyAtkCol Damage");
    }
}
