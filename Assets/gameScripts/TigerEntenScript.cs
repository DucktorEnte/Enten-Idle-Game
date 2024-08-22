using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TigerEntenScript : ClickableObject
{



    new void Start()
    {
        base.Start();

    }

    public override void delete_Target()
    {
        base.delete_Target();
    }

    public override bool checkIfPointInCollider(Vector3 vector)
    {
        return gameObject.GetComponent<BoxCollider2D>().bounds.Contains(vector);
    }

    //public override void gotclicked()
    //{
    //    if (scenemanager.getactivescene().name == "tigerentenschule")
    //    {
    //        //tigerentenlogicscript.setententarget(this);
    //    }
    //    else if (scenemanager.getactivescene().name == "essensraum")
    //    {
    //        entenscenelogicscript.setententarget(this);
    //    }

    //}



}
