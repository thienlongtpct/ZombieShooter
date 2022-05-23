using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] Text score;
    [SerializeField] GameObject musicOnBtn;
    [SerializeField] GameObject musicOffBtn;
    [SerializeField] GameObject soundOnBtn;
    [SerializeField] GameObject soundOffBtn;
    [SerializeField] AudioSource BGMusic;
    void Start()
    {
        score.text = "High Score: " + PlayerPrefs.GetInt("Score", 0);
        PlayerPrefs.SetInt("Music", 1);
        musicOnBtn.SetActive(true);
        musicOffBtn.SetActive(false);
        PlayerPrefs.SetInt("Sound", 1);
        soundOnBtn.SetActive(true);
        soundOffBtn.SetActive(false);
        PlayerPrefs.Save();
    }

    public void Play()
    {
        SceneManager.LoadScene("ZombieShooter");
    }

    public void TurnOffMusic()
    {
        PlayerPrefs.SetInt("Music", 0);
        BGMusic.mute = true;
        PlayerPrefs.Save();
    }
    public void TurnOnMusic()
    {
        PlayerPrefs.SetInt("Music", 1);
        BGMusic.mute = false;
        PlayerPrefs.Save();
    }

    public void TurnOffSound()
    {
        PlayerPrefs.SetInt("Sound", 0);
        PlayerPrefs.Save();
    }
    
    public void TurnOnSound()
    {
        PlayerPrefs.SetInt("Sound", 1);
        PlayerPrefs.Save();
    }
}
