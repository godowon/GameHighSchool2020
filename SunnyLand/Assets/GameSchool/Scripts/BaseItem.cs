using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseItem : MonoBehaviour
{
    public UnityEvent m_OnPickup;
    
    public void IsPickuped()
    {
        m_OnPickup.Invoke();
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

}
