using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsMove : MonoBehaviour
{
    public float speed = 0.2f;

    private void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }
}
