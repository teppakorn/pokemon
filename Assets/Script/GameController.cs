using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		//CheckTouch();
	}
	public GameObject CheckTouch(){
		if (Input.GetMouseButton(0)){
		 	RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			if(hit.collider != null){
				return hit.collider.gameObject;
			}
		}
		return null;
	}
}
