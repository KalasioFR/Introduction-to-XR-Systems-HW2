using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnifyingGlass : MonoBehaviour
{
    public Transform playerTarget;
    public Transform magnifyingGlass;
    public Transform magnifiedObject;

    void Update()
    {
        // Calculate the local position of the player relative to the magnifying glass
        Vector3 localPlayer = magnifyingGlass.InverseTransformPoint(playerTarget.position);

        // Update the position of the magnified object relative to the lens of the magnifying glass
        magnifiedObject.position = magnifyingGlass.TransformPoint(localPlayer);

        // Calculate the point to make the magnified object look at
        Vector3 lookAtPoint = magnifyingGlass.TransformPoint(-localPlayer);

        // Rotate the magnified object to look at the calculated point
        magnifiedObject.LookAt(lookAtPoint, magnifyingGlass.up);
    }
}
