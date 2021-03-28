using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apanha_granada : MonoBehaviour
{
    [SerializeField]
    GameObject _granada;
    bool apanhou = false;
    private void OnTriggerEnter(Collider other)
    {
        _granada.SetActive(true);
        this.gameObject.SetActive(false);
        apanhou = true;
    }
    public bool Apanhou()
    { return apanhou;}
}

