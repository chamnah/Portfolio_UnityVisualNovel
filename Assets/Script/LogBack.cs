using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogBack : MonoBehaviour {

    private GameObject game;
    private GameObject Routine;
    private Routine routine;

    // Use this for initialization
    void Start () {
        game = GameObject.FindGameObjectWithTag("Log");
        Routine = GameObject.FindGameObjectWithTag("Routine");
        routine = Routine.GetComponent<Routine>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        routine.bButton = true;
        Destroy(game);
    }
}