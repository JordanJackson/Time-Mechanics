using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Player))]
public class PlayerInput : MonoBehaviour {

	Player player;

    StateHistory history;
    bool rewind = false;

	void Start () {
		player = GetComponent<Player> ();
        history = player.gameObject.GetComponent<StateHistory>();
	}

	void Update () {

        HandleInputs();

        ProcessRewind();
	}

    void HandleInputs()
    {
        if (!rewind)
        {
            Vector2 directionalInput = new Vector2(Input.GetAxisRaw("HorizontalLeft"), Input.GetAxisRaw("VerticalLeft"));
            player.SetDirectionalInput(directionalInput);

            if (Input.GetButtonDown("A"))
            {
                player.OnJumpInputDown();
            }
            if (Input.GetButtonUp("A"))
            {
                player.OnJumpInputUp();
            }
        }

        if (Input.GetButtonDown("X"))
        {
            player.ActivateShield();
        }

        if (Input.GetButtonDown("RB"))
        {
            //rewind = !rewind;
            //if (history)
            //{
            //    history.FlipRewind();
            //}
            RewindHandler.Instance.FlipRewind();
        }
    }

    
}
