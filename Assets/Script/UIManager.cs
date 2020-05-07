using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class UIManager : MonoBehaviour {

    public enum Ending
    {
        One,
        Two,
        Three
    }


    public struct sSave // 저장 구조체
    {
        public bool bGirl;
        public int  iGCount;
        public bool bBack;
        public int iBCount;
        public int iCount;
        public Ending eEnding;
        public sSave(bool _girl,bool _back, int _count,Ending _ending, int _g_count, int _b_count)
        {
            this.bGirl = _girl;
            this.bBack = _back;
            this.iCount = _count;
            this.eEnding = _ending;
            this.iGCount = _g_count;
            this.iBCount = _b_count;
        }

        public static explicit operator sSave(int v)
        {
            throw new NotImplementedException();
        }
    }

    private static UIManager Instance;

    private List<string> listText = new List<string>();
    private List<string> listText2 = new List<string>();
    public List<string> listLog = new List<string>();
    public List<Sprite> listSprite = new List<Sprite>();
    public List<Sprite> listBack = new List<Sprite>();
    public List<Sprite> listPhone = new List<Sprite>();
    private List<AudioClip> listClip = new List<AudioClip>();
    public List<sSave> listSave = new List<sSave>();


    public bool bStart;
    public Animator animGirl;
    public Animator animBack;
    public Animator animTalk;
    public Animator animLoad;
    public Animator animPhone;
    public Text text;
    public Text Name;
    public Image imageGirl;
    public Image imageBack;
    public Image imageLoad;
    public Image imagePhone;
    public int iCount = 0;
    private bool bEnd = false; // 텍스트 끝남 여부
    private bool bAni = false;
    private int iNext = 0;
    private AudioSource AudioManager;
    private bool bButton = true;
    private bool bLoad = false;
    public Slider sVolume;
    public int iSCount = 0;
    public int iGCount = -1;
    public int iBCount = -1;

    public Animator animPA;

    private CountAni CA;

    public float fTexSpeed = 0.05f;

    // 로드 변수
    private bool bBack;
    private bool bGirl;

    public Ending ending = Ending.One;

    public static UIManager GetInstance()
    {
        if(Instance == null)
        {
            Instance = FindObjectOfType<UIManager>();
            if(Instance == null)
            {
                GameObject container = new GameObject("UIManager");
                Instance = container.AddComponent<UIManager>();
            }
        }

        return Instance;
    }

    // Use this for initialization
    void Start () {
        bStart = true;
        animBack.SetBool("Alpha",true);
        animBack.SetBool("NowAlpha", false);
        animGirl.SetBool("Alpha", true);
        animTalk.SetBool("Alpha", false);
        animLoad.SetBool("End", false);
        animPhone.SetBool("Hide", true);
        animPhone.SetBool("Alpha", false);
        animPA.SetBool("Alpha", false);
        text.text = "";
        bBack = false;
        bGirl = false;
        animPA.SetBool("Size",false);
        imageGirl.sprite = listSprite[0];
        AudioManager = GetComponent<AudioSource>();
        CA =  this.GetComponent<CountAni>() as CountAni;
        sVolume.value = 1f;
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        AudioManager.volume = sVolume.value;

        if (bStart)
        {
            //text.color = new Color(1, 1, 1);
            StartCoroutine(StartText());
        }
    }

    public void MusicPlay(int iNum)
    {
        AudioManager.clip = listClip[iNum];
        AudioManager.Play();
    }

    public void MusicStop()
    {
        AudioManager.Stop();
    }

    public void SetCountNum(int iNum)
    {
        iCount = iNum;
    }

    public void SetCount()
    {
        if (!bStart && !bAni)
        {
            if (bEnd)
            {
                listLog.Add(listText[iCount]);
                bEnd = false;
                iCount++;
                text.text = "";
                StopAllCoroutines();
                StartCoroutine(Routine());
            }
            else if (!bEnd)
            {
                StopAllCoroutines();
                text.text = "";
                text.text = listText[iCount];
                bEnd = true;
            }

            if (ending == Ending.One)
            {
                CA.Ani(iCount);
                iGCount = CA.GirlFace(iCount);
                CA.EffectSound(iCount);
            }
            else if (ending == Ending.Two)
            {
                CA.Ani2(iCount);
                iGCount = CA.GirlFace2(iCount);
                CA.EffectSound2(iCount);
            }
            else if (ending == Ending.Three)
                CA.Ani3(iCount);
        }
    }

    public void Load() // 로딩
    {
        text.text = "";

        bLoad = true;
        bAni = true;
        
        CA.GirlFace(iCount);

        if (iCount >= 2)
        {
            bBack = true;
        }

        if (iCount == 9)
        {
            animBack.SetBool("Move", true);
            StartCoroutine(StopAnim(0.5f));
        }

        if (iCount >= 38)
        {
            bBack = false;
        }

        if (iCount >= 49)
        {
            bBack = true;
        }

        if (iCount >= 53)
        {
            imageBack.sprite = listBack[1];
            bGirl = true;
        }

        if (iCount >= 91)
        {
            bGirl = false;
            bBack = true;
        }
        if (iCount >= 93)
        {
            imageBack.sprite = listBack[7];
            bGirl = true;
        }

        if (iCount >= 125)
        {
            bGirl = false;
            bBack = true;
        }
        if (iCount >= 128)
        {
            imageBack.sprite = listBack[13];
            bGirl = true;
        }
        if (iCount >= 145)
        {
            bBack = true;
            bGirl = false;
        }
        if (iCount >= 153)
        {
            imageBack.sprite = listBack[13];
            bGirl = true;
        }
        if (iCount >= 230)
        {
            bGirl = false;
            bBack = true;
        }
        if (iCount >= 253)
        {
            bBack = false;
        }
        if (iCount >= 254)
        {
            imageBack.sprite = listBack[2];
            bBack = true;
        }

        if (iCount == 315)
        {
            Select.GetInstance().SetSelect(true, "통화를 한다.", "갑자기 하기 싫다. 하지 말자.",false);
        }

        if (iCount == 327)
        {
            Select.GetInstance().SetSelect(true, "통화를 한다.", "하지 말자.",false);
        }

        if (iCount >= 376)
        {
            bBack = true;
        }

        if (iCount >= 398)
        {
            bBack = true;
        }
        if (iCount >= 413)
        {
            animLoad.SetBool("End", true);
        }
        if (iCount >= 415)
        {
            SceneManager.LoadScene("SampleScene");
        }

        animBack.SetBool("Alpha", true);
        animGirl.SetBool("Alpha", true);
        StopAllCoroutines();

        if (!bBack)
        {
            StartCoroutine(StopAnim(3f));
        }
        else if(bBack)
        {
            StartCoroutine(StopAnimContinue());
        }
    }

    public void SetListText(string _text)
    {
        listText.Add(_text);
    }

    public void SetListText2(string _text)
    {
        listText2.Add(_text);
    }

    public void SetIamgeGirl(Sprite[] iNum)
    {
        for(int j = 0; j < iNum.Length; j++)
        {
            listSprite.Add(iNum[j]);
        }
    }

    public void SetIamgeBack(Sprite[] iNum)
    {
        for (int j = 0; j < iNum.Length; j++)
        {
            listBack.Add(iNum[j]);
        }
    }

    public void SetImagePhone(Sprite[] iNum)
    {
        for(int i = 0; i < iNum.Length; i++)
        {
            listPhone.Add(iNum[i]);
        }
    }

    public void SetClip(AudioClip[] iNum)
    {
        for (int j = 0; j < iNum.Length; j++)
        {
            listClip.Add(iNum[j]);
        }
    }

    public void SetButton(bool _button)
    {
        bButton = _button;
    }

    public bool GetButton()
    {
        if(bLoad == true)
        {
            bButton = false;
        }
        else
            bButton = true;

        return bButton;
    }

    public void TransScene(int iNum)
    {
        switch (iNum)
        {
            case 1:
                ending = Ending.One;
                break;
            case 2:
                ending = Ending.Two;
                break;
            case 3:
                ending = Ending.Three;
                break;
            default:
                break;
        }
        iCount = 0;
        listText.Clear();

        TextAsset TA = Resources.Load("Ending" + iNum.ToString(), typeof(TextAsset)) as TextAsset;

        StringReader sr = new StringReader(TA.text);

        string tell = sr.ReadLine();
        
        while (tell != null)
        {
            listText.Add(tell);
            tell = sr.ReadLine();
        }

        sr.Close();

        bEnd = true;
    }

    private void CreateName()
    {
        if (listText[iCount].Length != 0)
        {
            if (listText[iCount][0] == '-')
            {
                Name.text = "???";
                //listText[iCount] = listText[iCount].Substring(1);
            }
            else if (listText[iCount][0] == '/')
            {
                Name.text = "유 다 혜";

                listText[iCount] = listText[iCount].Substring(1);
            }
            else if (listText[iCount][0] == '1')
            {
                Name.text = "엄 마";
                listText[iCount] = listText[iCount].Substring(1);
            }
            else if (listText[iCount][0] == '2')
            {
                Name.text = "사촌 누나";
                listText[iCount] = listText[iCount].Substring(1);
            }
            else if (listText[iCount][0] == '3')
            {
                Name.text = "군 인";
                listText[iCount] = listText[iCount].Substring(1);
            }
            else
            {
                Name.text = "";
            }
        }
        else
        {
            Name.text = "";
        }
    }

    IEnumerator Routine()
    {
        if (iCount < listText.Count)
        {
            CreateName();
            if (listText != null)
            {
                for (int i = 0; i < listText[iCount].Length; ++i)
                {
                    yield return new WaitForSeconds(fTexSpeed);
                    text.text += listText[iCount][i];
                }
                bEnd = true;
            }
            else
            {
                yield return new WaitForSeconds(1f);
            }
        }
    }

    public IEnumerator Stop(float fSec)
    {
        bAni = true;
        yield return new WaitForSeconds(fSec);
        bAni = false;
    }

    public IEnumerator TransPhone(int iNum)
    {
        bAni = true;
        animPA.SetBool("Size", false);
        yield return new WaitForSeconds(1f);
        imagePhone.sprite = listPhone[iNum];
        animPA.SetBool("Size", true);
        yield return new WaitForSeconds(0.5f);
        bAni = false;
        yield return null;
    }

    public IEnumerator OpenPhone(int iNum)
    {
        bAni = true;
        animPhone.SetBool("Hide", false);

        yield return new WaitForSeconds(1.5f);

        imagePhone.sprite = listPhone[iNum];
        animPA.SetBool("Size", true);

        yield return new WaitForSeconds(0.5f);

        bAni = false;

        yield return null;
    }

    public IEnumerator ClosePhone()
    {
        bAni = true;

        animPA.SetBool("Size", false);
        yield return new WaitForSeconds(1f);

        animPhone.SetBool("Hide", true);
        yield return new WaitForSeconds(1f);

        bAni = false;

        yield return null;
    }

    public IEnumerator StopAnim(float fTime)
    {
        bAni = true;

        yield return new WaitForSeconds(fTime);

        bAni = false;

        if(animBack.GetBool("Move"))
            animBack.SetBool("Move", false);

        if (!bLoad) // 로딩으로 들어온게 아니면 Count를 증가해서 애니메이션 끝나면 바로 다음 텍스트를 출력
        {
            iCount++;
        }
        else
           bLoad = false;
    
        bEnd = false;
        text.text = "";
        StopAllCoroutines();
        StartCoroutine(Routine());

        yield return null;
    }

    public IEnumerator StopAnimContinue()
    {
        bAni = true;
        
        text.text = "";

        yield return new WaitForSeconds(2f); // 애니매이션이 천천히 사라짐
        text.text = "";

        animBack.SetBool("Alpha", false);
        animBack.SetBool("NowAlpha", false);
        if (bGirl == true) // 로딩햇는데 그 위치가 여자가 나올 타이밍이면
            animGirl.SetBool("Alpha", false);
        if (ending == Ending.One)
        {
            if (iCount == 91)
            {
                iBCount = 6;
                imageBack.sprite = listBack[6];
            }
            else if (iCount == 125)
            {
                iBCount = 10;
                imageBack.sprite = listBack[10];
            }
            else if (iCount == 230)
            {
                iBCount = 11;
                imageBack.sprite = listBack[11];
            }
            else if (iCount == 376)
            {
                iBCount = 4;
                imageBack.sprite = listBack[4];
            }
            else if (iCount == 398)
            {
                iBCount = 12;
                imageBack.sprite = listBack[12];
            }
        }
        else if (ending == Ending.Two)
        {
            if (iCount == 11)
            {
                imageBack.sprite = listBack[4];
            }
            else if (iCount == 32)
            {
                imageBack.sprite = listBack[0];
            }
            else if (iCount == 109)
            {
                imageBack.sprite = listBack[16];
            }
            else if(iCount == 162)
            {
                imageBack.sprite = listBack[14];
            }
            else if(iCount == 210)
            {
                imageBack.sprite = listBack[17];
            }
        }
        yield return new WaitForSeconds(3f);
        
        bAni = false;
        bEnd = false;

        if (!bLoad)
        {
            iCount++;
        }
        else
            bLoad = false;

        text.text = "";
        StopAllCoroutines();
        StartCoroutine(Routine());


        yield return null;
    }

    IEnumerator StartText()
    {
        bStart = false;
        yield return new WaitForSeconds(2f);
        for (; iNext < listText[iCount].Length; iNext++)
        {
            if (iNext >= listText[iCount].Length)
                break;

            text.text += listText[iCount][iNext];

            yield return new WaitForSeconds(0.05f);
        }
        
        bEnd = true;

        yield return null;
    }
}