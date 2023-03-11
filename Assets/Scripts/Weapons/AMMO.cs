using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AMMO : MonoBehaviour
{
    [SerializeField]
    private int _ammoCount;

    public int GetCurentAMMO()
    {
        return _ammoCount;
    }

    public void ReduceCurrentAMMO()
    {
        _ammoCount--;
    }
}
