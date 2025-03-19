using UnityEngine;
using UnityEngine.SceneManagement;

public class ending : MonoBehaviour
{
    public bool yes = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            yes = true;
            SceneManager.LoadScene("endScrean");
        }
    }
}
