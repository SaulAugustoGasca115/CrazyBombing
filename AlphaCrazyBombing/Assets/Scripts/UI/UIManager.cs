using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //public Sprite[] lifes;
    public GameObject[] lifeImages;
    public Text scoreText;
    public int score;

    public GameObject[] conditionPanels;


    private void Awake()
    {


        conditionPanels[0].SetActive(false);
        conditionPanels[1].SetActive(false);
    }


    public void UpdateLife()
    {
        //lifeImages.sprite = lifes[currentLife];
        //lifeImages[0].gameObject.SetActive(true);
        //lifeImages[1].gameObject.SetActive(true);
        //lifeImages[2].gameObject.SetActive(true);
        

    }


    public void UpdateScore()
    {

    }


    

}
