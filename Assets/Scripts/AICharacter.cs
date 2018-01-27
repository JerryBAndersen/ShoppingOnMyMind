using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AICharacter : MonoBehaviour {

    private NavMeshAgent nav;
    public float navRadius = 5;
    private float timer;

    // Use this for initialization
    void Start () {
        nav = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
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
            timer = Random.Range(0.5f, 4f);
        }
        timer -= Time.deltaTime;

    }
}
