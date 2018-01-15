using UnityEngine;
using System.Collections;

public class ClickableSquare : MonoBehaviour {
    //Square ID
    public int squareNumber = 0;

	void OnMouseDown()
    {   //Prevent thesquare being clicked more than once.
        GameObject.Find("Game Manager").SendMessage("SquareClicked", gameObject);
        Destroy(this);
    }
}
