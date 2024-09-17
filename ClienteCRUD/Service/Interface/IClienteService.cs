using ClienteCRUD.Models;

namespace ClienteCRUD.Service.Interface
{
    public interface IClienteService
    {
        void Add(Cliente cliente);
        void Update(Cliente cliente);
        void Delete(int clienteId);
        Cliente FindById(int id);
        IEnumerable<Cliente> FindAll();

    }
}
