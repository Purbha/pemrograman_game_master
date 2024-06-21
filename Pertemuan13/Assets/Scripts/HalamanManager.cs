using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HalamanManager : MonoBehaviour
{

    public bool isEscapeToExit;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start Event");    
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if (isEscapeToExit) {
                Debug.Log("Exit Game");
                Application.Quit();
            } else {
                Debug.Log("Back To Menu");
                KembaliKeMenu();
            }
        }
        
    }

    public void MulaiPermainan()
    {
        Debug.Log("Start Game");
        SceneManager.LoadScene("SampleScene");
    }

    public void KembaliKeMenu()
    {
        Debug.Log("Back To Menu");
        SceneManager.LoadScene("Main");
    }
}
