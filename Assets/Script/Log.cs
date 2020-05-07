using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Log : MonoBehaviour {

    private Text text;
    private bool bView = true;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();

    }
	
	// Update is called once per frame
	void Update () {
        if(bView)
        {
            View();
            bView = false;
        }
    }

    void View()
    {
        for (int i = 0; i < UIManager.GetInstance().listLog.Count; ++i)
        {
            text.text += UIManager.GetInstance().listLog[i] + "\n";
        }
    }
}