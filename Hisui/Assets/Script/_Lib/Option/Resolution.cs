using System.Collections.Generic;
using System.Diagnostics;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Resolution : MonoBehaviour
{
    [SerializeField] Image min;
    [SerializeField] Image mid;
    [SerializeField] Image max;

    // メソッドの戻り値は void である必要があります
    //[Conditional("UNITY_EDITOR")]
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        int fullsc = PlayerPrefs.GetInt("ResoFull",0);
        bool isFull = true;
        if (fullsc == 0) isFull = false;

        Screen.SetResolution(
            PlayerPrefs.GetInt("ResoW", 1280), PlayerPrefs.GetInt("ResoH", 720), isFull);

        //mid.enabled = true;
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (Keyboard.current.digit1Key.wasPressedThisFrame)
    //    {

    //        // 例: 816×624のウィンドウモードで実行する場合
    //        Screen.SetResolution(816, 624, false);
    //        UnityEngine.Debug.Log("win 816×624");

    //        PlayerPrefs.SetInt("ResoW", 816);
    //        PlayerPrefs.SetInt("ResoH", 624);
    //        PlayerPrefs.GetInt("ResoFull", 0);

    //        PlayerPrefs.Save();
    //    }

    //    if (Keyboard.current.digit2Key.wasPressedThisFrame)
    //    {
    //        // 例: 1280x720のウィンドウモードで実行する場合
    //        Screen.SetResolution(1280, 720, false);
    //        UnityEngine.Debug.Log("win 1280");

    //        PlayerPrefs.SetInt("ResoW", 1280);
    //        PlayerPrefs.SetInt("ResoH", 720);
    //        PlayerPrefs.GetInt("ResoFull", 0);

    //        PlayerPrefs.Save();
    //    }

    //    if (Keyboard.current.digit3Key.wasPressedThisFrame)
    //    {
    //        // 例: 1920x1080のフルスクリーンで実行する場合
    //        Screen.SetResolution(1920, 1080, true);
    //        UnityEngine.Debug.Log("full 1920");

    //        PlayerPrefs.SetInt("ResoW", 1920);
    //        PlayerPrefs.SetInt("ResoH", 1080);
    //        PlayerPrefs.GetInt("ResoFull", 1);

    //        PlayerPrefs.Save();
    //    }
    //}

    public bool isFull=false;
    public void IsFull()
    {
        isFull = !isFull;

        Screen.SetResolution(
            PlayerPrefs.GetInt("ResoW", 1280), PlayerPrefs.GetInt("ResoH", 720), isFull);
        UnityEngine.Debug.Log("isFULL");


        int isFullNo = 0;
        if (isFull) isFullNo = 1;
        PlayerPrefs.SetInt("ResoFull", isFullNo);

        PlayerPrefs.Save();
    }

    public void Resolution816()
    {
        Screen.SetResolution(816, 624, isFull);
        UnityEngine.Debug.Log("win 816×624");

        PlayerPrefs.SetInt("ResoW", 816);
        PlayerPrefs.SetInt("ResoH", 624);
        //PlayerPrefs.SetInt("ResoFull", 0);

        //PlayerPrefs.Save();

        min.enabled = true;
        mid.enabled = false;
        max.enabled = false;

    }

    public void Resolution1280()
    {
        // 例: 1280x720のウィンドウモードで実行する場合
        Screen.SetResolution(1280, 720, isFull);
        UnityEngine.Debug.Log("win 1280");

        PlayerPrefs.SetInt("ResoW", 1280);
        PlayerPrefs.SetInt("ResoH", 720);
        //PlayerPrefs.SetInt("ResoFull", 0);

        //PlayerPrefs.Save();


        min.enabled = false;
        mid.enabled = true;
        max.enabled = false;

    }

    public void Resolution1920()
    {
        // 例: 1920x1080のフルスクリーンで実行する場合
        Screen.SetResolution(1920, 1080, isFull);
        UnityEngine.Debug.Log("full 1920");

        PlayerPrefs.SetInt("ResoW", 1920);
        PlayerPrefs.SetInt("ResoH", 1080);
        //PlayerPrefs.SetInt("ResoFull", 0);

        //PlayerPrefs.Save();


        min.enabled = false;
        mid.enabled = false;
        max.enabled = true;

    }

    public void Reset()
    {
        //int fullsc = PlayerPrefs.GetInt("ResoFull", 0);
        // bool isFull = true;
        //if (fullsc == 0) isFull = false;
        isFull = false;
        Screen.SetResolution(
            1280, 720, false);

        min.enabled = false;
        mid.enabled = true;
        max.enabled = false;
        //Screen.SetResolution(
        //    PlayerPrefs.GetInt("ResoW", 1280), PlayerPrefs.GetInt("ResoH", 720), isFull);
    }
}
