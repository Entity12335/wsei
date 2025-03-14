using UnityEngine;

public class start : MonoBehaviour
{
    public GameObject credits;

    private void Start()
    {
        credits.SetActive(false);
    }
    public void CreditsOn()
    {
        credits.SetActive(true);
    }
    public void CreditsOff()
    {
        credits.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
