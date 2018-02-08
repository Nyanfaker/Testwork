using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    bool haveKey;
    public bool Key {
        get { return haveKey; }
        set { haveKey = value; }
    }

}
