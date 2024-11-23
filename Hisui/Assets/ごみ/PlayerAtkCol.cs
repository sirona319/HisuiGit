using UnityEngine;

public class PlayerAtkCol : MonoBehaviour
{
    public int damageValue;

    void OnTriggerStay(Collider other)
    {
        //Debug.Log("PlayerAtkCol");
        //if (IsBreak) return;

        //プレイヤーが死んでたら無効
        //if (GameObject.FindGameObjectWithTag("Player").GetComponent<HPUIControl>().GetHp() <= 0)
        //    return;

        //攻撃インターバル
        //if (isPlayerAttackHit) return;
        if (other.gameObject.transform.CompareTag("Enemy"))
        {
            //複数の敵に当たるようにしたい　現在できていない


            //ランダム加算威力
            var randpow = Random.Range(5, 15 + 1);

            //クリティカル
            if (randpow > 12)
                randpow += 30;

            other.GetComponent<EnemyBase>().EnemyDamage(damageValue + randpow);
            var col = GetComponent<BoxCollider>();
            col.enabled = false;



        }

    }
}
