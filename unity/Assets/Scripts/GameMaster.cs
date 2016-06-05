using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {

    public static GameMaster gm; 

	void Start () {
        if (gm == null)
            gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>(); 
	}

    public static void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }

    public static void KillPlayer(GameObject player)
    {
        Destroy(player); 
    }

    public static void KillEnemy(GameObject enemy, float time)
    {
        Destroy(enemy, time);
    }
}
