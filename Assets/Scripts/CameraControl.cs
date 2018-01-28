using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	public static CameraControl instance = null;
	public Transform camera;
	public Transform highPoint;
	public Transform lowPoint;
	public Transform center;

	void Awake(){
		if (instance == null) {
			instance = this;		
		}		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float maxDist = 0f;
        int pl = 0;
		Vector3 flat = Vector3.zero;
		foreach (var player in GameController.players) {
			if (player == null) {
				continue;
			}
            flat += player.GetComponentInChildren<SkinnedMeshRenderer>().transform.position;
            pl++;
			foreach (var other in GameController.players) {
				if (other == player || other == null) {
					continue;
				}
				maxDist = Mathf.Max (maxDist,Vector3.Distance(other.GetComponentInChildren<SkinnedMeshRenderer>().transform.position,player.GetComponentInChildren<SkinnedMeshRenderer>().transform.position));
			}
		}
		flat.y = 0;
		flat /= pl!=0?pl:1;
        flat = Vector3.Lerp(flat,center.position, .9f);
		center.position = flat;
        Vector3 nu = Vector3.Lerp (lowPoint.localPosition,highPoint.localPosition,maxDist/30f);
		camera.transform.localPosition = Vector3.Lerp(nu,camera.transform.localPosition,.99f);
	}
}
