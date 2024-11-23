using UnityEngine;
using System.Collections.Generic;
using System;

[Serializable]
public class EnemyData
{
    public string Id;//string　固定

    public enum MoveType
    {
        RandomMove,
        PointMove,
        CircleMove,

        PointFloatMove,
        PointCircleMove,

        FloatVectorMove,

        //randomApoint,

    }

    public MoveType[] moveType;


    public enum AttackType
    {
        TargetMagazine,
        FiveMagazine,
        TwoMagazine,
        CircleMagazine,
        //CircleInverseMagazine,
        CircleOneMagazine,
        //NearMagazine,

        //NumAttackType,
    }
    public AttackType[] attackType;

    public enum BulletType
    {
        ShakeModule,
        CarveModule,//パラメータ設定できるようにしたい曲がる量　敵ごとに

        //分裂団
        //遅延弾
        //拡大弾
        //

    }
    public BulletType[] bulletType;

    //public bool IsMyDead = false;
    //[HideInInspector] 
    //public float MyDeadTimeMax = 1f;

    //public bool isFloat = false;
    //public Vector3 flaotVector;

    //public MoveType moveType = MoveType.random;
    //public AttackType attackType = AttackType.normal;



    [SerializeField]private float speed;
    public float Speed { get=> speed; }
    [SerializeField] int hpMax;
    public int HpMax { get => hpMax; }

    [SerializeField] float atkIntervalMax = 1;
    public float AtkIntervalMax { get => atkIntervalMax; }

    public float PointEndLength = 0.5f;

    //public GameObject go;

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
