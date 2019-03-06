using System;
using Microsoft.AspNetCore.Mvc;
using TableFootball.Models.Requests;
using TableFootball.Models.Responces;
using TableFootball.Services;

namespace TableFootball.Controllers
{
    [Route("api/[controller]")]
    public class PlayersController : Controller
    {
        private readonly PlayersService _playersService;

        public PlayersController()
        {
            _playersService = new PlayersService();
        }

        // GET: api/players
        [HttpGet]
        public PlayersResponce GetPlayers()
        {
            try
            {
                var players = _playersService.GetAllPlayers();
                return new PlayersResponce
                {
                    Players = players
                };
            }
            catch (Exception exception)
            {
                return new PlayersResponce(exception.Message);
            }
        }

        // POST: api/players
        [HttpPost]
        public BaseResponce UpdatePlayersRating([FromBody] GameResultsRequest request)
        {
            try
            {
                _playersService.UpdatePlayersPoints(request.Games);
                return new BaseResponce();
            }
            catch (Exception exception)
            {
                return new BaseResponce(exception.Message);
            }
        }

        // GET: api/players/clear
        [HttpGet, Route("clear")]
        public BaseResponce ClearPlayersPoints()
        {
            try
            {
                _playersService.ClearPlayersPoints();
                return new BaseResponce();
            }
            catch (Exception exception)
            {
                return new BaseResponce(exception.Message);
            }
        }

        // POST: api/players/add
        [HttpPost, Route("add")]
        public BaseResponce AddPlayers([FromBody] GameResultsRequest request)
        {
            try
            {
                _playersService.UpdatePlayersPoints(request.Games);
                return new BaseResponce();
            }
            catch (Exception exception)
            {
                return new BaseResponce(exception.Message);
            }
        }
    }
}
