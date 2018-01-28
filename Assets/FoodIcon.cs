using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodIcon : MonoBehaviour {

    [Range(0, 3)]
    public int ID = 0;
    public Sprite[] IconList;
    public Image[] CheckboxList;
    public Text underschrift;
    public bool[] Checked;

	// Use this for initialization
	void Start () {
        //Checkboxes initialize
        Checked = new bool[8];
        for (int i = 0; i < Checked.Length; i++)
        {
            Checked[i] = false; //No checks visible
            CheckboxList[i].gameObject.SetActive(false);
        }
	}

    public void heDidIt(int PlayerNr)
    {
        Checked[PlayerNr] = true;
        CheckboxList[PlayerNr].gameObject.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	public string current = "";

    public void changeIcon(string prefab)
    {
        Debug.Log(prefab);
        for(int i=0; i<IconList.Length; i++)
        {
            if (prefab == IconList[i].name)
            {
                this.GetComponent<Image>().sprite = IconList[i];
                underschrift.text = prefab;
            }
        }
    }

}
