﻿using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Rotation : MonoBehaviour
{

    public GameObject m_Bullet;

    public float m_RotationSpeed = 60f;
    public float m_AttackInterval = 1f;
    public float m_AttackCooltime = 0f;


    // Update is called once per frame
    void Update()
    {
        m_AttackCooltime += Time.deltaTime;
        if (m_AttackCooltime >= m_AttackInterval)
        {
            GameObject bullet = GameObject.Instantiate(m_Bullet);
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            var b = bullet.GetComponent<Bullet>();
            b.m_Velocity = transform.forward;

            m_AttackCooltime = 0;
        }

        transform.Rotate(0, m_RotationSpeed * Time.deltaTime, 0);
    }
}