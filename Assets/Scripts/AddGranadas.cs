using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGranadas : MonoBehaviour
{
    public int addGranadas = 2;

    private void OnTriggerEnter(Collider other)
    {
        AdicionarGranadas(other);
    }
    private void AdicionarGranadas(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            other.GetComponent<Atirar_granada>().AddGranada(addGranadas);
            Destroy(this.gameObject);
        }
    }
}
