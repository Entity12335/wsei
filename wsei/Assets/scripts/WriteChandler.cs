using Platformer;
using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class WriteChandler : MonoBehaviour
{
    public GameObject Player;
    public GameObject textBack;
    public TMP_Text TMP;
    public string[] text;
    public float typingSpeed = 0.05f;

    private string temp;
    private string fullText;
    private bool start = false;
    private string currentT = "";
    private bool interupt = false;
    private bool ready = true;
    private Coroutine coroutine;
    private int hell = 0;


    private void Start()
    {
        //textBack.SetActive(false);
        TMP.text = "";
    }
    private void Update()
    {

    }
    

    public IEnumerator StartTyping(string[] text)
    {
        foreach (string s in text)
        {
            yield return new WaitUntil(()=>(ready));

            fullText = s;
            currentT = "";
            coroutine = StartCoroutine(TypeText());

            //if (interupt)
            //{
            //    interupt = false;
            //    StopCoroutine(coroutine);
            //    ready = true;
            //}
            //Debug.Log("stoper");

            yield return new WaitUntil(()=>(Input.GetKeyDown(KeyCode.Space)));

        }
        textBack.SetActive(false);
        Player.GetComponent<PlayerController>().enabled = true;
    }

    private IEnumerator TypeText()
    {
        ready = false;
        foreach (char letter in fullText)
        {
            currentT += letter;
            TMP.text = currentT;

            yield return new WaitForSeconds(typingSpeed);
        }
        ready = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && hell<1)
        {
            StartCoroutine(StartTyping(text));
            textBack.SetActive(true);
            Player.GetComponent<PlayerController>().enabled = false;
            hell++;
        }
    }

}
