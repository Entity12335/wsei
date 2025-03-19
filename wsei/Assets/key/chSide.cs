using Platformer;
using UnityEngine;

public class chSide : MonoBehaviour
{
    public GameObject Player;
    public GameObject Camera;
    void Update()
    {
        ChH();
    }

    public void ChH()
    {

        if (Player.GetComponent<PlayerController>().isOverTrigerNYG)
        {
            Camera.transform.rotation = Quaternion.Euler(0,-180,0);
            Camera.transform.position = new Vector3(Player.transform.position.x,Player.transform.position.y,20);
        }
        else
        {
            Camera.transform.rotation = Quaternion.Euler(0, 0, 0);
            Camera.transform.position = new Vector3(Player.transform.position.x,Player.transform.position.y,-20);
        }

    }
}
