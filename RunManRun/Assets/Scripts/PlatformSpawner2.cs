using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner2 : MonoBehaviour {

	//public GameObject platform1;
	//public GameObject platform2;
	//public GameObject platform3;
	//public GameObject platform4;
	public GameObject platform;
	public GameObject platformEnd;

	public GameObject food1;//french fries
	public GameObject food2;//ice cream cone
	public GameObject food3;//muffin

	public GameObject food4;//burger
	public GameObject food5;//toast
	public GameObject food6;//rice bowl
	public GameObject food7;//avocado

	public GameObject food8;//bread



	Vector3 lastPos;
	bool lastPosIsSpawnedZ;

	float platformSizeX;
	float platformSizeZ;


	[HideInInspector]public bool gameOver;
	[HideInInspector]public int platformCount;

	int rand;
	int level;

	void Awake()
	{
		
	}

	// Use this for initialization
	void Start () {

	
		platformCount = 0;
		level = UIManager2.instance.level;

		lastPos = platform.transform.position;
		lastPosIsSpawnedZ = true;

		platformSizeX = platform.transform.localScale.x;
		platformSizeZ = platform.transform.localScale.z;


		//method1
		//for (int i = 1; i <= 10; i++) {
		//	SpawnPlatforms ();
		//}

		int limit = 0;

		switch (level) {
		case 1:
			limit = 30;
			break;
		case 2:
			limit = 40;
			break;
		case 3:
			limit = 50;
			break;

		case 4:
			limit = 50;
			break;

		}



		//method2
		for (int i = 1; i <= limit; i++) {
			SpawnPlatforms ();
		}
		platformCount = limit;
		loadLastPlatform ();
		Debug.Log("Loaded last platform");

	}

/*	public void startSpawning()
	{

		InvokeRepeating ("SpawnPlatforms",0.1f,0.2f);
	}

	// Update is called once per frame
	void Update () {
		if (GameManager2.instance.gameOver)
			stopSpawning ();
	}

	public void stopSpawning()
	{
		CancelInvoke ("SpawnPlatforms");
	}
*/

	void SpawnPlatforms () {



		rand= Random.Range (0, 6);



		if (rand < 3) {
			SpawnX ();
			//SpawnZ ();

		} else if (rand >= 3) {
			SpawnZ ();
			//SpawnX ();

		}


		platformCount += 1;

		int x = 2;//6:4:3:2.. ..60
//		Debug.Log ("Count="+platformCount);

		/*switch (level) {
		case 1:
			if (platformCount == 10*x) 
				loadLastPlatform ();
			break;
		case 2:
			if (platformCount == 15*x) 
				loadLastPlatform ();
			break;
		case 3:
			if (platformCount == 20 * x) {
				loadLastPlatform ();
			}
				
			break;

		case 4:
			if (platformCount == 5*x) 
				loadLastPlatform ();
			break;

		}*/
			
	}

	public void loadLastPlatform()
	{
		Vector3 pos = new Vector3(lastPos.x-1,lastPos.y,lastPos.z);
		pos.x += platformSizeX;
		platformEnd.transform.position = pos;
		//Instantiate (platformEnd, pos,  Quaternion.Euler(0,90,0));
		//CancelInvoke ("SpawnPlatforms");
		Debug.Log("Loaded last platform");
	}



	void SpawnX()
	{
		//Vector3 pos = lastPos;

		Vector3 pos = new Vector3(lastPos.x,lastPos.y,lastPos.z);
		//pos.x += platformSizeX;

		if(lastPosIsSpawnedZ)
		{
			pos.x+=(platformSizeX/2)+(platformSizeZ/2);
			pos.z += (platformSizeZ / 2) - (platformSizeX / 2);
			lastPosIsSpawnedZ = false;
		}
		else
		{
			pos.x += platformSizeZ;
			lastPosIsSpawnedZ = false;
			
		}
			
		lastPos = pos;
		Instantiate (platform, pos,  Quaternion.Euler(0,90,0));
		SpawnFood (pos);	
	}


	void SpawnZ()
	{
		//Vector3 pos = lastPos;
		Vector3 pos = new Vector3(lastPos.x,lastPos.y,lastPos.z);

		if(lastPosIsSpawnedZ)
		{
			pos.z += platformSizeZ;
			lastPosIsSpawnedZ =true;
		}
		else
		{
			pos.x+=(platformSizeZ/2)-(platformSizeX/2);
			pos.z+=(platformSizeZ/2)+(platformSizeX/2);
			lastPosIsSpawnedZ = true;
		}



		lastPos = pos;
		Instantiate (platform, pos,  Quaternion.identity);
		SpawnFood (pos);

	}



	void SpawnFood(Vector3 pos)
	{

		rand= Random.Range (1, 7);
		int rand2 = Random.Range (1, 3);

		int scaleFactor = 12;
	
		switch (rand) {
		case 1:
			var food = Instantiate (food1, new Vector3 (pos.x, pos.y + 4, pos.z), Quaternion.identity) as GameObject;

			if ( rand2>1) {
				food = Instantiate (food2, new Vector3(pos.x,pos.y+4,pos.z), Quaternion.identity)as GameObject;
			}
			food.transform.localScale = new Vector3(scaleFactor,scaleFactor,scaleFactor);
			break;
		
		case 2:
			
			if (rand2 < 2) {
				
				food = Instantiate (food3, new Vector3(pos.x,pos.y+4,pos.z), Quaternion.identity)as GameObject;

			} else {
				food = Instantiate (food4, new Vector3(pos.x,pos.y+4,pos.z), Quaternion.identity)as GameObject;
			}
			food.transform.localScale = new Vector3(scaleFactor,scaleFactor,scaleFactor);
			break;

		case 3:
			if (rand2 < 2) {
				food = Instantiate (food5, new Vector3(pos.x,pos.y+4,pos.z), Quaternion.identity)as GameObject;

			} else {
				food = Instantiate (food6, new Vector3(pos.x,pos.y+4,pos.z), Quaternion.identity)as GameObject;
			}
			food.transform.localScale = new Vector3(scaleFactor,scaleFactor,scaleFactor);	
			break;

		case 4:
			if (rand2 < 2) {
				food = Instantiate (food7, new Vector3(pos.x,pos.y+4,pos.z), Quaternion.identity)as GameObject;

			} else {
				food = Instantiate (food8, new Vector3(pos.x,pos.y+4,pos.z), Quaternion.identity)as GameObject;
			}
			food.transform.localScale = new Vector3(scaleFactor,scaleFactor,scaleFactor);
			break;

		}


	}


}
