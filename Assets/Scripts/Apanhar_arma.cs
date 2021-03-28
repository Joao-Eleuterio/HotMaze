using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Apanhar_arma : MonoBehaviour
{
    [SerializeField]
    GameObject _arma, _mao;
    [SerializeField]
    BoxCollider _box;
    bool apanhou = false;
    
    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.SetActive(false);
        _box.GetComponent<BoxCollider>().enabled = false;
        apanhou = true;   
        PlayerPrefs.SetInt("arma", 1);
        PlayerPrefs.Save();
    }
   public bool Apanhou()
    { return apanhou; }
}
