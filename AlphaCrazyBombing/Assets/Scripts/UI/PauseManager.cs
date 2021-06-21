using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [Header("Pause Manager")]
    public GameObject instructionsPanel;



    // Start is called before the first frame update
    void Start()
    {
        instructionsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
        Time.timeScale = 1;
    }


    public void ResumeGame()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 1;
    }


    public void OpenInstructionsPanel()
    {
        instructionsPanel.SetActive(true);
    }

    public void CloseInstructionsPanel()
    {
        instructionsPanel.SetActive(false);
    }

}
