using UnityEngine;
using System.Collections;

public class BackButton : MonoBehaviour {

	void Start () {
	
	}
	
	void OnMouseDown () 
    {
        Application.LoadLevel(0);
	}
}
