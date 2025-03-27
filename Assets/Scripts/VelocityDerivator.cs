using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityDerivator : MonoBehaviour
{
    private Vector2 lastPos;
    private Vector2 velocity;

    private void Awake()
    {
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = ((Vector2)transform.position - lastPos) / Time.deltaTime;
        lastPos = transform.position;
    }

    public Vector2 GetVelocity()
    {
        return velocity;
    }
}
