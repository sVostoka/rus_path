using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

static public class Saver
{
    static public void deleteLastPoint()
    {
        string pathHerouStr = PlayerPrefs.GetString("path", "0");

        List<string> pathList = pathHerouStr.Split(',').SkipLast(1).ToList();

        PlayerPrefs.DeleteKey("path");
        PlayerPrefs.SetString("path", string.Join(",", pathList.ToArray()));
        PlayerPrefs.SetInt("currentPoint", int.Parse(pathList[pathList.Count - 1]));
    }

    static public void saveStateMap(MapPoint currentPoint, List<MapPoint> points, List<int> pathHerou)
    {
        PlayerPrefs.SetInt("currentPoint", currentPoint.id);

        for(int index = 0; index < points.Count; index++) 
        {
            PlayerPrefs.SetInt("points" + index.ToString(), points[index].button.interactable ? 1 : 0);
        }

        PlayerPrefs.SetString("path", string.Join(",", pathHerou.ToArray()));
    }

    static public (MapPoint, List<MapPoint>, List<int>) getStateMap(List<MapPoint> points)
    {
        int currentPointId = PlayerPrefs.GetInt("currentPoint", 0);
        MapPoint currentPoint = null;
        foreach (MapPoint point in points)
        {
            if(point.id == currentPointId) 
            {
                currentPoint = point;
                break;
            }
        }

        for(int index = 0; index < points.Count; index++)
        {
            points[index].button.interactable = Convert.ToBoolean(PlayerPrefs.GetInt("points" + index.ToString(), 0));
        }

        string pathHerouStr = PlayerPrefs.GetString("path", "0");

        List<int> pathHerou = pathHerouStr.Split(",").Select(int.Parse).ToList();

        return (currentPoint, points, pathHerou);
    }

    static public void saveBonusCards(List<CardBonusBase> bonusCards, List<int> selectCards)
    {
        string cardsInPrefs = PlayerPrefs.GetString("BonusCards", "");
        
        foreach(var index in selectCards)
        {
            cardsInPrefs += bonusCards[index].Text + "\\" +
                bonusCards[index].HeroType.ToString() + "\\" +
                bonusCards[index].CardBonusType.ToString() + "\\" +
                bonusCards[index].Image + "\\";


            CardBonusParamBase param = bonusCards[index] as CardBonusParamBase;

            switch (bonusCards[index].CardBonusType)
            {
                case CardBonusType.ParamAll:
                    cardsInPrefs += param.IsPlus + "\\" + param.Number + "\\empty\\";
                    break;
                case CardBonusType.Param:
                    CardBonusParam temp = param as CardBonusParam;
                    cardsInPrefs += temp.IsPlus + "\\" + temp.Number + "\\" + temp.HeroParameter + "\\";
                    break;
                case CardBonusType.ChangeParam:
                    cardsInPrefs += "empty\\empty\\empty\\";
                    break;
                case CardBonusType.Help:
                    cardsInPrefs += "empty\\empty\\empty\\";
                    break;
                case CardBonusType.Swap:
                    cardsInPrefs += "empty\\empty\\empty\\";
                    break;
            }
            cardsInPrefs += bonusCards[index].Desc + "\\" + bonusCards[index].AudioId + "|";
        }

        PlayerPrefs.SetString("BonusCards", cardsInPrefs);
    }

    static public List<CardBonusBase> loadBonusCards() 
    {
        List<CardBonusBase> bonusCards = new List<CardBonusBase> ();
        
        string cardsInPrefs = PlayerPrefs.GetString("BonusCards", "");

        if (cardsInPrefs != "")
        {
            List<string> cardsStr = cardsInPrefs.Split("|").SkipLast(1).ToList();

            foreach (var cardStr in cardsStr)
            {
                List<string> cardElements = cardStr.Split("\\").ToList();
                CardBonusParam card = new CardBonusParam();

                card.Text = cardElements[0];
                card.HeroType = (HeroType)Enum.Parse(typeof(HeroType), cardElements[1]);
                card.CardBonusType = (CardBonusType)Enum.Parse(typeof(CardBonusType), cardElements[2]);
                card.Image = cardElements[3];
                if (cardElements[4] != "empty") 
                {
                    card.IsPlus = bool.Parse(cardElements[4]);
                    card.Number = int.Parse(cardElements[5]);
                    card.HeroParameter = cardElements[6] != "empty" ? 
                        (HeroParameter)Enum.Parse(typeof(HeroParameter), cardElements[6]) : HeroParameter.Strength;
                }
                card.Desc = cardElements[7];

                card.AudioId = Convert.ToInt32(cardElements[8]);

                bonusCards.Add(card);
            }
        }

        return bonusCards;
    }

    static public void saveHeroCards(List<CardHero> heroCards, List<int> selectCards)
    {
        string cardsInPrefs = PlayerPrefs.GetString("HeroCards", "");

        foreach (var index in selectCards)
        {
            cardsInPrefs += heroCards[index].Name + "\\" +
                heroCards[index].Strength.ToString() + "\\" +
                heroCards[index].Wit.ToString() + "\\" +
                heroCards[index].Faith.ToString() + "\\" +
                heroCards[index].HeroType.ToString() + "\\" +
                heroCards[index].Image + "\\" +
                heroCards[index].Desc + "\\" + heroCards[index].AudioId + "|";
        }

        PlayerPrefs.SetString("HeroCards", cardsInPrefs);
    }

    static public List<CardHero> loadHeroCards()
    {
        List<CardHero> heroCards = new List<CardHero>();

        string cardsInPrefs = PlayerPrefs.GetString("HeroCards", "");

        if(cardsInPrefs != "")
        {
            List<string> cardsStr = cardsInPrefs.Split("|").SkipLast(1).ToList();

            foreach (var cardStr in cardsStr)
            {
                List<string> cardElements = cardStr.Split("\\").ToList();
                CardHero card = new CardHero();

                card.Name = cardElements[0];
                card.Strength = int.Parse(cardElements[1]);
                card.Wit = int.Parse(cardElements[2]);
                card.Faith = int.Parse(cardElements[3]);
                card.HeroType = (HeroType)Enum.Parse(typeof(HeroType), cardElements[4]);
                card.Image = cardElements[5];
                card.Desc = cardElements[6];
                card.AudioId = Convert.ToInt32(cardElements[7]);

                heroCards.Add(card);
            }
        }

        return heroCards;
    }
}
