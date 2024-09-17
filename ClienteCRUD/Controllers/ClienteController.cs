using ClienteCRUD.Data;
using ClienteCRUD.Models;
using ClienteCRUD.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteCRUD.Controllers
{
    public class ClienteController : Controller
    {
        private readonly AppDbContext _context;

        public ClienteController(AppDbContext context)
        {
            _context = context;
        }

        // Exibe a página principal com a lista de clientes
        public IActionResult Index()
        {
            var clientes = _context.Clientes.Include(c => c.Endereco).ToList();
            return View("GerenciarClientes", clientes);
        }

        // Exibe a página para criar um novo cliente
        public IActionResult Create()
        {
            ViewBag.TipoEndereco = Enum.GetValues(typeof(TipoEndereco)).Cast<TipoEndereco>().ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // Exibe a página para editar um cliente existente
        public IActionResult Edit(int id)
        {
            var cliente = _context.Clientes.Include(c => c.Endereco).FirstOrDefault(c => c.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            ViewBag.TipoEndereco = Enum.GetValues(typeof(TipoEndereco)).Cast<TipoEndereco>().ToList();
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Update(cliente);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // Exclui um cliente
        public IActionResult Delete(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // Método para listar clientes para o DataGrid
        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            var clientes = await _context.Clientes.Include(c => c.Endereco).ToListAsync();
            return Json(new { data = clientes });
        }

        // Método para criar um cliente através do DataGrid
        public async Task<IActionResult> CreateCliente([FromBody] Cliente cliente)
        {
            try
            {
                if (cliente == null || cliente.Endereco == null)
                {
                    return BadRequest("Dados inválidos.");
                }

                // Cria uma nova instância de Endereco, se necessário
                if (cliente.Endereco != null)
                {
                    _context.Entry(cliente.Endereco).State = EntityState.Added;
                }

                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao criar o cliente: " + ex.Message);
                return StatusCode(500, "Erro interno do servidor.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCliente([FromBody] Cliente cliente)
        {
            try
            {
                if (cliente == null || cliente.Id <= 0)
                {
                    return BadRequest("Dados inválidos.");
                }

                var existingCliente = await _context.Clientes
                    .Include(c => c.Endereco)
                    .FirstOrDefaultAsync(c => c.Id == cliente.Id);

                if (existingCliente == null)
                {
                    return NotFound();
                }

                
                if (!string.IsNullOrEmpty(cliente.Nome))
                {
                    existingCliente.Nome = cliente.Nome;
                }
                if (!string.IsNullOrEmpty(cliente.Email))
                {
                    existingCliente.Email = cliente.Email;
                }

                
                if (cliente.Endereco != null)
                {
                    if (existingCliente.Endereco == null)
                    {
                        existingCliente.Endereco = new Endereco();
                    }

                    if (!string.IsNullOrEmpty(cliente.Endereco.Rua))
                    {
                        existingCliente.Endereco.Rua = cliente.Endereco.Rua;
                    }
                    if (!string.IsNullOrEmpty(cliente.Endereco.Cidade))
                    {
                        existingCliente.Endereco.Cidade = cliente.Endereco.Cidade;
                    }
                    if (!string.IsNullOrEmpty(cliente.Endereco.Estado))
                    {
                        existingCliente.Endereco.Estado = cliente.Endereco.Estado;
                    }
                    if (!string.IsNullOrEmpty(cliente.Endereco.CEP))
                    {
                        existingCliente.Endereco.CEP = cliente.Endereco.CEP;
                    }
                    existingCliente.Endereco.Tipo = cliente.Endereco.Tipo; 
                }

                _context.Clientes.Update(existingCliente);
                await _context.SaveChangesAsync();

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao atualizar o cliente: " + ex.Message);
                return StatusCode(500, "Erro interno do servidor.");
            }
        }



        [HttpDelete]
        public async Task<IActionResult> DeleteCliente([FromBody] Cliente cliente)
        {
            try
            {
                if (cliente == null || cliente.Id <= 0)
                {
                    return BadRequest("Dados inválidos.");
                }

                var existingCliente = await _context.Clientes.FindAsync(cliente.Id);
                if (existingCliente == null)
                {
                    return NotFound();
                }

                _context.Clientes.Remove(existingCliente);
                await _context.SaveChangesAsync();

                // Resposta JSON simples indicando sucesso
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                // Em caso de erro, loga e retorna um erro interno
                Console.WriteLine("Erro ao remover o cliente: " + ex.Message);
                return StatusCode(500, "Erro interno do servidor.");
            }
        }

        public async Task<IActionResult> GerenciarClientes()
        {
            var clientes = await _context.Clientes.Include(c => c.Endereco).ToListAsync();
            return View(clientes);
        }
    }
}
