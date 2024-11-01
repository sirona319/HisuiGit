using UnityEngine;

public class Jerry_Move : StateChildBase
{
    //[SerializeField] float MOVEXY = 100;
    //[SerializeField] Vector3[] movePos;
    //[SerializeField] Vector3 targetPos;
    //[SerializeField] float moveSaveTime = 0;


    //const float ENDMOVELEN = 1f;

    //Rigidbody m_rb;


    public override void Initialize(int stateNo)
    {
        base.Initialize(stateNo);

        foreach (var move in GetComponent<JerryScr>().baseMove)
            move.Initialize();

    }

    public override void OnEnter()
    {
        stateTime = 0f;

        foreach (var move in GetComponent<JerryScr>().baseMove)
            move.MoveEnter();

    }

    public override void OnExit()
    {
        stateTime = 0;
    }

    public override int StateUpdate()
    {
        stateTime += Time.deltaTime;
        //moveSaveTime += Time.deltaTime;

        if (GetComponent<EnemyBase>().IsDamage)
            GetComponent<EnemyBase>().ReturnStateTypeDamage();


        //移動の更新
        foreach (var move in GetComponent<JerryScr>().baseMove)
            move.MoveUpdate();

        //マガジンの更新
        GetComponent<JerryScr>().AttackMagazineUpdateAll();


        //if (stateTime > GetComponent<EnemyBase>().enemyData.AtkInterval)
        //{
        //GetComponent<JerryScr>().IsAttack = true;
        //return GetComponent<JerryScr>().JerryReturnStateType(StateType);
        //}

        return (int)StateType;

    }
}
