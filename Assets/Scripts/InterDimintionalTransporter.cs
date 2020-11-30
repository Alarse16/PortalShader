using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class InterDimintionalTransporter : MonoBehaviour
{
    public Material[] materials;

    /*
    private void OnTriggerStay(Collider other)
    {
        if(other.name != "Main Camera")
            return;

        if (transform.position.z > other.transform.position.z)
        {
            Debug.Log("inside portal");
            foreach (Material material in materials)
            {
                material.SetInt("_StencilTest", (int)CompareFunction.Equal);
            }
            
        }
        else
        {
            Debug.Log("Outside portal");
            foreach (Material material in materials)
            {
                material.SetInt("_StencilTest", (int)CompareFunction.NotEqual);
            }
        }

    }
    */
    private void OnTriggerEnter(Collider other)
    {
        if (other.name != "Main Camera")
            return;

        foreach (Material material in materials)
        {

            if (material.GetInt("_StencilTest") == (int)CompareFunction.Equal)
            {
                material.SetInt("_StencilTest", (int)CompareFunction.NotEqual);
            }

            else if (material.GetInt("_StencilTest") == (int)CompareFunction.NotEqual)
            {
                material.SetInt("_StencilTest", (int)CompareFunction.Equal);
            }
        }
    }
}
