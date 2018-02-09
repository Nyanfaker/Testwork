using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player2 : MonoBehaviour {

    bool haveCanister;
    bool canisterFull;
    bool carRefueled;

    public bool Canister { get { return haveCanister; } set { haveCanister = value; } }
    public bool Full { get { return canisterFull; } set { canisterFull = value; } }
    public bool Refuel { get { return carRefueled; } set { carRefueled = value; } }
}
