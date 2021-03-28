using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util : MonoBehaviour
{
    public static bool CanYouSeeThis(Vector3 positionFrom, Vector3 positionTo)
    {
        RaycastHit hit;
        var rayDirection = positionTo - positionFrom;
        // Debug.DrawRay(positionFrom, rayDirection, Color.blue);   Serve para observar se os NPCs conseguem ver o player(no Game não se vê)   
        if (Physics.Raycast(positionFrom, rayDirection, out hit))
        {
            return (hit.transform.position.Equals(positionTo));
        }
        return false;
    }
}
