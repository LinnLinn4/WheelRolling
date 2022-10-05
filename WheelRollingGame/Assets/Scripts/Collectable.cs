using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            Player.instance.AddScore(1);
            Destroy(gameObject);
        }
    }
}
