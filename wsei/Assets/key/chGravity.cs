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
            Player.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else
        {
            Physics2D.gravity = new Vector2(0, (float)-9.81);
        }
    }
}
