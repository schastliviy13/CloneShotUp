using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLwL : MonoBehaviour
{
    public event EventHandler OnDestroyLvlAction;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent(out Weapon Weapon))
        {
            OnDestroyLvlAction?.Invoke(this, EventArgs.Empty);
        }
    }
}
