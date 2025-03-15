using System;
using System.Collections;
using Platformer;
using TMPro;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class WriteChandler : MonoBehaviour
{
    public GameObject textBack;
    public TMP_Text TMP;
    public string[] text = {""};
    public float typingSpeed = 100f;

    private string fullText;
    private string[] textemp;
    private bool isTalking = false;
    private string currentT = "";
    private bool ready = true;
    [SerializeField]private int said = 0;
    private Coroutine coroutine;

    public GameObject Player;
    public GameObject MG;

    private string[] texttoshow = { "to wygl¹da jak coœ wa¿nego", "ah tak to wyrwa" };
    private bool used = false;

    private void Start()
    {
        //textBack.SetActive(false);
        TMP.text = "";
    }
    private void Update()
    {
        //if (!isTalking)
        //{
        //    isTalking = true;
        //    StartCoroutine(StartTyping(text));
        //}
        if (used == false)
        {
            if (Player.GetComponent<PlayerController>().isOverKCH)
            {
                if (!isTalking)
                {
                    isTalking = true;
                    StartCoroutine(StartTyping(text));
                }

            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            TMP.text = fullText;
            StopCoroutine(coroutine);
            ready = true;
        }

    }
    

    public IEnumerator StartTyping(string[] text)
    {
        if (said<text.Length)
        {
            textBack.SetActive(true);
            for ( int i = 0; text.Length>i;i++)
            {
                yield return new WaitUntil(()=>(ready));

                fullText = text[i];
                currentT = "";
                coroutine = StartCoroutine(TypeText());

                //if (interupt)
                //{
                //    interupt = false;
                //    StopCoroutine(coroutine);
                //    ready = true;
                //}
                Debug.Log(i);



                yield return new WaitUntil(()=>(Input.GetKeyDown(KeyCode.Space)));
                said++;
            }
            //Debug.Log("t");
            textBack.SetActive(false);
            isTalking= false;
            text = textemp;
        }
        else
        {
            
            said = 0;
            yield break;
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
