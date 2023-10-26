using UnityEngine;

public abstract class Collectible : MonoBehaviour
{
    [SerializeField] protected Player GM;
    [SerializeField] private GameObject prefab;

    private void OnTriggerEnter(Collider other)
    {
        if (CheckCollect(other))
        {
            Respawn();
            Destroy(gameObject);
        }
    }
    private void Respawn()
    {
        float Random_x = Random.Range(-5, 5);
        float Random_z = Random.Range(-5, 5);
        Vector3 newPosition = new Vector3(Random_x, 0, Random_z);
        Transform t= Instantiate(prefab, newPosition, Quaternion.identity).transform;
        t.localScale += Vector3.one;
    }

    protected abstract bool CheckCollect(Collider col);

}
