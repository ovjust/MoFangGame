using UnityEngine;
using System.Collections;

public class CubeTest : MonoBehaviour {
    float thick = 0.05f;
    float width = 1f;
    float fill = 0.9f;
    // Use this for initialization
    void Start () {
		//  示例  https://blog.csdn.net/yy763496668/article/details/53015674
		  for (int i = 0; i < 10; i+=2)
        {
            GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            obj.transform.position = new Vector3(i,0,0);
           // obj.GetComponent<Material>().color = Color.blue;
            obj.GetComponent<MeshRenderer>().material.color = Color.yellow;
        }

        /*
      //x z为平面轴，y为高度轴
      //上表面 黄色
     // if (testFace == 0 || testFace == 1)
          for (int i = -1; i <= 1; i++)//x
              for (int j = -1; j <= 1; j++)//z
              {
                  GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
                 // obj.transform.localScale = new Vector3(fill, thick, fill);
                  obj.transform.position = new Vector3(i * width, 1.5f * width, j * width);
                  obj.GetComponent<MeshRenderer>().material.color = Color.yellow;
                  //CubeStates.Add(new CubeState(obj, i, 1, j, "yellow"));
              }
              */
    }
    bool first = true;
	// Update is called once per frame
	void Update () {
	//if(first)
        {
            first = false;
           var obj=  GameObject.Find("Cube");
            obj.transform.Rotate(new Vector3(Time.deltaTime* 10f, 0, 0), Space.Self);
        }
	}
}
