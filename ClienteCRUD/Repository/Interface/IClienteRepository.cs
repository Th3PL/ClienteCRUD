using ClienteCRUD.Models;

namespace ClienteCRUD.Repository.Interface
{
    public interface IClienteRepository
    {
        void Add(Cliente cliente);
        void Update(Cliente cliente);
        void Delete(int clienteId);
        Cliente FindById(int id);
        IEnumerable<Cliente> FindAll();
    }
}
