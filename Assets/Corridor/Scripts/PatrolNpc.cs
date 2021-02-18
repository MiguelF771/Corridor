using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class PatrolNpc : MonoBehaviour
{
    private int pos = 0;
    private bool IsWalking = false;
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private TextMeshPro namePlayer;

    [SerializeField]
    private string[] names;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        namePlayer.text = names[Random.Range(0,names.Length-1)];
    }
    void GotoNextPoint()
    {
        if (points.Length == 0)
            return;
        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }
    void Update()
    {
        if (pos < points.Length && IsWalking)
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                GotoNextPoint();
                pos++;
            }
        }else if(!(pos < points.Length)) gameObject.SetActive(false);
    }
    public void StartWalking()
    {
        agent.autoBraking = false;
        GotoNextPoint();
        animator.SetBool("IsWalking", true);
        IsWalking = true;
    }
}
