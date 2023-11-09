using Assets.Scripts;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GetBonus : MonoBehaviour
{
    static List<CardBonusBase> cardsBonus = new List<CardBonusBase>();

    static List<GameObject> cardsBonusObjs;

    static List<int> selectBonusCards;

    static bool limitBonus;

    [SerializeField]
    Button continueButton;

    static GameObject AudioManager;
    static AudioManager am;

    void Start()
    {
        AudioManager = GameObject.FindGameObjectWithTag(Tags.AudioManager.ToString());
        am = AudioManager.GetComponent<AudioManager>();

        selectBonusCards = new List<int>();

        cardsBonus = GenerateCards.GenerateCardBonuses(5, HeroType.Rus);

        cardsBonusObjs = GameObject.FindGameObjectsWithTag(Tags.BonusCard.ToString()).ToList();
        cardsBonusObjs.Sort(delegate (GameObject a, GameObject b) { return a.name.CompareTo(b.name); });

        for (int index = 0; index < 5; index++)
        {
            TextMeshPro cardName = cardsBonusObjs[index].transform.GetChild(0).gameObject.transform.GetComponent<TextMeshPro>();
            TextMeshPro cardDescription = cardsBonusObjs[index].transform.GetChild(1).gameObject.transform.GetComponent<TextMeshPro>();
            Image cardImage = cardsBonusObjs[index].transform.GetChild(2).transform.GetChild(0).gameObject.transform.GetComponent<Image>();

            cardName.text = cardsBonus[index].Text;
            cardDescription.text = cardsBonus[index].Desc;
            cardImage.sprite = Resources.Load<Sprite>(cardsBonus[index].Image);
        }
    }

    void Update()
    {
        changeColorCards();
        checkLimit();
    }

    void changeColorCards()
    {
        for (int index = 0; index < 5; index++)
        {
            if (selectBonusCards.Contains(index))
            {
                cardsBonusObjs[index].transform.GetComponent<Renderer>().material.color = Color.green;
            }
            else
            {
                cardsBonusObjs[index].transform.GetComponent<Renderer>().material.color = Color.white;
            }
        }
    }

    void checkLimit()
    {
        if (selectBonusCards.Count >= 3)
            limitBonus = true;
        else
            limitBonus = false;

        if (limitBonus)
            continueButton.interactable = true;
        else
            continueButton.interactable = false;
    }

    public void saveSelectCards()
    {
        Saver.saveBonusCards(cardsBonus, selectBonusCards);
    }

    static public void selectCard(int index, Tags type)
    {
        if (type == Tags.BonusCard)
        {
            if (selectBonusCards.Contains(index))
                selectBonusCards.Remove(index);
            else
            {
                if (!limitBonus)
                {
                    selectBonusCards.Add(index);
                    am.BonusSound(cardsBonus[index].AudioId, cardsBonus[index].HeroType);
                }
            }
        }
    }
}
