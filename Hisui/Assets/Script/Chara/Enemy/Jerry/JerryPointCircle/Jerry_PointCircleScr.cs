using UnityEngine;

public class JerryPointCircleScr : JerryScr
{
    void Start()
    {
        base.StartInit();
        base.Init();

        //if文で弾の種類分けれる　攻撃ごとに　ボスなど
        //foreach (var magazine in baseMagazine)
        //    magazine.BulletLoad("prefab/EBulletNormalEX");


        stateController.Initialize((int)JerryPointCircleCtr.State.JerryCircle_Wait);
    }

    void Update()
    {
        //stateController.AutoStateTransitionSequence(0);

        AttackTimeUpdate();

        stateController.UpdateSequence();
    }


    void AttackTimeUpdate()
    {
        if (!IsAttack) return;

        AtkInterval -= Time.deltaTime;

        //if(enemyData.AtkInterval<=0)

    }



    public int JerryPointCircleReturnStateType(int stateType)
    {
        if (AtkInterval <= 0)
            return (int)JerryPointCircleCtr.State.JerryCircle_Wait;
        else if (IsMove)
            return (int)JerryPointCircleCtr.State.JerryCircle_MoveCircle;
        else
            return (int)JerryPointCircleCtr.State.JerryCircle_Wait;
            
        //return stateType;
    }
}


