using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using microservcursomestrado.Disciplina.Builder;
using microservcursomestrado.Disciplina.Entities;
using microservcursomestrado.Disciplina.Entities.Enum;

namespace microservcursomestrado.Disciplina.Builder
{
    public class NotaBuilder
    {
        private Guid _id;
        private TipoNota _tipo;
        private float _notaParcial;
        private float _peso;

        public NotaBuilder ComId(Guid id)
        {
            _id = id;
            return this;
        }

        public NotaBuilder ComTipo(int tipoValor)
        {
            if (Enum.IsDefined(typeof(TipoNota), tipoValor))
            {
                _tipo = (TipoNota)tipoValor;
            }
            else
            {
                throw new ArgumentException($"Valor inválido para TipoNota: {tipoValor}");
            }

            return this;
        }

        public NotaBuilder ComNotaParcial(float notaParcial)
        {
            _notaParcial = notaParcial;
            return this;
        }

        public NotaBuilder ComPeso(float peso)
        {
            _peso = peso;
            return this;
        }

        public Nota Build()
        {
            return new Nota
            {
                Id = _id,
                Tipo = _tipo,
                NotaParcial = _notaParcial,
                Peso = _peso
            };
        }
    }

}
