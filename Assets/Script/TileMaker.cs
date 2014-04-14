using UnityEngine;
using System.Collections;

public class TileMaker : MonoBehaviour {
	public GameObject obj;
	const float offsetTile = 1.2f;
	const int MaxTile = 9;
	int[,] map = new int[MaxTile, MaxTile] { 
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, }, 
		{ 0, 1, 1, 1, 1, 1, 1, 1, 0, }, 
		{ 0, 1, 1, 1, 1, 1, 1, 1, 0, }, 
		{ 0, 1, 1, 1, 1, 1, 1, 1, 0, },
		{ 0, 1, 1, 1, 1, 1, 1, 1, 0, },
		{ 0, 1, 1, 1, 1, 1, 1, 1, 0, },
		{ 0, 1, 1, 1, 1, 1, 1, 1, 0, },
		{ 0, 1, 1, 1, 1, 1, 1, 1, 0, },
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, }};
	public static GameObject[,] mapObj = new GameObject[MaxTile, MaxTile];


	// Use this for initialization
	void Start () {
		GenerateMap();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void GenerateMap(){
		for(int i=0;i<MaxTile;++i){
			for(int j=0;j<MaxTile;++j){
				GameObject a = GameObject.Instantiate(obj) as GameObject;
				a.transform.parent = gameObject.transform;
				a.transform.localPosition = new Vector3(offsetTile*i,offsetTile*j,0f);
				a.name = "TILE["+i.ToString()+"]["+j.ToString()+"]";
				mapObj[i,j] = a;

				Tile b = a.GetComponent<Tile>();
				if(map[i,j]==0){
					b.SetTile(Tile.TILE.ROCK);
				}else{
					b.SetTile(Tile.TILE.GREEN);
				}

				b.SetPos(i,j);
			}
		}
	}

	public static Vector2 GetPositionWorldTile(Node pos){
		return new Vector2(mapObj[pos.i,pos.j].transform.position.x,mapObj[pos.i,pos.j].transform.position.y);
	}
	public static Tile GetTile(Node pos){
		return mapObj[pos.i,pos.j].GetComponent<Tile>();
	}
}
