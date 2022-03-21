using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public Text BestScoreText;

    // Start is called before the first frame update
    void Start()
    {
        SetBestScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NameInput_OnEndEdit(string p_input)
    {
        GameManager.PlayerName = p_input;
    }

    void SetBestScoreText()
    {
        BestScoreText.text = $"Best Score: {GameManager.BestPlayerScore} Name: {GameManager.BestPlayerName}";
    }
}
