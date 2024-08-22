using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SceneLogicScriptWithClickableObjects : MonoBehaviour
{
    public List<ClickableObject> clickableObjects = new List<ClickableObject>();
    protected ClickableObject targetObject;
    protected bool targetHit;
    protected Vector3 targetVector;


    public void addClickableObject(ClickableObject target)
    {
        clickableObjects.Add(target);
        Logger.Normal("Clickable Objekt added: "+clickableObjects.ToString());
    }

    public bool removeClickableObject(ClickableObject target)
    {
        if( clickableObjects.Remove(target))
        {
            Logger.Normal("Clickable Objekt removed: " + clickableObjects.ToString());
            return true;
        }
            

        Logger.Normal("Unable to remove Object");
        return false;

    }



    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            leftMousButtonClick();
        }

    }

    protected virtual void leftMousButtonClick() {
        targetHit = false;
        targetVector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetVector.z = 0;
        foreach (ClickableObject target in clickableObjects.OfType<ClickableObject>())
        {
            if (target.checkIfPointInCollider(targetVector))
            {
                if (target.isDestroyed==false)
                {
                    targetObject = target;
                    //target.gotClicked();
                    targetHit = true;
                }

                Logger.DevTest("inside");
            }
            else
            {
                Logger.DevTest("outside");
            }
        }
    } 



}
