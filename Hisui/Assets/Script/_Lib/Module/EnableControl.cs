using System;
using UnityEngine;

public class EnableControl : MonoBehaviour
{
    //開始時に有効にするか無効にするか
    [SerializeField] bool enableTrueOrFalse;

    //それぞれのコンポーネントに対応 (デバッグ用など)
    [SerializeField] bool isSprite;
    [SerializeField] bool isBox2Col;
    [SerializeField] bool isBox3Col;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (isSprite)
            foreach (var c in gameObject.GetComponents<SpriteRenderer>())
                c.enabled = enableTrueOrFalse;

        if(isBox2Col)
            foreach (var c in gameObject.GetComponents<BoxCollider2D>())
                c.enabled = enableTrueOrFalse;

        if (isBox3Col)
            foreach (var c in gameObject.GetComponents<BoxCollider>())
                c.enabled = enableTrueOrFalse;

    }

}
