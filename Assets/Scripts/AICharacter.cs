using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class AICharacter : MonoBehaviour {

    private NavMeshAgent nav;
    public float navRadius = 15;
    private float timer;

    // Use this for initialization
    void Start () {
        nav = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
		if (!nav.isActiveAndEnabled) {
			return;
		}
        if (timer <=0)
        {
            Vector3 randomDirection = Random.insideUnitSphere * navRadius;
            randomDirection += transform.position;
            NavMeshHit hit;
            Vector3 finalPosition = Vector3.zero;
            if (NavMesh.SamplePosition(randomDirection, out hit, navRadius, 1))
            {
                nav.destination = new Vector3(hit.position.x, 0.05f,hit.position.z);
            }
            timer = Random.Range(5f, 8f);
        }
        timer -= Time.deltaTime;

    }
}
