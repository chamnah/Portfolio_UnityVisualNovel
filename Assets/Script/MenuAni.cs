using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAni : MonoBehaviour {

    public Animator[] animMenuBack;
    public Animator animLine;


    // Use this for initialization
    private void Awake()
    {
        animMenuBack[0].SetBool("Alpha", true);
        animMenuBack[2].SetBool("Alpha", true);
        animMenuBack[3].SetBool("Alpha", true);
        animMenuBack[4].SetBool("Alpha", true);
        animMenuBack[5].SetBool("Alpha", true);
    }

    void Start () {
        animMenuBack[0].SetBool("Alpha", false);
        StartCoroutine(Line());
    }
	
	// Update is called once per frame
	void Update ()
    {
	}

    private IEnumerator Line()
    {
        yield return new WaitForSeconds(4f);

        animMenuBack[1].SetBool("Size",true);

        yield return new WaitForSeconds(1f);

        animMenuBack[2].SetBool("Alpha", false);
        animMenuBack[3].SetBool("Alpha", false);
        animMenuBack[4].SetBool("Alpha", false);
        animMenuBack[5].SetBool("Alpha", false);

        yield return null;
    }
}