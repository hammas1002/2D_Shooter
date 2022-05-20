using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour,IDamage
{

   public int Health { get; set; }
    public int health;
    [SerializeField]
    int damageAmount = 1;

    public Image[] heartImages;

    private void Start()
    {
        Health = health;
    }
    public void Damage()
    {
        Health -= damageAmount;
        updateHealthUI();
        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    public void changeWeapon(weapon weaponToEquip)
    {
        Destroy(GameObject.FindGameObjectWithTag("Weapon"));
        Instantiate(weaponToEquip,transform.position,transform.rotation,transform);
    }

    void updateHealthUI() {
        for (int i=0; i<heartImages.Length;i++)
        {
            if (i<Health)
            {
                //Debug.Log("chaging color to red");
                heartImages[i].GetComponent<Image>().color = new Color(1f, 0f, 0f);
            }
            else
            {
               // Debug.Log("chaging color to black");
                heartImages[i].GetComponent<Image>().color= new Color(0f, 0f, 0f);
            }
        }
    
    }

    public void heal()
    {
        if (Health<3)
        {
            Health += 1;
            updateHealthUI();
        }
        
    }
}
