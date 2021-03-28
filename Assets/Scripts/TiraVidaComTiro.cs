using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TiraVidaComTiro: MonoBehaviour
{
    public float RangeTiro;
    public Camera mainCamera;
    public int damageTiro = 10;
    Atirar _atirar;
    AudioSource _audioSource;
    public AudioClip _som;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _atirar = GameObject.FindGameObjectWithTag("Player").GetComponent<Atirar>();
    }
    public void TiraVidaTiro()
    {
        _atirar.RetirarBalas();
         _audioSource.clip = _som;
            _audioSource.Play();
        RaycastHit hit;
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        if (Physics.Raycast(ray, out hit, RangeTiro))
        {
            var t = hit.transform.GetComponent<Vida>();
            if (t != null)
            { t.retiraVida(damageTiro); }           
        }
    }  
}

