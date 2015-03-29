//https://www.youtube.com/watch?v=KjJTsxXb1zU

function OnMouseEnter() {
	GetComponent.<Renderer>().material.color = Color.red;
}

function OnMouseExit() {
	GetComponent.<Renderer>().material.color = Color.white;
}

function OnMouseDown() {
	Application.LoadLevel("Instructions");
}