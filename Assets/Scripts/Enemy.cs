using UnityEngine;

public class Enemy : MonoBehaviour
{
    public SO_Enemy enemyType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Attack()
    {
        Debug.Log(enemyType.EnemyName + " is attacking!");
    }

    public void GetDamage(float damage)
    {
        //var finalDamage = damage - Random.Range(0f, armorClass);
        //hp -= damage;

        Debug.Log(enemyType.EnemyName + " is being attacked!");
    }

    public void Move()
    {

    }
}
