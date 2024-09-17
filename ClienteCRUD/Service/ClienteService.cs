using ClienteCRUD.Models;
using ClienteCRUD.Repository.Interface;
using ClienteCRUD.Service.Interface;

namespace ClienteCRUD.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public void Add(Cliente cliente)
        {
            if (String.IsNullOrWhiteSpace(cliente.Nome)) throw new Exception("Nome do CLiente é obrigatório");

            _clienteRepository.Add(cliente);
        }

        public void Delete(int clienteId)
        {
            var cliente = _clienteRepository.FindById(clienteId);
            if (cliente == null)
                throw new Exception("Cliente não encontrado.");

            _clienteRepository.Delete(clienteId);
        }

        public IEnumerable<Cliente> FindAll()
        {
            return _clienteRepository.FindAll();
        }

        public Cliente FindById(int id)
        {
            return _clienteRepository.FindById(id);
        }

        public void Update(Cliente cliente)
        {
            if (cliente.Id == 0)
                throw new Exception("Cliente não encontrado.");

            _clienteRepository.Update(cliente);
        }
    }
}
