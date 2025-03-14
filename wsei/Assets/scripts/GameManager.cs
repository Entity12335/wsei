using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer
{
    public class GameManager : MonoBehaviour
    {
        public int coinsCounter = 0;

        public GameObject playerGameObject;
        private PlayerController playerController;
        public GameObject deathPlayerPrefab;
        public GameObject ball;
        

        void Start()
        {
            playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        }

        void Update()
        {
            //coinText.text = coinsCounter.ToString();
            if(playerController.deathState == true)
            {
                playerGameObject.SetActive(false);
                GameObject deathPlayer = (GameObject)Instantiate(deathPlayerPrefab, playerGameObject.transform.position, playerGameObject.transform.rotation);
                deathPlayer.transform.localScale = new Vector3(playerGameObject.transform.localScale.x, playerGameObject.transform.localScale.y, playerGameObject.transform.localScale.z);
                playerController.deathState = false;
                Invoke("ReloadLevel", 3);
            }else if (playerController.isOverLadder)
            {
                playerController.GetComponent<Rigidbody2D>().gravityScale = 0;
            }
            else
            {
                playerController.GetComponent<Rigidbody2D>().gravityScale = 1;
            }

        }

        private void ReloadLevel()
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
