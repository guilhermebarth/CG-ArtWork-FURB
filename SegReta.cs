using OpenTK.Graphics.OpenGL;
using CG_Biblioteca;
using OpenTK;
using System.Collections.Generic;

namespace gcgcg
{

    internal class SegReta : ObjetoGeometria
    {
        private Ponto4D ponto1;
        private Ponto4D ponto2;

        Dictionary<Ponto4D, Color> coresPontos = new Dictionary<Ponto4D, Color>();

        public Ponto4D Ponto1
        {
            get { return ponto1; }
            set
            {
                pontosLista[0] = value;
                ponto1 = value;
            }
        }
        public Ponto4D Ponto2
        {
            get { return ponto2; }
            set
            {
                pontosLista[1] = value;
                ponto2 = value;
            }
        }

        public SegReta(string rotulo, Objeto paiRef, Ponto4D ponto1, Ponto4D ponto2) : base(rotulo, paiRef)
        {
            base.PrimitivaTipo = PrimitiveType.Lines;

            base.PontosAdicionar(ponto1);
            base.PontosAdicionar(ponto2);

            Ponto1 = ponto1;
            Ponto2 = ponto2;
        }

        public void DefinirCorPonto(int numeroPonto, Color cor)
        {
            if (!coresPontos.ContainsKey(pontosLista[numeroPonto]))
                coresPontos.Add(pontosLista[numeroPonto], cor);
        }

        protected override void DesenharObjeto()
        {
            GL.Begin(base.PrimitivaTipo);
            foreach (Ponto4D pto in pontosLista)
                GL.Vertex2(pto.X, pto.Y);
            GL.End();
        }

    }

}