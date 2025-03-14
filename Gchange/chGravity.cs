using Platformer;
using UnityEngine;

public class chGravity : MonoBehaviour
{
    public GameObject Player;
    void Update()
    {
        ChG();
    }

    public void ChG()
    {
        if (Player.GetComponent<PlayerController>().isOverTrigerNYG)
        {
            Physics2D.gravity = new Vector2(0, (float)9.81);
        }
        else
        {
            Physics2D.gravity = new Vector2(0, (float)-9.81);
        }
    }
}
