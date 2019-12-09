using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallGameOver : MonoBehaviour
{
    public GameObject gameOverPannel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //set game over screen
            gameOverPannel.SetActive(true);
        }
    }
       
}
