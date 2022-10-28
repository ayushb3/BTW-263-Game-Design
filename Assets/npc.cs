using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npc : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject dialoguePanel;
    public Text dialogueText;
    public string [] dialogue;
    public int index;

    public float wordSpeed;
    public bool playerIsClose;

    public GameObject contButton;

     
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerIsClose) {

            if(dialoguePanel.activeInHierarchy) {
                zeroText();
            }

            else 
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }

        if(dialogueText.text == dialogue[index]) {
            contButton.SetActive(true);
        }
        
    }

    public void zeroText() {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing() {

        foreach (char letter in dialogue[index].ToCharArray()) {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }
    public void NextLine() {
        contButton.SetActive(false);
        if (index < dialogue.Length - 1) {
            index++; 
            dialogueText.text = "";
            StartCoroutine(Typing() );

        }
        else {
            zeroText();
        }
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }   

    public void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();
        }
    }   
}
