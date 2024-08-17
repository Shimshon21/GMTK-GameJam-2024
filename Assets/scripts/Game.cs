using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    [SerializeField] private ObjectForSale[] levelItems;
    [SerializeField] private GameObject noteUI = null;
    [SerializeField] private TMP_Text scoreText;

    private int score = 0;
    private int points = 5;
    private int currentObjectIndex = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        noteUI.SetActive(true);
        noteUI.GetComponentInChildren<TMP_Text>().text = levelItems[currentObjectIndex].note;
        //noteUI.SetActive(false);
  
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
    }

    void displayItem(ObjectForSale levelItem)
    {

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
            print(failedText());
        }
    }

    public void RefusePressed()
    {
        print("Refuse button was pressed");
        if (levelItems[currentObjectIndex].IsItemOk())
        {
            print(failedText());
        }
        else
        {
            score += 5;
        }
    }

    public string failedText()
    {
        if (levelItems[currentObjectIndex].IsItemOk())
        {
            return "What are you doing?? this is a great price!";
        }

        return "Bloody hell, why did you bought this item?!";
    }

}
