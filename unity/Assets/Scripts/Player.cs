using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    [System.Serializable]
	public class PlayerStats
    {
        public int Health = 100; 
    }

    public PlayerStats p_stats = new PlayerStats(); 

    public void DamagePlayer(int damage)
    {
        p_stats.Health -= damage;
        if (p_stats.Health < 0)
            GameMaster.KillPlayer(gameObject); 
    }
}
