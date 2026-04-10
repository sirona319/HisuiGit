using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.UI
{
    public class CursolScr : MonoBehaviour
    {
        //enum SelectState
        //{
        //    Retry,
        //    Title,
        //    NULL
        //}
        //[SerializeField] SelectState selectState;

        //[SerializeField] SceneChangeClick retry;
        //[SerializeField] SceneChangeClick title;

        [SerializeField] Image upImage;
        [SerializeField] Image downImage;
        //[SerializeField] public Vector3 retryPos;
        //[SerializeField] public Vector3 titlePos;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //if(retry.isEnable)
            //{
            //    upImage.enabled = true;
            //    downImage.enabled = false;
            //    //GetComponent<Image>().enabled = true;
            //    //RectTransform rectTransform = GetComponent<RectTransform>();
            //    //var pos=gameObject.GetComponent<RectTransform>().position;
            //    //pos.y = retryPos.y;
            //    //gameObject.GetComponent<RectTransform>().position = pos;
            //    //transform.localPosition = Vector3.Lerp(transform.localPosition, retryPos, 0.1f);
            //}
            //else if(title.isEnable)
            //{
            //    downImage.enabled = true;
            //    upImage.enabled = false;

            //    // GetComponent<Image>().enabled = true;

            //    //var rectTransform = GetComponent<RectTransform>();
            //    //rectTransform.position = titlePos;

            //    //transform.localPosition = Vector3.Lerp(transform.localPosition, titlePos, 0.1f);
            //}
        }

        public void RetryEnable()
        {
            upImage.enabled = true;
            downImage.enabled = false;
        }

        public void TitleEnable()
        {
            downImage.enabled = true;
            upImage.enabled = false;
        }
    }
}