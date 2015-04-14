using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Dal;
using HearthStoneAlbum.Domain;
using HearthStoneAlbum.Interface;

namespace HearthStoneAlbum.Service {
    public class PlayerAccountService : IPlayerAccountService {
        private HearthStoneAlbumDbContext context;
        public PlayerAccountService(HearthStoneAlbumDbContext context) {
            this.context = context;
        }

        public async Task<int> CreateAccount(Player player) {
            await this.SetHeroClasses(player);
            int cardNumber = await this.SetFreeCards(player);
            this.context.Players.Add(player);
            await this.context.SaveChangesAsync();
            return cardNumber;
        }

        private async Task<int> SetFreeCards(Player player) {
            IEnumerable<Card> cards = await this.context.Cards
                .Include(c => c.Rarity)
                .Include(c => c.CardLanguages)
                .Where(c => c.CardSet.CardSetId == CardSet.BasicCardSetId)
                .Where(c => !this.context.HeroClassRewards.Any(hcr => hcr.CardId == c.CardId && !hcr.Golden))
                .ToListAsync();
            this.context.PlayerCards
                .AddRange(cards.Select(c => new PlayerCard {
                    Player = player,
                    Card = c,
                    Golden = false,
                    Number = c.Rarity.CopyNumber,
                }));
            return cards.Count();
        }
        private async Task SetHeroClasses(Player player) {
            IList<HeroClass> heroClasses = await this.context.HeroClasses
                .Include(hc => hc.HeroClassLanguages)
                .ToListAsync();
            this.context.PlayerHeroClasses
                .AddRange(heroClasses.Select(hc => new PlayerHeroClass {
                    Player = player,
                    HeroClass = hc,
                    Level = 0,
                }));
        }
    }
}
