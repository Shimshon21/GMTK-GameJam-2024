using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    [SerializeField] TMP_Text title;
    [SerializeField] TMP_Text text;


    [SerializeField] int worstScore;
    [SerializeField] int bestScore;

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
            text.text = "You got fired and now you don't have enough money for Macdonalds meal to feed your family";
        }

        if (score > worstScore && score < bestScore)
        {
            title.text = "Your sales was ok";
            text.text = "You got enough money to feed the family";
        }

        if (score >= bestScore)
        {
            title.text = "You are the best saller";
            text.text = "You got promoted to be the manager";
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("Game");
    }
}
