using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Save : SaveButton
{
    private GameObject desgame;
    private Routine routine;
    private GameObject Routine;

    // Use this for initialization
    void Start () {
        Routine = GameObject.FindGameObjectWithTag("Routine");
        routine = Routine.GetComponent<Routine>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        //PlayerPrefs.DeleteKey("SaveCount" + iCurrentCount.ToString());
        //PlayerPrefs.DeleteKey("SaveGirl" + iCurrentCount.ToString());
        //PlayerPrefs.DeleteKey("SaveBack" + iCurrentCount.ToString());
        PlayerPrefs.SetInt("SaveCount"+ UIManager.GetInstance().iSCount.ToString(), UIManager.GetInstance().iCount);
        PlayerPrefs.SetInt("SaveGirl" + UIManager.GetInstance().iSCount.ToString(), UIManager.GetInstance().animGirl.GetBool("Alpha") ? 1 : 0);
        PlayerPrefs.SetInt("SaveGirlCount" + UIManager.GetInstance().iSCount.ToString(), UIManager.GetInstance().iGCount);
        PlayerPrefs.SetInt("SaveBack" + UIManager.GetInstance().iSCount.ToString(), UIManager.GetInstance().animBack.GetBool("Alpha") ? 1 : 0);
        PlayerPrefs.SetInt("SaveBackCount" + UIManager.GetInstance().iSCount.ToString(), UIManager.GetInstance().iBCount);
        PlayerPrefs.SetInt("SaveEnding" + UIManager.GetInstance().iSCount.ToString(), (int)(UIManager.GetInstance().ending));
        desgame = GameObject.FindGameObjectWithTag("Log");
        Destroy(desgame);
        if(UIManager.GetInstance().iSCount < UIManager.GetInstance().listSave.Count)
        UIManager.GetInstance().listSave.RemoveAt(UIManager.GetInstance().iSCount);
        UIManager.GetInstance().listSave.Insert(UIManager.GetInstance().iSCount, new UIManager.sSave(UIManager.GetInstance().animGirl.GetBool("Alpha"), UIManager.GetInstance().animBack.GetBool("Alpha"), UIManager.GetInstance().iCount, UIManager.GetInstance().ending, UIManager.GetInstance().iGCount, UIManager.GetInstance().iBCount));
        //UIManager.GetInstance().listSave[UIManager.GetInstance().iSCount] = new UIManager.sSave(UIManager.GetInstance().animGirl.GetBool("Alpha"), UIManager.GetInstance().animBack.GetBool("Alpha"), UIManager.GetInstance().iCount, UIManager.GetInstance().ending, UIManager.GetInstance().iGCount, UIManager.GetInstance().iBCount);
        //ScreenCapture.CaptureScreenshot("Assets/Resources/Data/screen" + UIManager.GetInstance().iSCount.ToString() + ".jpg");
        routine.bButton = true;
    }

    public void OnLeft()
    {
        if (UIManager.GetInstance().iSCount != 0)
        {
            --UIManager.GetInstance().iSCount;
            Debug.Log(UIManager.GetInstance().iSCount);

            if (PlayerPrefs.HasKey("SaveCount" + UIManager.GetInstance().iSCount.ToString()) && UIManager.GetInstance().listSave[UIManager.GetInstance().iSCount].iBCount != -1)
                GameObject.FindGameObjectWithTag("SaveView").GetComponent<Image>().sprite =
                    UIManager.GetInstance().listBack[UIManager.GetInstance().listSave[UIManager.GetInstance().iSCount].iBCount];
        }
    }
    
    public void OnRight()
    {
        if (PlayerPrefs.HasKey("SaveCount" + UIManager.GetInstance().iSCount.ToString()))
        {
            ++UIManager.GetInstance().iSCount;
            Debug.Log(UIManager.GetInstance().iSCount);
            if (PlayerPrefs.HasKey("SaveCount" + UIManager.GetInstance().iSCount.ToString()) && UIManager.GetInstance().listSave[UIManager.GetInstance().iSCount].iBCount != -1)
                GameObject.FindGameObjectWithTag("SaveView").GetComponent<Image>().sprite =
                    UIManager.GetInstance().listBack[UIManager.GetInstance().listSave[UIManager.GetInstance().iSCount].iBCount];
            else
                GameObject.FindGameObjectWithTag("SaveView").GetComponent<Image>().sprite = null;
        }
    }

    public void OnClear()
    {
        PlayerPrefs.DeleteAll();
        GameObject.FindGameObjectWithTag("SaveView").GetComponent<Image>().sprite = null;
    }

    public void Load()
    {
        desgame = GameObject.FindGameObjectWithTag("Log");
        Destroy(desgame);
        routine.bButton = true;

        UIManager.GetInstance().animBack.SetBool("Alpha",true);
        UIManager.GetInstance().animGirl.SetBool("Alpha", true);
        UIManager.GetInstance().StopAnim(3f);
        if(UIManager.GetInstance().listSave[UIManager.GetInstance().iSCount].bBack)
        {
            UIManager.GetInstance().animBack.SetBool("Alpha", false);
            if (UIManager.GetInstance().listSave[UIManager.GetInstance().iSCount].bGirl)
            {
                UIManager.GetInstance().animGirl.SetBool("Alpha", false);
            }
        }
    }
}