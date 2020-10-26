using OpenTK.Graphics.OpenGL;
using CG_Biblioteca;

namespace gcgcg
{

    internal class Circulo : ObjetoGeometria
    {
        Ponto4D PontoCentral { get; set; }
        int RaioCirculo { get; set; }
        int Pontos { get; set; }

        public Circulo(string rotulo, Objeto paiRef, Ponto4D pontoCentral, int raioCirculo, int qtdPontos = 72, PrimitiveType primitivo = PrimitiveType.Points) : base(rotulo, paiRef)
        {
            base.PrimitivaTipo = primitivo;
            PontoCentral = pontoCentral;
            RaioCirculo = raioCirculo;
            Pontos = qtdPontos;
            GerarPontos(pontoCentral, raioCirculo, qtdPontos);
        }

        private void GerarPontos(Ponto4D pontoCentral, int raioCirculo, int qtdPontos)
        {
            base.PontosRemoverTodos();
            for (int i = 0; i < qtdPontos; i++)
            {
                var angulo = (qtdPontos == 72 ? i * 5 : i / 2);
                Ponto4D pontoCirculo = Matematica.GerarPtosCirculo(angulo, raioCirculo);
                Ponto4D pontoFinal = new Ponto4D(pontoCirculo.X + pontoCentral.X, pontoCirculo.Y + pontoCentral.Y, 0);
                base.PontosAdicionar(pontoFinal);
            }
        }

        protected override void DesenharObjeto()
        {
            GerarPontos(PontoCentral, RaioCirculo, Pontos);
            GL.Begin(base.PrimitivaTipo);
            foreach (Ponto4D pto in pontosLista)
            {
                GL.Vertex2(pto.X, pto.Y);
            }
            GL.End();
        }

    }

}