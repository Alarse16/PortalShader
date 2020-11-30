using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSlowly : MonoBehaviour
{
    public int speed;

    // Update is called once per frame
    void Update()
    {
        rotate(new Vector3(1, 0, 0));
        rotate(new Vector3(0, 2, 0));
        rotate(new Vector3(0, 0, 3));
    }

    void rotate(Vector3 dir)
    {
        transform.Rotate(dir, speed * Time.deltaTime);
    }
}
