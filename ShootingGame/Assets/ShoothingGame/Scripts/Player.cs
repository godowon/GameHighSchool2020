using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float m_Speed = 50f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {

        float xAxis = Input.GetAxis("Horizontal") * m_Speed * Time.deltaTime;
        float yAxis = Input.GetAxis("Vertical") * m_Speed * Time.deltaTime;
        this.transform.Translate(new Vector3(xAxis, yAxis, 0));
    }
}
