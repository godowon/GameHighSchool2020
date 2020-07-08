using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public float m_RotationSpeed = 60f;

    void Update()
    {


        transform.Rotate(0, m_RotationSpeed * Time.deltaTime, 0);
    }
}
