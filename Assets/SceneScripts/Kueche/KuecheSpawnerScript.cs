using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KuecheSpawnerScript : SceneSpawner
{
    public GameObject kuechentuer;
    public void spawnKuechentuer()
    {
        Instantiate(kuechentuer, transform.position + new Vector3(10.65f, 4, 0), transform.rotation);
    }
}
