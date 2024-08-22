using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TigerentenRoationScript : MonoBehaviour
{
    float rotationSpeed = 60;
    Vector3 currentEulerAngles;
    float z;
    public TigerentenschuleSpawnScript spawnscript;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        currentEulerAngles = transform.localEulerAngles;
        z = 1;
        spawnscript = GameObject.FindGameObjectWithTag("AllSpawner").GetComponent<TigerentenschuleSpawnScript>();
    }

    // Update is called once per frame
    void Update()
    {
        currentEulerAngles += new Vector3(0, 0, z) * Time.deltaTime * rotationSpeed;
        transform.localEulerAngles = currentEulerAngles;
        if (currentEulerAngles.z >= 360)
        {
            Destroy(gameObject);
            //Debug.Log(currentEulerAngles.ToString());
            spawnscript.spawnEnteundTigerenteSeperat();
        }

        if (currentEulerAngles.z >= 60 && currentEulerAngles.z < 180)
        {   

            if (SceneManager.GetActiveScene().name == "Tigerentenschule")
            {   
                Destroy(gameObject);
                SceneManager.LoadScene("Essensraum");
                gameManager.lastSceneName = "Essensraum";
            }
            else if (SceneManager.GetActiveScene().name == "Essensraum") 
            {
                Destroy(gameObject);
                SceneManager.LoadScene("Tigerentenschule");
                gameManager.lastSceneName = "Tigerentenschule";
            }
            
        }
    }
}
