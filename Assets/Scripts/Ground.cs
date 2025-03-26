using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ground : MonoBehaviour
{
    [SerializeField] private string blockTag = "Block";
    [SerializeField] private UnityEvent onCollisionEvent;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == blockTag)
        {
            onCollisionEvent.Invoke();
        }
    }
}
