using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class healthbar : MonoBehaviour
{
    public VariableHandler variable;
    [SerializeField] Slider healthBar;
    public int variablegecici;
    // Start is called before the first frame update
    void Start()
    {
        healthBar.maxValue =variable.Player.maxHealth;
        variable.Player.health = variable.Player.maxHealth;

        healthBar.value = variable.Player.health;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) // buraya pasif can artýþý ile þart yazýlacak þimdilik hata vermemesi için böyle yazýldý.
        {
            addHealth(variablegecici);//buraya cana artýþ kýsmý eklenmeli
        } 
    }

    private void addHealth(int value)
    {
        variable.Player.health += value;
        if (variable.Player.health>variable.Player.maxHealth)
        {
            variable.Player.health = variable.Player.maxHealth;
        }
        else if (variable.Player.health<0)
        {
            variable.Player.health = 0;
        }

        healthBar.value = variable.Player.health;
    }
}
