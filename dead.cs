using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class dead : MonoBehaviour
{
    public VariableHandler variable;
    private void Update()
    {
        if (variable.Player.health <= 0)
        {
            variable.Player.isAlive = false;
            // ölmeden sonra yapýlacaklar buraya eklenebilir.

        }
    }
}
