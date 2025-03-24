using UnityEngine;
using System.Collections.Generic;
using System;
using static BaseMagazine;
using static BaseBullet;
using static BaseMove;
using static CreateBullet;

[Serializable]
public class EnemyData
{
    public string Id;//string　固定

    public enum BuilderType
    {
        JERRY,
    }
    public BuilderType builderType;

    public MoveType[] moveType;

    public MagazineType[] magazineType;

    public BulletType[] bulletType;


    [SerializeField]private float speed;
    public float Speed { get=> speed; }
    [SerializeField] int hpMax;
    public int HpMax { get => hpMax; }

    [SerializeField] float atkIntervalMax = 1;
    public float AtkIntervalMax { get => atkIntervalMax; }


    //public BulletTarget bulletTarget;

    //[SerializeField] public Vector3 bulletTargetDir;

    //public float PointEndLength = 0.5f;


    //public float AtkInterval = 1;
    //public float AtkRandTimeMax;
    //public float AtkRandTimeMin;
    //public int Attack;

    //public bool FirstTargetPlayer=false;
    //public Transform[] movePointsSet;

    //public bool IsMyDead = false;
    //[HideInInspector] 
    //public float MyDeadTimeMax = 1f;

    //public bool isFloat = false;
    //public Vector3 flaotVector;

    //public MoveType moveType = MoveType.random;
    //public AttackType attackType = AttackType.normal;
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
