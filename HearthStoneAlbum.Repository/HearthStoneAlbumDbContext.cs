using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;
using HearthStoneAlbum.Repository.Mapping;

namespace HearthStoneAlbum.Repository {
    public class HearthStoneAlbumDbContext : DbContext {
        public HearthStoneAlbumDbContext(string connectionString) : base(connectionString) { }

        #region DbSets
        public DbSet<Player> Players { get; set; }

        public DbSet<Adventure> Adventures { get; set; }
        public DbSet<Boss> Bosses { get; set; }
        public DbSet<BossAchievement> BossAchievements { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<CardSet> CardSets { get; set; }
        public DbSet<CardType> CardTypes { get; set; }
        public DbSet<ChallengeAchievement> ChallengeAchievements { get; set; }
        public DbSet<ClassChallenge> ClassChallenges { get; set; }
        public DbSet<ClassLevel> ClassLevels { get; set; }
        public DbSet<PlayerClass> PlayerClasses { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Rarity> Rarities { get; set; }
        public DbSet<Wing> Wings { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<CardLanguage> CardLanguages { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            Database.SetInitializer<HearthStoneAlbumDbContext>(new DropCreateDatabaseIfModelChanges<HearthStoneAlbumDbContext>());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new PlayerMap());
            modelBuilder.Configurations.Add(new LanguageMap());
            modelBuilder.Configurations.Add(new AdventureMap());
            modelBuilder.Configurations.Add(new AdventureLanguageMap());
            modelBuilder.Configurations.Add(new BossMap());
            modelBuilder.Configurations.Add(new BossLanguageMap());
            modelBuilder.Configurations.Add(new BossAchievementMap());
            modelBuilder.Configurations.Add(new CardMap());
            modelBuilder.Configurations.Add(new CardLanguageMap());
            modelBuilder.Configurations.Add(new CardSetMap());
            modelBuilder.Configurations.Add(new CardSetLanguageMap());
            modelBuilder.Configurations.Add(new CardTypeMap());
            modelBuilder.Configurations.Add(new CardTypeLanguageMap());
            modelBuilder.Configurations.Add(new ChallengeAchievementMap());
            modelBuilder.Configurations.Add(new ClassChallengeMap());
            modelBuilder.Configurations.Add(new ClassLevelMap());
            modelBuilder.Configurations.Add(new PlayerClassMap());
            modelBuilder.Configurations.Add(new PlayerClassLanguageMap());
            modelBuilder.Configurations.Add(new RaceMap());
            modelBuilder.Configurations.Add(new RaceLanguageMap());
            modelBuilder.Configurations.Add(new RarityMap());
            modelBuilder.Configurations.Add(new RarityLanguageMap());
            modelBuilder.Configurations.Add(new WingMap());
            modelBuilder.Configurations.Add(new WingLanguageMap());
        }
    }
}
