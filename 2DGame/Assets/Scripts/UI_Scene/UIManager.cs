using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(1);
    } 
    public void Exit()
    {
        Application.Quit();
    } 
    public void Pause()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }
}
