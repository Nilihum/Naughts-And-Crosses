using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject naught;
    public GameObject cross;

    int[] squares = new int[9];

    //O moves on odds; X moves on evens
    int turn = 1;

    int winner = 0;
    int clickCount = 0;

	public void SquareClicked(GameObject square)
    {
        //Get Square Number
        int squareNumber = square.GetComponent<ClickableSquare>().squareNumber;
        print("Square number " + squareNumber + " was clicked.");
        //Spawn a Naught or Cross, as appropriate
        SpawnPrefab(square.transform.position);
        //Turns determined by squares clicked
        squares[squareNumber] = turn;
        clickCount++;
        CheckForWinner();
        NextTurn();
    }

    void CheckForWinner()
    {
       for (int player = 1; player <= 2; player++)
        {
            //Top row
            if (squares[0] == player && squares[1] == player && squares[2] == player)
            {
                DisableSquares();
                print("Player " + player + " wins!");
                winner = player;
            }
            //Middle Row
            else if (squares[3] == player && squares[4] == player && squares[5] == player)
            {
                DisableSquares();
                print("Player " + player + " wins!");
                winner = player;
            }
            //Bottom Row
            else if (squares[6] == player && squares[7] == player && squares[8] == player)
            {
                DisableSquares();
                print("Player " + player + " wins!");
                winner = player;
            }
            //Left Col
            else if (squares[0] == player && squares[3] == player && squares[6] == player)
            {
                DisableSquares();
                print("Player " + player + " wins!");
                winner = player;
            }
            //Middle Col
            else if (squares[1] == player && squares[4] == player && squares[7] == player)
            {
                DisableSquares();
                print("Player " + player + " wins!");
                winner = player;
            }
            //Right Col
            else if (squares[2] == player && squares[5] == player && squares[8] == player)
            {
                DisableSquares();
                print("Player " + player + " wins!");
                winner = player;
            }
            //LtR Diag
            else if (squares[0] == player && squares[4] == player && squares[8] == player)
            {
                DisableSquares();
                print("Player " + player + " wins!");
                winner = player;
            }
            //RtL Diag 
            else if (squares[2] == player && squares[4] == player && squares[6] == player)
            {
                DisableSquares();
                print("Player " + player + " wins!");
                winner = player;
            }
        }
       //No winner, Draw
       if (clickCount == 9 && winner == 0)
        {
            winner = 3;
        }
    }

    void DisableSquares()
    {   //Prevents any squares being clicked when someone wins
        foreach (ClickableSquare square in GameObject.FindObjectsOfType<ClickableSquare>())
        {
            Destroy(square);
        }
    }

    void SpawnPrefab(Vector3 position)
    {
        //places X and O in front of squares
        position.z = 0;

        if (turn == 1)
        {
            Instantiate(naught, position, Quaternion.identity);
        }

        else
        {
            Instantiate(cross, position, Quaternion.identity);
        }
    }

    void NextTurn()
    {
        turn++;

        if (turn == 3)
        {
            turn = 1;
        }
    }

    void OnGUI()
    {//Place a label on the screen declaring a winner
        if (winner == 1)
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "Naughts win!");
        }

        else if (winner == 2)
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "Crosses win!");
        }

        else if (winner == 3)
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "Draw!");
        }

        if (winner != 0)
        {//Place a button on the scren to reset the game
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 25, 100, 50), "Reset"))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}