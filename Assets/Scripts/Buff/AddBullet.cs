using UnityEngine;

public class AddBullet : MonoBehaviour
{
    private int maxAddBullet=6;
    private int minAddBullet = 2;
    private void OnTriggerEnter(Collider collision)
    {
        int addCountBullet = Random.Range(maxAddBullet,minAddBullet);
        if (collision.gameObject.TryGetComponent(out Weapon weapon))
        {
            //выдаем равндомное кол-во пуль
            weapon.AddBullet(addCountBullet);            
            Destroy(gameObject);
        }
    }
}
