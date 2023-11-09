using Assets.Scripts;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GetCards : MonoBehaviour
{
    System.Random rnd = new System.Random();

    static List<CardHero> cardsHero;
    static List<CardBonusBase> cardsBonus;

    List<GameObject> cardsBonusObjs;
    List<GameObject> cardsHeroObjs;

    static GameObject AudioManager;
    static AudioManager am;
    static List<int> selectBonusCards;
    static List<int> selectHeroCards;

    static bool limitBonus, limitHero;

    [SerializeField]
    Button continueButton;

    // Start is called before the first frame update
    void Start()
    {
        cardsHero = new List<CardHero>();
        cardsBonus = new List<CardBonusBase>();

        selectBonusCards = new List<int>();
        selectHeroCards = new List<int>();

        cardsHero = GenerateCards.GenerateCardHeros(5, HeroType.Rus);
        cardsBonus = GenerateCards.GenerateCardBonuses(5, HeroType.Rus);

        cardsBonusObjs = GameObject.FindGameObjectsWithTag(Tags.BonusCard.ToString()).ToList();
        cardsBonusObjs.Sort(delegate (GameObject a, GameObject b) { return a.name.CompareTo(b.name); });
        cardsHeroObjs = GameObject.FindGameObjectsWithTag(Tags.HeroCard.ToString()).ToList();
        cardsHeroObjs.Sort(delegate (GameObject a, GameObject b) { return a.name.CompareTo(b.name); });

        AudioManager = GameObject.FindGameObjectWithTag(Tags.AudioManager.ToString());
        am = AudioManager.GetComponent<AudioManager>();

        for (int index = 0; index < 5; index++) 
        {
            TextMeshPro cardName = cardsBonusObjs[index].transform.GetChild(0).gameObject.transform.GetComponent<TextMeshPro>();
            TextMeshPro cardDescription = cardsBonusObjs[index].transform.GetChild(1).gameObject.transform.GetComponent<TextMeshPro>();
            Image cardImage = cardsBonusObjs[index].transform.GetChild(2).transform.GetChild(0).gameObject.transform.GetComponent<Image>();

            cardName.text = cardsBonus[index].Text;
            cardDescription.text = cardsBonus[index].Desc;
            cardImage.sprite = Resources.Load<Sprite>(cardsBonus[index].Image);

            cardName = cardsHeroObjs[index].transform.GetChild(0).gameObject.transform.GetComponent<TextMeshPro>();
            cardDescription = cardsHeroObjs[index].transform.GetChild(1).gameObject.transform.GetComponent<TextMeshPro>();
            cardImage = cardsHeroObjs[index].transform.GetChild(2).transform.GetChild(0).gameObject.transform.GetComponent<Image>();
            TextMeshPro cardStatStrength = cardsHeroObjs[index].transform.GetChild(3).transform.GetChild(0).gameObject.transform.GetComponent<TextMeshPro>();
            TextMeshPro cardStatItelegence = cardsHeroObjs[index].transform.GetChild(3).transform.GetChild(1).gameObject.transform.GetComponent<TextMeshPro>();
            TextMeshPro cardStatFaith = cardsHeroObjs[index].transform.GetChild(3).transform.GetChild(2).gameObject.transform.GetComponent<TextMeshPro>();

            cardName.text = cardsHero[index].Name;
            cardDescription.text = cardsHero[index].Desc;
            cardImage.sprite = Resources.Load<Sprite>(cardsHero[index].Image);
            cardStatStrength.text = cardsHero[index].Strength.ToString();
            cardStatItelegence.text = cardsHero[index].Wit.ToString();
            cardStatFaith.text = cardsHero[index].Faith.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        changeColorCards();
        checkLimit();
    }

    void changeColorCards()
    {
        for(int index = 0; index < 5; index++)
        {
            if (selectBonusCards.Contains(index))
            {
                cardsBonusObjs[index].transform.GetComponent<Renderer>().material.color = Color.green;
            }
            else
            {
                cardsBonusObjs[index].transform.GetComponent<Renderer>().material.color = Color.white;
            }

            if (selectHeroCards.Contains(index))
            {
                cardsHeroObjs[index].transform.GetComponent<Renderer>().material.color = Color.green;
            }
            else
            {
                cardsHeroObjs[index].transform.GetComponent<Renderer>().material.color = Color.white;
            }
        }
    }

    void checkLimit()
    {
        if (selectBonusCards.Count >= 3)
            limitBonus = true;
        else
            limitBonus = false;

        if(selectHeroCards.Count >= 3)
            limitHero = true;
        else
            limitHero = false;

        if(limitBonus && limitHero)
            continueButton.interactable = true;
        else
            continueButton.interactable = false;
    }

    public void saveSelectCards()
    {
        Saver.saveBonusCards(cardsBonus, selectBonusCards);
        Saver.saveHeroCards(cardsHero, selectHeroCards);
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
        else
        {
            if (selectHeroCards.Contains(index))
                selectHeroCards.Remove(index);
            else
            {
                if (!limitHero)
                {
                    selectHeroCards.Add(index);
                    am.HeroSound(cardsHero[index].AudioId, cardsHero[index].HeroType);
                }
            }   
        }
    }
}

public enum Tags
{
    BonusCard,
    HeroCard,
    AudioManager
}