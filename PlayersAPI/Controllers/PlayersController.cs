using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlayersAPI.Context;
using PlayersAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly PlayerContext _context;

        public PlayersController(PlayerContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Obter todos os Jogadores
        /// </summary>
        /// <response code="200">A lista de jogadores foi obtida com sucesso.</response>
        /// <response code="500">Ocorreu um erro ao obter a lista de jogadores.</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayer()
        {

            return await _context.Player.ToListAsync();
        }

        /// <summary>
        /// Obter um Jogador pelo ID
        /// </summary>
        /// <param name="id">ID do Jogador.</param>
        /// <response code="200">O Jogador foi obtido com sucesso.</response>
        /// <response code="404">Não foi encontrado Jogador com ID especificado.</response>
        /// <response code="500">Ocorreu um erro ao obter o Jogador.</response>

        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetPlayer(int id)
        {
            var player = await _context.Player.FindAsync(id);

            if (player == null)
            {
                return NotFound();
            }

            return player;
        }

        /// <summary>
        /// Obtem os X Jogadores com maior pontuação
        /// </summary>
        /// <param name="max">maximo de jogadores a serem retornados.</param>
        /// <response code="200">A lista de jogadores foi obtida com sucesso.</response>
        /// <response code="500">Ocorreu um erro ao obter a lista de jogadores.</response>
        [HttpGet(), Route("TOP/{max}")]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayerTop(int max)
        {
            //  var player await _context.Player.ToListAsync();

            var player = await _context.Player.ToListAsync();

            return player.OrderByDescending(m => m.Score).Take(max).ToList();
        }

        /// <summary>
        /// Alterar Jogador.
        /// </summary> 
        /// <param name="id">ID do Jogador.</param>
        /// <response code="200">O Jogador foi alterado com sucesso.</response>
        /// <response code="400">O modelo do Jogador enviado é inválido.</response>
        /// <response code="404">Não foi encontrado Jogador com ID especificado.</response>
        /// <response code="500">Ocorreu um erro ao alterar o Jogador.</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayer(int id, Player player)
        {
            if (id != player.Id)
            {
                return BadRequest();
            }

            _context.Entry(player).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Criar um novo Jogador
        /// </summary>
        /// <response code="200">O Jogador foi criado com sucesso.</response>
        /// <response code="400">O modelo do jogador enviado é inválido.</response>
        /// <response code="500">Ocorreu um erro ao cadastrar o Jogador.</response>
        [HttpPost]
        public async Task<ActionResult<Player>> PostPlayer(Player player)
        {
            _context.Player.Add(player);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlayer", new { id = player.Id }, player);
        }

        /// <summary>
        /// Deletar Jogador cadastrado.
        /// </summary>
        /// <param name="id">ID do Jogador.</param>
        /// <response code="200">O Jogador foi deletado com sucesso.</response>
        /// <response code="404">Não foi encontrado Jogador com ID especificado.</response>
        /// <response code="500">Ocorreu um erro ao deletar o Jogador.</response>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Player>> DeletePlayer(int id)
        {
            var player = await _context.Player.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            _context.Player.Remove(player);
            await _context.SaveChangesAsync();

            return player;
        }

        private bool PlayerExists(int id)
        {
            return _context.Player.Any(e => e.Id == id);
        }
    }
}
