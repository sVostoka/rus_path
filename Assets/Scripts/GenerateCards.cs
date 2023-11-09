using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts
{
    public static class GenerateCards
    {
        public static List<CardHero> CardHerosRus = new List<CardHero>()
        {
            new CardHero
            {
                Name = "Рагнар Лютый",
                HeroType = HeroType.Rus,
                Strength = 15,
                Wit = 5,
                Faith = 15,
                Desc = "Рагнар Лютый люто любил снюс",
                Image = "Sprites/Hero/Rus/ragnar",
                AudioId = 0
            },
            new CardHero
            {
                Name = "Всеслав Жужелица",
                HeroType = HeroType.Rus,
                Strength = 20,
                Wit = 10,
                Faith = 10,
                Desc = "Всеслав Жужелица не любил ящеров",
                Image = "Sprites/Hero/Rus/vseslav",
                AudioId = 1
            },
            new CardHero
            {
                Name = "Святосмех I",
                HeroType = HeroType.Rus,
                Strength = 18,
                Wit = 8,
                Faith = 20,
                Desc = "Святосмех I любил рофлы и постиронию",
                Image = "Sprites/Hero/Rus/svyatosmeh",
                AudioId = 2
            },
            new CardHero
            {
                Name = "Владимем Игоревич",
                HeroType = HeroType.Rus,
                Strength = 6,
                Wit = 15,
                Faith = 20,
                Desc = "Владимем Игоревич любил мемы",
                Image = "Sprites/Hero/Rus/vladimem",
                AudioId = 3
            },
            new CardHero
            {
                Name = "Дубыня Святогор",
                HeroType = HeroType.Rus,
                Strength = 12,
                Wit = 15,
                Faith = 18,
                Desc = "Дубыня Святогор был героем доты",
                Image = "Sprites/Hero/Rus/dybunya",
                AudioId = 4
            },
            new CardHero
            {
                Name = "Олег Могучий",
                HeroType = HeroType.Rus,
                Strength = 17,
                Wit = 8,
                Faith = 12,
                Desc = "Олег Могучий быть сильным",
                Image = "Sprites/Hero/Rus/oleg",
                AudioId = 5
            },
            new CardHero
            {
                Name = "Михайло Киевский",
                HeroType = HeroType.Rus,
                Strength = 10,
                Wit = 15,
                Faith = 20,
                Desc = "Михайло Киевский основал Киев",
                Image = "Sprites/Hero/Rus/mihailo",
                AudioId = 6
            },
            new CardHero
            {
                Name = "Ярослав Рязанский",
                HeroType = HeroType.Rus,
                Strength = 15,
                Wit = 8,
                Faith = 16,
                Desc = "Ярослав Рязанский не был в Рязани",
                Image = "Sprites/Hero/Rus/yaroslav",
                AudioId = 7
            },
            new CardHero
            {
                Name = "Князь Казимир Победоносный",
                HeroType = HeroType.Rus,
                Strength = 15,
                Wit = 12,
                Faith = 6,
                Desc = "Князь Казимир Победоносный любил фонк",
                Image = "Sprites/Hero/Rus/kazimir_3",
                AudioId = 8
            },
            new CardHero
            {
                Name = "Князь Черномаз",
                HeroType = HeroType.Rus,
                Strength = 18,
                Wit = 10,
                Faith = 12,
                Desc = "Князь Черномаз был последнем князем Южно-Африканской Руси",
                Image = "Sprites/Hero/Rus/chernomaz",
                AudioId = 9
            },
        };

        public static List<CardHero> CardHerosLizard = new List<CardHero>()
        {
            new CardHero
            {
                Name = "Геккослав Шипастый",
                HeroType = HeroType.Lizard,
                Strength = 15,
                Wit = 7,
                Faith = 15,
                Desc = "Геккослав Шипастый — злобный ящер, атакующий русов без пощады",
                Image = "Sprites/Hero/Lizards/gekkoslav",
                AudioId = 0
            },
            new CardHero
            {
                Name = "Лиззий Хвосторез",
                HeroType = HeroType.Lizard,
                Strength = 12,
                Wit = 12,
                Faith = 12,
                Desc = "Лиззий Хвосторез — ящер с летальным укусом, угрожает русам в тайге",
                Image = "Sprites/Hero/Lizards/lizzyi",
                AudioId = 1
            },
            new CardHero
            {
                Name = "Василиск Глазозмей",
                HeroType = HeroType.Lizard,
                Strength = 20,
                Wit = 8,
                Faith = 20,
                Desc = "Василиск Глазозмей — ящер с гипнотическим взглядом, пугающий русов во сне.",
                Image = "Sprites/Hero/Lizards/basilisk",
                AudioId = 2
            },
            new CardHero
            {
                Name = "Токсикс Ядоклюй",
                HeroType = HeroType.Lizard,
                Strength = 6,
                Wit = 15,
                Faith = 20,
                Desc = "Токсикс Ядоклюй — ящер с ядовитым укусом, терроризирует русов в зарослях.",
                Image = "Sprites/Hero/Lizards/toxiks",
                AudioId = 3
            },
            new CardHero
            {
                Name = "Черепах Твердопанцирник",
                HeroType = HeroType.Lizard,
                Strength = 12,
                Wit = 19,
                Faith = 8,
                Desc = "Черепах Твердопанцирник — ящер с непробиваемым панцирем, дерзкий противник русов.",
                Image = "Sprites/Hero/Lizards/cherepah",
                AudioId = 4
            },
            new CardHero
            {
                Name = "Леонард Рептилоид",
                HeroType = HeroType.Lizard,
                Strength = 17,
                Wit = 8,
                Faith = 12,
                Desc = "Леонард Рептилоид — ящер, проклятый враг русов, искусный в бою.",
                Image = "Sprites/Hero/Lizards/leonard",
                AudioId = 5
            },
            new CardHero
            {
                Name = "Скорп Хвостокол",
                HeroType = HeroType.Lizard,
                Strength = 20,
                Wit = 15,
                Faith = 10,
                Desc = "Скорп Хвостокол — ящер с ядовитым хвостом, сталкивался с русами в схватках.",
                Image = "Sprites/Hero/Lizards/skorp",
                AudioId = 6
            },
            new CardHero
            {
                Name = "Чамелеон Размазня",
                HeroType = HeroType.Lizard,
                Strength = 5,
                Wit = 8,
                Faith = 16,
                Desc = "Чамелеон Размазня — ящер, меняющий облик, зловещий противник русов.",
                Image = "Sprites/Hero/Lizards/chamelion",
                AudioId = 7
            },
            new CardHero
            {
                Name = "Варан Бронекожий",
                HeroType = HeroType.Lizard,
                Strength = 18,
                Wit = 12,
                Faith = 6,
                Desc = "Варан Бронекожий — ящер с неуязвимой чешуей, сопротивляющийся русам в битвах.",
                Image = "Sprites/Hero/Lizards/varan",
                AudioId = 8
            },
            new CardHero
            {
                Name = "Комод Крепкий",
                HeroType = HeroType.Lizard,
                Strength = 8,
                Wit = 10,
                Faith = 12,
                Desc = "Комод Крепкий — ящер, несгибаемый в сражениях с русами.",
                Image = "Sprites/Hero/Lizards/komod",
                AudioId = 9
            },

            new CardHero
            {
                Name = "Великий космический Крокодил",
                HeroType = HeroType.Lizard,
                Strength = 30,
                Wit = 30,
                Faith = 30,
                Desc = "Ящеры построили космического крокодила и затмили им солнце на 30 лет и 3 года",
                Image = "Sprites/Hero/Lizards/space_croc",
                AudioId = 10
            },
        };

        public static List<CardBonusBase> CardBonuses = TakeCardBonuses();

        private static List<CardBonusBase> TakeCardBonuses()
        {
            var result = new List<CardBonusBase>();

            #region CardBonusAll

            var rusParamAllPlus = Enumerable.Range(0, 3).Select(el => new CardBonusAll
            {
                Text = "Вода из байкала",
                HeroType = HeroType.Rus,
                CardBonusType = CardBonusType.ParamAll,
                IsPlus = true,
                Number = el + 2,
                Desc = $"Добаляет {el + 2} ко всем характеристикам русов",
                Image = "Sprites/Bonus/Rus/baikal_water",
                AudioId = 0
            }).ToList();
            
            var rusParamAllMin = rusParamAllPlus.Select(el => new CardBonusAll
            {
                Text = "Славянский гнев",
                HeroType = el.HeroType,
                CardBonusType = el.CardBonusType,
                IsPlus = false,
                Number = el.Number,
                Desc = $"Отнимает {el.Number} от всех характеристик ящеров",
                Image = "Sprites/Bonus/Rus/slavic_rage",
                AudioId = 1
            }).ToList();
            
            var lizParamAllPlus = rusParamAllPlus.Select(el => new CardBonusAll
            {
                Text = "Вода из Атлантиды",
                HeroType = HeroType.Lizard,
                CardBonusType = el.CardBonusType,
                IsPlus = el.IsPlus,
                Number = el.Number,
                Desc = $"Добаляет {el.Number} ко всем характеристикам ящеров",
                Image = "Sprites/Bonus/Lizards/atlantic_water",
                AudioId = 0
            }).ToList();
            
            var lizParamAllMin = rusParamAllMin.Select(el => new CardBonusAll
            {
                Text = "Отравление байкальской воды",
                HeroType = HeroType.Lizard,
                CardBonusType = el.CardBonusType,
                IsPlus = el.IsPlus,
                Number = el.Number,
                Desc = $"Отнимает {el.Number} от всех характеристик русов",
                Image = "Sprites/Bonus/Lizards/poison_potion",
                AudioId = 1
            }).ToList();

            result.AddRange(rusParamAllPlus);
            result.AddRange(rusParamAllMin);
            result.AddRange(lizParamAllPlus);
            result.AddRange(lizParamAllMin);

            #endregion

            #region CardBonusParam

            for (int a = 0; a < 2; a++)
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            string text = "", desc = "", image = "";
                            int audioID = 0;
                            if (a == 0)
                            {
                                if (i == 0)
                                {
                                    if (j == 0)
                                    {
                                        text = "Благославление Перуна";
                                        desc = $"Плюс {4 + 2 * k} к Силе";
                                        image = "Sprites/Bonus/Rus/perun_blessing";
                                        audioID = 2;
                                    }
                                    else if (j == 1)
                                    {
                                        text = "Благославление Сварога";
                                        desc = $"Плюс {4 + 2 * k} к Смекалке";
                                        image = "Sprites/Bonus/Rus/svarog_blessing";
                                        audioID = 4;
                                    }
                                    else
                                    {
                                        text = "Благославление Велеса";
                                        desc = $"Плюс {4 + 2 * k} к Вере";
                                        image = "Sprites/Bonus/Rus/veles_blessing";
                                        audioID = 3;
                                    }  
                                }
                                else
                                {
                                    if (j == 0)
                                    {
                                        text = "Поддержка космического крокодила";
                                        desc = $"Плюс {4 + 2 * k} к Силе";
                                        image = "Sprites/Bonus/Lizards/space_croc_support";
                                        audioID = 2;
                                    }
                                    else if (j == 1)
                                    {
                                        text = "Поддержка Пирамиды";
                                        desc = $"Плюс {4 + 2 * k} к Смекалке";
                                        image = "Sprites/Bonus/Lizards/pyramid_support";
                                        audioID = 4;
                                    }
                                    else
                                    {
                                        text = "Поддержка Атлантиды";
                                        desc = $"Плюс {4 + 2 * k} к Вере";
                                        image = "Sprites/Bonus/Lizards/atlantic_support";
                                        audioID = 3;
                                    }  
                                }
                            }
                            else
                            {
                                if (i == 0)
                                {
                                    if (j == 0)
                                    {
                                        text = "Проклятие Перуна";
                                        desc = $"Минус {4 + 2 * k} к Силе ящера";
                                        image = "Sprites/Bonus/Rus/perun_curse";
                                        audioID = 5;
                                    }
                                    else if (j == 1)
                                    {
                                        text = "Проклятие Сварога";
                                        desc = $"Минус {4 + 2 * k} к Смекалке ящера";
                                        image = "Sprites/Bonus/Rus/svarog_curse";
                                        audioID = 7;
                                    }
                                    else
                                    {
                                        text = "Проклятие Велеса";
                                        desc = $"Минус {4 + 2 * k} к Вере ящера";
                                        image = "Sprites/Bonus/Rus/veles_curse";
                                        audioID = 6;
                                    }
                                }
                                else
                                {
                                    if (j == 0)
                                    {
                                        text = "Разорение Южно-Африканской Руси";
                                        desc = $"Минус {4 + 2 * k} к Силе руса";
                                        image = "Sprites/Bonus/Lizards/ruined_settlement";
                                        audioID = 5;
                                    }
                                    else if (j == 1)
                                    {
                                        text = "Математика";
                                        desc = $"Минус {4 + 2 * k} к Смекалке руса";
                                        image = "Sprites/Bonus/Lizards/math";
                                        audioID = 7;
                                    }
                                    else
                                    {
                                        text = "Постройка пирамиды";
                                        desc = $"Минус {4 + 2 * k} к Вере руса";
                                        image = "Sprites/Bonus/Lizards/pyramid_building";
                                        audioID = 6;
                                    }
                                        
                                }
                            }

                            result.Add(new CardBonusParam
                            {
                                Text = text,
                                HeroType = (HeroType)i,
                                CardBonusType = CardBonusType.Param,
                                IsPlus = a == 0,
                                Number = 4 + 2*k,
                                HeroParameter = (HeroParameter)j,
                                Desc = desc,
                                Image = image,
                                AudioId = audioID
                            });
                        }
                    }
                }
            }

            #endregion

            #region CardBonusChangeParam

            result.Add(new CardBonusChangeParam 
            { 
                CardBonusType = CardBonusType.ChangeParam,
                HeroType = HeroType.Rus,
                Text = "Славянская смекалка",
                Desc = "Смена характ. по которой идет драка",
                Image = "Sprites/Bonus/Rus/slavic_wit",
                AudioId = 8
            });

            result.Add(new CardBonusChangeParam
            {
                CardBonusType = CardBonusType.ChangeParam,
                HeroType = HeroType.Lizard,
                Text = "Ящерская хитрость",
                Desc = "Смена характ. по которой идет драка",
                Image = "Sprites/Bonus/Lizards/lizard_wit",
                AudioId = 8
            });

            #endregion

            #region CardBonusHelp

            result.Add(new CardBonusHelp
            {
                CardBonusType = CardBonusType.Help,
                HeroType = HeroType.Rus,
                Text = "Призыв дружины",
                Desc = "Добавить карту руса",
                Image = "Sprites/Bonus/Rus/squad_call",
                AudioId = 9
            });

            result.Add(new CardBonusHelp
            {
                CardBonusType = CardBonusType.Help,
                HeroType = HeroType.Lizard,
                Text = "Подмога с Атлантиды",
                Desc = "Добавить карту ящера",
                Image = "Sprites/Bonus/Lizards/atlantic_help",
                AudioId = 9
            });

            #endregion

            #region CardBonusSwap

            result.Add(new CardBonusSwap
            {
                CardBonusType = CardBonusType.Swap,
                HeroType = HeroType.Rus,
                Text = "Замена руса",
                Desc = "Замена карты руса",
                Image = "Sprites/Bonus/Rus/swap",
                AudioId = 10
            });

            result.Add(new CardBonusSwap
            {
                CardBonusType = CardBonusType.Swap,
                HeroType = HeroType.Lizard,
                Text = "Замена ящера",
                Desc = "Замена карты ящера",
                Image = "Sprites/Bonus/Lizards/swap",
                AudioId = 10
            });

            #endregion

            return result;
        }

        public static List<CardBonusBase> GenerateCardBonuses(int count, HeroType heroType)
        {
            var r = new Random();

            var indexes = new List<int>();

            var result = new List<CardBonusBase>();

            while (count >= indexes.Count)
            {
                int tmp = r.Next(CardBonuses.Count);
                if (indexes.Contains(tmp))
                    continue;
                else
                {
                    if (CardBonuses[tmp].HeroType == heroType)
                        indexes.Add(tmp);
                }
            }

            foreach (var index in indexes)
                result.Add(CardBonuses[index]);

            return result;
        }

        public static List<CardBonusBase> GenerateCardBonusesNoHelp(int count, HeroType heroType)
        {
            var result = new List<CardBonusBase>();

            while (count > result.Count)
            {
                var card = GenerateCardBonuses(1, heroType);

                if (card[0].CardBonusType == CardBonusType.Swap || card[0].CardBonusType == CardBonusType.Help || card[0].CardBonusType == CardBonusType.ChangeParam)
                    continue;

                result.Add(card[0]);
            }

            return result;
        }

        public static List<CardHero> GenerateCardHeros(int count, HeroType heroType)
        {
            switch (heroType)
            {
                case HeroType.Rus:
                    return GenerateCardHeros(CardHerosRus, count);
                case HeroType.Lizard:
                    return GenerateCardHeros(CardHerosLizard.SkipLast(1).ToList(), count);
                default:
                    throw new ArgumentException("gg...");
            }
        }

        private static List<CardHero> GenerateCardHeros(List<CardHero> CardHeros, int count)
        {
            var r = new Random();

            var indexes = new List<int>();

            var result = new List<CardHero>();

            while (count >= indexes.Count)
            {
                int tmp = r.Next(CardHeros.Count);
                if (indexes.Contains(tmp))
                    continue;
                else
                    indexes.Add(tmp);
            }

            foreach (var index in indexes)
                result.Add(CardHeros[index]);

            return result;
        }
    }
}
