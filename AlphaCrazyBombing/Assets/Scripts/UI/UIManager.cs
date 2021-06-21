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

    public float timeStart = 60.0f;
    public Text txtTime;
    public float timeSpeed = 5.0f;

    public bool timerActive = false;


    private void Awake()
    {

        timerActive = true;

        txtTime.text = timeStart.ToString();



        //AudioSource.PlayClipAtPoint(menuSoundFX, Camera.main.transform.position, 1.0f);
        

        conditionPanels[0].SetActive(false);
        conditionPanels[1].SetActive(false);
        conditionPanels[2].SetActive(false);

        //audio.loop = true;

        //StartCoroutine(LoopAudio());
        
    }

    private void Update()
    {
        TimeRemaining();

        PauseGame();
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

    
    public void TimeRemaining()
    {
        if(timerActive)
        {
            timeStart -= Time.deltaTime * timeSpeed;

            txtTime.text = Mathf.Round(timeStart).ToString();

            if (timeStart < 1)
            {
                txtTime.text = 0.ToString();
                conditionPanels[0].SetActive(true);
                conditionPanels[1].SetActive(false);
            }
        }
       


    }


    public void StopTime()
    {
        timerActive = !timerActive;
    }


    public void PauseGame()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            conditionPanels[2].SetActive(true);
            

        } 
        
    }

    


}
