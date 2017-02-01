using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldInteraction : MonoBehaviour
{

    public void ShieldHit(/* shield parameters */)
    {
        gameObject.SendMessage("InteractWithShield");
    }
}
