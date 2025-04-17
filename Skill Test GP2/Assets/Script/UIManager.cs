using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static Action<int> Health;


    private void OnEnable()
    {
        Health += WriteHealth;
    }

    private void OnDisable()
    {
        Health -= WriteHealth;
    }

    private void WriteHealth(int obj)
    {
        throw new NotImplementedException();
    }

}
