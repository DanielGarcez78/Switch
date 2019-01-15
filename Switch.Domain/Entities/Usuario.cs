using Switch.Domain.Enum;
using System;
using System.Collections.Generic;

namespace Switch.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public GeneroEnum Genero { get; set; }
        public string UrlFoto { get; set; }
        public int? ProcurandoPorId { get; set; }
        public int? StatusRelacionamentoId { get; set; }
        public virtual Identificacao Identificacao { get; set; }
        public virtual StatusRelacionamento StatusRelacionamento { get; set; }
        public virtual ProcurandoPor ProcurandoPor { get; set; }
        public virtual ICollection<Postagem> Postagens { get; set; }
        public virtual ICollection<Comentario> Comentarios { get; set; }
        public virtual ICollection<UsuarioGrupo> UsuarioGrupos { get; set; }
        public virtual ICollection<LocalTrabalho> LocaisTrabalho { get; set; }
        public virtual ICollection<InstituicaoEnsino> InstituicoesEnsino { get; set; }
        public virtual ICollection<Amigo> Amigos { get; set; }

        public Usuario()
        {
            Postagens = new List<Postagem>();
            Comentarios = new List<Comentario>();
            UsuarioGrupos = new List<UsuarioGrupo>();
            LocaisTrabalho = new List<LocalTrabalho>();
            InstituicoesEnsino = new List<InstituicaoEnsino>();
            Amigos = new List<Amigo>();
        }

    }
}
