using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraControler : MonoBehaviour
{
	private void Update() {
    }





	/*
    private Vector3 forward = new Vector3(0, 0, 1);
    private Vector3 clockwise = new Vector3(0, 1, 0);
    public int MSpeed;
    public int RSpeed;
    public Material mat;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
            Move(forward);

        if (Input.GetKey(KeyCode.S))
            Move(-forward);

        if (Input.GetKey(KeyCode.D))
            Rotate(clockwise);

        if (Input.GetKey(KeyCode.A))
            Rotate(-clockwise);

        if (Input.GetKey(KeyCode.E))
            Move(new Vector3(1, 0, 0));

        if (Input.GetKey(KeyCode.Q))
            Move(-new Vector3(1, 0, 0));


    }

    void Move(Vector3 dir)
    {
        transform.Translate(dir *MSpeed * Time.deltaTime);
    }

    void Rotate(Vector3 dir)
    {
        transform.Rotate(dir * RSpeed * Time.deltaTime);
    }

    /*
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, mat);
    }
    */

}
