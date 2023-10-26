using UnityEngine;

public abstract class Collectible : MonoBehaviour
{
    [SerializeField] protected Player GM;
    [SerializeField] private GameObject prefab;

    private void OnTriggerEnter(Collider other)
    {
        if (CheckCollect(other)) // Checks if other gameobject can be collected
        {
            Respawn(); // Spawns a new gameobject to replace the destroyed one
            Destroy(gameObject); // Destroys the gameobject
        }
    }
    private void Respawn() // Respawns the object
    {
        float Random_x = Random.Range(-5, 5); // Choses random x cord
        float Random_z = Random.Range(-5, 5); // Choses random y cord
        Vector3 newPosition = new Vector3(Random_x, 0, Random_z); // Makes a new Position with said cords
        Instantiate(prefab, newPosition, Quaternion.identity); // Spawns the gameobject at new position
    }

    protected abstract bool CheckCollect(Collider col); // Checks if the object is being collected by the right gameobject

}
