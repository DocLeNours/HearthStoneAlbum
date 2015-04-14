using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using HearthStoneAlbum.Domain;
using HearthStoneAlbum.Interface;

namespace HearthStoneAlbum.WebApi.Controllers {
    [RoutePrefix("api/PlayerAccount")]
    public class PlayerAccountController : ApiController {
        IPlayerAccountService playerAccountService;
        public PlayerAccountController(IPlayerAccountService service) {
            this.playerAccountService = service;
        }

        // GET: api/PlayerAccount
        public async Task<IHttpActionResult> Get() {
            Player player = new Player();
            await this.playerAccountService.CreateAccount(player);
            return Ok(new {
                Id = player.PlayerId,
                HeroClasses = player.PlayerHeroClasses
                    .Select(phc => new { 
                        HeroClass = phc.HeroClass.HeroClassLanguages.First().Name,
                        Level = phc.Level,
                }),
                Cards = player.PlayerCards
                    .Select(pc => new {
                        CardId = pc.Card.CardLanguages.First().Name,
                        Golden = pc.Golden,
                        Number = pc.Number,
                }),
            });
        }

        // GET: api/PlayerAccount/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/PlayerAccount
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/PlayerAccount/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/PlayerAccount/5
        //public void Delete(int id)
        //{
        //}
    }
}
