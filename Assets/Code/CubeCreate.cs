using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;

public class CubeCreate : MonoBehaviour {
	public int testFace;
    public int fontSize=25;
    //public int TestFace2{set;get;}
    float thick=0.05f;
	float width=1f;
	float fill=0.9f;
    DateTime startTime=DateTime.Now;
    int stepCount;
	List<CubeState> CubeStates=new List<CubeState>();
    GameObject TextCount;

    bool saveRecover = true;
    int screenWidth;
    int screenHeight;
    float buttonWidth;
    float buttonHeight;
    GUIStyle fontStyle;
    /// <summary>
    /// 
    /// </summary>
    List<StepRecord> stepRecovers = new List<StepRecord>();
    

    // Use this for initialization定义
    void Start () {
        
        //GUI.skin.button.fontSize = fontSize;
        //  示例  https://blog.csdn.net/yy763496668/article/details/53015674
        /*  for (int i = 0; i < 10; i+=2)
        {
            GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            obj.transform.position = new Vector3(i,0,0);
          //  obj.GetComponent<Material>().color = Color.blue;

        }
		 */
         /*
        fontStyle = new GUIStyle();
        fontStyle.alignment = TextAnchor.MiddleCenter;
        fontStyle.fontSize = 25;
       // fontStyle.normal.textColor = Color.white;
        //fontStyle.normal.background = (Texture2D)buttonTexture;
//https://blog.csdn.net/qianqi33/article/details/78925131
*/

       
        TextCount = GameObject.Find("TextCount");
      
       
        screenWidth = UnityEngine.Screen.width;
        screenHeight= UnityEngine.Screen.height;
        buttonWidth = screenWidth * 0.1f;
        buttonHeight = screenHeight * 0.1f;
        bottomButtonStart = screenHeight * 0.7f;
        rightButtonStart = UnityEngine.Screen.width - 2.10f*buttonWidth;
        CreateCubes();
        print(screenWidth);
        fontSize =Convert.ToInt32( screenWidth / 1000f * 20);

    }
	
	// Update is called once per frame
	void Update () {
        var time1 = DateTime.Now.Subtract(startTime);
        TextCount.GetComponentInChildren<TextMesh>().text = string.Format("{0}:{1:00} | {2}", time1.Minutes, time1.Seconds, stepCount);
 
    }
	float rightButtonStart=600;
	float bottomButtonStart=300;
    bool firstFontSize = true;
	void OnGUI(){
        if(firstFontSize)
        {
            firstFontSize = false;
            print("GUI.skin.button.fontSize" + GUI.skin.button.fontSize);
            GUI.skin.button.fontSize = fontSize;
        }
     
        if (GUI.Button(new Rect(0, 0, buttonWidth, buttonHeight), "B"))
		 {
             RotateLevel("z",new int[]{ 1},true);
        }
	

        if (GUI.Button(new Rect(1.10f*buttonWidth, 0, buttonWidth, buttonHeight), "B'"))
        {
          RotateLevel("z", new int[] { 1 }, false);
        }
        	if (GUI.Button(new Rect(0, 2*buttonHeight, buttonWidth, buttonHeight), "U"))
		 {
            RotateLevel("y", new int[] { 1 }, true);
        }
	

        if (GUI.Button(new Rect(1.10f * buttonWidth, 2 * buttonHeight, buttonWidth, buttonHeight), "U'"))
        {
             RotateLevel("y", new int[] { 1 }, false);
        }
		
		 	if (GUI.Button(new Rect(0, 5f * buttonHeight, buttonWidth, buttonHeight), "L"))
		 {
           RotateLevel("x", new int[] { -1 }, true);
        }
	

        if (GUI.Button(new Rect(1.10f * buttonWidth, 5f * buttonHeight, buttonWidth, buttonHeight), "L'"))
        {
            RotateLevel("x", new int[] { -1 }, false);
        }
		
		
		if (GUI.Button(new Rect(rightButtonStart, 0, buttonWidth, buttonHeight), "R"))
		 {
           RotateLevel("x", new int[] { 1 }, true);
        }
	

        if (GUI.Button(new Rect(rightButtonStart+ 1.10f * buttonWidth, 0, buttonWidth, buttonHeight), "R'"))
        {
            RotateLevel("x", new int[] { 1 }, false);
        }
		
		
			if (GUI.Button(new Rect(rightButtonStart, 2 * buttonHeight, buttonWidth, buttonHeight), "F"))
		 {
             RotateLevel("z", new int[] { -1 }, false);
        }
	

        if (GUI.Button(new Rect(rightButtonStart+ 1.10f * buttonWidth, 2 * buttonHeight, buttonWidth, buttonHeight), "F'"))
        {
            RotateLevel("z", new int[] { -1 }, true);
        }
		
			if (GUI.Button(new Rect(rightButtonStart, 5 * buttonHeight, buttonWidth, buttonHeight), "D"))
		 {
             RotateLevel("y", new int[] { -1 }, false);
        }
	

        if (GUI.Button(new Rect(rightButtonStart+ 1.10f * buttonWidth, 5 * buttonHeight, buttonWidth, buttonHeight), "D'"))
        {
            RotateLevel("y", new int[] { -1 }, true);
        }


        if (GUI.Button(new Rect(rightButtonStart, 3.5f * buttonHeight, 0.65f* buttonWidth, 0.8f*buttonHeight), "打乱"))
        {
            var arxs = new string[] { "x","y","z"};
            //var rand = new Random();
            for (var i=0;i<20;i++)
            {
               var arx= UnityEngine.Random.Range(0, 2);
                var dire= Convert.ToBoolean( UnityEngine.Random.Range(0, 1));
                var level= UnityEngine.Random.Range(-1, 1);
                RotateLevel(arxs[arx], new int[] {level }, dire);
            }
            startTime = DateTime.Now;
            stepCount = 0;
        }


        if (GUI.Button(new Rect(rightButtonStart+0.70f*buttonWidth, 3.5f*buttonHeight, 0.65f * buttonWidth, 0.8f * buttonHeight), "记忆点"))
        {
            saveRecover = true;
            stepRecovers.Clear();
        }

        if (GUI.Button(new Rect(rightButtonStart + 1.40f * buttonWidth, 3.5f * buttonHeight, 0.65f * buttonWidth, 0.8f * buttonHeight), "还原"))
        {
            for(var i=stepRecovers.Count-1;i>=0;i--)
            {
                var step = stepRecovers[i];
                RotateLevel(step.Arx, step.Levels, !step.Forward);
            }
            stepRecovers.Clear();
        }




        if (GUI.Button(new Rect(0, bottomButtonStart, 0.9f * buttonWidth, 0.9f * buttonHeight), "X"))
		 {
			//for(var i=-1;i<=1;i++)
           		 RotateLevel("x", new int[] { -1,0,1 }, true);

        }
	

        if (GUI.Button(new Rect(0, bottomButtonStart+ 1.8f*buttonHeight, 0.9f * buttonWidth, 0.9f * buttonHeight), "X'"))
        {
           //for(var i=-1;i<=1;i++)
           		 RotateLevel("x", new int[] { -1, 0, 1 }, false);
        }
		
			if (GUI.Button(new Rect(1* buttonWidth, bottomButtonStart, 0.9f * buttonWidth, 0.9f * buttonHeight), "Y"))
		 {
            //for(var i=-1;i<=1;i++)
           		 RotateLevel("y", new int[] { -1, 0, 1 }, true);
        }
	

        if (GUI.Button(new Rect( 1 * buttonWidth, bottomButtonStart + 1.8f * buttonHeight, 0.9f * buttonWidth, 0.9f * buttonHeight), "Y'"))
        {
           // for(var i=-1;i<=1;i++)
           		 RotateLevel("y", new int[] { -1, 0, 1 }, false);
        }
				if (GUI.Button(new Rect(2 * buttonWidth, bottomButtonStart, 0.9f * buttonWidth, 0.9f * buttonHeight), "Z"))
		 {
           //for(var i=-1;i<=1;i++)
           		 RotateLevel("z", new int[] { -1, 0, 1 }, true);
        }
	

        if (GUI.Button(new Rect( 2 * buttonWidth, bottomButtonStart + 1.8f * buttonHeight, 0.9f * buttonWidth, 0.9f * buttonHeight), "Z'"))
        {
             //for(var i=-1;i<=1;i++)
           		 RotateLevel("z", new int[] { -1, 0, 1 }, false);
        }


   

    }
	
	void RotateLevel(string arx,int[] level,bool forward)
	{
        if (level.Length == 1)
            stepCount++;
        if(saveRecover)
        {
            stepRecovers.Add(new StepRecord( arx,level,forward));
        }

		int vecX=0,vecY=0,vecZ=0,angel=0;
		List<CubeState> cubes;
			if(forward)
			angel=90;
		else
			angel=-90;
		List<RotateWatch> listWatch=new List<RotateWatch>();
		if(arx=="x")
		{
			vecX=1;
			cubes=CubeStates.Where(p=> level.Contains( p.X)).ToList();
			cubes.ForEach(p=>{
				p.Cube.GetComponent<Renderer>().transform.RotateAround(new Vector3 (0f,0f, 0f), new Vector3 (vecX, vecY, vecZ), angel);
				var x0=  p.Z;
				var y0=p.Y;
				var angelValau=Math.PI*angel/180;
				p.Z=(int)Math.Round( x0 * Math.Cos(angelValau) + y0 * Math.Sin(angelValau),0);
				p.Y=(int)Math.Round(-x0 * Math.Sin(angelValau) + y0 * Math.Cos(angelValau),0);
				listWatch.Add(new RotateWatch(x0,y0,p.Z,p.Y,p.Color,p.Cube));
			});	
		}
		else if(arx=="y")
		{
			vecY=1;
			cubes=CubeStates.Where(p=> level.Contains(p.Y)).ToList();
			cubes.ForEach(p=>{
				p.Cube.GetComponent<Renderer>().transform.RotateAround(new Vector3 (0f,0f, 0f), new Vector3 (vecX, vecY, vecZ), angel);
			var x0=  p.X;
				var y0=p.Z;
				var angelValau=Math.PI*angel/180;
				p.X= (int)Math.Round(x0 * Math.Cos(angelValau) + y0 * Math.Sin(angelValau),0);
				p.Z=(int)Math.Round(-x0 * Math.Sin(angelValau) + y0 * Math.Cos(angelValau),0);
				listWatch.Add(new RotateWatch(x0,y0,p.Z,p.X,p.Color,p.Cube));
			});	
		}
		else if(arx=="z")
		{
			vecZ=1;
			cubes=CubeStates.Where(p=> level.Contains(p.Z)).ToList();
			cubes.ForEach(p=>{
				p.Cube.GetComponent<Renderer>().transform.RotateAround(new Vector3 (0f,0f, 0f), new Vector3 (vecX, vecY, vecZ), angel);
				var x0=  p.Y;
				var y0=p.X;
				var angelValau=Math.PI*angel/180;
				p.Y= (int)Math.Round(x0 * Math.Cos(angelValau) + y0 * Math.Sin(angelValau),0);
				p.X=(int)Math.Round(-x0 * Math.Sin(angelValau) + y0 * Math.Cos(angelValau),0);
				listWatch.Add(new RotateWatch(x0,y0,p.X,p.Y,p.Color,p.Cube));
			});	
		}
		
		var strs= listWatch.OrderBy(p=>p.y0).ThenBy(p=>p.x0).Select(p=>string.Format("{0},{1}  {2},{3}  {4}  {5},{6},{7}"
			,p.x0,p.y0,p.x1,p.y1,p.Color
			,Math.Round( p.Cube.transform.position.x,1)
			,Math.Round( p.Cube.transform.position.y,1)
			,Math.Round( p.Cube.transform.position.z,1))).ToArray();
		var str=String.Join("\n",strs);
		print ( string.Format("{2} {0}  \n{1}",angel, str,arx));
		// Debug.Log("第二个Button被点击了！");
		/*
		StringBuilder sb0=new StringBuilder();
		StringBuilder sb1=new StringBuilder();
	     for(var i=-1;i<=1;i++)//y
			for(var j=-1;j<=1;j++)//x
		{
			var watch=listWatch.
			sb0.Append(
		}
		*/
		/*
		CubeStates.ForEach(p=>{
				p.Cube.renderer.transform.RotateAround(new Vector3 (0f,0f, 0f), new Vector3 (vecX, vecY, vecZ), angel);
				
			});	
			
			cubes.ForEach(p=>{
				p.Cube.renderer.transform.RotateAround(new Vector3 (0f,0f, 0f), new Vector3 (vecX, vecY, vecZ), angel);
				
			});	
			*/
		
		
	}
	
	
	void CreateCubes()
	{
				//x z为平面轴，y为高度轴
		//上表面 黄色
			if(testFace==0||testFace==1)
	  for (int i = -1; i <=1 ; i++)//x
			for (int j = -1; j <= 1; j++)//z
        {
            GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
			obj.transform.localScale=new Vector3(fill,thick,fill);
            obj.transform.position = new Vector3(i*width,1.5f*width, j*width);
			obj.GetComponent<MeshRenderer>().material.color=Color.yellow;
			CubeStates.Add(new CubeState(obj,i,1,j,"yellow"));
        }
										//下表面 白色
		if(testFace==0||testFace==2)
	  for (int i = -1; i <=1 ; i++)//x
			for (int j = -1; j <= 1; j++)//z
        {
            GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
			obj.transform.localScale=new Vector3(fill,thick,fill);
            obj.transform.position = new Vector3(i*width,-1.5f*width, j*width);
			obj.GetComponent<MeshRenderer>().material.color=Color.white;
			CubeStates.Add(new CubeState(obj,i,-1,j,"white"));
        }
		/*
		//上表面 黄色
		if(testFace==0||testFace==1)
	  for (int i = -1; i <=1 ; i++) 
			for (int j = -1; j <= 1; j++)
        {
            GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
			obj.transform.localScale=new Vector3(fill,fill,thick);
            obj.transform.position = new Vector3(i*width,j*width,1.5f*width);
           // obj.GetComponent<Material>().color = Color.yellow;
			obj.GetComponent<MeshRenderer>().material.color=Color.white;
			CubeStates.Add(new CubeState(obj,i,j,1));
        }
	
			//下表面 白色
		if(testFace==0||testFace==2)
	  for (int i = -1; i <=1 ; i++)  //x
			for (int j = -1; j <= 1; j++)  //y
        {
            GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
			obj.transform.localScale=new Vector3(fill,fill,thick);
            obj.transform.position = new Vector3(i*width,j*width,-1.5f*width);
			obj.GetComponent<MeshRenderer>().material.color=Color.white;
			CubeStates.Add(new CubeState(obj,i,j,-1));
        }
          */
					//左表面 橙
		if(testFace==0||testFace==3)
	  for (int i = -1; i <=1 ; i++)//y
			for (int j = -1; j <= 1; j++)//z
        {
            GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
			obj.transform.localScale=new Vector3(thick,fill,fill);
            obj.transform.position = new Vector3(-1.5f*width, i*width,j*width);
			obj.GetComponent<MeshRenderer>().material.color=new Color(1f,0.5f,0);
			CubeStates.Add(new CubeState(obj,-1,i,j,"orange"));
        }
      
							//右表面 红
		if(testFace==0||testFace==4)
	  for (int i = -1; i <=1 ; i++)//y
			for (int j = -1; j <= 1; j++)//z
        {
            GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
			obj.transform.localScale=new Vector3(thick,fill,fill);
            obj.transform.position = new Vector3(1.5f*width, i*width,j*width);
			obj.GetComponent<MeshRenderer>().material.color=Color.red;
			CubeStates.Add(new CubeState(obj,1,i,j,"red"));
        }
		/*
									//前表面 蓝
		if(testFace==0||testFace==5)
	  for (int i = -1; i <=1 ; i++)//x
			for (int j = -1; j <= 1; j++)//z
        {
            GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
			obj.transform.localScale=new Vector3(fill,thick,fill);
            obj.transform.position = new Vector3(i*width,-1.5f*width, j*width);
			obj.GetComponent<MeshRenderer>().material.color=Color.blue;
			CubeStates.Add(new CubeState(obj,i,-1,j));
        }
											//后表面 绿
		if(testFace==0||testFace==6)
	  for (int i = -1; i <=1 ; i++)//x
			for (int j = -1; j <= 1; j++)//z
        {
            GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
			obj.transform.localScale=new Vector3(fill,thick,fill);
            obj.transform.position = new Vector3(i*width,1.5f*width, j*width);
			obj.GetComponent<MeshRenderer>().material.color=Color.green;
			CubeStates.Add(new CubeState(obj,i,1,j));
        }
        */
			//后表面 绿
			if(testFace==0||testFace==5)
	  for (int i = -1; i <=1 ; i++) 
			for (int j = -1; j <= 1; j++)
        {
            GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
			obj.transform.localScale=new Vector3(fill,fill,thick);
            obj.transform.position = new Vector3(i*width,j*width,1.5f*width);
           // obj.GetComponent<Material>().color = Color.yellow;
			obj.GetComponent<MeshRenderer>().material.color=Color.green;
			CubeStates.Add(new CubeState(obj,i,j,1,"green"));
        }
	
			//前表面 蓝
		if(testFace==0||testFace==6)
	  for (int i = -1; i <=1 ; i++)  //x
			for (int j = -1; j <= 1; j++)  //y
        {
            GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
			obj.transform.localScale=new Vector3(fill,fill,thick);
            obj.transform.position = new Vector3(i*width,j*width,-1.5f*width);
			obj.GetComponent<MeshRenderer>().material.color=Color.blue;
			CubeStates.Add(new CubeState(obj,i,j,-1,"blue"));
        }
		
		
		var strs= CubeStates.OrderBy(p=>p.Color).ThenBy(p=>p.X).ThenBy(p=>p.Y).ThenBy(p=>p.Z).Select(p=>string.Format("{0},{1},{2}  {3}",p.X,p.Y,p.Z,p.Color)).ToArray();
		var str=String.Join("\n",strs);
		print ( string.Format("all cube:\n {0}  ",str));
	}
}
//检查旋转是否正确
public class RotateWatch
{
	public int x0{set;get;}
	public int x1{set;get;}
	public int y0{set;get;}
	public int y1{set;get;}
	public string Color{set;get;}
	public GameObject Cube{set;get;}
	public RotateWatch(int x0,int y0,int x1,int y1,string color=null,GameObject cube=null)
					{
					this.x0=x0;
						this.x1=x1;
						this.y0=y0;
						this.y1=y1;
		Color=color;
		this.Cube=cube;
					}
}
/// <summary>
/// 单步操作记录
/// </summary>
public class StepRecord
{
    public int[] Levels { set; get; }
    public bool Forward { set; get; }
    public string Arx { set; get; }

  public StepRecord( string arx,int[] level,bool forward)
    {
        Levels = level;
        Forward = forward;
        Arx = arx;
    }
}
public class CubeState{
		public GameObject Cube{set;get;}
		public int X{set;get;}
		public int Y{set;get;}
		public int Z{set;get;}
	public string Color{set;get;}
	/*	public CubeState(GameObject cube,int x,int y,int z)
		{
			this.Cube=cube;
			this.X=x;
			this.Y=y;
			this.Z=z;
		}
		*/
	public CubeState(GameObject cube,int x,int y,int z,string color)
		{
		this.Color=color;
			this.Cube=cube;
			this.X=x;
			this.Y=y;
			this.Z=z;
		}
	}