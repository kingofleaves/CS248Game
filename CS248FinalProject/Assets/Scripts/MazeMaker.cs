using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class MazeMaker : MonoBehaviour {
	private bool MazeMade;
	public TextAsset stageFile;
	public int width, height;
	public Material brick = null;
	private int[,] Maze;
	private List<Vector3> pathMazes = new List<Vector3>();
	private Stack<Vector2> _tiletoTry = new Stack<Vector2>();
	private List<Vector2> offsets = new List<Vector2> { new Vector2(0, 1), new Vector2(0, -1), new Vector2(1, 0), new Vector2(-1, 0) };
	//private System.Random rnd = new System.Random();
	private int _width, _height;
	private Vector2 _currentTile;
	public String MazeString;
	//private Vector3 startPos;
	//private Vector3 goalPos;
	private Vector3 worldOffset;
	public GameObject floor;
	public GameObject mapBlock;
	public GameObject playerObj;
	public GameObject goal;
	public GameObject canon;
	public GameObject laser;
	public GameObject explosives1;
	public GameObject explosives2;
	public GameObject explosives3;
	private CharacterControl mainCharControl = null;


	public Vector2 CurrentTile {
		get { return _currentTile; }
		private set {
			if (value.x < 1 || value.x >= this.width - 1 || value.y < 1 || value.y >= this.height - 1){
				throw new ArgumentException("Width and Height must be greater than 2 to make a maze");
			}
			_currentTile = value;
		}
	}
	private static MazeMaker instance;
	public static MazeMaker Instance {
		get {return instance;}
	}
	void Awake()  { instance = this;}
	void Start() { 
		MazeMade = false;
	}

	void Update () {
		if (!MazeMade) {
			MakeBlocks (); 
			MazeMade = true;
		}
	}

	// end of main program

	// ============= subroutines ============

	void MakeBlocks() {
		Maze = CreateMaze();  // generate the maze in Maze Array.
		floor.transform.localScale = new Vector3 (width, 1f, height);
		Transform parentTransform = this.GetComponentInParent<Transform>();
		parentTransform.Translate(parentTransform.TransformPoint(worldOffset));
	}

	// =======================================
	public int[,] CreateMaze() {
		string stageInfo = stageFile.text;
		string[] stageInfoArray = stageInfo.Split ('\n');
		height = Convert.ToInt32(stageInfoArray[0].Trim());
		width = Convert.ToInt32(stageInfoArray[1].Trim());
		worldOffset = new Vector3 (-width / 2f + 0.5f, 1f, height / 2f - 0.5f); 
		Maze = new int[width, height];
		for (int z = 0; z < height; z++) {		
			// Debug.Log (stageInfoArray[2+z]);
			string currLine = stageInfoArray[2 + z].Trim ();
			for (int x = 0; x < width; x++) {
				Char currBlock = currLine [x];
				switch (currBlock) {
				case '0':
					Maze [x, z] = 0;
					break;
				case 'X':
					Maze [x, z] = 1;
					setObject(x, 0, z, mapBlock, Quaternion.identity);
					break;
				case 'S':
					Maze [x, z] = 0;
					GameObject playerInstance = setObject (x, 0, z, playerObj, Quaternion.identity);
					Camera perspCamera = GameObject.FindGameObjectWithTag ("CameraHandler").GetComponent<SwitchCamera> ().perspCamera;
					perspCamera.GetComponent<FollowCharacter> ().playerObject = playerInstance;
					CharacterControl charControl = playerInstance.GetComponent<CharacterControl> ();
					if (mainCharControl == null) {
						mainCharControl = charControl;
						mainCharControl.GameOverUI = GameObject.FindGameObjectWithTag ("GameOverUI");
						mainCharControl.SuccessUI = GameObject.FindGameObjectWithTag ("SuccessUI");
						mainCharControl.Menu = GameObject.FindGameObjectWithTag ("Menu");
						mainCharControl.GameOverUI.SetActive (false);
						mainCharControl.Menu.SetActive (false);
						mainCharControl.SuccessUI.SetActive (false);
					} else {
						charControl.GameOverUI = mainCharControl.GameOverUI;
						charControl.SuccessUI = mainCharControl.SuccessUI;
						charControl.Menu = mainCharControl.Menu;
					}
					break;
				case 'G':
					Maze [x, z] = 0;
					setObject(x, 0, z, goal, Quaternion.identity);
					break;
				case 'C':
					Maze [x, z] = 0;
					setObject(x, 0, z, canon, Quaternion.identity);
					break;
				case 'D':
					Maze [x, z] = 0;
					setObject(x, 0, z, canon, Quaternion.AngleAxis(90f, Vector3.up));
					break;
				case 'L':
					Maze [x, z] = 0;
					setObject(x, 0, z, laser, Quaternion.identity);
					break;
				case 'E':
					Maze [x, z] = 0;
					setObject(x, 0, z, explosives1, Quaternion.identity);
					break;
				case 'F':
					Maze [x, z] = 0;
					setObject(x, 0, z, explosives2, Quaternion.AngleAxis(90f, Vector3.left));
					break;
				case 'H':
					Maze [x, z] = 0;
					setObject(x, 0, z, explosives3, Quaternion.identity);
					break;
				case 'I':
					Maze [x, z] = 0;
					setObject(x, 0, z, explosives2, Quaternion.AngleAxis(90f, Vector3.forward));
					break;
				case 'Z':
					Maze [x, z] = 0;
					GameObject wallObject = setObject (x, 0, z, explosives2, Quaternion.identity);
					wallObject.GetComponentInChildren<Rigidbody> ().isKinematic = true;
					break;
				}
			}
		}
		return Maze;
	}

	// ================================================
	// Get all the prospective neighboring tiles "centerTile" The tile to test
	// All and any valid neighbors</returns>
	private List<Vector2> GetValidNeighbors(Vector2 centerTile) {
		List<Vector2> validNeighbors = new List<Vector2>();
		//Check all four directions around the tile
		foreach (var offset in offsets) {
			//find the neighbor's position
			Vector2 toCheck = new Vector2(centerTile.x + offset.x, centerTile.y + offset.y);
			//make sure the tile is not on both an even X-axis and an even Y-axis
			//to ensure we can get walls around all tunnels
			if (toCheck.x % 2 == 1 || toCheck.y % 2 == 1) {

				//if the potential neighbor is unexcavated (==1)
				//and still has three walls intact (new territory)
				if (Maze[(int)toCheck.x, (int)toCheck.y]  == 1 && HasThreeWallsIntact(toCheck)) {

					//add the neighbor
					validNeighbors.Add(toCheck);
				}
			}
		}
		return validNeighbors;
	}
	// ================================================
	// Counts the number of intact walls around a tile
	//"Vector2ToCheck">The coordinates of the tile to check
	//Whether there are three intact walls (the tile has not been dug into earlier.
	private bool HasThreeWallsIntact(Vector2 Vector2ToCheck) {

		int intactWallCounter = 0;
		//Check all four directions around the tile
		foreach (var offset in offsets) {

			//find the neighbor's position
			Vector2 neighborToCheck = new Vector2(Vector2ToCheck.x + offset.x, Vector2ToCheck.y + offset.y);
			//make sure it is inside the maze, and it hasn't been dug out yet
			if (IsInside(neighborToCheck) && Maze[(int)neighborToCheck.x, (int)neighborToCheck.y] == 1) {
				intactWallCounter++;
			}
		}
		//tell whether three walls are intact
		return intactWallCounter == 3;
	}

	// ================================================
	private bool IsInside(Vector2 p) {
		//return p.x >= 0  p.y >= 0  p.x < width  p.y < height;
		return p.x >= 0 && p.y >= 0 && p.x < width && p.y < height;
	}

	void SetStartAndGoal() {
		//GameObject.FindGameObjectWithTag ("Player").transform.localPosition = startPos;
		//GameObject.FindGameObjectWithTag ("Goal").transform.localPosition = goalPos;
	}

	GameObject setObject(int x, int y, int z, GameObject obj, Quaternion objRotation) {
		if (obj == null)
			return null;
		Vector3 pos = new Vector3 (x, 0, -z);
		//pos += worldOffset;
		GameObject objInstance = Instantiate (obj);
		Vector3 currScale = objInstance.transform.localScale;
		// DO THIS FOR POSITION AND ROTATION TOO
		objInstance.transform.parent = this.transform;
		objInstance.transform.localPosition = pos;
		objInstance.transform.localRotation = objRotation;
		objInstance.transform.localScale = currScale;
		return objInstance;
	}
}