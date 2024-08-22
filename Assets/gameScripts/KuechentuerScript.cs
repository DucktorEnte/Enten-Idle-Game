using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KuechentuerScript : ClickableObject
{


    public override bool checkIfPointInCollider(Vector3 vector)
    {
        return gameObject.GetComponent<BoxCollider2D>().bounds.Contains(vector);
    }
}
