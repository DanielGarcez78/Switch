﻿using Switch.Domain.Enum;
using System;

namespace Switch.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; private set; }

        public string Nome { get; set; }

        public string SobreNome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public DateTime DataNascimento { get; set; }

        public GeneroEnum Genero { get; set; }

        public string UrlFoto { get; set; }
    }
}