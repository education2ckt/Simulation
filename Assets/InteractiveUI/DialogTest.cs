using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DialogTest : MonoBehaviour
{

    public static DialogTest dt;

    public static bool isNext = false;
    public static bool isFinish = false;

    public Canvas dialog;
    // Start is called before the first frame update
    void Start()
    {
        dt = this;
        Dictionary<string, string[]> map = LoadScript("script0");        
        GameObject[] objs  = GameObject.FindGameObjectsWithTag("event0");    
        foreach(GameObject o in objs)  {
            o.GetComponent<DialogEventDetector>().script = map[o.name];
        }
    }

    void Update()
    {
        if ( Input.GetKeyDown(  KeyCode.X)  ) { isNext = true; }
    }

    public void OnClickMessage() {
        StartCoroutine(ShowDialog());
    }

    public void OnClickMessages() {
        StartCoroutine(ShowDialog2());
    }

    public void OnClickScript() {
        string[] script = {"char3,안녕!!\n누구야?",  "char3,오늘 날씨?", "char1,몰라요"};
        StartCoroutine(ShowDialog3(script));        
    }


    IEnumerator ShowDialog() {
        dialog.enabled = true;
        dialog.transform.Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>( "char3" );
        dialog.transform.Find("Text").GetComponent<Text>().text = "hello!!!\n또바";
        while ( ! isNext) { 
            yield return null;
        }     
        dialog.enabled = false;
        yield return null;
    }

    IEnumerator ShowDialog2() {
        dialog.enabled = true;
        dialog.transform.Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>( "char3" );
        string[] contents = {"111", "2222", "3333"};
        for(int n = 0 ; n < contents.Length; n++) {
            dialog.transform.Find("Text").GetComponent<Text>().text = contents[n];
            while ( ! isNext) yield return null;
            isNext = false;
        }
        dialog.enabled = false;
        yield return null;
    }

    public IEnumerator ShowDialog3(string[] script) {
        dialog.enabled = true;        
        for(int n = 0 ; n < script.Length; n++) {
            string[] token = script[n].Split(',');            
            dialog.transform.Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>(token[0].Trim());        
            dialog.transform.Find("Text").GetComponent<Text>().text = token[1].Trim();
            while ( ! isNext) yield return null;
            isNext = false;
        }
        dialog.enabled = false;
        yield return null;
    }


    public Dictionary<string, string[]> LoadScript(string filename) {
        TextAsset lines = Resources.Load(filename) as TextAsset;      
        Dictionary<string, string[]> map = new  Dictionary<string, string[]>();  

        string id = "";

        List<string> list = new List<string>();
        foreach(string line in lines.text.Split('\n') ) {
            if ( line.IndexOf("#") >= 0 )  {
                if (id != "" )  {
                    map.Add(id,  list.ToArray() );
                    list.Clear();
                }
                id = line.Replace("#", "").Trim();
            }
            else if ( line.Length > 4  ) {
                list.Add(line.Trim());
            }
        }        
        map.Add(id, list.ToArray() );
        return map;
    }
}