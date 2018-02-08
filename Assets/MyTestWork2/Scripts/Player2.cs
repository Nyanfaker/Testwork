using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player2 : MonoBehaviour {

    bool haveCanister;
    bool canisterFull;

    public bool Canister { get { return haveCanister; } set { haveCanister = value; } }
    public bool Full { get { return canisterFull; } set { canisterFull = value; } }
}
