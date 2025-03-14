using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class WriteChandler : MonoBehaviour
{
    public GameObject textBack;
    public TMP_Text TMP;
    public string[] text;
    public float typingSpeed = 100f;

    private string temp;
    private string fullText;
    private bool start = false;
    private string currentT = "";
    private bool interupt = false;
    private string[] TT = { "kkkkk", "ooooo" };
    private bool ready = true;
    private Coroutine coroutine;


    private void Start()
    {
        //textBack.SetActive(false);
        TMP.text = "";
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(StartTyping(TT));
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            interupt = true;
            TMP.text = fullText;
            StopCoroutine(coroutine);
            ready = true;
        }

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
            Debug.Log("stoper");

            yield return new WaitUntil(()=>(Input.GetKeyDown(KeyCode.Space)));

        }
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
}
