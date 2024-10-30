using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyDamageUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textUI;
    //Transform transUI;

    void Start()
    {
        textUI.DOFade(0, 0);
        //transUI = textUI.gameObject.transform;
    }

    void LateUpdate()
    {
        transform.rotation = Camera.main.transform.rotation;
    }

    //void Update()
    //{
    //    //if(Input.GetKeyDown(KeyCode.Z))
    //    //{
    //    //    DamegeView(1);
    //    //}
    //}

    public void DamegeView(int damage)
    {

        //textUI.enabled = true;
        textUI.text = "-" + damage.ToString();

        textUI.DOFade(1, 0f);
        textUI.DOFade(0, 1f);

        //StartCoroutine(MyLib.DelayCoroutine(1.0f, () =>
        //{
        //textUI.enabled = false;
        //textUI.DOFade(1, 0);
        //}));
    }
}

