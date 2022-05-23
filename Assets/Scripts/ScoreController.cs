using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField] Text score;
    int kills;
    [SerializeField] Image damaged;
    [SerializeField] GameObject endgameUI;
    public int Kills { get => kills; set => kills = value; }
    public Image Damaged { get => damaged; set => damaged = value; }
    public GameObject EndgameUI { get => endgameUI; set => endgameUI = value; }
    void Start()
    {
        kills = 0;
        endgameUI.SetActive(false);
        damaged.color = new Color(1f, 1f, 1f, 0f);
    }

    void Update()
    {
        score.text = "Score: " + kills;
    }

    public void SaveScore(int sc)
    {
        int tmp = PlayerPrefs.GetInt("Score", 0);
        if (tmp < sc)
        {
            PlayerPrefs.SetInt("Score", sc);
            PlayerPrefs.Save();
        }
    }
}
