using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGamer.Model
{
    class FormataQuantidade
    {
        public FormataQuantidade()
        {

        }

        public string converterCampo(int campo, int quantidadeTotal)
        {
            string campoRecebido = campo.ToString();
            string campoConvertido = campoRecebido += " / " + quantidadeTotal;
            return campoConvertido;
        }
    }
}
