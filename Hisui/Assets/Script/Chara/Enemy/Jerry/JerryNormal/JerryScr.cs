using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JerryScr : EnemyBase
{

    //public Transform front;


    [SerializeField]float floatSpeed = .005f;
    //[SerializeField] Vector3 flaotVector;
    void Start()
    {
        base.StartInit();
        base.Init();

        //isFloat=enemyData.

        //if文で弾の種類分けれる　攻撃ごとに　ボスなど
        //foreach (var magazine in baseMagazine)
        //    magazine.BulletLoad("prefab/EBulletNormalEX");
        

        stateController.Initialize((int)JerryCtr.State.Jerry_Wait);
    }

    void Update()
    {
        //stateController.AutoStateTransitionSequence(0);

        AttackTimeUpdate();

        stateController.UpdateSequence();

        if(!IsMove&& enemyData.isFloat)
        MyLib.LoopMotionSinVector(transform, floatSpeed, enemyData.flaotVector);

    }


    void AttackTimeUpdate()
    {
        if (!IsAttack) return;

        AtkInterval -= Time.deltaTime;

        //if(enemyData.AtkInterval<=0)

    }



    public int JerryReturnStateType(int stateType)
    {
        if (AtkInterval <= 0)
            return (int)JerryCtr.State.Jerry_Attack;
        else if (IsMove)
            return (int)JerryCtr.State.Jerry_Move;
        else
            return (int)JerryCtr.State.Jerry_Wait;

        //return stateType;
    }

    //private void OnTriggerExit(Collider other)
    //{

    //    if (other.CompareTag("ExitErea"))
    //    {

    //        //Debug.Log("エリア外消去");

    //        this.gameObject.SetActive(false);

    //        Destroy(this.gameObject);
    //        return;
    //    }

    //}

}
