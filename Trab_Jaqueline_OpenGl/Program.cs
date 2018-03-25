using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace Trab_Jaqueline_OpenGl
{
    
     class Program
    {
        #region Variaveis de configuração do centro do campo

        static float ponto , raio ,x, y;
        const float PI = 3.14159265358f;
        #endregion


        static void Main(string[] args)
        {

            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_SINGLE | Glut.GLUT_RGB);
            Glut.glutInitWindowSize(800, 400);
            Glut.glutInitWindowPosition(100, 100);
            Glut.glutCreateWindow("Copa do Mundo");
            inicialize();
            Glut.glutDisplayFunc(desenhar);
            Glut.glutMainLoop();
        }

        static void cenaCampo()
        {
            //Gramado
            Gl.glColor3f(0.0f, 0.5f,0.0f);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex2f(0f, 0f);
            Gl.glVertex2f(1f, 0f);
            Gl.glVertex2f(1f, 1f);
            Gl.glVertex2f(0f, 1f);
            Gl.glEnd();

            //Linhas
            Gl.glLineWidth(5);
            Gl.glColor3f(1f, 1f, 1f);
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2f(0.05f, 0.05f);
            Gl.glVertex2f(0.95f, 0.05f);
            Gl.glVertex2f(0.95f, 0.95f);
            Gl.glVertex2f(0.05f, 0.95f);
            Gl.glEnd();

            //linha central
            Gl.glLineWidth(5);
            Gl.glColor3f(1f, 1f, 1f);
            Gl.glBegin(Gl.GL_LINES);
            Gl.glVertex2f(0.5f, 0.05f);
            Gl.glVertex2f(0.5f, 0.95f);
            Gl.glEnd();

            //Ponto da linha central
            ponto = (2 * PI) / 500;
            raio = 0.02f;
            Gl.glColor3f(1f, 1f, 1f);
            Gl.glBegin(Gl.GL_TRIANGLE_FAN);
            for (float angulo = 0; angulo < (2*PI); angulo+=ponto)
            {
                x = (float)(raio * Math.Cos(angulo) + 0.5f);
                y = (float)(raio * Math.Sin(angulo) + 0.5f);
                Gl.glVertex2f(x, y);
            }
            Gl.glEnd();

            //Linha de contorno circular central
            ponto = (2 * PI) / 500;
            raio = 0.15f;
            Gl.glLineWidth(5);
            Gl.glColor3f(1f, 1f, 1f);
            Gl.glBegin(Gl.GL_LINE_LOOP);
            for (float angulo = 0; angulo < (2 * PI); angulo += ponto)
            {
                x = (float)(raio * Math.Cos(angulo) + 0.5f);
                y = (float)(raio * Math.Sin(angulo) + 0.5f);
                Gl.glVertex2f(x, y);
            }
            Gl.glEnd();

            //linhas da area do gol Esquerdo
            Gl.glLineWidth(5);
            Gl.glColor3f(1.0f, 1.0f, 1.0f);
            Gl.glBegin(Gl.GL_LINE_STRIP);
            Gl.glVertex2f(0.05f, 0.15f);
            Gl.glVertex2f(0.25f, 0.15f);
            Gl.glVertex2f(0.25f, 0.85f);
            Gl.glVertex2f(0.05f, 0.85f);
            Gl.glEnd();


            //linhas da area do gol direito
            Gl.glLineWidth(5);
            Gl.glColor3f(1.0f, 1.0f, 1.0f);
            Gl.glBegin(Gl.GL_LINE_STRIP);
            Gl.glVertex2f(0.95f, 0.15f);
            Gl.glVertex2f(0.75f, 0.15f);
            Gl.glVertex2f(0.75f, 0.85f);
            Gl.glVertex2f(0.95f, 0.85f);
            Gl.glEnd();

            //Linha do gol esquerda
            Gl.glLineWidth(5);
            Gl.glColor3f(1.0f, 1.0f, 1.0f);
            Gl.glBegin(Gl.GL_LINE_STRIP);
            Gl.glVertex2f(0.05f, 0.25f);
            Gl.glVertex2f(0.15f, 0.25f);
            Gl.glVertex2f(0.15f, 0.75f);
            Gl.glVertex2f(0.05f, 0.75f);
            Gl.glEnd();


            //Linha do gol direita
            Gl.glLineWidth(5);
            Gl.glColor3f(1.0f, 1.0f, 1.0f);
            Gl.glBegin(Gl.GL_LINE_STRIP);
            Gl.glVertex2f(0.95f, 0.25f);
            Gl.glVertex2f(0.85f, 0.25f);
            Gl.glVertex2f(0.85f, 0.75f);
            Gl.glVertex2f(0.95f, 0.75f);
            Gl.glEnd();

            //Gol esquerdo
            Gl.glLineWidth(15);
            Gl.glColor3f(1.0f, 0.0f, 1.0f);
            Gl.glBegin(Gl.GL_LINES);
            Gl.glVertex2f(0.05f, 0.35f);
            Gl.glVertex2f(0.05f,0.65f);
            Gl.glEnd();

            //Gol direito
            Gl.glLineWidth(15);
            Gl.glColor3f(1.0f, 0.0f, 1.0f);
            Gl.glBegin(Gl.GL_LINES);
            Gl.glVertex2f(0.95f, 0.35f);
            Gl.glVertex2f(0.95f, 0.65f);
            Gl.glEnd();


        }

        static void inicialize()
        {
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Glu.gluOrtho2D(0.0f, 1.0f, 0.0f, 1.0f);

            Gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);

        }

        static void jogador( float tx, float ty)
        {
            
            //corpo
            Gl.glColor3f(0f, 0.0f, 0f);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex2f(tx, ty);
            Gl.glVertex2f((tx + 0.05f), ty);
            Gl.glVertex2f((tx + 0.05f), (ty + 0.025f));
            Gl.glVertex2f(tx, (ty + 0.025f));
            Gl.glEnd();

            //

            float auxX,auxY;
            auxX= tx + ((tx+0.05f)-tx)/ 2;
            auxY = (ty + 0.055f);
            ponto = (2 * PI) / 500;
            raio = 0.033f;
            Gl.glColor3f(1f, 0f, 0f);
            Gl.glBegin(Gl.GL_TRIANGLE_FAN);
            Gl.glVertex2f(auxX, auxY);
            for (float angulo = 0; angulo < (2 * PI); angulo += ponto)
            {
                x = (float)(raio * Math.Cos(angulo) + auxX);
                y = (float)(raio * Math.Sin(angulo) + auxY);
                Gl.glVertex2f(x, y);
            }
            Gl.glEnd();
        }

        static void desenhar()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            cenaCampo();
            Glut.glutSwapBuffers();
        }

        static void desenharJogadores(int quantidade)
        {
            
            int cont = 0;
            float x, y;
            Random randon = new Random();
            do
            {

                x = (float)randon.NextDouble(0.07f,0.87f);

                y = (float)randon.NextDouble(0.07f, 0.87f);

                jogador(x, y);
                cont++;
            } while (cont<=quantidade);
        }

       
    }

    #region ClasseNumeroRandomicoFloat

    public static class RandomExtensions
    {
        public static double NextDouble(
            this Random random,
            double minValue,
            double maxValue)
        {
            return random.NextDouble() * (maxValue - minValue) + minValue;
        }
    }
    #endregion
}
