using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Vector2 _direction=Vector2.right;
    private List<Transform> _segments;
    [SerializeField] private Transform _transformSegment;
  
    
   

    void Start()
    {

        _segments = new List<Transform>();
        _segments.Add(transform); 
         
    }
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
           _direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _direction = Vector2.down; 
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            _direction= Vector2.left;

        }
        else if (Input.GetKeyDown (KeyCode.D))
        {
            _direction= Vector2.right;
        }

    }

    private void FixedUpdate()
    {
        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }
        this.transform.position = new Vector3(Mathf.Round(transform.position.x) + _direction.x, Mathf.Round(transform.position.y) + _direction.y, z: 0);

    }
    private void ResetState()
    {
        for (int i = 0; i <_segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }
        _segments.Clear();
        _segments.Add(transform);
        transform.position = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Bait"))
        {
            //Vector2 currentScale = transform.localScale;
            //currentScale.y += _scaleAmount;
            //transform.localScale = currentScale;
            Grow();
        }
        else if (collision.gameObject.CompareTag("Walls"))
        {
           ResetState();
        }

    }

    private void Grow()
    {
        Transform segment = Instantiate(_transformSegment);
        segment.position = _segments[_segments.Count - 1].position;
        // Küpün sonuna eklemek istediðim için en sonuncun poz aldým.
        _segments.Add(segment);
    }

} 