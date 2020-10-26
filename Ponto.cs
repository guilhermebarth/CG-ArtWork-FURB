using CG_Biblioteca;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Text;

namespace gcgcg
{
    internal class Ponto : ObjetoGeometria
    {
        public Ponto4D ponto { get; set; }
        public Color cor { private get; set; }
        

        public Ponto(string rotulo, Objeto paiRef, Ponto4D ponto, int tamanho = 15) : base(rotulo, paiRef)
        {
            PrimitivaTamanho = tamanho;
            base.PrimitivaTipo = PrimitiveType.Points;
            base.PontosAdicionar(ponto);
            this.ponto = ponto;
            cor = Color.Black;
        }

        protected override void DesenharObjeto()
        {
            GL.Begin(PrimitiveType.Points);
            GL.Color3(cor);
            GL.Vertex2(pontosLista[0].X, pontosLista[0].Y);
            GL.End();
        }
    }
}
