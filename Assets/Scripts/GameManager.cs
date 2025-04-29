using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using NUnit.Framework.Internal;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField]
    private TextMeshProUGUI text;
    private int score = 0;
    private int attackCount = 0;

    [SerializeField]
    private GameObject[] gamePanels;

    void Awake()
    {
        if (instance == null) {
            instance = this;
        }
    }

    public void IncreaseFood()
    {
        score += 2;
        text.SetText(score.ToString());
        if (score >= 10) {
            SetGameComplete();   
        }
    }

    public void DecreaseAttack()
    {
        attackCount++;
        if (attackCount < 5) {
            score -= 5;
            text.SetText(score.ToString());
        } else {
            SetGameOver();
        }
    }

    public void SetGameOver()
    {
        Invoke("ShowGameOverPanel", 1f);
    }

    void ShowGameOverPanel()
    {
        gamePanels[0].SetActive(true);
    }

    public void SetGameComplete()
    {
        Invoke("ShowGameCompletePanel", 1f);
    }

    void ShowGameCompletePanel()
    {
        gamePanels[1].SetActive(true);
    }
    
    public void PlayAgain()
    {
        SceneManager.LoadScene("Catch My Food");
    }

}
