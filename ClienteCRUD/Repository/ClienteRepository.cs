using ClienteCRUD.Data;
using ClienteCRUD.Models;
using ClienteCRUD.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace ClienteCRUD.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public void Delete(int clienteId)
        {
            var cliente = _context.Clientes.Find(clienteId);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Cliente> FindAll()
        {
            return _context.Clientes.Include(c => c.Endereco).ToList();
        }

        public Cliente FindById(int id)
        {
            return _context.Clientes.Include(c => c.Endereco).FirstOrDefault(c => c.Id == id);
        }

        public void Update(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            _context.SaveChanges();
        }
    }
}
