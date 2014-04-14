using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour {
	List<Node> path = new List<Node>();
	public GameObject go_controller;
	public GameObject satoshi;
	const float speed_satoshi = 3.0f;
	public Node now_satoshi;
	GameController gc;

	// Use this for initialization

	void Start () {
		gc = go_controller.GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
		PlayerCheckTouch();
		MoveSatoshi();
	}
	void PlayerCheckTouch(){
		GameObject hit = gc.CheckTouch();
		if(hit==null)return;

		Tile a = hit.GetComponent<Tile>();
		if(!isMovable(a))return;

		a.SelectTile();

		SavePathPlayer(a.pos);
	}

	void SavePathPlayer(Node newNode){
		if(path.Count>0 && newNode.Equals(path[path.Count-1]))return;
		path.Add(newNode);

		/*string ShowPath = "";
		foreach(Node b in path){
			ShowPath+=",("+b.i+","+b.j+")";
		}
		Debug.Log(ShowPath);*/
	}

	bool isMovable(Tile a){
		if(!a.isPass())return false;
		if(path.Count>0){
			float distance = Mathf.Abs(a.pos.i-path[path.Count-1].i)+Mathf.Abs(a.pos.j-path[path.Count-1].j);
			if(distance>=2)return false;
		}
		return true;
	}
	void MoveSatoshi(){
		if(path.Count>0){
			Hashtable hashtable = new Hashtable();
			hashtable.Add("position", GetPositionWorldTile(path[0]));
			hashtable.Add("speed", speed_satoshi);
			hashtable.Add("onComplete", "RemoveHeadPath");
			hashtable.Add("onCompleteTarget", gameObject);
			hashtable.Add("easetype",iTween.EaseType.linear);
			iTween.MoveTo(satoshi,hashtable);
		}
	}
	void RemoveHeadPath(){
		if(path.Count>0){
			UnSelectTile(path[0]);
			path.RemoveAt(0);
		}
	}
	void UnSelectTile(Node a){
		for(int i=1;i<path.Count;++i){
			if(a.Equals(path[i]))return;
		}
		Tile b = TileMaker.GetTile(a);
		b.UnSelectTile();
	}
	Vector3 GetPositionWorldTile(Node a){
		return new Vector3(TileMaker.GetPositionWorldTile(a).x,TileMaker.GetPositionWorldTile(a).y,satoshi.transform.position.z);
	}
}



public class Node{
	public int i=0;
	public int j=0;
	public bool Equals(Node nodeObj){
		return (this.i==nodeObj.i)&(this.j==nodeObj.j);
	}
};