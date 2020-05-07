using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SaveButton : MonoBehaviour {

    private GameObject game;
    private GameObject game2;
    private GameObject Root;
    public Animator animOpt;
    private Vector3 pos;
    private GameObject op;
    private Image sp;

    // Use this for initialization
    void Start () {
        AddList();
        game = Resources.Load("Prefeb/Save") as GameObject;
        game2 = Resources.Load("Prefeb/OptionButton") as GameObject;
        Root = GameObject.FindGameObjectWithTag("Root");
        op = GameObject.FindGameObjectWithTag("Option");
        pos = op.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void OnView()
    {
        UIManager.GetInstance().iSCount = 0;
        if (!animOpt.GetBool("Hide"))
        {
            animOpt.SetBool("Hide", true);

            GameObject child;

            child = Instantiate(game2);
            child.transform.SetParent(Root.transform);
            child.transform.localScale = new Vector3(1f, 1f, 1f);
            child.transform.position = pos;

            GameObject ob;
            ob = Instantiate(game);
            ob.transform.SetParent(Root.transform);
            ob.transform.localScale = new Vector3(1f, 1f, 1f);

            sp = GameObject.FindGameObjectWithTag("SaveView").GetComponent<Image>();
            //sp.sprite = Resources.Load<Sprite>("Data/screen" + iCurrentCount.ToString());// 리소스 파일명 확장자 No
            if (PlayerPrefs.HasKey("SaveBack0") && PlayerPrefs.GetInt("SaveBackCount0") != -1)
            {
                int iNum = PlayerPrefs.GetInt("SaveBackCount0");
                sp.sprite = UIManager.GetInstance().listBack[iNum];
            }
            else
            {
                sp.sprite = null;
            }
        }
    }

    public void AddList()
    {
        UIManager.GetInstance().listSave.Clear();
        int i = 0;
        bool bGirl = false;
        bool bBack = false;
        while (true)
        {
            if (PlayerPrefs.HasKey("SaveBack" + i.ToString()))
            {
                bBack = true;
                if (PlayerPrefs.GetInt("SaveBack" + i.ToString()) == 0)
                {
                    if (PlayerPrefs.GetInt("SaveGirl" + i.ToString()) == 0)
                        bGirl = true;
                        
                    else
                        bGirl = false;
                }
                else
                    bBack = false;

                UIManager.GetInstance().listSave.Insert(i, new UIManager.sSave(bGirl, bBack, PlayerPrefs.GetInt("SaveCount" + i.ToString()), (UIManager.Ending)PlayerPrefs.GetInt("SaveEnding" + i.ToString()), PlayerPrefs.GetInt("SaveGirlCount" + i.ToString()), PlayerPrefs.GetInt("SaveBackCount" + i.ToString())));
            }
            else
                break;

            i++;
        }
    }
}