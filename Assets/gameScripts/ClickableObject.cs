using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ClickableObject : MonoBehaviour
{
    public bool isDestroyed;
    public SceneLogicScriptWithClickableObjects parentSceneLogicScript; 
    // Start is called before the first frame update
    protected void Start()
    {
        isDestroyed = false;
        parentSceneLogicScript = GameObject.FindGameObjectWithTag("SceneLogicTag").GetComponent<SceneLogicScriptWithClickableObjects>();
        parentSceneLogicScript.addClickableObject(this);
    }

    virtual public void  delete_Target() {
        if (isDestroyed) return;
        isDestroyed = true;
        Destroy(gameObject);
    }




    //not sure if this is the way to go
    protected void informLogicScriptOFDeletion() {
        parentSceneLogicScript.removeClickableObject(this);
    }

    private void OnDestroy()
    {
        //should be called twice but just to be sure written here again
        informLogicScriptOFDeletion();
    }

    abstract public bool checkIfPointInCollider(Vector3 vector);

    //abstract public void gotClicked();
    
}
