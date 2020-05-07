using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogButton : MonoBehaviour {

    public Animator animOpt;

    private GameObject op;
    //private OptionButton option;
    private GameObject game;
    private GameObject game2;
    private GameObject Root;
    private Vector3 pos;

    // Use this for initialization
    void Start ()
    {
        Root = GameObject.FindGameObjectWithTag("Root");
        op = GameObject.FindGameObjectWithTag("Option");
        pos = op.transform.position;
        game = Resources.Load("Prefeb/OptionButton") as GameObject;
        game2 = Resources.Load("Prefeb/Image") as GameObject;
    }
	
	// Update is called once per frame
	void Update ()
    {	
	}

    public void OnClick()
    {
        if (!animOpt.GetBool("Hide"))
        {
            animOpt.SetBool("Hide", true);

            GameObject child;

            child = Instantiate(game);
            child.transform.SetParent(Root.transform);
            child.transform.localScale = new Vector3(1f, 1f, 1f);
            child.transform.position = pos;

            GameObject child2;
            child2 = Instantiate(game2);
            child2.transform.SetParent(Root.transform);
            child2.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
} 