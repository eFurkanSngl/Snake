using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject _prefab;
    [SerializeField] private BoxCollider2D _gridArea;

    private void Start()
    {
        StartCoroutine(SpawinBait());
    }

   private IEnumerator SpawinBait()
    {
        while (true)
        {
            Bounds bounds = _gridArea.bounds;
            float x = Random.Range(bounds.min.x, bounds.max.x);
            float y = Random.Range(bounds.min.y, bounds.max.y);

            transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), z: 0);
            // Dönen deðerleri ýzgaraya tam getirmek için Round kullandýk.
        
             Vector3 newPos = transform.position;


            Instantiate(_prefab,newPos , Quaternion.identity);
            Debug.Log("work");

            yield return new WaitForSeconds(4);
        }
    }

}
