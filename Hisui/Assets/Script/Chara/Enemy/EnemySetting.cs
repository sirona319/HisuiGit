using UnityEngine;
using System.Collections.Generic;
using System;

[Serializable]
public class EnemyData
{
    public string Id;//stringÅ@å≈íË

    public enum MoveType
    {
        RandomMove,
        PointMove,
        CircleMove
        //randomApoint,
        
    }

    public enum AttackType
    {
        NormalMagazine,
        FiveMagazine,
        CircleMagazine,
        //NumAttackType,
    }

    //public EnemyBase a;

    public MoveType[] moveType;
    public AttackType[] attackType;

    //public MoveType moveType = MoveType.random;
    //public AttackType attackType = AttackType.normal;

    public float Speed;
    public int HpMax;
    public int Hp;

    public float AtkInterval=1;
    //public float AtkRandTimeMax;
    //public float AtkRandTimeMin;
    //public int Attack;

    public bool FirstTargetPlayer=false;
}

[CreateAssetMenu(fileName = "EnemySetting", menuName = "Scriptable Objects/Enemy Setting")]
public class EnemySetting : ScriptableObject
{
    public List<EnemyData> DataList;
}
