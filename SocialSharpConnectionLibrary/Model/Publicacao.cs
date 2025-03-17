using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace library.Model
{
    public abstract class Publicacao
    {
        public long Id { get; protected set; }
        public long IdUser { get; protected set; }
        public string Conteudo { get; protected set; }
        public DateTime Data { get; protected set; }

        protected Publicacao(long id, long idUser, string conteudo, DateTime data)
        {
            Id = id;
            IdUser = idUser;
            Conteudo = conteudo;
            Data = data;
        }

        public abstract void Exibir();
    }
}
