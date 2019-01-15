﻿using Switch.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Switch.Domain.Entities
{
    public class ProcurandoPor
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public bool NaoEspecificado { get { return Id == (int)ProcurandoPorEnum.NaoEspecificado; } }
        public bool Namoro { get { return Id == (int)ProcurandoPorEnum.Namoro; } }
        public bool Amizade { get { return Id == (int)ProcurandoPorEnum.Amizade; } }
        public bool RelacionamentoSerio { get { return Id == (int)ProcurandoPorEnum.RelacionamentoSerio; } }
        public bool ApenasSexo { get { return Id == (int)ProcurandoPorEnum.ApenasSexo; } }

        public virtual ICollection<Usuario> Usuarios { get; set; }

    }
}
