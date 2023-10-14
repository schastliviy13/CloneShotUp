using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLvL : MonoBehaviour
{
    public event EventHandler OnNewLvlAction;
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent(out Weapon Weapon))
        {
            OnNewLvlAction?.Invoke(this, EventArgs.Empty);
            Destroy(gameObject);
        }
    }
}
