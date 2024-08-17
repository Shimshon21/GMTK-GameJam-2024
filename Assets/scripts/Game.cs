using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    [SerializeField] private ObjectForSale[] levelItems;
    [SerializeField] private GameObject noteUI = null;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text timeText;

    [SerializeField] private EndGameManager endGameManager;

    private int score = 0;
    private int points = 5;
    private int currentObjectIndex = 0;

    public float targetTime = 60.0f;



    // Start is called before the first frame update
    void Start()
    {
        notePressed();
        //noteUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
        targetTime -= Time.deltaTime;

        int minutes = Mathf.FloorToInt(targetTime / 60);
        int seconds = Mathf.FloorToInt(targetTime % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (targetTime < 0) {
            EndGame();
        }
    }

    void displayNextItem()
    {

        levelItems[currentObjectIndex].gameObject.SetActive(false);

        if (currentObjectIndex + 1 < levelItems.Length)
        {
            currentObjectIndex++;
        } else
        {
            currentObjectIndex = 0;
            EndGame();
        }

        print(currentObjectIndex);
        print(levelItems.Length);
        levelItems[currentObjectIndex].gameObject.SetActive(true);
    }

    void EndGame()
    {
        endGameManager.DisplayEndGamePopUp(score: score);
    }

    public void AcceptPressed()
    {
        print("accept button was pressed");
        if (levelItems[currentObjectIndex].IsItemOk())
        {
            score += 5;
        }
        else
        {
            print(failedSaleResponseText());
        }

        displayNextItem();
    }

    public void RefusePressed()
    {
        print("Refuse button was pressed");
        if (levelItems[currentObjectIndex].IsItemOk())
        {
            print(failedSaleResponseText());
        }
        else
        {
            score += 5;
        }

        displayNextItem();
    }

    public string failedSaleResponseText()
    {
        if (levelItems[currentObjectIndex].IsItemOk())
        {
            return "What are you doing?? this is a great price!";
        }

        return "Bloody hell, why did you bought this item?!";
    }

    public void notePressed()
    {
        noteUI.SetActive(true);
        noteUI.GetComponentInChildren<TMP_Text>().text = levelItems[currentObjectIndex].note;
    }
}

