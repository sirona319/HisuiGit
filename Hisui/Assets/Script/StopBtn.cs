using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class StopBtn : MonoBehaviour
{
    [SerializeField] GameObject bc;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bc.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //タイム
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (Time.timeScale == 0f)
            {
                Time.timeScale = 1.0f;
                bc.SetActive(false);

            }
            else
            {
                Time.timeScale = 0f;

                bc.SetActive(true);


                //UI表示　　
                //文字表示　　タイトルへ　　　左右クリック　　スペースパリイ赤バリア　ビーム後半？

            }
        }
    }
}
