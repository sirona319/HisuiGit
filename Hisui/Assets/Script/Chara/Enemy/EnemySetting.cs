using UnityEngine;
using System.Collections.Generic;
using System;

[Serializable]
public class EnemyData
{
    public string Id;//string@ŒÅ’è

    public enum MoveType
    {
        RandomMove,
        PointMove,
        CircleMove,
        PointCircleMove,
        FloatVectorMove,
        //randomApoint,

    }

    public MoveType[] moveType;


    public enum AttackType
    {
        NormalMagazine,
        FiveMagazine,
        CircleMagazine,
        CircleInverseMagazine,
        CircleOneMagazine,
        //NumAttackType,
    }
    public AttackType[] attackType;

    public bool IsMyDead = false;
    //[HideInInspector] 
    public float MyDeadTimeMax = 1f;

    //public bool isFloat = false;
    //public Vector3 flaotVector;

    //public MoveType moveType = MoveType.random;
    //public AttackType attackType = AttackType.normal;

    //public float Speed;
    public int HpMax;
    public float AtkIntervalMax = 1;

    public float PointEndLength = 0.5f;

    public GameObject go;

    public GameObject builder;

    //public float AtkInterval = 1;
    //public float AtkRandTimeMax;
    //public float AtkRandTimeMin;
    //public int Attack;

    //public bool FirstTargetPlayer=false;
    //public Transform[] movePointsSet;


}


[CreateAssetMenu(fileName = "EnemySetting", menuName = "Scriptable Objects/Enemy Setting")]
public class EnemySetting : ScriptableObject
{

    //[SerializeField]private readonly PoolManager poolManager;
    //[SerializeField] public PoolManager PoolManager => poolManager;
    //public PoolManager poolManager;

    //private readonly float bulletDeadTime = 3f;
    //public float BulletDeadTime => bulletDeadTime;


    public List<EnemyData> DataList;
}
