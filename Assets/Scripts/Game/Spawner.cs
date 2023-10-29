using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _blocks;

    public bool isDroped = false;

    void Update()
    {
        if (isDroped == true)
        {
            Spawn();
        }
    }
    private void Spawn()
    {
        isDroped = false;
        int randomCube = Random.Range(0, _blocks.Length);
        Instantiate(_blocks[randomCube], transform.position + new Vector3(-1, 5, 0), transform.rotation);

    }
}
