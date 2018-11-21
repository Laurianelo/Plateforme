using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySampleAssets._2D;

public class GameManager : MonoBehaviour {

    private static GameManager instance;

    [SerializeField]
    private Transform playerPrefab;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private GameObject particuleSpawn;

    private Transform playerInstance;

    private Camera2DFollow cam;

    private Player playerScript;

    public Transform playerInstanciate {get{return playerInstance;} }
    public static GameManager Instance {get{return instance; } }

    private void Awake()
    {
        if(instance !=null)
        {
            Destroy(gameObject);
        }
        instance = this;

        cam = Camera.main.GetComponent<Camera2DFollow>();

        InstanciatePlayer();
    }

    private void InstanciatePlayer()
    {
        playerInstance = Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
        cam.target = playerInstance;

        playerScript = playerInstance.GetComponent<Player>();
        playerScript.rebornEvent += PlayerScript_Event;
    }

    private void PlayerScript_Event()
    {
        Destroy(playerInstance.gameObject);
        StartCoroutine(RespawnPlayer());
    }

    private IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(1);
        InstanciatePlayer();
        SpawnParticule();
    }

    private void SpawnParticule()
    {
        var _clone = Instantiate(particuleSpawn, playerInstance.position, Quaternion.identity);
        Destroy(_clone, 4f);
    }

}
