using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Select : MonoBehaviour {

    private static Select Instance;

    public static Select GetInstance()
    {
        if (Instance == null)
        {
            Instance = FindObjectOfType<Select>();
        }

        return Instance;
    }

    GameObject[] gameObjects;
    private bool bIs;
    private bool bClick;
    private bool bMove;
    private bool bChange;
    public GameObject Root;
    GameObject game;
    GameObject game1;
    private string text;
    private string text1;
    // Use this for initialization
    void Start ()
    {
        bMove = true;
        bIs = false;
        bClick = false;
        bChange = false;
        game = Resources.Load("Prefeb/Select") as GameObject;
        game1 = Resources.Load("Prefeb/Select") as GameObject;
    }

    // Update is called once per frame
    void Update () {
        if (bIs)
        {
            bMove = false;

            GameObject child = Instantiate(game);
            child.transform.localPosition = new Vector3(0, 2, 0);
            child.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            child.transform.SetParent(Root.transform);
            child.GetComponentInChildren<Text>().text = text;
            if(!bChange)
            child.GetComponent<Click>().Enter = true;
            else
                child.GetComponent<Click>().Enter = false;
            child = Instantiate(game1);
            child.transform.position = new Vector3(0, 0, 0);
            child.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            child.transform.SetParent(Root.transform);
            child.GetComponentInChildren<Text>().text = text1;

            if (!bChange)
                child.GetComponent<Click>().Enter = false;
            else
                child.GetComponent<Click>().Enter = true;

            bIs = false;
        }
	}

    public void OnClick()
    {
        bIs = false;
    }

    public void SetSelect(bool _select,string _text,string _text1,bool _change)
    {
        text = _text;
        text1 = _text1;
        bIs = _select;
        bChange = _change;

    }

    public bool GetSelect()
    {
        return bIs;
    }

    public bool GetClick()
    {
        return bClick;
    }

    public void SetClick(bool _click)
    {
        bClick = _click;
        bMove = true;
        gameObjects = GameObject.FindGameObjectsWithTag("Select");
        for (int i =0; i < gameObjects.Length;++i)
        {
            Destroy(gameObjects[i]);
        }
    }

    public bool GetDonMove()
    {
        return bMove;
    }
}   