using UnityEngine;

public class PlayerAtkCol : MonoBehaviour
{
    public int damageValue;

    void OnTriggerStay(Collider other)
    {
        //Debug.Log("PlayerAtkCol");
        //if (IsBreak) return;

        //�v���C���[������ł��疳��
        //if (GameObject.FindGameObjectWithTag("Player").GetComponent<HPUIControl>().GetHp() <= 0)
        //    return;

        //�U���C���^�[�o��
        //if (isPlayerAttackHit) return;
        if (other.gameObject.transform.CompareTag("Enemy"))
        {
            //�����̓G�ɓ�����悤�ɂ������@���݂ł��Ă��Ȃ�


            //�����_�����Z�З�
            var randpow = Random.Range(5, 15 + 1);

            //�N���e�B�J��
            if (randpow > 12)
                randpow += 30;

            other.GetComponent<EnemyBase>().EnemyDamage(damageValue + randpow);
            var col = GetComponent<BoxCollider>();
            col.enabled = false;



        }

    }
}
