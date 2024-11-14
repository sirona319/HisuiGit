//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEditor;

//[CustomEditor(typeof(EnemyData))]
//public class FieldTestEditor : Editor
//{
//    public override void OnInspectorGUI()
//    {
//        base.OnInspectorGUI();

//        EnemyData instance = target as EnemyData;

//        if(instance.moveType == EnemyData.MoveType.PointMove) 
//        {
//                instance.MyDeadTime = EditorGUILayout.FloatField("MyDeadTime", instance.MyDeadTime);
//        }
//    }


//}
