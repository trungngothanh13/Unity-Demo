using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Chest_Collision : MonoBehaviour
{
    public virtual void OnCollisionEnter2D(Collision2D collision) { }
}
