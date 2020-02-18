using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;

public class CubeCreate : MonoBehaviour {
	public int testFace;
	//public int TestFace2{set;get;}
	float thick=0.05f;
	float width=1f;
	float fill=0.9f;
	List<CubeState> CubeStates=new List<CubeState>();
	// Use this for initialization定义
	void Start () {
		//  示例  https://blog.csdn.net/yy763496668/article/details/53015674
		/*  for (int i = 0; i < 10; i+=2)
        {
            GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            obj.transform.position = new Vector3(i,0,0);
          //  obj.GetComponent<Material>().color = Color.blue;

        }
		 */
	CreateCubes();
	}
	
	// Update is called once per frame
	void Update () {
		
       
	}
	int rightButtonStart=600;
	int bottomButtonStart=300;
	void OnGUI(){
		if (GUI.Button(new Rect(0, 0, 100, 50), "B"))
		 {
             RotateLevel("z",1,true);
        }
	

        if (GUI.Button(new Rect(110, 0, 100, 50), "B'"))
        {
          RotateLevel("z",1,false);
        }
        	if (GUI.Button(new Rect(0, 100, 100, 50), "U"))
		 {
            RotateLevel("y",1,true);
        }
	

        if (GUI.Button(new Rect(110, 100, 100, 50), "U'"))
        {
             RotateLevel("y",1,false);
        }
		
		 	if (GUI.Button(new Rect(0, 250, 100, 50), "L"))
		 {
           RotateLevel("x",-1,true);
        }
	

        if (GUI.Button(new Rect(110, 250, 100, 50), "L'"))
        {
            RotateLevel("x",-1,false);
        }
		
		
		if (GUI.Button(new Rect(rightButtonStart, 0, 100, 50), "R"))
		 {
           RotateLevel("x",1,true);
        }
	

        if (GUI.Button(new Rect(rightButtonStart+110, 0, 100, 50), "R'"))
        {
            RotateLevel("x",1,false);
        }
		
		
			if (GUI.Button(new Rect(rightButtonStart, 200, 100, 50), "F"))
		 {
             RotateLevel("z",-1,false);
        }
	

        if (GUI.Button(new Rect(rightButtonStart+110, 200, 100, 50), "F'"))
        {
            RotateLevel("z",-1,true);
        }
		
			if (GUI.Button(new Rect(rightButtonStart, 300, 100, 50), "D"))
		 {
             RotateLevel("y",-1,false);
        }
	

        if (GUI.Button(new Rect(rightButtonStart+110, 300, 100, 50), "D'"))
        {
            RotateLevel("y",-1,true);
        }
		
		
		
		
		
		
		
		
		
		
		
			if (GUI.Button(new Rect(0, bottomButtonStart, 80, 40), "X"))
		 {
			for(var i=-1;i<=1;i++)
           		 RotateLevel("x",i,true);

        }
	

        if (GUI.Button(new Rect(0, bottomButtonStart+50, 80, 40), "X'"))
        {
           for(var i=-1;i<=1;i++)
           		 RotateLevel("x",i,false);
        }
		
			if (GUI.Button(new Rect(90, bottomButtonStart, 80, 40), "Y"))
		 {
            for(var i=-1;i<=1;i++)
           		 RotateLevel("y",i,true);
        }
	

        if (GUI.Button(new Rect(90, bottomButtonStart+50, 80, 40), "Y'"))
        {
            for(var i=-1;i<=1;i++)
           		 RotateLevel("y",i,false);
        }
				if (GUI.Button(new Rect(180, bottomButtonStart, 80, 40), "Z"))
		 {
           for(var i=-1;i<=1;i++)
           		 RotateLevel("z",i,true);
        }
	

        if (GUI.Button(new Rect(180, bottomButtonStart+50, 80, 40), "Z'"))
        {
             for(var i=-1;i<=1;i++)
           		 RotateLevel("z",i,false);
        }
	}
	
	void RotateLevel(string arx,int level,bool forward)
	{
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
			cubes=CubeStates.Where(p=>p.X==level).ToList();
			cubes.ForEach(p=>{
				p.Cube.renderer.transform.RotateAround(new Vector3 (0f,0f, 0f), new Vector3 (vecX, vecY, vecZ), angel);
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
			cubes=CubeStates.Where(p=>p.Y==level).ToList();
			cubes.ForEach(p=>{
				p.Cube.renderer.transform.RotateAround(new Vector3 (0f,0f, 0f), new Vector3 (vecX, vecY, vecZ), angel);
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
			cubes=CubeStates.Where(p=>p.Z==level).ToList();
			cubes.ForEach(p=>{
				p.Cube.renderer.transform.RotateAround(new Vector3 (0f,0f, 0f), new Vector3 (vecX, vecY, vecZ), angel);
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