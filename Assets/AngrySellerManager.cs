using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AngrySellerManager : MonoBehaviour
{
    [SerializeField] TMP_Text warning;
    public float targetTime = 5.0f;
    public AudioClip clip1;
    public AudioClip clip2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        if(targetTime > 0) {
            targetTime -= Time.deltaTime;
        } else
        {
            gameObject.SetActive(false);
        }


    }

    public void ShowWarning(bool wasItemOk)
    {
        targetTime = 5.0f;
        AudioSource audioSource = GetComponent<AudioSource>();
        if (wasItemOk)
        {
            audioSource.clip = clip1;
            warning.text = "You missed a good one, you moron.";
            audioSource.Play();
            return;
        }

        audioSource.clip = clip2;
        audioSource.Play();
        warning.text = "That's junk, you dumbass!";
    }
}
