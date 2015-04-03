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

            context.PlayerClasses.AddRange(new[] {
                new PlayerClass { PlayerClassId = 2, PlayerClassLanguages = new[] {
		            new PlayerClassLanguage { PlayerClassId = 2, LanguageId = 1, Name = "Druid" },
                }},
                new PlayerClass { PlayerClassId = 3, PlayerClassLanguages = new[] {
		            new PlayerClassLanguage { PlayerClassId = 3, LanguageId = 1, Name = "Hunter" },
                }},
                new PlayerClass { PlayerClassId = 4, PlayerClassLanguages = new[] {
		            new PlayerClassLanguage { PlayerClassId = 4, LanguageId = 1, Name = "Mage" },
                }},
                new PlayerClass { PlayerClassId = 5, PlayerClassLanguages = new[] {
		            new PlayerClassLanguage { PlayerClassId = 5, LanguageId = 1, Name = "Paladin" },
                }},
                new PlayerClass { PlayerClassId = 6, PlayerClassLanguages = new[] {
		            new PlayerClassLanguage { PlayerClassId = 6, LanguageId = 1, Name = "Priest" },
                }},
                new PlayerClass { PlayerClassId = 7, PlayerClassLanguages = new[] {
		            new PlayerClassLanguage { PlayerClassId = 7, LanguageId = 1, Name = "Rogue" },
                }},
                new PlayerClass { PlayerClassId = 8, PlayerClassLanguages = new[] {
		            new PlayerClassLanguage { PlayerClassId = 8, LanguageId = 1, Name = "Shaman" },
                }},
                new PlayerClass { PlayerClassId = 9, PlayerClassLanguages = new[] {
		            new PlayerClassLanguage { PlayerClassId = 9, LanguageId = 1, Name = "Warlock" },
                }},
                new PlayerClass { PlayerClassId = 10, PlayerClassLanguages = new[] {
		            new PlayerClassLanguage { PlayerClassId = 10, LanguageId = 1, Name = "Warrior" },
                }},
            });

            DbSet<PlayerClass> classes = context.PlayerClasses;
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

        private PlayerClass GetByName(DbSet<PlayerClass> classes, string name) {
            return classes.SingleOrDefault(pc => pc.PlayerClassLanguages.Any(pcl => pcl.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)));
        }

        private Adventure SetNaxx(DbSet<PlayerClass> classes) {
            return new Adventure() {
                AdventureLanguages = new[] {
                new AdventureLanguage { LanguageId = 1, Name = "Curse of Naxxramas" }},
                Wings = new[] {
                    new Wing { WingLanguages = new[] { 
                        new WingLanguage { LanguageId = 1, Name = "Arachnid Quarter" }},
                        Bosses = new[] {
                            new Boss { BossLanguages = new[] {
                                new BossLanguage { LanguageId = 1, Name = "Anub'Rekhan" },
                            }},
                            new Boss { PlayerClass = GetByName(classes, "Druid"), BossLanguages = new[] {
                                new BossLanguage { LanguageId = 1, Name = "Grand Widow Faerlina" },
                            }},
                            new Boss { PlayerClass = GetByName(classes, "Rogue"), BossLanguages = new[] {
                                new BossLanguage { LanguageId = 1, Name = "Maexxna" },
                            }},
                        }
                    },
                    new Wing { WingLanguages = new[] { 
                        new WingLanguage { LanguageId = 1, Name = "Plague Quarter" }},
                        Bosses = new [] {
                            new Boss { BossLanguages = new[] {
                                new BossLanguage { LanguageId = 1, Name = "Noth the Plaguebringer" },
                            }},
                            new Boss { PlayerClass = GetByName(classes, "Mage"), BossLanguages = new[] {
                                new BossLanguage { LanguageId = 1, Name = "Heigan the Unclean" },
                            }},
                            new Boss { PlayerClass = GetByName(classes, "Hunter"), BossLanguages = new[] {
                                new BossLanguage { LanguageId = 1, Name = "Loatheb" },
                            }},
                        }
                    },
                    new Wing { WingLanguages = new[] { 
                        new WingLanguage { LanguageId = 1, Name = "Military Quarter" }},
                        Bosses = new [] {
                            new Boss { BossLanguages = new[] {
                                new BossLanguage { LanguageId = 1, Name = "Instructor Razuvious" },
                            }},
                            new Boss { PlayerClass = GetByName(classes, "Shaman"), BossLanguages = new[] {
                                new BossLanguage { LanguageId = 1, Name = "Gothik the Harvester" },
                            }},
                            new Boss { PlayerClass = GetByName(classes, "Warlock"), BossLanguages = new[] {
                                new BossLanguage { LanguageId = 1, Name = "The Four Horsemen" },
                            }},
                        }
                    },
                    new Wing { WingLanguages = new[] { 
                        new WingLanguage { LanguageId = 1, Name = "Construct Quarter" }},
                        Bosses = new [] {
                            new Boss { BossLanguages = new[] {
                                new BossLanguage { LanguageId = 1, Name = "Patchwerk" },
                            }},
                            new Boss { PlayerClass = GetByName(classes, "Warrior"), BossLanguages = new[] {
                                new BossLanguage { LanguageId = 1, Name = "Grobbulus" },
                            }},
                            new Boss { BossLanguages = new[] {
                                new BossLanguage { LanguageId = 1, Name = "Gluth" },
                            }},
                            new Boss { PlayerClass = GetByName(classes, "Priest"), BossLanguages = new[] {
                                new BossLanguage { LanguageId = 1, Name = "Thaddius" },
                            }},
                        }
                    },
                    new Wing { WingLanguages = new[] { 
                        new WingLanguage { LanguageId = 1, Name = "Frostwyrm Lair" }},
                        Bosses = new [] {
                            new Boss { BossLanguages = new[] {
                                new BossLanguage { LanguageId = 1, Name = "Sapphiron" },
                            }},
                            new Boss { PlayerClass = GetByName(classes, "Paladin"), BossLanguages = new[] {
                                new BossLanguage { LanguageId = 1, Name = "Kel'Thuzad" },
                            }},
                        }
                    },
                }
            };
        }
        private Adventure SetBlackrock(DbSet<PlayerClass> classes) {
            return new Adventure() {
                AdventureLanguages = new[] {
                new AdventureLanguage { LanguageId = 1, Name = "Blackrock Mountain" }},
                Wings = new[] {
                    new Wing { WingLanguages = new[] { 
                        new WingLanguage { LanguageId = 1, Name = "Blackrock Depths" }},
                        Bosses = new[] {
                            new Boss { PlayerClass = GetByName(classes, "Hunter"), BossLanguages = new[] {
                                new BossLanguage { LanguageId = 1, Name = "Coren Direbrew" },
                            }},
                            new Boss { PlayerClass = GetByName(classes, "Mage"), BossLanguages = new[] {
                                new BossLanguage { LanguageId = 1, Name = "High Justice Grimstone" },
                            }},
                            new Boss { BossLanguages = new[] {
                                new BossLanguage { LanguageId = 1, Name = "Emperor Thaurissan" },
                            }},
                        }
                    },
                    new Wing { WingLanguages = new[] { 
                        new WingLanguage { LanguageId = 1, Name = "Molten Core" }},
                    },
                    new Wing { WingLanguages = new[] { 
                        new WingLanguage { LanguageId = 1, Name = "Blackrock Spire" }},
                    },
                    new Wing { WingLanguages = new[] { 
                        new WingLanguage { LanguageId = 1, Name = "Blackwing Lair" }},
                    },
                    new Wing { WingLanguages = new[] { 
                        new WingLanguage { LanguageId = 1, Name = "Hidden Laboratory" }},
                    },
                }
            };
        }
    }
}
