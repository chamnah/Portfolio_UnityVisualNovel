using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class Routine : MonoBehaviour {
    [TextArea(1,2)]
    private string[] talk;
    public Sprite[] sprites;
    public Sprite[] spriteBack;
    public AudioClip[] audioList;
    public Sprite[] spritePhone;

    public bool bClick = false;
    public bool bDrag = false;

    public bool bButton = false;

    private void Start()
    {
        //string[] talk = System.IO.File.ReadAllLines("Assets\\Resources\\Ending1.txt", System.Text.Encoding.Default);
        TextAsset    textAsset = Resources.Load("Ending1", typeof(TextAsset)) as TextAsset;

        StringReader sr = new StringReader(textAsset.text);

        string tell = sr.ReadLine();
        //string[] value = null;

        //파일열고 읽어 저장, 라인별로 배열에 저장됨
        //for (int i = 0; i < talk.Length; i++)
        //    Debug.Log(i + " " + talk[i]);
        
        while (tell != null)
        {
            //value = tell.Split('/');
            UIManager.GetInstance().SetListText(tell);
            tell = sr.ReadLine();
        }

        sr.Close();

        /*for (int i = 0; i < talk.Length; ++i)
        {
            UIManager.GetInstance().SetListText(talk[i]);
        }*/

        UIManager.GetInstance().bStart = true;
        UIManager.GetInstance().SetIamgeGirl(sprites);
        UIManager.GetInstance().SetIamgeBack(spriteBack);
        UIManager.GetInstance().SetClip(audioList);
        UIManager.GetInstance().SetImagePhone(spritePhone);
    }

    private void OnMouseUp()
    {
        
    }

    private void Update()
    {   
        if (!bDrag && !bClick)
        {
            if (UIManager.GetInstance().GetButton() && Select.GetInstance().GetDonMove())
            {
                if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.RightArrow))
                {
                    UIManager.GetInstance().SetCount();
                }
                else if (UIManager.GetInstance().iCount > 0 && (Input.GetKeyUp(KeyCode.LeftArrow) || (Input.GetKeyUp(KeyCode.Backspace))))
                {
                    UIManager.GetInstance().iCount--;
                    if (UIManager.GetInstance().iCount > 1)
                        UIManager.GetInstance().iCount--;
                    UIManager.GetInstance().SetCount();
                }
            }
        }

        if(bButton)
        {
            bButton = false;
            StartCoroutine(WaitClick());
        }

        //if (option.bClick)
        //    option.bClick = false;
        if (bDrag)
            bDrag = false;
    }

    IEnumerator WaitClick()
    {
        yield return new WaitForSeconds(0.5f);
        bClick = false;
        yield return null;
    }
}       