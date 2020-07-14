using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Animator m_Animator;

    public bool m_IsGround = false;
    public bool m_IsDead = false;

    public bool isdead = false;
    public bool isground = true;

    public int m_JumpCount = 0;

    public Rigidbody2D m_Rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    isground = !isground;
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    isdead = !isdead;
        //}
        //m_Animator.SetBool("IsDead", isdead);
        //m_Animator.SetBool("IsGround", isground);

        m_Animator.SetBool("IsGround", m_IsGround);

        if (Input.GetKeyDown(KeyCode.Space) && m_JumpCount < 2)
        {
            m_Rigidbody2D.velocity = Vector2.zero;
            m_Rigidbody2D.AddForce(Vector2.up * 400);
            m_JumpCount++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "ground")
        {
            m_IsGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.otherCollider.tag == "ground")
        {
            m_IsGround = false;
        }
    }
}
