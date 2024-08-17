using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject[] levelItems;
    [SerializeField] private GameObject noteUI = null;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text timeText;

    [SerializeField] private EndGameManager endGameManager;
    [SerializeField] private AngrySellerManager sellerManager;

    [Header("Sparkle")]
    [SerializeField] private Transform sparkleSpawn;
    [SerializeField] private GameObject sparkleEffect;

    private int score = 0;
    private int currentObjectIndex = 0;

    public float targetTime = 60.0f;

    private int POINTS = 5;

    // Start is called before the first frame update
    void Start()
    {
        // notePressed();
        //noteUI.SetActive(false);

        Instantiate(levelItems[0]);
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

        if (currentObjectIndex + 1 < levelItems.Length)
        {
            print("Add plus 1");
            currentObjectIndex++;
        } else
        {
            currentObjectIndex = 0;
            EndGame();
        }

        print(currentObjectIndex);
        print(levelItems.Length);
        Instantiate(levelItems[currentObjectIndex]);
    }

    void EndGame()
    {
        endGameManager.DisplayEndGamePopUp(score: score);
    }

    public void AcceptPressed()
    {
        bool isItemOk = levelItems[currentObjectIndex].GetComponent<ObjectForSale>().IsItemOk();

        print("accept button was pressed");

        if (isItemOk)
        {
            score += POINTS;
        }
        else
        {
            showAngryManager(isItemOk);
        }

        FindObjectOfType<AnimationMovment>().MoveToBuyer();

        displayNextItem();
        Instantiate(sparkleEffect, sparkleSpawn);
    }

    public void RefusePressed()
    {
        print("Refuse button was pressed");
        bool isItemOk = levelItems[currentObjectIndex].GetComponent<ObjectForSale>().IsItemOk();

        if(isItemOk)
        {
            showAngryManager(isItemOk);
        }
        else
        {
            score += POINTS;
        }

        FindObjectOfType<AnimationMovment>().MoveToSeller();

        displayNextItem();
    }

    public void notePressed()
    {
        noteUI.SetActive(true);
        noteUI.GetComponentInChildren<TMP_Text>().text = levelItems[currentObjectIndex].GetComponent<ObjectForSale>().note;
    }

    public void showAngryManager(bool isItemOK)
    {
        sellerManager.gameObject.SetActive(true);
        sellerManager.ShowWarning(isItemOK);
    }
}

