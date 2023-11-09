using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCardGetCards : MonoBehaviour
{
    [SerializeField]
    int index;

    [SerializeField]
    Tags type;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
  
    }

    void OnMouseDown()
    {
        GetCards.selectCard(index, type);
    }
}
