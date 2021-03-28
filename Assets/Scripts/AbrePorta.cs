using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AbrePorta : MonoBehaviour
{
    MovePorta _MovePorta;
   public GameObject bau1,bau2,bau3;
    bool _isInsideTrigger=false;
    public GameObject OpenPanel = null;
    public BoxCollider _box;
    GameObject player;
    int chave;
    bool portaAberta1 = false, portaAberta2 = false, portaAberta3 = false;
    AbreBau _bau1;
    AbreBau _bau2;
    AbreBau _bau3;
    private void Start()
    {
        if (SceneManager.GetActiveScene().name.Equals("Nivel3"))
        { _bau3 = GameObject.FindGameObjectWithTag("Bau3").GetComponent<AbreBau>(); }
        _MovePorta = GetComponent<MovePorta>();
        _bau1 = GameObject.FindGameObjectWithTag("Bau1").GetComponent<AbreBau>();
        _bau2 = GameObject.FindGameObjectWithTag("Bau2").GetComponent<AbreBau>();
        OpenPanel.SetActive(false);
        _box = GetComponent<BoxCollider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            if (_box.tag.Equals("jaula3"))
            {
                _MovePorta.GetComponent<MovePorta>().enabled = true;
            }
            else
            {
                if (portaAberta1.Equals(true) && portaAberta2.Equals(true))
                { OpenPanel.SetActive(false);}
                OpenPanel.SetActive(true);
                _isInsideTrigger= true;
            }
        }
    }
    private void Update()
    {
        if (portaAberta1.Equals(false))
        {
            if (_isInsideTrigger.Equals(true) && _box.tag.Equals("jaula1"))
            {
                if (bau1.GetComponent<AbreBau>().enabled.Equals(false))
                {
                    chave++;
                    bau1.GetComponent<AbreBau>().enabled = true;
                }
                    if (chave > 0 && Input.GetKeyDown(KeyCode.E))
                    { 
                     _bau1.RetirarChave();
                    _MovePorta.GetComponent<MovePorta>().enabled = true;
                    OpenPanel.SetActive(false);
                    portaAberta1 = true;   
                    }
            }
        }
        if (portaAberta2.Equals(false))
        {
            if (_isInsideTrigger.Equals(true) && _box.tag.Equals("jaula2"))
            {
                if (bau2.GetComponent<AbreBau>().enabled.Equals(false))
                {
                    chave++;
                    bau2.GetComponent<AbreBau>().enabled = true;
                }
                if (chave > 0 && Input.GetKeyDown(KeyCode.E))
                {
                    _bau2.RetirarChave();
                    _MovePorta.GetComponent<MovePorta>().enabled = true;
                    OpenPanel.SetActive(false);
                    portaAberta2 = true;  
                }
            }
        }
        if (SceneManager.GetActiveScene().name.Equals("Nivel3"))
        {
            if (portaAberta3.Equals(false))
            {
                if (_isInsideTrigger.Equals(true) && _box.tag.Equals("jaula4"))
                {
                    if (bau3.GetComponent<AbreBau>().enabled.Equals(false))
                    {
                        chave++;
                        bau3.GetComponent<AbreBau>().enabled = true;
                    }
                    if (chave > 0 && Input.GetKeyDown(KeyCode.E))
                    {
                        _bau3.RetirarChave();
                        _MovePorta.GetComponent<MovePorta>().enabled = true;
                        OpenPanel.SetActive(false);
                        portaAberta3 = true;
                    }
                }
            }
        }
        if (_isInsideTrigger.Equals(true) && _box.tag.Equals("jaula3"))
        {
            _MovePorta.GetComponent<MovePorta>().enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            _isInsideTrigger = false;
            OpenPanel.SetActive(false);
        }
    }
}
