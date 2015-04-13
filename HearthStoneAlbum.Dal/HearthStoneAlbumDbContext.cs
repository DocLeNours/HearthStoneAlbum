using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;
using HearthStoneAlbum.Dal.Mapping;

namespace HearthStoneAlbum.Dal {
    public class HearthStoneAlbumDbContext : DbContext {
        public HearthStoneAlbumDbContext(string connectionString) : base(connectionString) { }

        #region DbSets
        public DbSet<Player> Players { get; set; }
        public DbSet<Adventure> Adventures { get; set; }
        public DbSet<Boss> Bosses { get; set; }
        public DbSet<PlayerBoss> PlayerBosses { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<CardSet> CardSets { get; set; }
        public DbSet<CardType> CardTypes { get; set; }
        public DbSet<PlayerHeroClass> PlayerHeroClasses { get; set; }
        public DbSet<HeroClass> HeroClasses { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Rarity> Rarities { get; set; }
        public DbSet<Wing> Wings { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<CardLanguage> CardLanguages { get; set; }
        public DbSet<AdventureLanguage> AdventureLanguages { get; set; }
        public DbSet<BossLanguage> BossLanguages { get; set; }
        public DbSet<CardSetLanguage> CardSetLanguages { get; set; }
        public DbSet<CardTypeLanguage> CardTypeLanguages { get; set; }
        public DbSet<HeroClassLanguage> HeroClassLanguages { get; set; }
        public DbSet<RaceLanguage> RaceLanguages { get; set; }
        public DbSet<RarityLanguage> RarityLanguages { get; set; }
        public DbSet<WingLanguage> WingLanguages { get; set; }
        public DbSet<PlayerCard> PlayerCards { get; set; }
        public DbSet<HeroClassChallenge> HeroClassChallenges { get; set; }
        public DbSet<PlayerHeroClassChallenge> PlayerHeroClassChallenges { get; set; }
        public DbSet<WingReward> WingRewards { get; set; }
        public DbSet<BossReward> BossRewards { get; set; }
        public DbSet<HeroClassChallengeReward> HeroClassChallengeRewards { get; set; }
        public DbSet<RaceReward> RaceRewards { get; set; }
        public DbSet<CardSetRaceReward> CardSetRaceRewards { get; set; }
        public DbSet<HeroClassReward> HeroClassRewards { get; set; }

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            Database.SetInitializer<HearthStoneAlbumDbContext>(new HearthStoneAlbumDbInitializer());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new PlayerMap());
            modelBuilder.Configurations.Add(new LanguageMap());
            modelBuilder.Configurations.Add(new AdventureMap());
            modelBuilder.Configurations.Add(new AdventureLanguageMap());
            modelBuilder.Configurations.Add(new BossMap());
            modelBuilder.Configurations.Add(new BossLanguageMap());
            modelBuilder.Configurations.Add(new PlayerBossMap());
            modelBuilder.Configurations.Add(new CardMap());
            modelBuilder.Configurations.Add(new CardLanguageMap());
            modelBuilder.Configurations.Add(new CardSetMap());
            modelBuilder.Configurations.Add(new CardSetLanguageMap());
            modelBuilder.Configurations.Add(new CardTypeMap());
            modelBuilder.Configurations.Add(new CardTypeLanguageMap());
            modelBuilder.Configurations.Add(new PlayerHeroClassMap());
            modelBuilder.Configurations.Add(new HeroClassMap());
            modelBuilder.Configurations.Add(new HeroClassLanguageMap());
            modelBuilder.Configurations.Add(new RaceMap());
            modelBuilder.Configurations.Add(new RaceLanguageMap());
            modelBuilder.Configurations.Add(new RarityMap());
            modelBuilder.Configurations.Add(new RarityLanguageMap());
            modelBuilder.Configurations.Add(new WingMap());
            modelBuilder.Configurations.Add(new WingLanguageMap());
            modelBuilder.Configurations.Add(new PlayerCardMap());
            modelBuilder.Configurations.Add(new HeroClassChallengeMap());
            modelBuilder.Configurations.Add(new PlayerHeroClassChallengeMap());
            modelBuilder.Configurations.Add(new RewardMap());
            modelBuilder.Configurations.Add(new WingRewardMap());
            modelBuilder.Configurations.Add(new BossRewardMap());
            modelBuilder.Configurations.Add(new HeroClassChallengeRewardMap());
            modelBuilder.Configurations.Add(new RaceRewardMap());
            modelBuilder.Configurations.Add(new CardSetRaceRewardMap());
            modelBuilder.Configurations.Add(new HeroClassRewardMap());
        }
    }
}
