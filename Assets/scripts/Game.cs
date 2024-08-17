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
    [SerializeField] private AngrySellerManager sellerManager;

    private int score = 0;
    private int currentObjectIndex = 0;

    public float targetTime = 60.0f;

    private int POINTS = 5;

    private void Awake()
    {
        levelItems = FindObjectsOfType<ObjectForSale>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // notePressed();
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
        bool isItemOk = levelItems[currentObjectIndex].IsItemOk();

        print("accept button was pressed");

        if (isItemOk)
        {
            score += POINTS;
        }
        else
        {
            showAngryManager(isItemOk);
        }

        displayNextItem();
    }

    public void RefusePressed()
    {
        print("Refuse button was pressed");
        bool isItemOk = levelItems[currentObjectIndex].IsItemOk();

        if(isItemOk)
        {
            showAngryManager(isItemOk);
        }
        else
        {
            score += POINTS;
        }

        displayNextItem();
    }

    public void notePressed()
    {
        noteUI.SetActive(true);
        noteUI.GetComponentInChildren<TMP_Text>().text = levelItems[currentObjectIndex].note;
    }

    public void showAngryManager(bool isItemOK)
    {
        sellerManager.gameObject.SetActive(true);
        sellerManager.ShowWarning(isItemOK);
    }
}

