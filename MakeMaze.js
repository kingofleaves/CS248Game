// makemaze.js  - MichShire Feb2015
// forum URL: https://forum.unity3d.com/threads/quick-maze-generator.173370/
 
var mazecube : GameObject;
var cubesize=3;
var brick : Material;
private var MazeString : String = "";
private var width : int;
private var height : int;
private static var mazearray : Array;
private var t : boolean = false ;
 
function Start() {
    MazeString = mazecube.GetComponent("MazeGenerator").MazeString;
    width = mazecube.GetComponent("MazeGenerator").width;
    height = mazecube.GetComponent("MazeGenerator").height;
    print ("mazegen width = " + width + " height = " + height +" array = \n" +MazeString);
    makeMaze();
}
 
function makeMaze() {
 
        var mazearray = MazeString.Split("\n"[0]);
        //print (mazearray[0]);
        //mod = mazearray[0];  index = 9;
    //mazearray[0] = mod.Substring(0, index) + '0' + mod.Substring(index + 1);
 
    RemoveBlocks(mazearray);
 
 
        for (var i : int = 0; i <width; i++)  {
            //print ("array " + i + " = " + mazearray[i]);
            for (var j : int = 0; j <height; j++)  {
                var st=mazearray[i];
                //print ("mazei= " + i + mazearray[i] );
                //print ("substring= " + st.Substring(0,1) );
                if (st.Substring(j,1)=="X")  {      // make a block if 'X' ...
                ptype = GameObject.CreatePrimitive(PrimitiveType.Cube);
                ptype.transform.position = new Vector3(j * cubesize, .5+(cubesize/2), i *cubesize);
                ptype.transform.localScale = new Vector3(cubesize, cubesize, cubesize);
 
                if (brick != null)  { ptype.GetComponent.<Renderer>().material = brick; }
                    ptype.transform.parent = transform;
                }
                // just to show colored blocks every second block
                t=!t;
                if (t==true && (i==0 || i==2 || i==4 ||i==6 || i==8 || i==10 || i==12)){
                //    ptype.GetComponent.<Renderer>().material.color = Color.red;
                }
            }
        }
        //t=1;
            return;
    }
 
    // ====================
function RemoveBlocks(mazearray) {
    var mod; var index;
 
    //print (mazearray[0]);
 
    // entrance
    mod = mazearray[0];  index = 1;
    mazearray[0] = mod.Substring(0, index) + '0' + mod.Substring(index + 1);
 
    // exit
    mod = mazearray[12];  index = 7;
    mazearray[12] = mod.Substring(0, index) + '0' + mod.Substring(index + 1);
}
   