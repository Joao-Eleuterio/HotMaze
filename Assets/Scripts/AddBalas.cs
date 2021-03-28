using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBalas : MonoBehaviour
{
     public int addbalas = 10;

    private void OnTriggerEnter(Collider other)
    {
        AdicionarBalas(other);
    }
    private void AdicionarBalas(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            other.GetComponent<Atirar>().AdicionaBalas(addbalas);
            Destroy(this.gameObject);
        }
    }
}
