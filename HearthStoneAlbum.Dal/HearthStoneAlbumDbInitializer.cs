using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Dal {
    public class HearthStoneAlbumDbInitializer : DropCreateDatabaseIfModelChanges<HearthStoneAlbumDbContext> {

        protected override void Seed(HearthStoneAlbumDbContext context) {
            context.Languages.AddRange(new[] {
                new Language { LanguageId = 1, Name = "enUS" },
                new Language { LanguageId = 2, Name = "frFR" },
                new Language { LanguageId = 3, Name = "zhTW" },
                new Language { LanguageId = 4, Name = "zhCN" },
                new Language { LanguageId = 5, Name = "ruRU" },
                new Language { LanguageId = 6, Name = "ptBR" },
                new Language { LanguageId = 7, Name = "plPL" },
                new Language { LanguageId = 8, Name = "koKR" },
                new Language { LanguageId = 9, Name = "itIT" },
                new Language { LanguageId = 10, Name = "esMX" },
                new Language { LanguageId = 11, Name = "esES" },
                new Language { LanguageId = 12, Name = "deDE" },
                new Language { LanguageId = 13, Name = "enGB" },
                new Language { LanguageId = 14, Name = "ptPT" },
            });

            context.HeroClasses.AddRange(new[] {
                new HeroClass { HeroClassId = 2, HeroClassLanguages = new[] {
		            new HeroClassLanguage { HeroClassId = 2, LanguageId = 1, Name = "Druid" },
                }},
                new HeroClass { HeroClassId = 3, HeroClassLanguages = new[] {
		            new HeroClassLanguage { HeroClassId = 3, LanguageId = 1, Name = "Hunter" },
                }},
                new HeroClass { HeroClassId = 4, HeroClassLanguages = new[] {
		            new HeroClassLanguage { HeroClassId = 4, LanguageId = 1, Name = "Mage" },
                }},
                new HeroClass { HeroClassId = 5, HeroClassLanguages = new[] {
		            new HeroClassLanguage { HeroClassId = 5, LanguageId = 1, Name = "Paladin" },
                }},
                new HeroClass { HeroClassId = 6, HeroClassLanguages = new[] {
		            new HeroClassLanguage { HeroClassId = 6, LanguageId = 1, Name = "Priest" },
                }},
                new HeroClass { HeroClassId = 7, HeroClassLanguages = new[] {
		            new HeroClassLanguage { HeroClassId = 7, LanguageId = 1, Name = "Rogue" },
                }},
                new HeroClass { HeroClassId = 8, HeroClassLanguages = new[] {
		            new HeroClassLanguage { HeroClassId = 8, LanguageId = 1, Name = "Shaman" },
                }},
                new HeroClass { HeroClassId = 9, HeroClassLanguages = new[] {
		            new HeroClassLanguage { HeroClassId = 9, LanguageId = 1, Name = "Warlock" },
                }},
                new HeroClass { HeroClassId = 10, HeroClassLanguages = new[] {
		            new HeroClassLanguage { HeroClassId = 10, LanguageId = 1, Name = "Warrior" },
                }},
            });

            DbSet<HeroClass> classes = context.HeroClasses;
            Adventure naxx = SetNaxx(classes);
            context.Adventures.Add(naxx);
            Adventure blackrock = SetBlackrock(classes);
            context.Adventures.Add(blackrock);

            context.CardSets.AddRange(new[] {
                new CardSet { CardSetId = 2, CardSetLanguages = new[] {
                    new CardSetLanguage { CardSetId = 2 , LanguageId = 1, Name= "Basic" },
                }},
                new CardSet { CardSetId = 3, CardSetLanguages = new[] {
                    new CardSetLanguage { CardSetId = 3 , LanguageId = 1, Name= "Classic" },
                }},
                new CardSet { CardSetId = 4, CardSetLanguages = new[] {
                    new CardSetLanguage { CardSetId = 4 , LanguageId = 1, Name= "Reward" },
                }},
                new CardSet { CardSetId = 11, CardSetLanguages = new[] {
                    new CardSetLanguage { CardSetId = 11 , LanguageId = 1, Name= "Promotion" },
                }},
                new CardSet { CardSetId = 12, Adventure = naxx, CardSetLanguages = new[] {
                    new CardSetLanguage { CardSetId = 12 , LanguageId = 1, Name= "Curse of Naxxramas" },
                }},
                new CardSet { CardSetId = 13, CardSetLanguages = new[] {
                    new CardSetLanguage { CardSetId = 13 , LanguageId = 1, Name= "Goblins vs Gnomes" },
                }},
                new CardSet { CardSetId = 14, Adventure = blackrock, CardSetLanguages = new[] {
                    new CardSetLanguage { CardSetId = 14 , LanguageId = 1, Name= "Blackrock Mountain" },
                }},
            });

            context.CardTypes.AddRange(new[] {
                new CardType { CardTypeId = 4, CardTypeLanguages = new[] {
    		        new CardTypeLanguage {CardTypeId = 4, LanguageId = 1, Name = "Minion" },
                }},
                new CardType { CardTypeId = 5, CardTypeLanguages = new[] {
		            new CardTypeLanguage {CardTypeId = 5, LanguageId = 1, Name = "Spell" },
                }},
                new CardType { CardTypeId = 7, CardTypeLanguages = new[] {
		            new CardTypeLanguage {CardTypeId = 7, LanguageId = 1, Name = "Weapon" },
                }},
            });

            context.Rarities.AddRange(new[] {
                new Rarity { RarityId = 1, RarityLanguages = new[] {
        		    new RarityLanguage { RarityId = 1, LanguageId = 1, Name = "Common" },
                }},
                new Rarity { RarityId = 2, RarityLanguages = new[] {
		            new RarityLanguage { RarityId = 2, LanguageId = 1, Name = "Free" },
                }},
                new Rarity { RarityId = 3, RarityLanguages = new[] {
        		    new RarityLanguage { RarityId = 3, LanguageId = 1, Name = "Rare" },
                }},
                new Rarity { RarityId = 4, RarityLanguages = new[] {
        		    new RarityLanguage { RarityId = 4, LanguageId = 1, Name = "Epic" },
                }},
                new Rarity { RarityId = 5, RarityLanguages = new[] {
        		    new RarityLanguage { RarityId = 5, LanguageId = 1, Name = "Legendary" },
                }},
            });

            context.Races.AddRange(new[] {
                new Race { RaceId = 14, RaceLanguages = new[] {
                    new RaceLanguage { RaceId = 14, LanguageId = 1, Name = "Murloc" },
                }},
                new Race { RaceId = 15, RaceLanguages = new[] {
        		    new RaceLanguage { RaceId = 15, LanguageId = 1, Name = "Demon" },
                }},
                new Race { RaceId = 20, RaceLanguages = new[] {
        		    new RaceLanguage { RaceId = 20, LanguageId = 1, Name = "Beast" },
                }},
                new Race { RaceId = 21, RaceLanguages = new[] {
        		    new RaceLanguage { RaceId = 21, LanguageId = 1, Name = "Totem" },
                }},
                new Race { RaceId = 23, RaceLanguages = new[] {
		            new RaceLanguage { RaceId = 23, LanguageId = 1, Name = "Pirate" },
                }},
                new Race { RaceId = 24, RaceLanguages = new[] {
		            new RaceLanguage { RaceId = 24, LanguageId = 1, Name = "Dragon" },
                }},
                new Race { RaceId = 17, RaceLanguages = new[] {
		            new RaceLanguage { RaceId = 17, LanguageId = 1, Name = "Mech" },
                }},
            });

            context.SaveChanges();
        }

        private HeroClass GetHeroClassByName(DbSet<HeroClass> classes, string name) {
            return classes.SingleOrDefault(pc => pc.HeroClassLanguages
                .Any(pcl => pcl.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)));
        }

        private Adventure SetNaxx(DbSet<HeroClass> classes) {
            return new Adventure() {
                AdventureLanguages = new[] {
                new AdventureLanguage { LanguageId = 1, Name = "Curse of Naxxramas" }},
                Wings = new[] {
                    new Wing { Order = 1, WingLanguages = new[] { 
                        new WingLanguage { LanguageId = 1, Name = "Arachnid Quarter" }},
                        Bosses = new[] {
                            new Boss { Order = 1, BossLanguages = new[] {
                                new BossLanguage { LanguageId = 1, Name = "Anub'Rekhan" },
                            }},
                            new Boss { Order = 2, BossLanguages = new[] {
                                new BossLanguage { LanguageId = 1, Name = "Grand Widow Faerlina" },
                            }},
                            new Boss { Order = 3, BossLanguages = new[] {
                                new BossLanguage { LanguageId = 1, Name = "Maexxna" },
                            }},
                        },
                        HeroClassChallenges = new[] {
                            new HeroClassChallenge { HeroClass = GetHeroClassByName(classes, "Druid") },
                            new HeroClassChallenge { HeroClass = GetHeroClassByName(classes, "Rogue") },
                        },
                    },
                    new Wing { Order = 2, WingLanguages = new[] { 
                        new WingLanguage { LanguageId = 1, Name = "Plague Quarter" }},
                        Bosses = new [] {
                            new Boss { Order = 1, BossLanguages = new[] {
                                new BossLanguage { LanguageId = 1, Name = "Noth the Plaguebringer" },
                            }},
                            new Boss { Order = 2, BossLanguages = new[] {
                                new BossLanguage { LanguageId = 1, Name = "Heigan the Unclean" },
                            }},
                            new Boss { Order = 3, BossLanguages = new[] {
                                new BossLanguage { LanguageId = 1, Name = "Loatheb" },
                            }},
                        },
                        HeroClassChallenges = new[] {
                            new HeroClassChallenge { HeroClass = GetHeroClassByName(classes, "Mage") },
                            new HeroClassChallenge { HeroClass = GetHeroClassByName(classes, "Hunter") },
                        },
                    },
                    new Wing { Order = 3, WingLanguages = new[] { 
                        new WingLanguage { LanguageId = 1, Name = "Military Quarter" }},
                        Bosses = new [] {
                            new Boss { Order = 1, BossLanguages = new[] {
                                new BossLanguage { LanguageId = 1, Name = "Instructor Razuvious" },
                            }},
                            new Boss { Order = 2, BossLanguages = new[] {
                                new BossLanguage { LanguageId = 1, Name = "Gothik the Harvester" },
                            }},
                            new Boss { Order = 3, BossLanguages = new[] {
                                new BossLanguage { LanguageId = 1, Name = "The Four Horsemen" },
                            }},
                        },
                        HeroClassChallenges = new[] {
                            new HeroClassChallenge { HeroClass = GetHeroClassByName(classes, "Shaman") },
                            new HeroClassChallenge { HeroClass = GetHeroClassByName(classes, "Warlock") },
                        },
                    },
                    new Wing { Order = 4, WingLanguages = new[] { 
                        new WingLanguage { LanguageId = 1, Name = "Construct Quarter" }},
                        Bosses = new [] {
                            new Boss { Order = 1, BossLanguages = new[] {
                                new BossLanguage { LanguageId = 1, Name = "Patchwerk" },
                            }},
                            new Boss { Order = 2, BossLanguages = new[] {
                                new BossLanguage { LanguageId = 1, Name = "Grobbulus" },
                            }},
                            new Boss { Order = 3, BossLanguages = new[] {
                                new BossLanguage { LanguageId = 1, Name = "Gluth" },
                            }},
                            new Boss { Order = 4, BossLanguages = new[] {
                                new BossLanguage { LanguageId = 1, Name = "Thaddius" },
                            }},
                        },
                        HeroClassChallenges = new[] {
                            new HeroClassChallenge { HeroClass = GetHeroClassByName(classes, "Warrior") },
                            new HeroClassChallenge { HeroClass = GetHeroClassByName(classes, "Priest") },
                        },
                    },
                    new Wing { Order = 5, WingLanguages = new[] { 
                        new WingLanguage { LanguageId = 1, Name = "Frostwyrm Lair" }},
                        Bosses = new [] {
                            new Boss { Order = 1, BossLanguages = new[] {
                                new BossLanguage { LanguageId = 1, Name = "Sapphiron" },
                            }},
                            new Boss { Order = 2, BossLanguages = new[] {
                                new BossLanguage { LanguageId = 1, Name = "Kel'Thuzad" },
                            }},
                        },
                        HeroClassChallenges = new[] {
                            new HeroClassChallenge { HeroClass = GetHeroClassByName(classes, "Paladin") },
                        },
                    },
                }
            };
        }
        private Adventure SetBlackrock(DbSet<HeroClass> classes) {
            return new Adventure() {
                AdventureLanguages = new[] {
                new AdventureLanguage { LanguageId = 1, Name = "Blackrock Mountain" }},
                Wings = new[] {
                    new Wing { Order = 1, WingLanguages = new[] { 
                        new WingLanguage { LanguageId = 1, Name = "Blackrock Depths" }},
                        Bosses = new[] {
                            new Boss { Order = 1, BossLanguages = new[] {
                                new BossLanguage { LanguageId = 1, Name = "Coren Direbrew" },
                            }},
                            new Boss { Order = 2, BossLanguages = new[] {
                                new BossLanguage { LanguageId = 1, Name = "High Justice Grimstone" },
                            }},
                            new Boss { Order = 3, BossLanguages = new[] {
                                new BossLanguage { LanguageId = 1, Name = "Emperor Thaurissan" },
                            }},
                        },
                        HeroClassChallenges = new[] {
                            new HeroClassChallenge { HeroClass = GetHeroClassByName(classes, "Hunter") },
                            new HeroClassChallenge { HeroClass = GetHeroClassByName(classes, "Mage") },
                        },
                    },
                    new Wing { Order = 2, WingLanguages = new[] { 
                        new WingLanguage { LanguageId = 1, Name = "Molten Core" }},
                    },
                    new Wing { Order = 3, WingLanguages = new[] { 
                        new WingLanguage { LanguageId = 1, Name = "Blackrock Spire" }},
                    },
                    new Wing { Order = 4, WingLanguages = new[] { 
                        new WingLanguage { LanguageId = 1, Name = "Blackwing Lair" }},
                    },
                    new Wing { Order = 5, WingLanguages = new[] { 
                        new WingLanguage { LanguageId = 1, Name = "Hidden Laboratory" }},
                    },
                }
            };
        }
    }
}
