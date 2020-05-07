using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadButton : MonoBehaviour {

    private GameObject game;
    private GameObject game2;
    private GameObject Root;
    public Animator animOpt;
    private Vector3 pos;
    private GameObject op;
    private Image sp;

    // Use this for initialization
    void Start () {
        game = Resources.Load("Prefeb/Load") as GameObject;
        game2 = Resources.Load("Prefeb/OptionButton") as GameObject;
        Root = GameObject.FindGameObjectWithTag("Root");
        op = GameObject.FindGameObjectWithTag("Option");
        pos = op.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        if (UIManager.GetInstance().iCount != PlayerPrefs.GetInt("Save"))
        {
            UIManager.GetInstance().SetButton(false); // 이건 일단 보류
            UIManager.GetInstance().iCount = PlayerPrefs.GetInt("Save");
            UIManager.GetInstance().Load();
        }
    }

    public void OnLoad()
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
}