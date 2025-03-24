using UnityEngine;


public class Jerry_Wait : StateChildBase
{
    public override void Initialize(int stateNo)
    {
        base.Initialize(stateNo);

    }

    public override void OnEnter()
    {
        stateTime = 0f;
    }

    public override void OnExit()
    {

    }

    public override int StateUpdate()
    {
        if (GetComponent<EnemyBase>().IsDamage)
            if (GetComponent<EnemyBase>().ReturnStateTypeDead())
                return (int)JerryCtr.State.Jerry_Dead;

        stateTime += Time.deltaTime;
        //if (GetComponent<JerryScr>().atkMove != null)
        //{
        //    GetComponent<JerryScr>().atkMove.MoveUpdate();
        //    Debug.Log("atkMOVE");
        //}
        //transform.rotation = MyLib.TargetRotation2D((transform.position + Vector3.up), transform, 10f);
        transform.rotation = MyLib.GetAngleRotationFuncs((transform.position + Vector3.up), transform, 10f);


        return GetComponent<JerryScr>().JerryReturnStateType(StateType);


    }

}
