using UnityEngine;

public class SpawnTurrets : MonoBehaviour
{
    [SerializeField]
    private GameObject _turret1;
	[SerializeField]
	private GameObject _turret2;
	[SerializeField]
	private GameObject _turret3;
	[SerializeField]
	private GameObject _turret4;

	void Start()
    {
        switch(MenuController.playerCount)
        {
			case 1:
				spawnTurret(_turret1, 0, 0, 1, 1);
				break;
			case 2:
				spawnTurret(_turret1, 0, 0, 0.5f, 1);
				spawnTurret(_turret2, 0.5f, 0, 0.5f, 1);
				break;
			case 3:
				spawnTurret(_turret1, 0, 0, 0.5f, 0.5f);
				spawnTurret(_turret2, 0.5f, 0, 0.5f, 0.5f);
				spawnTurret(_turret3, 0.25f, 0.5f, 0.5f, 0.5f);
				break;
			case 4:
				spawnTurret(_turret1, 0, 0, 0.5f, 0.5f);
				spawnTurret(_turret2, 0.5f, 0, 0.5f, 0.5f);
				spawnTurret(_turret3, 0, 0.5f, 0.5f, 0.5f);
				spawnTurret(_turret4, 0.5f, 0.5f, 0.5f, 0.5f);
				break;
		}

		void spawnTurret(GameObject turret, float x, float y, float w, float h)
		{
			turret.SetActive(true);
			turret.GetComponentInChildren<Camera>().rect = new Rect(x, y, w, h);
		}
    }  
}
