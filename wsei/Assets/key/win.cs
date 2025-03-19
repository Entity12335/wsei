using UnityEngine;

public class win : MonoBehaviour
{
    public GameObject ball;
    public GameObject won;
    public bool wont;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == won.tag)
        {
            wont = true;
        }
    }
}
