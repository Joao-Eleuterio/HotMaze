using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foi_Apanhado : MonoBehaviour
{
    Apanhar_arma _Apanha;
    [SerializeField]
    bool arma_na_mao=false;
    private void Start()
    { _Apanha = GetComponent<Apanhar_arma>(); }

    void Update()
    {
        if (_Apanha.Apanhou().Equals(true) || _Apanha.Equals(null))
            arma_na_mao = true;
        else
            arma_na_mao = false;   
    }
    public bool NaMao()
    { return arma_na_mao; }
}
