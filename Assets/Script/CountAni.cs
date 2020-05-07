using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class CountAni : MonoBehaviour {

    private int iSelect = -1;
    private bool Music = false;
    private int iTemp;

    // Use this for initialization
    void Start () {
		
	}   
	    
	// Update is called once per frame
	void Update () {
		
	}   
        
    public void Ani(int iCount)
    {
        if (iCount == 2)
        {
            UIManager.GetInstance().iBCount = 0;
            UIManager.GetInstance().imageBack.color = new Color(1, 1, 1, 0);
            UIManager.GetInstance().animBack.SetBool("Alpha", false);

            StartCoroutine(UIManager.GetInstance().StopAnim(3f));
        }

        else if (iCount == 9)
        {
            UIManager.GetInstance().animBack.SetBool("Move", true);
            StartCoroutine(UIManager.GetInstance().StopAnim(0.5f));
        }

        else if (iCount == 38)
        {
            UIManager.GetInstance().animBack.SetBool("Alpha", true);
            StartCoroutine(UIManager.GetInstance().StopAnim(3f));
        }

        else if (iCount == 49)
        {
            UIManager.GetInstance().iBCount = 14;
            UIManager.GetInstance().imageBack.sprite = UIManager.GetInstance().listBack[14];
            UIManager.GetInstance().animBack.SetBool("Alpha", false);
            StartCoroutine(UIManager.GetInstance().StopAnim(3f));
        }
        else if (iCount == 53)
        {
            UIManager.GetInstance().iBCount = 15;
            UIManager.GetInstance().imageBack.sprite = UIManager.GetInstance().listBack[15];
            UIManager.GetInstance().animGirl.SetBool("Alpha", false);
            StartCoroutine(UIManager.GetInstance().StopAnim(3f));
        }

        else if (iCount == 91)
        {
            UIManager.GetInstance().animBack.SetBool("Alpha", true);
            UIManager.GetInstance().animGirl.SetBool("Alpha", true);
            StartCoroutine(UIManager.GetInstance().StopAnimContinue());
        }
        else if (iCount == 93)
        {
            UIManager.GetInstance().iBCount = 7;
            UIManager.GetInstance().imageBack.sprite = UIManager.GetInstance().listBack[7];
            UIManager.GetInstance().animGirl.SetBool("Alpha", false);
            StartCoroutine(UIManager.GetInstance().StopAnim(3f));
        }

        else if (iCount == 125)
        {
            UIManager.GetInstance().animBack.SetBool("Alpha", true);
            UIManager.GetInstance().animGirl.SetBool("Alpha", true);
            StartCoroutine(UIManager.GetInstance().StopAnimContinue());
        }
        else if (iCount == 128)
        {
            UIManager.GetInstance().iBCount = 13;
            UIManager.GetInstance().imageBack.sprite = UIManager.GetInstance().listBack[13];
            UIManager.GetInstance().animGirl.SetBool("Alpha", false);
            StartCoroutine(UIManager.GetInstance().StopAnim(3f));
        }
        else if (iCount == 145)
        {
            UIManager.GetInstance().animBack.SetBool("Alpha", true);
            UIManager.GetInstance().animGirl.SetBool("Alpha", true);
            StartCoroutine(UIManager.GetInstance().StopAnimContinue());
        }
        else if (iCount == 153)
        {
            UIManager.GetInstance().iBCount = 13;
            UIManager.GetInstance().imageBack.sprite = UIManager.GetInstance().listBack[13];
            UIManager.GetInstance().animGirl.SetBool("Alpha", false);
            StartCoroutine(UIManager.GetInstance().StopAnim(3f));
        }
        else if (iCount == 230)
        {
            UIManager.GetInstance().animBack.SetBool("Alpha", true);
            UIManager.GetInstance().animGirl.SetBool("Alpha", true);
            StartCoroutine(UIManager.GetInstance().StopAnimContinue());
        }
        else if (iCount == 253)
        {
            UIManager.GetInstance().animBack.SetBool("NowAlpha", true);
        }
        else if (iCount == 254)
        {
            UIManager.GetInstance().iBCount = 2;
            UIManager.GetInstance().imageBack.sprite = UIManager.GetInstance().listBack[2];
            UIManager.GetInstance().animBack.SetBool("NowAlpha", false);
            StartCoroutine(UIManager.GetInstance().StopAnim(3f));
        }
        else if (iCount == 287)
        {
            UIManager.GetInstance().animPhone.SetBool("Hide", false);
            StartCoroutine(UIManager.GetInstance().StopAnim(1.5f));
        }
        else if (iCount == 290)
        {
            UIManager.GetInstance().animPA.SetBool("Size", true);

            StartCoroutine(UIManager.GetInstance().StopAnim(1f));
        }
        else if (iCount == 303)
        {
            StartCoroutine(UIManager.GetInstance().TransPhone(5));
            StartCoroutine(UIManager.GetInstance().StopAnim(2f));
        }
        else if (iCount == 314)
        {
            UIManager.GetInstance().imagePhone.sprite = UIManager.GetInstance().listPhone[2];
        }
        else if (iCount == 315)
        {
            StartCoroutine(UIManager.GetInstance().TransPhone(0));
            StartCoroutine(UIManager.GetInstance().StopAnim(2f));
            //UIManager.GetInstance().animPA.SetBool("Size", false);
            //UIManager.GetInstance().animPhone.SetBool("Hide", true);
        }

        else if (iCount == 319)
        {
            Select.GetInstance().SetSelect(true, "통화를 한다.", "갑자기 하기 싫다. 하지 말자.",false);
        }
        else if (iCount == 320)
        {
            StartCoroutine(UIManager.GetInstance().ClosePhone());
            StartCoroutine(UIManager.GetInstance().StopAnim(2f));
        }
        else if (iCount == 331)
        {
            StartCoroutine(UIManager.GetInstance().OpenPhone(0));
            StartCoroutine(UIManager.GetInstance().StopAnim(2f));
        }

        else if (iCount == 333)
        {
            Select.GetInstance().SetSelect(true, "통화를 한다.", "하지 말자.",false);
        }

        else if(iCount == 334)
        {
            StartCoroutine(UIManager.GetInstance().TransPhone(5));
            StartCoroutine(UIManager.GetInstance().StopAnim(2f));
        }
        else if(iCount == 339)
        {
            UIManager.GetInstance().imagePhone.sprite = UIManager.GetInstance().listPhone[1];
        }

        else if(iCount == 370)
        {
            UIManager.GetInstance().imagePhone.sprite = UIManager.GetInstance().listPhone[2];
        }

        else if(iCount == 378)
        {
            StartCoroutine(UIManager.GetInstance().TransPhone(3));
            StartCoroutine(UIManager.GetInstance().StopAnim(2f));
        }

        else if (iCount == 384)
        {
            UIManager.GetInstance().animPhone.SetBool("Alpha", true);
            UIManager.GetInstance().animPA.SetBool("Alpha", true);
            UIManager.GetInstance().animBack.SetBool("Alpha", true);
            StartCoroutine(UIManager.GetInstance().StopAnimContinue());
        }

        else if(iCount == 386)
        {
            UIManager.GetInstance().animPhone.SetBool("Alpha", false);
            UIManager.GetInstance().animPA.SetBool("Alpha", false);
        }

        else if (iCount == 406)
        {
            UIManager.GetInstance().animBack.SetBool("Alpha", true);
            StartCoroutine(UIManager.GetInstance().StopAnimContinue());
        }
        else if (iCount == 421)
        {
            UIManager.GetInstance().animLoad.SetBool("End", true);
            StartCoroutine(UIManager.GetInstance().StopAnim(3f));
        }
        else if (iCount == 423)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void Ani2(int iCount)
    {
        if (iCount == 4)
        {
            UIManager.GetInstance().animPA.SetBool("Size", false);
            StartCoroutine(UIManager.GetInstance().Stop(0.5f));
        }
        else if (iCount == 6)
        {
            StartCoroutine(UIManager.GetInstance().TransPhone(1));
        }
        else if (iCount == 11)
        {
            UIManager.GetInstance().animBack.SetBool("Alpha", true);
            UIManager.GetInstance().animPhone.SetBool("Alpha", true);
            UIManager.GetInstance().animPA.SetBool("Alpha", true);
            StartCoroutine(UIManager.GetInstance().StopAnimContinue());
        }
        else if (iCount == 13)
        {
            UIManager.GetInstance().animPhone.SetBool("Hide", true);
            UIManager.GetInstance().animPA.SetBool("Size", false);
            UIManager.GetInstance().animPhone.SetBool("Alpha", false);
            UIManager.GetInstance().animPA.SetBool("Alpha", false);
        }
        else if (iCount == 32)
        {
            UIManager.GetInstance().animBack.SetBool("Alpha", true);
            StartCoroutine(UIManager.GetInstance().StopAnimContinue());
        }
        else if (iCount == 37)
        {
            StartCoroutine(UIManager.GetInstance().OpenPhone(3));
        }
        else if (iCount == 46)
        {
            UIManager.GetInstance().animPhone.SetBool("Alpha", true);
            UIManager.GetInstance().animPA.SetBool("Alpha", true);
            UIManager.GetInstance().animBack.SetBool("Alpha", true);
            StartCoroutine(UIManager.GetInstance().StopAnim(3f));
        }
        else if (iCount == 48)
        {
            UIManager.GetInstance().animPhone.SetBool("Hide", true);
            UIManager.GetInstance().animPA.SetBool("Size", false);
            UIManager.GetInstance().animPhone.SetBool("Alpha", false);
            UIManager.GetInstance().animPA.SetBool("Alpha", false);
            UIManager.GetInstance().imageBack.sprite = UIManager.GetInstance().listBack[14];
            UIManager.GetInstance().animBack.SetBool("Alpha", false);
            StartCoroutine(UIManager.GetInstance().StopAnim(3f));
        }
        else if (iCount == 50)
        {
            UIManager.GetInstance().imageBack.sprite = UIManager.GetInstance().listBack[15];
            UIManager.GetInstance().animGirl.SetBool("Alpha", false);
            StartCoroutine(UIManager.GetInstance().StopAnim(1f));
        }
        else if (iCount == 88)
        {
            UIManager.GetInstance().animBack.SetBool("Alpha", true);
            UIManager.GetInstance().animGirl.SetBool("Alpha", true);
            StartCoroutine(UIManager.GetInstance().StopAnim(2f));
        }
        else if (iCount == 93)
        {
            UIManager.GetInstance().imageBack.sprite = UIManager.GetInstance().listBack[0];
            UIManager.GetInstance().animBack.SetBool("Alpha", false);
            StartCoroutine(UIManager.GetInstance().StopAnim(3f));
        }
        else if (iCount == 109)
        {
            UIManager.GetInstance().animBack.SetBool("Alpha", true);
            StartCoroutine(UIManager.GetInstance().StopAnimContinue());
        }
        else if (iCount == 120)
        {
            StartCoroutine(UIManager.GetInstance().OpenPhone(7));
        }
        else if (iCount == 141)
        {
            StartCoroutine(UIManager.GetInstance().TransPhone(8));
        }
        else if (iCount == 162)
        {
            UIManager.GetInstance().animBack.SetBool("Alpha", true);
            UIManager.GetInstance().animPhone.SetBool("Alpha", true);
            UIManager.GetInstance().animPA.SetBool("Alpha", true);
            StartCoroutine(UIManager.GetInstance().StopAnimContinue());
        }
        else if (iCount == 164)
        {
            UIManager.GetInstance().animPhone.SetBool("Hide", true);
            UIManager.GetInstance().animPA.SetBool("Size", false);
            UIManager.GetInstance().animPhone.SetBool("Alpha", false);
            UIManager.GetInstance().animPA.SetBool("Alpha", false);
        }
        else if (iCount == 165)
        {
            UIManager.GetInstance().imageBack.sprite = UIManager.GetInstance().listBack[15];
            UIManager.GetInstance().animGirl.SetBool("Alpha", false);
            StartCoroutine(UIManager.GetInstance().StopAnim(1f));
        }
        else if (iCount == 210)
        {
            UIManager.GetInstance().animBack.SetBool("Alpha", true);
            UIManager.GetInstance().animGirl.SetBool("Alpha", true);
            StartCoroutine(UIManager.GetInstance().StopAnimContinue());
        }
        else if (iCount == 215)
        {
            StartCoroutine(UIManager.GetInstance().OpenPhone(5));
        }
        else if (iCount == 218)
        {
            UIManager.GetInstance().imagePhone.sprite = UIManager.GetInstance().listPhone[10];
        }
        else if (iCount == 219)
        {
            UIManager.GetInstance().imagePhone.sprite = UIManager.GetInstance().listPhone[6];
        }
        else if (iCount == 223)
        {
            StartCoroutine(UIManager.GetInstance().TransPhone(8));
        }
        else if (iCount == 225)
        {
            UIManager.GetInstance().imagePhone.sprite = UIManager.GetInstance().listPhone[9];
        }
        else if (iCount == 226)
        {
            UIManager.GetInstance().imagePhone.sprite = UIManager.GetInstance().listPhone[6];
        }
        else if (iCount == 231)
        {
            StartCoroutine(UIManager.GetInstance().TransPhone(1));
        }
        else if (iCount == 254)
        {
            Select.GetInstance().SetSelect(true, "가겠다고 한다.", "누나의 생각에 대해 의구심을 던진다.", true);
        }
        else if (iCount == 273)
        {
            UIManager.GetInstance().imagePhone.sprite = UIManager.GetInstance().listPhone[2];
        }
        else if (iCount == 274)
        {
            StartCoroutine(UIManager.GetInstance().ClosePhone());
        }
        else if (iCount == 286)
        {
            UIManager.GetInstance().animBack.SetBool("Alpha", true);
            StartCoroutine(UIManager.GetInstance().StopAnim(2f));
        }
        else if (iCount == 308)
        {
            UIManager.GetInstance().imageBack.sprite = UIManager.GetInstance().listBack[19];
            UIManager.GetInstance().animBack.SetBool("Alpha", false);
            StartCoroutine(UIManager.GetInstance().StopAnim(3f));
        }
        else if (iCount == 347)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void Ani3(int iCount)
    {
    }

    public void EffectSound(int iCount)
    {
        if (Music && iTemp != iCount)
            Music = false;

        // 0 : 냉장고 1 : 노크 2 : 문열림
        if (!Music)
        {
            if (iCount == 17)
            {
                iTemp = iCount;
                UIManager.GetInstance().MusicStop();
                UIManager.GetInstance().MusicPlay(0);
                Music = true;
            }

            else if (iCount == 40)
            {
                iTemp = iCount;
                UIManager.GetInstance().MusicStop();
                UIManager.GetInstance().MusicPlay(1);
                Music = true;
            }
            else if (iCount == 49)
            {
                iTemp = iCount;
                UIManager.GetInstance().MusicStop();
                UIManager.GetInstance().MusicPlay(2);
                Music = true;
            }
            else if (iCount == 127)
            {
                iTemp = iCount;
                UIManager.GetInstance().MusicStop();
                UIManager.GetInstance().MusicPlay(3);
                Music = true;
            }
            else if (iCount == 128)
            {
                UIManager.GetInstance().MusicStop();
            }
            else if (iCount == 145) // 술잔 부딪히는 소리
            {
                iTemp = iCount;
                UIManager.GetInstance().MusicStop();
                UIManager.GetInstance().MusicPlay(4);
                Music = true;
            }
            else if (iCount == 305)
            {
                iTemp = iCount;
                UIManager.GetInstance().MusicStop();
                UIManager.GetInstance().MusicPlay(5);
                Music = true;
            }
            else if (iCount == 306)
            {
                iTemp = iCount;
                UIManager.GetInstance().MusicStop();
                UIManager.GetInstance().MusicPlay(5);
                Music = true;
            }
            else if (iCount == 309)
            {
                iTemp = iCount;
                UIManager.GetInstance().MusicStop();
                UIManager.GetInstance().MusicPlay(5);
                Music = true;
            }
            else if (iCount == 310)
            {
                iTemp = iCount;
                UIManager.GetInstance().MusicStop();
                UIManager.GetInstance().MusicPlay(5);
                Music = true;
            }
            else if (iCount == 336)
            {
                iTemp = iCount;
                UIManager.GetInstance().MusicStop();
                UIManager.GetInstance().MusicPlay(5);
                Music = true;
            }
            else if (iCount == 337)
            {
                iTemp = iCount;
                UIManager.GetInstance().MusicStop();
                UIManager.GetInstance().MusicPlay(5);
                Music = true;
            }
            else if (iCount == 365)
            {
                iTemp = iCount;
                UIManager.GetInstance().MusicStop();
                UIManager.GetInstance().MusicPlay(6);
                Music = true;
            }
        }
    }

    public void EffectSound2(int iCount)
    {
        if (!Music && iCount == 48)
        {
            UIManager.GetInstance().MusicStop();
            if (!Music)
                UIManager.GetInstance().MusicPlay(1);
            Music = true;
        }
        else
            Music = false;
    }

    public void TransBack(int iCount)
    {
    }

    public int GirlFace(int iCount)
    {
        
        if (iCount == 55) // 0 : 입닫기 1 : 웃기 2 : 말하기 3: 찡그리기 4. 째려보기 5 허세 6 아쉬움 7 무표정
            iSelect = 2;

        else if (iCount == 56)
            iSelect = 0;

        else if (iCount == 60)
            iSelect = 3;

        else if (iCount == 72)
            iSelect = 2;

        else if (iCount == 73)
            iSelect = 0;

        else if (iCount == 74)
            iSelect = 4;

        else if (iCount == 75)
            iSelect = 0;

        else if (iCount == 80)
            iSelect = 2;

        else if (iCount == 81)
            iSelect = 0;

        else if (iCount == 82)
            iSelect = 4;

        else if (iCount == 83)
            iSelect = 0;

        else if (iCount == 84)
            iSelect = 1;

        else if (iCount == 85)
            iSelect = 0;

        else if (iCount == 95)
            iSelect = 4;

        else if (iCount == 96)
            iSelect = 0;

        else if (iCount == 97)
            iSelect = 2;

        else if (iCount == 98)
            iSelect = 0;

        else if (iCount == 102)
            iSelect = 1;

        else if (iCount == 103)
            iSelect = 0;

        else if (iCount == 104)
            iSelect = 5;

        else if (iCount == 105)
            iSelect = 0;

        else if (iCount == 106)
            iSelect = 2;

        else if (iCount == 107)
            iSelect = 0;

        else if (iCount == 111)
            iSelect = 3;

        else if (iCount == 112)
            iSelect = 0;

        else if (iCount == 113)
            iSelect = 4;

        else if (iCount == 114)
            iSelect = 0;

        else if (iCount == 117)
            iSelect = 6;

        else if (iCount == 119)
            iSelect = 0;

        else if (iCount == 120)
            iSelect = 6;

        else if (iCount == 124)
            iSelect = 0;

        else if (iCount == 129)
            iSelect = 2;

        else if (iCount == 130)
            iSelect = 0;

        else if (iCount == 136)
            iSelect = 4;

        else if (iCount == 138)
            iSelect = 2;

        else if (iCount == 139)
            iSelect = 0;

        else if (iCount == 140)
            iSelect = 5;

        else if (iCount == 141)
            iSelect = 7;

        else if (iCount == 143)
            iSelect = 0;

        else if (iCount == 154)
            iSelect = 9;

        else if (iCount == 155)
            iSelect = 8;

        else if (iCount == 156)
            iSelect = 9;

        else if (iCount == 159)
            iSelect = 8;

        else if (iCount == 160)
            iSelect = 10;

        else if (iCount == 163)
            iSelect = 8;

        else if (iCount == 164)
            iSelect = 9;

        else if (iCount == 165)
            iSelect = 8;

        else if (iCount == 166)
            iSelect = 9;

        else if (iCount == 167)
            iSelect = 8;

        else if (iCount == 168)
            iSelect = 9;

        else if (iCount == 169)
            iSelect = 8;

        else if (iCount == 170)
            iSelect = 10;

        else if (iCount == 172)
            iSelect = 9;

        else if (iCount == 173)
            iSelect = 8;

        else if (iCount == 176)
            iSelect = 9;

        else if (iCount == 183)
            iSelect = 8;

        else if (iCount == 184)
            iSelect = 9;

        else if (iCount == 185)
            iSelect = 8;

        else if (iCount == 186)
            iSelect = 9;

        else if (iCount == 187)
            iSelect = 8;

        else if (iCount == 188)
            iSelect = 9;

        else if (iCount == 189)
            iSelect = 8;

        else if (iCount == 198)
            iSelect = 9;

        else if (iCount == 199)
            iSelect = 8;

        else if (iCount == 200)
            iSelect = 10;

        else if (iCount == 210)
            iSelect = 9;

        else if (iCount == 211)
            iSelect = 8;

        else if (iCount == 212)
            iSelect = 9;

        else if (iCount == 213)
            iSelect = 8;

        else if (iCount == 214)
            iSelect = 10;

        else if (iCount == 222)
            iSelect = 9;

        else if (iCount == 223)
            iSelect = 8;

        else if (iCount == 225)
            iSelect = 9;

        else if (iCount == 226)
            iSelect = 8;

        else if (iCount == 227)
            iSelect = 9;

        else if (iCount == 228)
            iSelect = 8;
        if(iSelect != -1)
        UIManager.GetInstance().imageGirl.sprite = UIManager.GetInstance().listSprite[iSelect];

        return iSelect;
    }

    public int GirlFace2(int iCount)
    {
        // 11 웃기 12 말하기 13 입닫기

        if(iCount == 50)
            iSelect = 13;

        else if (iCount == 53)
            iSelect = 12;

        else if (iCount == 54)
            iSelect = 13;
        
        else if (iCount == 55)
            iSelect = 11;
        
        else if (iCount == 57)
            iSelect = 12;
        
        else if (iCount == 58)
            iSelect = 13;
        
        else if (iCount == 60)
            iSelect = 12;
        
        else if (iCount == 61)
            iSelect = 13;
        
        else if (iCount == 62)
            iSelect = 12;
        
        else if (iCount == 69)
            iSelect = 13;
        
        else if (iCount == 70)
            iSelect = 12;
        
        else if (iCount == 73)
            iSelect = 13;
        
        else if (iCount == 74)
            iSelect = 11;
        
        else if (iCount == 77)
            iSelect = 12;
        
        else if (iCount == 78)
            iSelect = 13;
        
        else if (iCount == 79)
            iSelect = 12;
        
        else if (iCount == 80)
            iSelect = 13;
        
        else if (iCount == 83)
            iSelect = 12;
        
        else if (iCount == 84)
            iSelect = 13;
        
        else if (iCount == 85)
            iSelect = 12;
        
        else if (iCount == 86)
            iSelect = 13;
        
        else if(iCount == 165)
            iSelect = 14;

        if (iSelect != -1)
            UIManager.GetInstance().imageGirl.sprite = UIManager.GetInstance().listSprite[iSelect];

        return iSelect;
    }
}