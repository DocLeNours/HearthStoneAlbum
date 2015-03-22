using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class Player {

        public Player(IList<ClassLevel> classLevels, IList<BossAchievement> bossAchievements, IList<ChallengeAchievement> challengeAchievements, Album album) {
            this.classLevels = classLevels;
            this.bossAchievements = bossAchievements;
            this.challengeAchievements = challengeAchievements;
            this.Album = album;
        }

        public int PayerId { get; private set; }
        private IList<ClassLevel> classLevels;
        public IReadOnlyCollection<ClassLevel> ClassLevels {
            get {
                return new ReadOnlyCollection<ClassLevel>(classLevels);
            }
        }
        private IList<BossAchievement> bossAchievements;
        public IReadOnlyCollection<BossAchievement> BossAchievements {
            get {
                return new ReadOnlyCollection<BossAchievement>(bossAchievements);
            }
        }
        private IList<ChallengeAchievement> challengeAchievements;
        public IReadOnlyCollection<ChallengeAchievement> ChallengeAchievements {
            get {
                return new ReadOnlyCollection<ChallengeAchievement>(challengeAchievements);
            }
        }
        public Album Album { get; private set; }

        public void SetPlayerClassLevel(PlayerClass playerClass, int level) {
            ClassLevel playerClassLevel = new ClassLevel(playerClass, level);
            classLevels = classLevels.Where(pcl => pcl.PlayerClass != playerClass).ToList();
            classLevels.Add(playerClassLevel);
            // TODO Gérer les cartes    Album.SetCardByLevel(playerClassLevel);
        }
        public void SetBossAchievement(Boss boss, bool achieved) {
            BossAchievement bossAchievement = new BossAchievement(boss, achieved);
            bossAchievements = bossAchievements.Where(ba => ba.Boss != boss).ToList();
            bossAchievements.Add(bossAchievement);
            // TODO Gérer les cartes    Album.SetCardByBoss(bossAchievement);
            // TODO Gérer les challenge
        }
        public void SetChallengeAchievement(ClassChallenge challenge, bool achieved) {
            ChallengeAchievement challengeAchievement = new ChallengeAchievement(challenge, achieved);
            challengeAchievements = challengeAchievements.Where(ca => ca.ClassChallenge != challenge).ToList();
            challengeAchievements.Add(challengeAchievement);
            // TODO Gérer les cartes    Album.SetCardByChallenge(ChallengeAchievement);
        }
    }
}
