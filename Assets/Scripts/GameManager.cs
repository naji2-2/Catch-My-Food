using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using NUnit.Framework.Internal;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField]
    private TextMeshProUGUI text;
    private int score = 0;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    public void IncreaseFood() {
        score += 2;
        text.SetText(score.ToString());
    }

    public void DecreaseAttack() {
        score -= 5;
        text.SetText(score.ToString());
    }

}
