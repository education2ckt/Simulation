using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    public Canvas dialog;    
    public Canvas background;    


    public Sprite[] sprites;
    public static DialogSystem ds;

    
    // Start is called before the first frame update
    void Start()
    {
        ds = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show(string[] message) {
        // 이미 진행중이면 새로운 메시지는 무시한다.
        //if (! dialog.enabled ) StartCoroutine(_Show(message));
        StartCoroutine(_Show(message));
    }

    public void Show(string message) {
        string[] messages = {message};
        StartCoroutine(_Show(messages));
    }

    IEnumerator _Show(string[] messages) {

        Text text = dialog.transform.Find("Text").GetComponent<Text>();
        dialog.enabled = true;
        foreach(string message in messages) {
            text.text = message;
            yield return new WaitForSeconds(2);
        }        
        dialog.enabled = false;
    }

    public void ShowImage() {

        StartCoroutine(_ShowImage());
    }

    IEnumerator _ShowImage() {
        background.enabled = true;

        Image image  = background.transform.Find("Image").GetComponent<Image>();
        Text text  = background.transform.Find("Text").GetComponent<Text>();
        for(int i=0; i  < 3; i++) {
            image.sprite = sprites[i];
             Color color = image.color;
             color.a = 0.0f;
            while (color.a < 1.0f)
            {
                color.a += Time.deltaTime / 1.5f;
                image.color = color;
                yield return null;
            }
            text.text = "여기는 배경이야기 입니다.^^^^";
            yield return new WaitForSeconds(3);
        }
        background.enabled = false;
    }
    
}
