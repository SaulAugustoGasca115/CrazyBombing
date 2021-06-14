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

    public AudioClip menuSoundFX;
    public AudioClip instructionsSoundFX;

    


    private void Awake()
    {
        AudioSource.PlayClipAtPoint(menuSoundFX, Camera.main.transform.position, 1.0f);
        instructionsPanel.SetActive(false);

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
        menuSoundFX.UnloadAudioData();
        instructionsPanel.SetActive(true);
        AudioSource.PlayClipAtPoint(instructionsSoundFX, Camera.main.transform.position, 1.0f);
    }


    public void CloseInstructionsPanel()
    {
        instructionsPanel.SetActive(false);
        instructionsSoundFX.UnloadAudioData();
        AudioSource.PlayClipAtPoint(menuSoundFX, Camera.main.transform.position, 1.0f);
    }

    

}
