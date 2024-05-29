using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiTest : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;
    public Image image;
    public Sprite[] sprites;
    
    void Start()
    {
        text.text = "안녕하세요";
        image.sprite = sprites[2];
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
