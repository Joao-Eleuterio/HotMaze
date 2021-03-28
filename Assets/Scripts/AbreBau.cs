using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AbreBau : MonoBehaviour
{
    public Animator _animator;
    public GameObject OpenPanel = null;
    public BoxCollider _box;
    bool _isInsideTrigger = false;
    bool _open = false;
    public int chave;
    public GameObject player;
    bool JaAbriu = false;

    void Start()
    {

        OpenPanel.SetActive(false);
        _animator = GetComponent<Animator>();
        _box = GetComponent<BoxCollider>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            if(JaAbriu.Equals(false))
            OpenPanel.SetActive(true);

            _isInsideTrigger = true;
        }
    }
    private bool IsOpenPanelActive
    {
        get
        { return OpenPanel.activeInHierarchy; }
    }
    void Update()
    {
        if (_isInsideTrigger.Equals(true) && IsOpenPanelActive)
        {
           if (Input.GetKeyDown(KeyCode.E))
            {
                _animator.SetBool("open", !_open);
                _box.isTrigger = true;
               
                if(_box.tag.Equals("Bau1"))
                {
                    JaAbriu = true;
                    chave++;
                    OpenPanel.SetActive(false);
                    _box.GetComponent<BoxCollider>().enabled = false;
                    this.enabled = false;
                    

                }
                if(_box.tag.Equals("Bau2"))
                {   
                    JaAbriu = true;
                    chave++; 
                    OpenPanel.SetActive(false);
                    _box.GetComponent<BoxCollider>().enabled = false;
                    this.enabled = false;
                }             
                   if (_box.tag.Equals("Bau3"))
                   {
                        JaAbriu = true;
                        chave++;
                        OpenPanel.SetActive(false);
                        _box.GetComponent<BoxCollider>().enabled = false;
                        this.enabled = false;    
                   }          
            }
        }
    }
    private void OnTriggerExit(Collider other)
    { 
        OpenPanel.SetActive(false);
        _isInsideTrigger = false;
        if (other.tag.Equals("Player") && chave > 0)
        {
            _animator.SetBool("open", false);
            this.enabled = false;
            _animator.GetComponent<Animator>().enabled = false;
        }
    }
    public int GetChave()
    { return chave; }
    public void RetirarChave()
    {  chave=0; }
}
