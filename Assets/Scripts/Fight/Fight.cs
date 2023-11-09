using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Assets.Scripts;
using System;
using System.Reflection;
using System.Collections;

public class Fight : MonoBehaviour
{
    System.Random rnd = new System.Random();
    Conductor conductor = new Conductor();

    #region Player cards
    static List<CardHero> cardsHero;
    static List<CardBonusBase> cardsBonus;
    #endregion

    #region Cards in field
    static List<CardSpawn> cardsSpawnHand;
    static List<CardSpawn> cardsSpawnField;
    static List<CardSpawn> cardsSpawnEnemy;
    static List<CardSpawn> cardsSpawnEnemyField;

    static bool respawnHand;
    static bool respawnField;
    static bool respawnEnemy;
    #endregion

    HeroParameter lizardParameter;
    CardHero lizardTopCard;
    int maxParam;

    #region Point in field
    [SerializeField]
    public TextMeshProUGUI enemyPoint;
    [SerializeField]
    public TextMeshProUGUI playerPoint;
    [SerializeField]
    public Image targetCategory;
    #endregion

    #region Cards prefab
    [SerializeField]
    public GameObject bonusCardPrefab;
    [SerializeField]
    public GameObject heroCardPrefab;
    [SerializeField]
    public GameObject emptyCardPrefab;
    #endregion

    #region Select menu
    [SerializeField]
    public GameObject selectMenu;
    [SerializeField]
    public Button strengthButton;
    [SerializeField]
    public Button faithButton;
    [SerializeField]
    public Button witButton;

    static bool visibilitySelectMenu;
    static bool activeControl;
    #endregion

    FieldParam hand = new FieldParam();
    FieldParam field = new FieldParam();
    FieldParam enemy = new FieldParam();

    static HeroParameter targetCategoryValue;

    int emenyPointValue = 0;
    int playerPointValue = 0;

    static List<int> enemyPointsCategory;
    static List<int> playerPointsCategory;
    static GameObject AudioManager;
    static AudioManager am;

    int currentCardEnemy = 0;

    static bool playerMove;
    static bool endFightValue;
    static bool enemyMove;

    static bool playHero;
    static bool playBonus;

    static bool bonusSwap;

    [SerializeField]
    public Button endFightButton;

    [SerializeField]
    public TypeFight currentType;

    void Start()
    {

        AudioManager = GameObject.FindGameObjectWithTag(Tags.AudioManager.ToString());
        am = AudioManager.GetComponent<AudioManager>();

        cardsSpawnHand = new List<CardSpawn>();
        cardsSpawnField = new List<CardSpawn>();
        cardsSpawnEnemy = new List<CardSpawn>();
        cardsSpawnEnemyField = new List<CardSpawn>();

        respawnHand = true;
        respawnField = false;
        respawnEnemy = false;

        visibilitySelectMenu = false;
        activeControl = true;

        enemyPointsCategory = new List<int>() { 0, 0, 0 };
        playerPointsCategory = new List<int>() { 0, 0, 0 };

        playerMove = false;
        endFightValue = false;
        enemyMove = true;

        playHero = true;
        playBonus = false;

        bonusSwap = false;

        cardsHero = Saver.loadHeroCards();
        cardsBonus = Saver.loadBonusCards();

        ((lizardTopCard, (maxParam, lizardParameter)), cardsSpawnEnemy) = CardSpawn.GetFightData(currentType);

        targetCategoryValue = lizardParameter;

        foreach (var cardHero in cardsHero)
        {
            cardsSpawnHand.Add(new CardSpawn(cardHero: cardHero));
        }

        foreach (var cardBonus in cardsBonus)
        {
            cardsSpawnHand.Add(new CardSpawn(cardBonus: cardBonus));
        }

        endFightButton.onClick.AddListener(endFightF);
        strengthButton.onClick.AddListener(strengthButtonClick);
        faithButton.onClick.AddListener(faithButtonClick);
        witButton.onClick.AddListener(witButtonClick);
    }

    void Update()
    {
        if (!playerMove || endFightValue)
        {
            stepEnemy();
        }

        updatePoints();

        if (respawnHand)
        {
            spawnForParamField(hand, "hand");
            respawnHand = false;
        }

        if (respawnField)
        {
            spawnForParamField(field, "field");
            respawnField = false;
        }

        if (respawnEnemy)
        {
            spawnForParamField(enemy, "enemy");
            respawnEnemy = false;
        }

        if (visibilitySelectMenu)
        {
            selectMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            selectMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    void stepEnemy()
    {
        if(currentCardEnemy == 0)
        {
            enemyPointsCategory[0] += cardsSpawnEnemy[currentCardEnemy].cardHero.Strength;
            enemyPointsCategory[1] += cardsSpawnEnemy[currentCardEnemy].cardHero.Wit;
            enemyPointsCategory[2] += cardsSpawnEnemy[currentCardEnemy].cardHero.Faith;

            cardsSpawnEnemyField.Add(cardsSpawnEnemy[currentCardEnemy]);

            am.HeroSound(cardsSpawnEnemy[currentCardEnemy].cardHero.AudioId, cardsSpawnEnemy[currentCardEnemy].cardHero.HeroType);

            currentCardEnemy++;

            foreach (var card in cardsSpawnEnemyField)
            {
                Destroy(card.cardPrefab);
                Destroy(card.emptyCardPrefab);
            }

            playerMove = true;
            respawnEnemy = true;
        }
        else if(currentCardEnemy < cardsSpawnEnemy.Count) 
        {
            CardBonusBase cardSpawn = cardsSpawnEnemy[currentCardEnemy].cardBonus;
            CardBonusParamBase paramBase = cardSpawn as CardBonusParamBase;
            CardBonusParam param = cardSpawn as CardBonusParam;

            switch (cardSpawn.CardBonusType)
            {
                case CardBonusType.ParamAll:
                    if (paramBase.IsPlus)
                    {
                        enemyPointsCategory[0] += paramBase.Number;
                        enemyPointsCategory[1] += paramBase.Number;
                        enemyPointsCategory[2] += paramBase.Number;
                    }
                    else
                    {
                        playerPointsCategory[0] = playerPointsCategory[0] - paramBase.Number < 0 ? 0
                                    : playerPointsCategory[0] - paramBase.Number;
                        playerPointsCategory[1] = playerPointsCategory[1] - paramBase.Number < 0 ? 0
                                    : playerPointsCategory[1] - paramBase.Number;
                        playerPointsCategory[2] = playerPointsCategory[2] - paramBase.Number < 0 ? 0
                                    : playerPointsCategory[2] - paramBase.Number;
                    }
                    break;
                case CardBonusType.Param:
                    switch (param.HeroParameter)
                    {
                        case HeroParameter.Strength:
                            if (paramBase.IsPlus)
                            {
                                enemyPointsCategory[0] += param.Number;
                            }
                            else
                            {
                                playerPointsCategory[0] = playerPointsCategory[0] - param.Number < 0 ? 0 
                                    : playerPointsCategory[0] - param.Number;
                            }

                            break;
                        case HeroParameter.Wit:
                            if (paramBase.IsPlus)
                            {
                                enemyPointsCategory[1] += param.Number;
                            }
                            else
                            {
                                playerPointsCategory[1] = playerPointsCategory[1] - param.Number < 0 ? 0
                                    : playerPointsCategory[1] - param.Number;
                            }
                            break;
                        case HeroParameter.Faith:
                            if (paramBase.IsPlus)
                            {
                                enemyPointsCategory[2] += param.Number;
                            }
                            else
                            {
                                playerPointsCategory[2] = playerPointsCategory[2] - param.Number < 0 ? 0
                                    : playerPointsCategory[2] - param.Number;
                            }
                            break;
                    }
                    break;
            }

            cardsSpawnEnemyField.Add(cardsSpawnEnemy[currentCardEnemy]);

            //am.BonusSound(cardsSpawnEnemy[currentCardEnemy].cardBonus.AudioId, cardsSpawnEnemy[currentCardEnemy].cardBonus.HeroType);

            currentCardEnemy++;

            foreach (var card in cardsSpawnEnemyField)
            {
                Destroy(card.cardPrefab);
                Destroy(card.emptyCardPrefab);
            }

            playerMove = true;
            respawnEnemy = true;
        }
        else
        {
            if (enemyMove)
            {
                Image imageEnemyPoint = GameObject.Find("Enemy").transform.GetComponent<Image>();

                imageEnemyPoint.color = Color.green;

                enemyMove = false;
            }
        }
    }

    void updatePoints()
    {
        emenyPointValue = 0;
        playerPointValue = 0;

        switch (targetCategoryValue)
        {
            case HeroParameter.Strength:
                playerPointValue += playerPointsCategory[0];
                emenyPointValue += enemyPointsCategory[0];
                break;
            case HeroParameter.Wit:
                playerPointValue += playerPointsCategory[1];
                emenyPointValue += enemyPointsCategory[1];
                break;
            case HeroParameter.Faith:
                playerPointValue += playerPointsCategory[2];
                emenyPointValue += enemyPointsCategory[2];
                break;
        }

        enemyPoint.text = emenyPointValue.ToString();
        playerPoint.text = playerPointValue.ToString();
        targetCategory.sprite = Resources.Load<Sprite>($"Card Background/{targetCategoryValue}");
    }

    void calculateVar(FieldParam fieldParam, string type)
    {
        fieldParam.totalCount = type == "field" ? cardsSpawnField.Count : 
            type == "hand" ? cardsSpawnHand.Count : cardsSpawnEnemyField.Count;
        fieldParam.middle = fieldParam.totalCount / 2;
        fieldParam.middleIndex = fieldParam.middle - 1;
        fieldParam.step = 9f / fieldParam.totalCount >= 2.1f ? 2.1f : 9f / fieldParam.totalCount;
    }

    void spawnForParamField(FieldParam fieldParam, string type) 
    {
        calculateVar(fieldParam, type);

        if (fieldParam.totalCount == 1)
        {
            spawnCards(0, 1, type, "middle", z: fieldParam.middle);
        }
        else if (fieldParam.totalCount > 0)
        {
            spawnCards(fieldParam.middleIndex, fieldParam.middleIndex + 1, type, "middle", z: fieldParam.middle);
            spawnCards(0, fieldParam.middleIndex, type, "left", -fieldParam.step, fieldParam.middle - 1);
            spawnCards(fieldParam.middleIndex + 1, fieldParam.totalCount, type, "right", fieldParam.step, fieldParam.middle + 1);
        }
    }

    void spawnCards(int start, int end, string type, string direction, float x = 0, int z = 0)
    {
        for(int i = start; i < end; i++)
        {
            GameObject obj = null;
            CardSpawn card = type == "hand" ? cardsSpawnHand[i] : 
                type == "field" ? cardsSpawnField[i] : cardsSpawnEnemyField[i];

            if (card.cardHero != null)
            {
                obj = Instantiate(heroCardPrefab);
                TextMeshPro cardName = obj.transform.GetChild(0).gameObject.transform.GetComponent<TextMeshPro>();
                TextMeshPro cardDescription = obj.transform.GetChild(1).gameObject.transform.GetComponent<TextMeshPro>();
                Image cardImage = obj.transform.GetChild(2).transform.GetChild(0).gameObject.transform.GetComponent<Image>();
                TextMeshPro cardStatStrength = obj.transform.GetChild(3).transform.GetChild(0).gameObject.transform.GetComponent<TextMeshPro>();
                TextMeshPro cardStatItelegence = obj.transform.GetChild(3).transform.GetChild(1).gameObject.transform.GetComponent<TextMeshPro>();
                TextMeshPro cardStatFaith = obj.transform.GetChild(3).transform.GetChild(2).gameObject.transform.GetComponent<TextMeshPro>();

                cardName.text = card.cardHero.Name;
                cardDescription.text = card.cardHero.Desc;
                cardImage.sprite = Resources.Load<Sprite>(card.cardHero.Image);
                cardStatStrength.text = card.cardHero.Strength.ToString();
                cardStatItelegence.text = card.cardHero.Wit.ToString();
                cardStatFaith.text = card.cardHero.Faith.ToString();
            }

            if (card.cardBonus != null)
            {
                obj = Instantiate(bonusCardPrefab);
                TextMeshPro cardName = obj.transform.GetChild(0).gameObject.transform.GetComponent<TextMeshPro>();
                TextMeshPro cardDescription = obj.transform.GetChild(1).gameObject.transform.GetComponent<TextMeshPro>();
                Image cardImage = obj.transform.GetChild(2).transform.GetChild(0).gameObject.transform.GetComponent<Image>();

                cardName.text = card.cardBonus.Text;
                cardDescription.text = card.cardBonus.Desc;
                cardImage.sprite = Resources.Load<Sprite>(card.cardBonus.Image);
            }

            float y = type == "hand" ? -4.4f :
                type == "field" ? -0.8f : 2.2f;

            obj.transform.localPosition = new Vector3(x, y, z);

            GameObject emptyObj = Instantiate(emptyCardPrefab, new Vector3(x, y, z), Quaternion.identity);
            emptyObj.AddComponent<SelectCardFight>();
            emptyObj.GetComponent<SelectCardFight>().index = z;
            emptyObj.GetComponent<SelectCardFight>().type = type == "hand" ? TypeCardInFight.Hand : 
                type == "field" ? TypeCardInFight.Field : TypeCardInFight.Enemy;
            emptyObj.GetComponent<SelectCardFight>().tags = card.cardHero != null ? Tags.HeroCard : Tags.BonusCard;
            emptyObj.AddComponent<BoxCollider2D>();

            card.index = z;
            card.cardPrefab = obj;
            card.emptyCardPrefab = emptyObj;

            if (direction == "left")
            {
                x -= type == "hand" ? hand.step : type == "field" ? field.step : enemy.step;
                z--;
            }

            if (direction == "right")
            {
                x += type == "hand" ? hand.step : type == "field" ? field.step : enemy.step;
                z++;
            }
        }
    }

    static public void selectCard(int index, TypeCardInFight type)
    {
        if (activeControl)
        {
            List<CardSpawn> prefabList = type == TypeCardInFight.Hand ? cardsSpawnHand :
                type == TypeCardInFight.Field ? cardsSpawnField : cardsSpawnEnemyField;
            GameObject prefab = null;

            prefab = prefabList.Where(obj => obj.index == index).First().cardPrefab;

            var scale = prefab.transform.localScale;
            prefab.transform.localScale = new Vector3(0.9f, 0.9f, scale.z);

            var position = prefab.transform.localPosition;
            prefab.transform.localPosition = new Vector3(position.x, -1f, -1);
        }
    }

    static public void unSelectCard(int index, TypeCardInFight type) 
    {
        if(activeControl)
        {
            List<CardSpawn> prefabList = type == TypeCardInFight.Hand ? cardsSpawnHand :
                type == TypeCardInFight.Field ? cardsSpawnField : cardsSpawnEnemyField;
            GameObject prefab = null;

            prefab = prefabList.Where(obj => obj.index == index).First().cardPrefab;

            var scale = prefab.transform.localScale;
            prefab.transform.localScale = new Vector3(0.4f, 0.4f, scale.z);

            float y = type == TypeCardInFight.Hand ? -4.4f : type == TypeCardInFight.Field ? -0.8f : 2.2f; 

            var position = prefab.transform.localPosition;
            prefab.transform.localPosition = new Vector3(position.x, y, index);
        }
    }

    static public void raffleCard(int index, TypeCardInFight type, Tags tags)
    {
        if((cardsSpawnField.Count != 0 || tags == Tags.HeroCard) && activeControl)
        {
            CardSpawn cardSpawn = cardsSpawnHand.Where(obj => obj.index == index).First();

            foreach (var card in cardsSpawnHand)
            {
                Destroy(card.cardPrefab);
                Destroy(card.emptyCardPrefab);
            }

            foreach (var card in cardsSpawnField)
            {
                Destroy(card.cardPrefab);
                Destroy(card.emptyCardPrefab);
            }

            if (playHero)
            {
                if (tags == Tags.HeroCard)
                {
                    cardsSpawnHand.Remove(cardSpawn);

                    if(bonusSwap)
                    {
                        playerPointsCategory[0] -= cardsSpawnField[0].cardHero.Strength;
                        playerPointsCategory[1] -= cardsSpawnField[0].cardHero.Wit;
                        playerPointsCategory[2] -= cardsSpawnField[0].cardHero.Faith;

                        bonusSwap = false;
                    }

                    playerPointsCategory[0] += cardSpawn.cardHero.Strength;
                    playerPointsCategory[1] += cardSpawn.cardHero.Wit;
                    playerPointsCategory[2] += cardSpawn.cardHero.Faith;

                    cardsSpawnField.Add(cardSpawn);

                    am.HeroSound(cardSpawn.cardHero.AudioId, cardSpawn.cardHero.HeroType);
                }

                playHero = false;
                playBonus = true;

                playerMove = false;
            }

            if (playBonus)
            {
                if (tags == Tags.BonusCard)
                {
                    cardsSpawnHand.Remove(cardSpawn);

                    CardBonusBase cardBonus = cardSpawn.cardBonus;
                    CardBonusParamBase paramBase = cardBonus as CardBonusParamBase;
                    CardBonusParam param = cardBonus as CardBonusParam;

                    switch (cardBonus.CardBonusType)
                    {
                        case CardBonusType.ParamAll:
                            if (paramBase.IsPlus)
                            {
                                playerPointsCategory[0] += paramBase.Number;
                                playerPointsCategory[1] += paramBase.Number;
                                playerPointsCategory[2] += paramBase.Number;
                            }
                            else
                            {
                                enemyPointsCategory[0] = enemyPointsCategory[0] - paramBase.Number < 0 ? 0 : enemyPointsCategory[0] - paramBase.Number;
                                enemyPointsCategory[1] = enemyPointsCategory[1] - paramBase.Number < 0 ? 0 : enemyPointsCategory[1] - paramBase.Number;
                                enemyPointsCategory[2] = enemyPointsCategory[2] - paramBase.Number < 0 ? 0 : enemyPointsCategory[2] - paramBase.Number;
                            }
                            playerMove = false;
                            break;
                        case CardBonusType.Param:
                            switch (param.HeroParameter)
                            {
                                case HeroParameter.Strength:
                                    if (paramBase.IsPlus)
                                    {
                                        playerPointsCategory[0] += param.Number;
                                    }
                                    else
                                    {
                                        enemyPointsCategory[0] = enemyPointsCategory[0] - param.Number < 0 ? 0 : enemyPointsCategory[0] - param.Number;
                                    }

                                    break;
                                case HeroParameter.Wit:
                                    if (paramBase.IsPlus)
                                    {
                                        playerPointsCategory[1] += param.Number;
                                    }
                                    else
                                    {
                                        enemyPointsCategory[1] = enemyPointsCategory[1] - param.Number < 0 ? 0 : enemyPointsCategory[1] - param.Number;
                                    }
                                    break;
                                case HeroParameter.Faith:
                                    if (paramBase.IsPlus)
                                    {
                                        playerPointsCategory[2] += param.Number;
                                    }
                                    else
                                    {
                                        enemyPointsCategory[2] = enemyPointsCategory[2] - param.Number < 0 ? 0 : enemyPointsCategory[2] - param.Number;
                                    }
                                    break;
                            }
                            playerMove = false;
                            break;
                        case CardBonusType.ChangeParam:
                            activeControl = false;
                            visibilitySelectMenu = true;
                            playerMove = false;
                            break;
                        case CardBonusType.Help:
                            playHero = true;
                            playBonus = false;
                            break;
                        case CardBonusType.Swap:
                            bonusSwap = true;
                            playHero = true;
                            playBonus = false;
                            break;
                    }

                    cardsSpawnField.Add(cardSpawn);

                    am.BonusSound(cardSpawn.cardBonus.AudioId, cardSpawn.cardBonus.HeroType);
                }
            }

            respawnField = true;
            respawnHand = true;
        }
    }

    void endFightF()
    {
        endFightValue = true;
        playerMove = false;

        Image imageEnemyPoint = GameObject.Find("Player").transform.GetComponent<Image>();

        imageEnemyPoint.color = Color.green;

        endFightButton.interactable = false;

        if (emenyPointValue <= playerPointValue)
        {
            foreach(var card in cardsSpawnField)
            {
                if(card.cardHero != null)
                {
                    for(int i = 0; i < cardsHero.Count; i++)
                    {
                        if(card.cardHero.Name == cardsHero[i].Name)
                        {
                            switch(targetCategoryValue)
                            {
                                case HeroParameter.Strength:
                                    cardsHero[i].Strength += 3;
                                    break;
                                case HeroParameter.Wit:
                                    cardsHero[i].Wit += 3;
                                    break;
                                case HeroParameter.Faith:
                                    cardsHero[i].Faith += 3;
                                    break;
                            }
                        }
                    }
                }
            }
        }
        else
        {
            if(cardsHero.Count == 1)
            {
                if(cardsBonus.Count != 0)
                {
                    int removeIndex = rnd.Next(0, cardsBonus.Count);
                    cardsBonus.RemoveAt(removeIndex);
                }
            }
            else
            {
                int removeIndex = rnd.Next(0, cardsHero.Count + cardsBonus.Count);

                if (removeIndex < cardsHero.Count)
                {
                    cardsHero.RemoveAt(removeIndex);
                }
                else
                {
                    cardsBonus.RemoveAt(removeIndex - cardsHero.Count);
                }
            }
        }

        PlayerPrefs.DeleteKey("HeroCards");
        PlayerPrefs.DeleteKey("BonusCards");

        List<int> selectHero = new List<int>();
        for (int i = 0; i < cardsHero.Count; i++)
        {
            selectHero.Add(i);
        }

        List<int> selectBonus = new List<int>();
        for (int i = 0; i < cardsBonus.Count; i++)
        {
            selectBonus.Add(i);
        }

        Saver.saveHeroCards(cardsHero, selectHero);
        Saver.saveBonusCards(cardsBonus, selectBonus);

        if(emenyPointValue <= playerPointValue)
        {
            GameObject win = GameObject.Find("Win").transform.GetChild(0).gameObject;
            win.SetActive(true);
            am.Finish(true);
            activeControl = false;
            StartCoroutine(coroutine());
        }
        else
        {
            GameObject lose = GameObject.Find("Lose").transform.GetChild(0).gameObject;
            lose.SetActive(true);
            am.Finish(false);
            activeControl = false;
            StartCoroutine(coroutine());
        }
    }

    IEnumerator coroutine()
    {
        yield return new WaitForSeconds(3);

        if (currentType == TypeFight.Boss)
        {
            PlayerPrefs.DeleteAll();
            conductor.showScene(0);
        }
        else
        {
            conductor.showScene(2);
        }
    }

    void strengthButtonClick()
    {
        targetCategoryValue = HeroParameter.Strength;
        visibilitySelectMenu = false;
        activeControl = true;
    }

    void faithButtonClick()
    {
        targetCategoryValue = HeroParameter.Faith;
        visibilitySelectMenu = false;
        activeControl = true;
    }

    void witButtonClick()
    {
        targetCategoryValue = HeroParameter.Wit;
        visibilitySelectMenu = false;
        activeControl = true;
    }
}

public class CardSpawn
{
    public int index;
    public CardHero cardHero;
    public CardBonusBase cardBonus;
    public GameObject cardPrefab;
    public GameObject emptyCardPrefab;

    public CardSpawn(int index = 0, CardHero cardHero = null, CardBonusBase cardBonus = null, 
        GameObject cardPrefab = null, GameObject emptyCardPrefab = null)
    {
        this.index = index;
        this.cardHero = cardHero;
        this.cardBonus = cardBonus;
        this.cardPrefab = cardPrefab;
        this.emptyCardPrefab = emptyCardPrefab;
    }

    public static ((CardHero, (int, HeroParameter)), List<CardSpawn>) GetFightData(TypeFight typeFight)
    {
        var data = new List<CardSpawn>();

        var bonusCard = GenerateCards.GenerateCardBonusesNoHelp(3, HeroType.Lizard);

        (CardHero, (int, HeroParameter)) maxCard;

        if (typeFight == TypeFight.Standart)
        {
            var cardHeros = GenerateCards.GenerateCardHeros(3, HeroType.Lizard);

            maxCard = CardHero.MaxParam(cardHeros);
        }
        else
        {
            var crock = GenerateCards.CardHerosLizard[GenerateCards.CardHerosLizard.Count - 1];

            maxCard = (crock, (crock.Faith, CrockRand(crock)));
        }

        data.Add(new CardSpawn(cardHero: maxCard.Item1));

        foreach (var item in bonusCard)
        {
            if(item.CardBonusType == CardBonusType.Param)
            {
                CardBonusParam card = (CardBonusParam)item;

                if (card.HeroParameter != maxCard.Item2.Item2)
                    continue;
            }

            data.Add(new CardSpawn(cardBonus: item));
        }

        return (maxCard, data);
    }

    private static HeroParameter CrockRand(CardHero crock)
    {
        var rand = new System.Random();

        HeroParameter param;

        var ri = rand.Next(3);

        if (ri == 0)
            param = HeroParameter.Strength;
        else if (ri == 1)
            param = HeroParameter.Wit;
        else
            param = HeroParameter.Faith;

        return param;
    }
}

class FieldParam
{
    public int totalCount { get; set; }
    public int middle { get; set; }
    public int middleIndex { get; set; }
    public float step { get; set; }
}

public enum TypeCardInFight
{
    Field,
    Hand,
    Enemy
}

public enum TypeFight
{
    Boss,
    Standart
}