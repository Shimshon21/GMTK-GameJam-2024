using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    [SerializeField] TMP_Text title;
    [SerializeField] TMP_Text text;
    [SerializeField] TMP_Text highestScoreText;

    [SerializeField] int worstScore;
    [SerializeField] int bestScore;

    static int highestScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void DisplayEndGamePopUp(int score)
    {
        gameObject.SetActive(true);

        if(score <= worstScore)
        {
            title.text = "You are fired!";
            text.text = "You got fired and now you don't have enough money for Macdonalds meal to feed your family.";
        }

        if (score > worstScore && score < bestScore)
        {
            title.text = "Your sales was ok";
            text.text = "You got enough money to feed the family.";
        }

        if (score >= bestScore)
        {
            title.text = "IS CLOSED UNTIL FURTHER NOTICE";
            text.text = "Due to\nRUNNING OUT OF MONEY\nTurns out you also need to sell items.\nJoin Fugly and Shopkip in their next adventure, where they buy AND sell items.\n\nIf Fugly will ever open shop again...";
        }

        text.text += $"\n(score: {score})";

        highestScore = Mathf.Max(highestScore, score);

        highestScoreText.text = $"HIGH SCORE: {highestScore}";
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("Game");
    }
}
