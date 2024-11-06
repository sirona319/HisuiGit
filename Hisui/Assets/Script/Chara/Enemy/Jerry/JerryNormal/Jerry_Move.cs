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

        //foreach (var move in GetComponent<JerryScr>().baseMove)
        //    move.Initialize();


        //GetComponent<JerryScr>().baseMove.move

    }

    public override void OnEnter()
    {
        stateTime = 0f;

        foreach (var move in GetComponent<JerryScr>().baseMove)
            move.MoveEnter();

    }

    public override void OnExit()
    {
        //stateTime = 0;
    }

    public override int StateUpdate()
    {
        stateTime += Time.deltaTime;
        //moveSaveTime += Time.deltaTime;

        if (GetComponent<EnemyBase>().IsDamage)
            return GetComponent<JerryScr>().ReturnStateTypeDamage();


        //移動の更新
        foreach (var move in GetComponent<JerryScr>().baseMove)
        {
            move.MoveUpdate();
            GetComponent<JerryScr>().IsMove = move.IsMove;
        }

        //マガジンの更新



        if (!GetComponent<JerryScr>().IsMove)
            GetComponent<JerryScr>().IsAttack = true;

        //GetComponent<JerryScr>().AttackMagazineUpdateAll();

        return GetComponent<JerryScr>().JerryReturnStateType(StateType);


        //return (int)StateType;

    }
}
