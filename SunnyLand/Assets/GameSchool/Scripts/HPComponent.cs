using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HPComponent : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEvent m_OnDie;
    public UnityEvent m_OnTakeDamage;
    public UnityEvent m_OnTakeHeal;

    void Start()
    {
        m_OnTakeDamage.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject);
    }
}
