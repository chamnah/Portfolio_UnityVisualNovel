using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour {

    private Image sprite;
    public Sprite[] sprites;
    private bool bSelect;
    public bool Enter;
    public int iText = 335;
    

	// Use this for initialization
	void Start () {
        sprite = GetComponent<Image>();
        bSelect = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseEnter()
    {
        bSelect = true;
        sprite.sprite = sprites[1];
    }

    private void OnMouseExit()
    {
        bSelect = false;
        sprite.sprite = sprites[0];
    }

    private void OnMouseUp()
    {
        if (bSelect)
        {
            if (Enter)
            {
                if (UIManager.GetInstance().ending == UIManager.Ending.One)
                    UIManager.GetInstance().SetCountNum(333);
                else if(UIManager.GetInstance().ending == UIManager.Ending.Two)
                    UIManager.GetInstance().SetCountNum(254);
            }
            else
            {
                if (UIManager.GetInstance().ending == UIManager.Ending.One && UIManager.GetInstance().iCount == 333)
                {
                    UIManager.GetInstance().TransScene(2);
                }
                else if (UIManager.GetInstance().ending == UIManager.Ending.Two && UIManager.GetInstance().iCount == 254)
                {
                    UIManager.GetInstance().TransScene(3);
                }
            }
            
            Select.GetInstance().SetClick(true);
        }
    }
}