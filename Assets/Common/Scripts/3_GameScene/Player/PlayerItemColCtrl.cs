using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemColCtrl : MonoBehaviour
{

    public PlayerCtrl player;
    //public ParticleSystem ItemP;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpawnTrigger"))
        {
            player.spawnManager.SpawnTriggerEnter();
            player.spawnManager.plotSpawner.SpawnPlot();

        }
        
        if (other.CompareTag("Items"))
        {
            player.EffectList[0].Play();
            player.audioManager.soundEffectAudio[5].Play();
        }

        if (other.CompareTag("ObsSpawnTrigger"))
        {
            player.spawnManager.obstaclesSpawner.SpawnObstacle();

        }

    }

}
