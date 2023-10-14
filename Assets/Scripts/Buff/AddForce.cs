using UnityEngine;

public class AddForce : MonoBehaviour
{
    private enum Direction
    {
        Up,
        UpRight,
        UpLeft,
        Right,
        Left
    }
    private Direction direction;
    private float maxforce = 12;
    private float minforce = 6;
    private void OnTriggerEnter(Collider collision)
    {
        Vector3 dir;
        //выбирается ранодомное направление
        direction = (Direction)Random.Range(0, 4);
        if (collision.gameObject.TryGetComponent(out Weapon Weapon))
        {
            //применение выбрнного направления с рандомной силой
            switch (direction)
            {
                case Direction.Up:
                    dir = Vector3.up;
                    Weapon.AddForce(dir.normalized, Random.Range(maxforce,minforce));
                    break;
                case Direction.UpRight:
                    dir = Vector3.up + Vector3.right;
                    Weapon.AddForce(dir.normalized, Random.Range(maxforce, minforce));
                    break;
                case Direction.UpLeft:
                    dir = Vector3.up + Vector3.left;
                    Weapon.AddForce(dir.normalized, Random.Range(maxforce, minforce));
                    break;
                case Direction.Right:
                    dir = Vector3.right;
                    Weapon.AddForce(dir.normalized, Random.Range(maxforce, minforce));
                    break;
                case Direction.Left:
                    dir = Vector3.left;
                    Weapon.AddForce(dir.normalized, Random.Range(maxforce, minforce));
                    break;
            }
            Destroy(gameObject);
        }
    }
}
