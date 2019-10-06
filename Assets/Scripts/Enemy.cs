using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    private NavMeshAgent agent;
    [SerializeField] private GameObject player;
    private bool moveAcrossNavMeshesStarted;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        //if (agent.isOnOffMeshLink && !moveAcrossNavMeshesStarted)
        //{
        //    StartCoroutine(MoveAcrossNavMeshLink());
        //    moveAcrossNavMeshesStarted = true;
        //}

    }

    OffMeshLinkData data;
    Vector3 startPos, endPos;
    float duration, t, tStep;
    Object previousNavMesh;
    float angle;

    IEnumerator MoveAcrossNavMeshLink()
    {
        data = agent.currentOffMeshLinkData;
        agent.updateRotation = false;
        previousNavMesh = agent.navMeshOwner;
        angle = Vector3.Angle(agent.transform.position, player.transform.position) * Mathf.Deg2Rad;
        angle = Mathf.Clamp(angle, -1, 1);
        angle = Mathf.Acos(angle);
        startPos = agent.transform.position;
        startPos.z = 0;
        endPos = new Vector3(player.transform.position.x ,data.endPos.y, 0) ;
        duration = (endPos - startPos).magnitude / agent.speed;
        t = 0.0f;
        tStep = 1.0f / duration;
        while (t < 1.0f)
        {
            transform.position = Vector3.Lerp(startPos, endPos, t);
            agent.destination = transform.position;
            Debug.Log(agent.destination);
            t += tStep * Time.deltaTime;
            yield return null;
        }
        transform.position = endPos;
        agent.updateRotation = true;
        agent.CompleteOffMeshLink();
        moveAcrossNavMeshesStarted = false;

    }
}
