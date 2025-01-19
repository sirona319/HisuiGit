using UnityEngine;

public class Jerry_Attack : StateChildBase
{

    public override void Initialize(int stateType)
    {

        base.Initialize(stateType);

    }

    public override void OnEnter()
    {

        stateTime = 0f;
        foreach (var magazine in GetComponent<JerryScr>().baseMagazine)
            magazine.MagazineEnter();
    }

    public override void OnExit()
    {
        // Debug.Log("攻撃終了");
    }

    public override int StateUpdate()
    {

        stateTime += Time.deltaTime;

        if (GetComponent<EnemyBase>().IsDamage)
            if (GetComponent<EnemyBase>().ReturnStateTypeDead())
                return (int)JerryCtr.State.Jerry_Dead;


        //マガジンの更新
        GetComponent<JerryScr>().AttackMagazineUpdateAll();


        foreach (var move in GetComponent<JerryScr>().baseMove)
        {
            if(move.IsKeepMove)
                move.MoveUpdate();
        }



        if (stateTime > GetComponent<JerryScr>().baseMagazine[0].shotTime)
        {
            float randAtkVal = UnityEngine.Random.Range(-0.5f, 0.5f);
            GetComponent<JerryScr>().AtkInterval = GetComponent<JerryScr>().AtkIntervalMax+ randAtkVal;
            return GetComponent<JerryScr>().JerryReturnStateType(StateType);
        }


        return (int)StateType;
    }

}
