﻿using ClienteCRUD.Models.Enums;

namespace ClienteCRUD.Models
{
    public class Endereco
    {
        public int Id { get; set; }
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public TipoEndereco Tipo { get; set; }
    }
}
