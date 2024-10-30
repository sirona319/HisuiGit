using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtkCol : MonoBehaviour
{
    [SerializeField] Collider col;
    //[SerializeField] bool isEnter = false;

    [SerializeField] bool hitErase = true;

    [SerializeField] int ATKVAL;//�U����
    //�U���p�̃R���W�����̐ݒ�@�����G������
    private void OnTriggerStay(Collider other)
    {



        //Debug.Log("EnemyAtkCol");
        if (!other.transform.CompareTag("Player"))
            return;

        // Debug.Log("EnemyAtkCol LatePlayer");
        if (col == null)
            col = GetComponent<BoxCollider>();


        //�v���C���[�ւ̃_���[�W����
        other.transform.GetComponent<PlayerScr>().PlayerDamage(ATKVAL);

        if (hitErase)
            col.enabled = false;
        //else
        //    col.enabled = true;

        //Debug.Log("EnemyAtkCol Damage");
    }
}
