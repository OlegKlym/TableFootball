using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TableFootball.Models;
using TableFootball.Models.Responces;
using TableFootball.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TableFootball.Controllers
{
    [Route("api/[controller]")]
    public class GamesController : Controller
    {
        private readonly PlayersService _playersService;

        public GamesController()
        {
            _playersService = new PlayersService();
        }

        // GET: api/games
        [HttpGet]
        public GameResultsResponce GetTotalResults()
        {
            try
            {
                //_playersService.UpdatePlayersPoints(request.Games);
                return new GameResultsResponce();
            }
            catch (Exception exception)
            {
                return new GameResultsResponce(exception.Message);
            }
        }

        // GET api/games/25-08-19
        //[HttpGet("{game/datetime}")]
        //public GameResultsResponce GetDayResults(DateTime date)
        //{
        //    try
        //    {
        //        //_playersService.UpdatePlayersPoints(request.Games);
        //        return new GameResultsResponce();
        //    }
        //    catch (Exception exception)
        //    {
        //        return new GameResultsResponce(exception.Message);
        //    }
        //}

        // GET api/game/25-08-19/31-08-19
        [HttpGet, Route("game/{start:datetime}/{end:datetime}")]
        public GameResultsResponce GetWeekResults(DateTime start, DateTime end)
        {
            try
            {
                //_playersService.UpdatePlayersPoints(request.Games);
                return new GameResultsResponce();
            }
            catch (Exception exception)
            {
                return new GameResultsResponce(exception.Message);
            }
        }
    }
}
