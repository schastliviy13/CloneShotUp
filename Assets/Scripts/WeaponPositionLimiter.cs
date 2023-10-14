using UnityEngine;

public class WeaponPositionLimiter : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    private readonly float limitPositiveX = 4;
    private readonly float limitNegativeX = -4;
    public void Update()
    {
        if (weapon.transform.position.x > limitPositiveX)
        {
            weapon.transform.position = new Vector3
                (limitNegativeX, weapon.transform.position.y, weapon.transform.position.z);
        }
        if (weapon.transform.position.x < limitNegativeX)
        {
            weapon.transform.position = new Vector3
                (limitPositiveX, weapon.transform.position.y, weapon.transform.position.z);
        }

    }
}
