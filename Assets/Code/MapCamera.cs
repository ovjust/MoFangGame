using UnityEngine;
using System.Collections;

public class MapCamera : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        var mirrorCamera = GetComponent<Camera>();
        //MirrorFlipCamera(Camera.main);
        MirrorFlipCamera(mirrorCamera);
    }

    void MirrorFlipCamera(Camera camera)
    {
        Matrix4x4 mat = camera.projectionMatrix;
        mat *= Matrix4x4.Scale(new Vector3(-1, 1, 1));
        camera.projectionMatrix = mat;
    }

    // Update is called once per frame
    void Update()
    {

    }
}