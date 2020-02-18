using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
	void OnGUI(){
		if (GUI.Button(new Rect(0, 0, 100, 50), "第一个Button"))
		 {
            Debug.Log("第一个Button被点击了！");
        }
	/*

        if (GUI.Button(new Rect(20, 20, 100, 50), "第二个Button"))
        {
            Debug.Log("第二个Button被点击了！");
        }
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
			CubeStates.Add(new CubeState(obj,i,1,j));
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
			CubeStates.Add(new CubeState(obj,i,-1,j));
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
			CubeStates.Add(new CubeState(obj,-1,i,j));
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
			CubeStates.Add(new CubeState(obj,1,i,j));
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
			CubeStates.Add(new CubeState(obj,i,j,1));
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
			CubeStates.Add(new CubeState(obj,i,j,-1));
        }
	}
}
public class CubeState{
		public GameObject Cube{set;get;}
		public int X{set;get;}
		public int Y{set;get;}
		public int Z{set;get;}
		public CubeState(GameObject cube,int x,int y,int z)
		{
			this.Cube=cube;
			this.X=x;
			this.Y=y;
			this.Z=z;
		}
	}