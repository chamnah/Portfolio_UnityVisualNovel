using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour {

    public Animator animOpt;

    private GameObject op;
    //private OptionButton option;
    private GameObject game;
    private GameObject Root;
    private Vector3 pos;
    private GameObject Routine;
    private Routine routine;

    // Use this for initialization
    void Start ()
    {
        Routine = GameObject.FindGameObjectWithTag("Routine");
        routine = Routine.GetComponent<Routine>();

        Root = GameObject.FindGameObjectWithTag("Root");
        op = GameObject.FindGameObjectWithTag("Option");
        pos = op.transform.position;
        //option = op.GetComponent<OptionButton>();
        game = Resources.Load("Prefeb/OptionButton") as GameObject;
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
            StartCoroutine(Hide());
        }
    }

    IEnumerator Hide()
    {
        yield return new WaitForSeconds(1f);
        GameObject child;

        child = Instantiate(game);
        routine.bClick = false;
        child.transform.SetParent(Root.transform);
        child.transform.localScale = new Vector3(1f, 1f, 1f);
        child.transform.position = pos;

        yield return null;
    }
} 