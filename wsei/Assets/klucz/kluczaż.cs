using Platformer;
using UnityEngine;

public class kluczaż : MonoBehaviour
{
    public GameObject kluc;
    public GameObject kluczacz;

    private bool keelOn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        kluc.SetActive(false);
        kluczacz.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (keelOn)
        { 
            kluc.SetActive(true);
            kluczacz.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        keelOn = true;
    }

}
