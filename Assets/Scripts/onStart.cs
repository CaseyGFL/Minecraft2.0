using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onStart : MonoBehaviour {
    public Image background;
    Vector3 newSize;
	// Use this for initialization
	void Start () {
        background.rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
