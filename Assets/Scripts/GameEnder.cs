
//--------------------------------------------------

using UnityEngine;

//--------------------------------------------------

public class GameEnder: MonoBehaviour {

    public Game owner;
    public PlayerController [] players;

    void FixedUpdate () {

        PlayerController last_player = null;
        foreach (PlayerController player in players) {

            if (player.IsDead ()) continue;
            if (last_player != null) return;
            last_player = player;
        }

        if (last_player == null) return;
        owner.EndGame (last_player.victory_text);
    }
}

//--------------------------------------------------

