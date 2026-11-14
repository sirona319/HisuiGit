using UnityEngine;

public class Jerry_Attack : StateChildBase
{

    public override void Initialize(int stateType)
    {

        base.Initialize(stateType);

        //if (GetComponent<JerryScr>().atkMagazine == null)
         //   Debug.Log("atkMagazineが設定されていない");

        //GetComponent<JerryScr>().atkMagazine.Initialize();
    }

    public override void OnEnter()
    {

        stateTime = 0f;
        //foreach (var magazine in GetComponent<JerryScr>().atkMagazine)
            GetComponent<JerryScr>().atkMagazine.MagazineEnter();

        if (GetComponent<JerryScr>().atkMove != null)
        {
            GetComponent<JerryScr>().atkMove.MoveEnter();
            //Debug.Log("atkMOVE");
        }

    }

    public override void OnExit()
    {
        // Debug.Log("攻撃終了");
    }

    public override int StateUpdate()
    {

        stateTime += Time.deltaTime;

        if (GetComponent<JerryScr>().IsDamage)
            if (GetComponent<JerryScr>().ReturnStateTypeDead())
                return (int)JerryCtr.State.Jerry_Dead;


        //マガジンの更新
        GetComponent<JerryScr>().atkMagazine.MagazineUpdate();

        if (GetComponent<JerryScr>().atkMove != null)
        {
            GetComponent<JerryScr>().atkMove.MoveUpdate();
            //Debug.Log("atkMOVE");
        }

        //foreach (var move in GetComponent<JerryScr>().atkMove)
        //{
        //    //if(move.IsKeepMove)
        //        move.MoveUpdate();
        //}


        //atkMagazine
        if (!GetComponent<JerryScr>().IsAttack)
        {
            //float randAtkVal = UnityEngine.Random.Range(-0.5f, 0.5f);
            //GetComponent<JerryScr>().AtkInterval = GetComponent<JerryScr>().AtkIntervalMax + randAtkVal;
            return GetComponent<JerryScr>().JerryReturnStateType(StateType);
        }


        return (int)StateType;
    }

}
