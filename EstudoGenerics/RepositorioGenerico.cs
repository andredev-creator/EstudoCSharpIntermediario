using System;
using System.Collections.Generic;
using System.Text;

namespace EstudoGenerics
{
    public class RepositorioGenerico<TTipo>
    {

        private List<TTipo> list;

        public RepositorioGenerico()
        {
            list = new List<TTipo>();
        }

        public List<TTipo> Get()
        {
            return list;
        }

        public void Insert(TTipo meuObjeto)
        {
            list.Add(meuObjeto);
        }
    }
}
