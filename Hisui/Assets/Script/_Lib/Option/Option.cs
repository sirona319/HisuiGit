using Unity.VectorGraphics;
using UnityEngine;

public class Option : MonoBehaviour
{
    [SerializeField] GameObject optionBtn;

    void Start()
    {
        //optionBtn.SetActive(false);
    }
    public void ResetBtn()
    {

       // Screen.SetResolution(
       //     1280, 720, false);
        GetComponent<Resolution>().Reset();

        GetComponent<SoundOption>().Reset();

        PlayerPrefs.DeleteAll();
    }

    public void End()
    {

        optionBtn.SetActive(false);
        //Escが押された時
        //if (Keyboard.current.escapeKey.wasPressedThisFrame)
        //{
        PlayerPrefs.Save();

#if UNITY_EDITOR
        //UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    //Application.Quit();//ゲームプレイ終了
#endif
        // }
    }


    public void OptionOn()
    {
        optionBtn.SetActive(true);
    }
}
