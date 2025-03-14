using Platformer;
using UnityEngine;

public class key : MonoBehaviour
{
    public GameObject Player;
    public GameObject Key;

    private void Update()
    {
        if (Player.GetComponent<PlayerController>().isOverKCH)
        {
            Key.SetActive(true);
        }
        else
        {
            Key.SetActive(false);
        }

    }
}
