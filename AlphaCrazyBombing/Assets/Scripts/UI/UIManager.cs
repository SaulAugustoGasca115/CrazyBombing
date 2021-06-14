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
    public GameObject instructionsPanel;

    //public AudioClip[] menuSoundFX;
    //public AudioClip instructionsSoundFX;
    //public AudioClip[] soundFX;
    public AudioSource audio1;
    public AudioSource audio2;

    


    private void Awake()
    {

        audio1 = GetComponent<AudioSource>();
        

        //audio1.clip = soundFX[0];

        audio1.loop = true;

        audio1.Play();

        //audio2 = GetComponent<AudioSource>();

        //audio2.clip = soundFX[1];

        audio2.loop = true;

        



        //AudioSource.PlayClipAtPoint(menuSoundFX, Camera.main.transform.position, 1.0f);
        instructionsPanel.SetActive(false);

        conditionPanels[0].SetActive(false);
        conditionPanels[1].SetActive(false);

        //audio.loop = true;

        //StartCoroutine(LoopAudio());
        
    }

    private void Update()
    {
        StartCoroutine(LoopAudio());
        StartCoroutine(LoopAudio2());
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

    public void ExitApp()
    {
        Application.Quit();
    }

    public void OpenInstructionsPanel()
    {
        //soundFX[0].UnloadAudioData();
        instructionsPanel.SetActive(true);
        //AudioSource.PlayClipAtPoint(soundFX[1], Camera.main.transform.position, 1.0f);

        //StartCoroutine(LoopAudio2());

        audio1.Stop();
        audio2.Play();


    }


    public void CloseInstructionsPanel()
    {
        instructionsPanel.SetActive(false);
        //soundFX[1].UnloadAudioData();
        //AudioSource.PlayClipAtPoint(soundFX[0], Camera.main.transform.position, 1.0f);

        audio2.Stop();
        audio1.Play();
        
    }

    IEnumerator LoopAudio()
    {
        audio1 = GetComponent<AudioSource>();
        float length = audio1.clip.length;

        while (true)
        {
            audio1.Play();
            yield return new WaitForSeconds(length);
        }
    }

    IEnumerator LoopAudio2()
    {
        audio2 = GetComponent<AudioSource>();
        float length = audio2.clip.length;

        while (true)
        {
            audio1.Play();
            yield return new WaitForSeconds(length);
        }
    }

}
