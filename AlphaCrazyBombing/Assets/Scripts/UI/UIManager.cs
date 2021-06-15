using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    //public Sprite[] lifes;
    public GameObject[] lifeImages;
    public Text scoreText;
    public int score;
    

    public GameObject[] conditionPanels;
    

    //public AudioClip[] menuSoundFX;
    //public AudioClip instructionsSoundFX;
    //public AudioClip[] soundFX;
   

    


    private void Awake()
    {

        
        



        //AudioSource.PlayClipAtPoint(menuSoundFX, Camera.main.transform.position, 1.0f);
        

        conditionPanels[0].SetActive(false);
        conditionPanels[1].SetActive(false);

        //audio.loop = true;

        //StartCoroutine(LoopAudio());
        
    }

    private void Update()
    {
        
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
        score += 10;
        scoreText.text = "" + score;
    }

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    

}
