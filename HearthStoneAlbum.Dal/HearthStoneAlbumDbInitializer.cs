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
                });

            PlayerClass druid = new PlayerClass { PlayerClassId = 2 };
            PlayerClass hunter = new PlayerClass { PlayerClassId = 3 };
            PlayerClass mage = new PlayerClass { PlayerClassId = 4 };
            PlayerClass paladin = new PlayerClass { PlayerClassId = 5 };
            PlayerClass priest = new PlayerClass { PlayerClassId = 6 };
            PlayerClass rogue = new PlayerClass { PlayerClassId = 7 };
            PlayerClass shaman = new PlayerClass { PlayerClassId = 8 };
            PlayerClass warlock = new PlayerClass { PlayerClassId = 9 };
            PlayerClass warrior = new PlayerClass { PlayerClassId = 10 };
            context.PlayerClasses.AddRange(new[] {
                    new PlayerClass { PlayerClassId = 0 },
                    druid,
                    hunter,
                    mage,
                    paladin,
                    priest,
                    rogue,
                    shaman,
                    warlock,
                    warrior,
                    new PlayerClass { PlayerClassId = 11 },
                });
            context.PlayerClassLanguages.AddRange(new[] {
		            new PlayerClassLanguage { PlayerClassId = 0, LanguageId = 1, Name = "Undefined" },
		            new PlayerClassLanguage { PlayerClassId = 2, LanguageId = 1, Name = "Druid" },
		            new PlayerClassLanguage { PlayerClassId = 3, LanguageId = 1, Name = "Hunter" },
		            new PlayerClassLanguage { PlayerClassId = 4, LanguageId = 1, Name = "Mage" },
		            new PlayerClassLanguage { PlayerClassId = 5, LanguageId = 1, Name = "Paladin" },
		            new PlayerClassLanguage { PlayerClassId = 6, LanguageId = 1, Name = "Priest" },
		            new PlayerClassLanguage { PlayerClassId = 7, LanguageId = 1, Name = "Rogue" },
		            new PlayerClassLanguage { PlayerClassId = 8, LanguageId = 1, Name = "Shaman" },
		            new PlayerClassLanguage { PlayerClassId = 9, LanguageId = 1, Name = "Warlock" },
		            new PlayerClassLanguage { PlayerClassId = 10, LanguageId = 1, Name = "Warrior" },
		            new PlayerClassLanguage { PlayerClassId = 11, LanguageId = 1, Name = "Dream" },
                });

            Adventure naxx = new Adventure { };
            context.Adventures.Add(naxx);
            context.AdventureLanguages.Add(new AdventureLanguage { Adventure = naxx, LanguageId = 1, Name = "Curse of Naxxramas" });

            Wing arachnid = new Wing { WingId = 1, Adventure = naxx };
            Wing plague = new Wing { WingId = 2, Adventure = naxx };
            Wing military = new Wing { WingId = 3, Adventure = naxx };
            Wing construct = new Wing { WingId = 4, Adventure = naxx };
            Wing frostwyrm = new Wing { WingId = 5, Adventure = naxx };
            context.Wings.AddRange(new[] { arachnid, plague, military, construct, frostwyrm });
            context.WingLanguages.AddRange(new[] {
                    new WingLanguage { Wing = arachnid, LanguageId = 1, Name = "Arachnid Quarter" },
                    new WingLanguage { Wing = plague, LanguageId = 1, Name = "Plague Quarter" },
                    new WingLanguage { Wing = military, LanguageId = 1, Name = "Military Quarter" },
                    new WingLanguage { Wing = construct, LanguageId = 1, Name = "Construct Quarter" },
                    new WingLanguage { Wing = frostwyrm, LanguageId = 1, Name = "Frostwyrm Lair" },
                });

            context.Bosses.AddRange(new[] {
                    new Boss { BossId = 1, Wing = arachnid },
                    new Boss { BossId = 2, Wing = arachnid, PlayerClass = druid },
                    new Boss { BossId = 3, Wing = arachnid, PlayerClass = rogue },
                    new Boss { BossId = 4, Wing = plague },
                    new Boss { BossId = 5, Wing = plague, PlayerClass = mage },
                    new Boss { BossId = 6, Wing = plague, PlayerClass = hunter },
                    new Boss { BossId = 7, Wing = military },
                    new Boss { BossId = 8, Wing = military, PlayerClass = shaman },
                    new Boss { BossId = 9, Wing = military, PlayerClass = warlock },
                    new Boss { BossId = 10, Wing = construct },
                    new Boss { BossId = 11, Wing = construct, PlayerClass = warrior },
                    new Boss { BossId = 12, Wing = construct },
                    new Boss { BossId = 13, Wing = construct, PlayerClass = priest },
                    new Boss { BossId = 14, Wing = frostwyrm },
                    new Boss { BossId = 15, Wing = frostwyrm, PlayerClass = paladin },
                });
            context.BossLanguages.AddRange(new[] {
                    new BossLanguage { BossId = 1, LanguageId = 1, Name = "Anub'Rekhan" },
                    new BossLanguage { BossId = 2, LanguageId = 1, Name = "Grand Widow Faerlina" },
                    new BossLanguage { BossId = 3, LanguageId = 1, Name = "Maexxna" },
                    new BossLanguage { BossId = 4, LanguageId = 1, Name = "Noth the Plaguebringer" },
                    new BossLanguage { BossId = 5, LanguageId = 1, Name = "Heigan the Unclean" },
                    new BossLanguage { BossId = 6, LanguageId = 1, Name = "Loatheb" },
                    new BossLanguage { BossId = 7, LanguageId = 1, Name = "Instructor Razuvious" },
                    new BossLanguage { BossId = 8, LanguageId = 1, Name = "Gothik the Harvester" },
                    new BossLanguage { BossId = 9, LanguageId = 1, Name = "The Four Horsemen" },
                    new BossLanguage { BossId = 10, LanguageId = 1, Name = "Patchwerk" },
                    new BossLanguage { BossId = 11, LanguageId = 1, Name = "Grobbulus" },
                    new BossLanguage { BossId = 12, LanguageId = 1, Name = "Gluth" },
                    new BossLanguage { BossId = 13, LanguageId = 1, Name = "Thaddius" },
                    new BossLanguage { BossId = 14, LanguageId = 1, Name = "Sapphiron" },
                    new BossLanguage { BossId = 15, LanguageId = 1, Name = "Kel'Thuzad" },
                });

            context.CardSets.AddRange(new[] {
                    new CardSet { CardSetId = 2 },
                    new CardSet { CardSetId = 3 },
                    new CardSet { CardSetId = 4 },
                    new CardSet { CardSetId = 5 },
                    new CardSet { CardSetId = 7 },
                    new CardSet { CardSetId = 8 },
                    new CardSet { CardSetId = 11 },
                    new CardSet { CardSetId = 12, Adventure = naxx },
                    new CardSet { CardSetId = 13 },
                    new CardSet { CardSetId = 16 },
                });
            context.CardSetLanguages.AddRange(new[] {
                    new CardSetLanguage { CardSetId = 2 , LanguageId = 1, Name= "Basic" },
                    new CardSetLanguage { CardSetId = 3 , LanguageId = 1, Name= "Classic" },
                    new CardSetLanguage { CardSetId = 4 , LanguageId = 1, Name= "Reward" },
                    new CardSetLanguage { CardSetId = 5 , LanguageId = 1, Name= "Missions" },
                    new CardSetLanguage { CardSetId = 7 , LanguageId = 1, Name= "System" },
                    new CardSetLanguage { CardSetId = 8 , LanguageId = 1, Name= "Debug" },
                    new CardSetLanguage { CardSetId = 11 , LanguageId = 1, Name= "Promotion" },
                    new CardSetLanguage { CardSetId = 12 , LanguageId = 1, Name= "Curse of Naxxramas" },
                    new CardSetLanguage { CardSetId = 13 , LanguageId = 1, Name= "Goblins vs Gnomes" },
                    new CardSetLanguage { CardSetId = 16 , LanguageId = 1, Name= "Credits" }, 
                });

            context.CardTypes.AddRange(new[] {
                    new CardType { CardTypeId = 3 },
                    new CardType { CardTypeId = 4 },
                    new CardType { CardTypeId = 5 },
                    new CardType { CardTypeId = 6 },
                    new CardType { CardTypeId = 7 },
                    new CardType { CardTypeId = 10 },
                });
            context.CardTypeLanguages.AddRange(new[] {
		            new CardTypeLanguage {CardTypeId = 3, LanguageId = 1, Name = "Hero" },
		            new CardTypeLanguage {CardTypeId = 4, LanguageId = 1, Name = "Minion" },
		            new CardTypeLanguage {CardTypeId = 5, LanguageId = 1, Name = "Spell" },
		            new CardTypeLanguage {CardTypeId = 6, LanguageId = 1, Name = "Enchantment" },
		            new CardTypeLanguage {CardTypeId = 7, LanguageId = 1, Name = "Weapon" },
		            new CardTypeLanguage {CardTypeId = 10, LanguageId = 1, Name = "Hero Power" },
                });

            context.Rarities.AddRange(new[] {
                    new Rarity { RarityId = 0 },
                    new Rarity { RarityId = 1 },
                    new Rarity { RarityId = 2 },
                    new Rarity { RarityId = 3 },
                    new Rarity { RarityId = 4 },
                    new Rarity { RarityId = 5 },
                });
            context.RarityLanguages.AddRange(new[] {
                    new RarityLanguage { RarityId = 0, LanguageId = 1, Name = "Undefined" },
		            new RarityLanguage { RarityId = 1, LanguageId = 1, Name = "Common" },
		            new RarityLanguage { RarityId = 2, LanguageId = 1, Name = "Free" },
		            new RarityLanguage { RarityId = 3, LanguageId = 1, Name = "Rare" },
		            new RarityLanguage { RarityId = 4, LanguageId = 1, Name = "Epic" },
		            new RarityLanguage { RarityId = 5, LanguageId = 1, Name = "Legendary" },
                });

            context.Races.AddRange(new[] {
                    new Race { RaceId = 14 },
                    new Race { RaceId = 15 },
                    new Race { RaceId = 20 },
                    new Race { RaceId = 21 },
                    new Race { RaceId = 23 },
                    new Race { RaceId = 24 },
                    new Race { RaceId = 17 },
                });
            context.RaceLanguages.AddRange(new[] {
                	new RaceLanguage { RaceId = 14, LanguageId = 1, Name = "Murloc" },
		            new RaceLanguage { RaceId = 15, LanguageId = 1, Name = "Demon" },
		            new RaceLanguage { RaceId = 20, LanguageId = 1, Name = "Beast" },
		            new RaceLanguage { RaceId = 21, LanguageId = 1, Name = "Totem" },
		            new RaceLanguage { RaceId = 23, LanguageId = 1, Name = "Pirate" },
		            new RaceLanguage { RaceId = 24, LanguageId = 1, Name = "Dragon" },
		            new RaceLanguage { RaceId = 17, LanguageId = 1, Name = "Mech" },
                });

            context.SaveChanges();
        }
    }
}
