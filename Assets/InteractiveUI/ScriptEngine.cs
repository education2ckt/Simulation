using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Cinemachine;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ScriptEngine : MonoBehaviour
{
    [TextArea(3,10)]
    public string script;

    public static ScriptEngine engine;
    public GameObject[] cameras;
    public Canvas dialog;
    public Canvas video;
    public Canvas image;

    public Canvas info;

    private bool isNext = false;
    // Start is called before the first frame update
    void Start()
    {
       engine = this;
    }

    IEnumerator _Run(string name) {
        GameObject target = null;
        for(int i = 0; i < cameras.Length; i++) {
            cameras[i].SetActive(false);
            if ( cameras[i].name == name ) {
                target = cameras[i];
                break;
            }
        }
        if ( target != null) {            
            float old = CinemachineCore.Instance.GetActiveBrain(0).m_DefaultBlend.m_Time;
            if (name == "CM vcam2" )
                CinemachineCore.Instance.GetActiveBrain(0).m_DefaultBlend.m_Time = 0;
            target.SetActive(true);
            yield return new WaitForSeconds(old);
            CinemachineCore.Instance.GetActiveBrain(0).m_DefaultBlend.m_Time = old;
        }

        yield return null;
    }

    // Update is called once per frame


    public IEnumerator executeScript(string script) {

        
        
        string[] lines = script.Split(';');
        foreach(string line in lines) {
            string l = line.Replace('(', ',');
            l = l.Replace(')',' ');
            print(l);
            string[] tokens = l.Split(',');
            string cmd = tokens[0].Trim();
            if ( cmd == "wait" )  {                
                float p1;
                if ( float.TryParse(tokens[1], out p1) )
                    yield return new WaitForSeconds(p1);
                else while ( ! isNext) yield return null;
            } else if ( cmd == "camera") {
                string name = tokens[1].Trim();
                float p1;
                if (  float.TryParse(name, out p1)  ) {
                        CinemachineCore.Instance.GetActiveBrain(0).m_DefaultBlend.m_Time = p1;
                } else {
                    if (name == "") {
                        current.SetActive(true);
                    }
                    else {
                        current = (CinemachineCore.Instance.GetActiveBrain(0).ActiveVirtualCamera as CinemachineVirtualCamera).gameObject;
                        findCamera(name).SetActive(true);
                    }
                }
            } else if ( cmd == "dialog" ) { // dialog(char3,안녕!!!!,-1)
                dialog.enabled = true;        
                dialog.transform.Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>(tokens[1].Trim());        
                dialog.transform.Find("Text").GetComponent<Text>().text = tokens[2].Trim();
                float p1 = float.Parse(tokens[3].Trim());
                if ( p1 < 0 ) while ( ! isNext) yield return null;
                else yield return new WaitForSeconds(p1);
                isNext = false;                
                dialog.enabled = false;
            } else if ( cmd == "video") {
                string p1 = tokens[1].Trim();
                if ( p1 == "play" )  {                    
                    string p2 = tokens[2].Trim();                                
                    video.gameObject.GetComponent<VideoPlayer>().clip = Resources.Load<VideoClip>(p2) as VideoClip;
                    video.gameObject.SetActive(true);
                    video.gameObject.GetComponent<VideoPlayer>().Play();
                } else if ( p1 == "stop") {
                    video.gameObject.GetComponent<VideoPlayer>().Stop();
                    video.gameObject.SetActive(false);
                } 
            } else if ( cmd == "info" ) {
                info.enabled = true;        
                info.transform.Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>(tokens[1].Trim());        
                info.transform.Find("Text").GetComponent<Text>().text = tokens[2].Trim();
                float p1 = float.Parse(tokens[3].Trim());
                if ( p1 < 0 ) while ( ! isNext) yield return null;
                else yield return new WaitForSeconds(p1);
                isNext = false;                
                info.enabled = false;
            } else if ( cmd == "image") {  // image(background,[배경]안녕,fill,3)
                string p1 = tokens[1].Trim();
                if ( p1 == "hide" ) {
                    image.enabled = false;                    
                } else{
                    
                    Image front = image.transform.Find("Front").GetComponent<Image>();
                    Image back = image.transform.Find("Back").GetComponent<Image>();
                    Text text = image.transform.Find("Text").GetComponent<Text>();
                    
                    back.sprite = old;
                    back.type = Image.Type.Simple;
                    image.enabled = true;                        
                    
                    string p2 = tokens[2].Trim();
                    string p3 = tokens[3].Trim();                    
                    float p4 = float.Parse(tokens[4].Trim());
                    text.text = p2;
                    front.sprite = Resources.Load<Sprite>(p1);
                    old = front.sprite;
                    if ( p3 == "no")  {
                        yield return new WaitForSeconds(p4);
                    } else if ( p3 == "fill" ) {                        
                        front.type = Image.Type.Filled;
                        front.fillMethod = Image.FillMethod.Radial360;
                        front.fillAmount = 0f;
                        while (front.fillAmount < 1.0f) {
                            front.fillAmount += Time.deltaTime / p4;
                            yield return null;
                        }
                    }else if ( p3 == "fade" ) {                        
                        Color color = front.color;
                        color.a = 0.0f;
                        while (color.a < 1.0f) {
                            color.a += Time.deltaTime / 3.0f;
                            front.color = color;
                            yield return null;
                        }
                    }
                }                
            }
        }
        yield return null;
    }

    private GameObject current;
    private Sprite old;
    

    GameObject findCamera(string name) {
        GameObject target = null;
        for(int i = 0; i < cameras.Length; i++) {
            cameras[i].SetActive(false);
            if ( cameras[i].name == name ) {
                target = cameras[i];
                break;
            }
        }
        return target;
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

    
    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.X) ) isNext = true;        
    }
    
    
}
