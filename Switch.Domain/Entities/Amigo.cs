﻿namespace Switch.Domain.Entities
{
    public class Amigo
    {
        public int UsuarioId { get; set; }
        public int UsuarioAmigoId { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Usuario UsuarioAmigo { get; set; }
    }
}
