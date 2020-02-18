using UnityEngine;
using System.Collections;

public class CubeTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//  示例  https://blog.csdn.net/yy763496668/article/details/53015674
		  for (int i = 0; i < 10; i+=2)
        {
            GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            obj.transform.position = new Vector3(i,0,0);
         // obj.GetComponent<Material>().color = Color.blue;

        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
