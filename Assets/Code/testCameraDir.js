#pragma strict

function Start () {
var cube2=GameObject.Find("Cube100red");
cube2.GetComponent.<Renderer>().material.color=Color.red;

cube2=GameObject.Find("Cube001blue");
cube2.GetComponent.<Renderer>().material.color=Color.blue;
cube2=GameObject.Find("Cube010green");
cube2.GetComponent.<Renderer>().material.color=Color.green;
}

function Update () {

}