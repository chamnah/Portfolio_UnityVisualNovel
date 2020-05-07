using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionButton : MonoBehaviour {


    private Image image;
    private GameObject OpCon;
    private GameObject Routine;
    private Routine routine;
    private Animator aniOption;

    // Use this for initialization
    void Start () {
        OpCon = GameObject.FindGameObjectWithTag("OptionContent");
        Routine = GameObject.FindGameObjectWithTag("Routine");
        routine = Routine.GetComponent<Routine>();
        aniOption = OpCon.GetComponent<Animator>();
        image = GetComponent<Image>();
      
        aniOption.SetBool("Hide", true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void pointclick()
    {
        Destroy(this.gameObject);
        routine.bClick = true;
        aniOption.SetBool("Hide", false);
    }

    public void Hideclick()
    {
        routine.bClick = true;
        aniOption.SetBool("Hide", true);
    }

    public void pointup()
    {
        image.color = new Color(1,0,0);
    }

    public void drag()
    {
        //bDrag = true;
        image.color = new Color(0, 1, 0);
    }

    public void EndDrag()
    {
        routine.bDrag = true;
        image.color = new Color(0, 0, 1);
    }
}