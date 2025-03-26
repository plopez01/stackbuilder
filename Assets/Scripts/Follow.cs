using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] private Vector2 target;
    [SerializeField] private float delta;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.x, target.y, transform.position.z), Time.deltaTime);
    }

    public void Move()
    {
        target.y += delta;
    }
}
