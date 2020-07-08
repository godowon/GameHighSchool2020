using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_D : MonoBehaviour
{
    public Rigidbody m_Rigidbody;
    public float m_Speed = 10f;
    // Start is called before the first frame update

    // Update is called once per frame
    private void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        Vector3 velocity = new Vector3(xAxis, 0, zAxis).normalized * m_Speed;
        velocity.y = m_Rigidbody.velocity.y;
        m_Rigidbody.velocity = velocity;
        //Vector3 movement = velocity * Time.deltaTime;
        //transform.position = transform.position + movement;
    }

    public void Die()
    {

    }
}
