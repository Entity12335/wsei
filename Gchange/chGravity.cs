using Platformer;
using UnityEngine;

public class chGravity : MonoBehaviour
{
    public GameObject Player;
    void Update()
    {
        if (Player.GetComponent<PlayerController>().OverTag == "gChange")
        {
            Physics2D.gravity = new Vector2(0, (float)9.81);
        }
        else
        {
            Physics2D.gravity = new Vector2(0, (float)-9.81);
        }
    }

    public void ChangeIt()
    {
    }
}
