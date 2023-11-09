using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCardFight : MonoBehaviour
{
    [SerializeField]
    public int index;

    [SerializeField]
    public TypeCardInFight type;

    [SerializeField]
    public Tags tags;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (type == TypeCardInFight.Hand)
        {
            Fight.raffleCard(index, type, tags);
        }
    }

    private void OnMouseEnter()
    {
        Fight.selectCard(index, type);
    }

    private void OnMouseExit()
    {
        Fight.unSelectCard(index, type);
    }
}
