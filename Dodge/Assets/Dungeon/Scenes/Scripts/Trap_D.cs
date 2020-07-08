using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_D : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("Collaision이 어떤 Collaision과 충돌이 일어나고있음");
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Collaision이 어떤 Collaision과 충돌이 끝났음");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collaision이 어떤 Collaision과 충돌이 일어났음");

        if (collision.rigidbody != null)
        {
            var player = collision.rigidbody.GetComponent<Player_D>();
            if (player != null)
                player.Die();
        }
    }
}
