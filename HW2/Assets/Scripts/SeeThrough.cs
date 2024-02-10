using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeThrough : MonoBehaviour
{
    public Transform mainCamera;
    public Transform lens;

    void Update()
    {
        Vector3 localPlayer = lens.InverseTransformPoint(mainCamera.position);
        transform.position = lens.position;

        Vector3 lookatmirror = lens.TransformPoint(new Vector3(-localPlayer.x, -localPlayer.y, -localPlayer.z));
        transform.LookAt(lookatmirror, lens.up);
    }
}
