/**
  Autor: Dalton Solano dos Reis
**/

using OpenTK.Graphics.OpenGL;
using CG_Biblioteca;
using OpenTK;
using System.Collections.Generic;
using System.Linq;

namespace gcgcg
{
    internal class Retangulo : ObjetoGeometria
    {
        Dictionary<Ponto4D, Color> coresPontos = new Dictionary<Ponto4D, Color>();

        public Retangulo(string rotulo, Objeto paiRef, Ponto4D ptoInfEsq, Ponto4D ptoSupDir) : base(rotulo, paiRef)
        {
            base.PontosAdicionar(ptoInfEsq);
            base.PontosAdicionar(new Ponto4D(ptoSupDir.X, ptoInfEsq.Y));
            base.PontosAdicionar(ptoSupDir);
            base.PontosAdicionar(new Ponto4D(ptoInfEsq.X, ptoSupDir.Y));
        }

        protected override void DesenharObjeto()
        {
            GL.Begin(base.PrimitivaTipo);
            foreach (Ponto4D pto in pontosLista)
            {
                if (coresPontos.ContainsKey(pto))
                {
                    Color cor = coresPontos.Where(r => r.Key == pto).First().Value;
                    GL.Color3(cor);
                }
                GL.Vertex2(pto.X, pto.Y);
            }
            GL.End();
        }

        public void DefinirCorPonto(int numeroPonto, Color cor)
        {
            if(!coresPontos.ContainsKey(pontosLista[numeroPonto]))
                coresPontos.Add(pontosLista[numeroPonto], cor);
        }

        //TODO: melhorar para exibir não só a lsita de pontos (geometria), mas também a topologia ... poderia ser listado estilo OBJ da Wavefrom
        public override string ToString()
        {
            string retorno;
            retorno = "__ Objeto Retangulo: " + base.rotulo + "\n";
            for (var i = 0; i < pontosLista.Count; i++)
            {
                retorno += "P" + i + "[" + pontosLista[i].X + "," + pontosLista[i].Y + "," + pontosLista[i].Z + "," + pontosLista[i].W + "]" + "\n";
            }
            return (retorno);
        }

    }
}