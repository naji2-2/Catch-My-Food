using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    private float minY = -4;

    void Start()
    {

    }

    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;

        if (transform.position.y < minY) {
            Destroy(gameObject);
        }
    }
}
