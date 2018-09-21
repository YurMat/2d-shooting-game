using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyArea : MonoBehaviour {

    // Use this for initialization
    void OnTriggerExit2D(Collider2D collider)
    {
        Destroy(collider.gameObject);
    }
}
