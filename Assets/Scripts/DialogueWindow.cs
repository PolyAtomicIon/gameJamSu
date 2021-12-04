using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using TMPro;

public class DialogueWindow : MonoBehaviour {

    public string allDialogueText;
    public TMP_Text labelText;
    public TMP_Text mainText;
    public GameObject closeButton;
    int currentSentenceIndex = 0;
    string[] sentences;
    public bool isDialogueFinished = false;

    public void Start() {
    }

    public void SetAllDialogueText(string text){
        allDialogueText = text;
        ProcessText();
    }

    public void ProcessText(){
        closeButton.SetActive(false);
        currentSentenceIndex = 0;
        sentences = allDialogueText.Split(';');
    }

    void Update(){
        if( sentences != null && sentences.Length != 0 ){
            string[] sentence = sentences[currentSentenceIndex].Split(':');

            labelText.text = sentence[0];
            mainText.text = sentence[1];
        }
    }

    public void PrevSentence(){
        if( currentSentenceIndex - 1 < 0 )
            return;
        currentSentenceIndex--;
    }
    public void NextSentence(){
        if( currentSentenceIndex + 1 >= sentences.Length - 2 ){
            closeButton.SetActive(true);
        }
        if( currentSentenceIndex + 1 >= sentences.Length - 1 ){
            isDialogueFinished = true;
            return;
        }
        currentSentenceIndex++;
    }

    public void Enable(){
        // gameObject.SetActive(true);
        foreach (Transform child in transform)
            child.gameObject.SetActive(true);
    }

    public void Disable(){
        // gameObject.SetActive(false);
        foreach (Transform child in transform)
            child.gameObject.SetActive(false);
    }

}