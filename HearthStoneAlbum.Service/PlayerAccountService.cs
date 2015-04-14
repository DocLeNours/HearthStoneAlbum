using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Dal;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Service {
    public class PlayerAccountService {
        private HearthStoneAlbumDbContext Context;
        public PlayerAccountService(HearthStoneAlbumDbContext context) {
            this.Context = context;
        }

        public async Task<int> CreateAccount(Player player) {
            await this.SetHeroClasses(player);
            int cardNumber = await this.SetFreeCards(player);
            this.Context.Players.Add(player);
            await this.Context.SaveChangesAsync();
            return cardNumber;
        }

        private async Task<int> SetFreeCards(Player player) {
            IEnumerable<Card> cards = await this.Context.Cards
                .Include(c => c.Rarity)
                .Where(c => c.CardSet.CardSetId == CardSet.BasicCardSetId)
                .Where(c => !this.Context.HeroClassRewards.Any(hcr => hcr.CardId == c.CardId && !hcr.Golden))
                .ToListAsync();
            this.Context.PlayerCards
                .AddRange(cards.Select(c => new PlayerCard {
                    Player = player,
                    Card = c,
                    Golden = false,
                    Number = c.Rarity.CopyNumber,
                }));
            return cards.Count();
        }
        private async Task SetHeroClasses(Player player) {
            IList<HeroClass> heroClasses = await this.Context.HeroClasses.ToListAsync();
            this.Context.PlayerHeroClasses
                .AddRange(heroClasses.Select(hc => new PlayerHeroClass {
                    Player = player,
                    HeroClass = hc,
                    Level = 0,
                }));
        }
    }
}
