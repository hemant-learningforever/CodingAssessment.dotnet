using CardGame.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CardGame.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeckController : ControllerBase
    {
        private readonly IDeckService _deckService;

        public DeckController(IDeckService deckService)
        {
            _deckService = deckService;
        }

        [HttpGet("shuffle")]
        public IActionResult ShuffleDeck()
        {
            _deckService.ShuffleDeck();
            return Ok();
        }

        [HttpGet("draw")]
        public IActionResult DrawCard()
        {
            var card = _deckService.DrawCard();
            if (card == null)
                return NotFound("No cards left in the deck.");
            return Ok(card);
        }

        [HttpGet("reset")]
        public IActionResult ResetDeck()
        {
            _deckService.ResetDeck();
            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAllCards()
        {
            return Ok(_deckService.GetAllCards());
        }
    }
}
