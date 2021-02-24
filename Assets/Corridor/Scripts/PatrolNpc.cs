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
    private GameObject center;
    [SerializeField]
    private float time;

    [SerializeField]
    private string[] names;
    [SerializeField]
    private AlertsInUI alert;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        namePlayer.text = names[Random.Range(0,names.Length-1)];
        gameObject.transform.SetParent(center.transform);
    }
    void GotoNextPoint()
    {
        if (points.Length == 0)
            return;
        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
        pos++;
    }
    void Update()
    {
        if (pos <= points.Length && IsWalking)
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                GotoNextPoint();
            }
        }
        else if (!(pos < points.Length)) 
        {
            StopAllCoroutines();
            alert.ShowAlert($"{namePlayer.text} has been disconected.",1.5f);
            gameObject.SetActive(false);
        }
    }
    public void StartWalking()
    {
        agent.autoBraking = false;
        GotoNextPoint();
        animator.SetBool("IsWalking", true);
        IsWalking = true;
        StartCoroutine(FollowAgent());
    }
    private IEnumerator FollowAgent()
    {
        var wait = new WaitForSeconds(time);
        while (IsWalking)
        {
            var raster = new Raster
            {
                x = gameObject.transform.localPosition.x * -1,
                y = gameObject.transform.localPosition.z * -1,
                rotation = gameObject.transform.localRotation.eulerAngles.y
            };
            GlobalStats.playerSaveStats.Agent.Add(raster);
            yield return wait;
        }
    }
}
