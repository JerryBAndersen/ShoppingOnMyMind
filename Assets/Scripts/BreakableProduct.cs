using UnityEngine;
using System.Collections;

public class BreakableProduct : Product, Breakable
{
	GameObject[] fragmentPrefabs = null;
	GameObject[] fragments = null;

	public bool isBroken{
		get{ 
			return fragments != null;
		}
	}

	public void Break(){
		fragments = new GameObject[fragmentPrefabs.Length];
		for (int i= 0; i < fragmentPrefabs.Length; i++) {
			fragments[i] = Instantiate (fragmentPrefabs [i]);
		}
	}
}