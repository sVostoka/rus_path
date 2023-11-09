using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


#region CardHero
public class CardHero
{
    public string Name { get; set; }

    public int Strength { get; set; }

    //Smekalka
    public int Wit { get; set; }

    public int Faith { get; set; }

    public HeroType HeroType { get; set; }

    public string Image { get; set; } = "";

    public string Desc { get; set; } = "";

    public int AudioId { get; set; }

    public (CardHero, (int, HeroParameter)) MaxParam()
    {
        if(Strength > Wit)
        {
            if (Strength > Faith)
                return (this, (Strength, HeroParameter.Strength));
            else
                return (this, (Faith, HeroParameter.Faith));
        }
        else
        {
            if (Wit > Faith)
                return (this, (Wit, HeroParameter.Wit));
            else
                return (this, (Faith, HeroParameter.Faith));
        }
    }

    public static (CardHero, (int, HeroParameter)) MaxParam(List<CardHero> heroes)
    {
        var maxParams = heroes.Select(el => el.MaxParam()).ToList();

        var maxParam = maxParams[0];

        foreach (var param in maxParams)
            if (param.Item2.Item1 > maxParam.Item2.Item1)
                maxParam = param;

        return maxParam;
    }
}

#endregion

#region CardBonus

public class CardBonusBase
{
    public string Text { get; set; }

    public HeroType HeroType { get; set; }

    public CardBonusType CardBonusType { get; set; }

    public string Image { get; set; } = "";

    public string Desc { get; set; } = "";

    public int AudioId { get; set; }
}

public class CardBonusParamBase : CardBonusBase
{
    public bool IsPlus { get; set; }

    public int Number { get; set; }
}

public class CardBonusAll : CardBonusParamBase { }

public class CardBonusParam : CardBonusParamBase
{
    public HeroParameter HeroParameter { get; set; }
}

public class CardBonusChangeParam : CardBonusBase
{
}

public class CardBonusHelp : CardBonusBase
{
}

public class CardBonusSwap : CardBonusBase
{
}

#endregion

public enum HeroParameter
{
    Strength = 0,
    Faith = 2,
    Wit = 1
}

public enum HeroType
{
    Rus = 0,
    Lizard = 1
}

public enum CardBonusType
{
    ParamAll = 0,
    Param = 1,
    ChangeParam = 2,
    Help = 3,
    Swap = 4,
}