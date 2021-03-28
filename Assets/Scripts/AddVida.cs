using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddVida : MonoBehaviour
{
    
    public int addvida = 1;

    private void OnTriggerEnter(Collider other)
    {
        AdicionarVida(other);
    }
    private void AdicionarVida(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            other.GetComponent<Vida>().adicionaVida(20);
            Destroy(this.gameObject);
        }
    }
}
