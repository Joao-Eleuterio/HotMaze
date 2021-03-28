using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using UnityStandardAssets.Characters.FirstPerson;

public class NPC : MonoBehaviour
{
    [SerializeField]
    Transform[] pontos; //este vetor terá os pontos em que o npc vai passar
    public int proximoPonto = 0;
    [SerializeField]
    float velocidade = 1;
    [SerializeField]
    float distanciaMinima;
    [SerializeField]
    bool emMovimento = false;
    [SerializeField]
    AudioClip som;
    public float tempo;
    public bool seguir = false;
    AudioSource _audioSource;
    Rigidbody _rigidbody;
    NavMeshAgent _navMeshAgent;
    Animator _animator;
    GameObject player;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _rigidbody = GetComponent<Rigidbody>();  //faz cache do rigidbody        
        _navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if (player == null)
            return;
        //distancia para o proximo ponto      
            if (Util.CanYouSeeThis(player.transform.position, this.transform.position))
            {
                seguir = true;
                tempo = 0;
            }
            else
            {
                tempo += Time.deltaTime;
                if (tempo >= 5)
                    seguir = false;
            }
        if (seguir)
        {
          _navMeshAgent.destination = player.transform.position;
          _animator.SetFloat("velocidade", _navMeshAgent.velocity.magnitude);
        }      
        else
        {
            if (pontos.Length.Equals(0))
            {
                Debug.Log("Tem de indicar os pontos a percorrer");
                return;
            }
            if (Vector3.Distance(transform.position, pontos[proximoPonto].position) < distanciaMinima)
            {
                //passa para o próximo
                proximoPonto++;
                if (proximoPonto > pontos.Length - 1)//nao tem mais pontos volta ao inicio
                    proximoPonto = 0;
            }
            else
            {
                _navMeshAgent.SetDestination(pontos[proximoPonto].position);
                _animator.SetFloat("velocidade", _navMeshAgent.velocity.magnitude);
            }
        }
    }
}