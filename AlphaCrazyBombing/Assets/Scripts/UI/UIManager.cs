using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //public Sprite[] lifes;
    public GameObject[] lifeImages;

    public void UpdateLife()
    {
        //lifeImages.sprite = lifes[currentLife];
        lifeImages[0].gameObject.SetActive(true);
        lifeImages[1].gameObject.SetActive(true);
        lifeImages[2].gameObject.SetActive(true);
        

    }

    

}
