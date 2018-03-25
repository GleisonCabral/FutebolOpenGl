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
        static float ponto, raio, x, y;     // Variaveis do valor de ponto, raio e posição.@@
        const float PI = 3.14159265358f;    // Variavel valor do PI, para as circunferências.@@
        static float[] Novacor;             // Vetor para nova cor.@@
        static float gbPosy = 0.0f;         // Posição do goleiro do Brasil.@@
        static float gaPosy = 0.0f;         // Posição do goleiro da Alemanha.@@
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
            Glut.glutSpecialFunc(moverGoleiroBrasil);
            Glut.glutKeyboardFunc(new Glut.KeyboardCallback(moverGoleiroAlemanha));
            Glut.glutMainLoop();
        }

        static void cenaCampo()
        {
            //Gramado
            Gl.glColor3f(0.0f, 0.5f, 0.0f);
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
            for (float angulo = 0; angulo < (2 * PI); angulo += ponto)
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
            Gl.glVertex2f(0.05f, 0.65f);
            Gl.glEnd();
            
            ////Jogadores da Alemanha
            //Novacor = new float[3] { 0.87f, 0f, 0f };
            //Jogadores(2, Novacor, 0.06f, 0.75f);

            ////Jogadores do Brasil
            //Novacor = new float[3] { 1f, 0.87f, 0f };
            //Jogadores(2, Novacor, 0.25f, 0.87f);

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

        static void desenhar()
        {
            
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            cenaCampo();
            Novacor = new float[3] { 0.87f, 0f, 0f };
            goleiroAlemanha(Novacor);
            Novacor = new float[3] { 1f, 0.87f, 0f };
            goleiroBrasil(Novacor);
            Glut.glutSwapBuffers();
        }

        static void jogador(float tx, float ty, float[] cor)
        {
           
            //corpo
            Gl.glColor3f(0f, 0.0f, 0f);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex2f(tx, ty);
            Gl.glVertex2f((tx + 0.05f), ty);
            Gl.glVertex2f((tx + 0.05f), (ty + 0.025f));
            Gl.glVertex2f(tx, (ty + 0.025f));
            Gl.glEnd();

            //Cabeça

            float auxX, auxY;
            auxX = tx + ((tx + 0.05f) - tx) / 2;
            auxY = (ty + 0.055f);
            ponto = (2 * PI) / 500;
            raio = 0.033f;
            Gl.glColor3f(cor[0], cor[1], cor[2]);
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

        static void goleiroAlemanha(float[] cor)
        {
            const float tx = 0.03f;
            const float ty = 0.45f;
            Gl.glPushMatrix();
            Gl.glTranslatef(tx, gaPosy, 0);

            //corpo
            Gl.glColor3f(0f, 0.0f, 0f);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex2f(tx, ty);
            Gl.glVertex2f((tx + 0.05f), ty);
            Gl.glVertex2f((tx + 0.05f), (ty + 0.025f));
            Gl.glVertex2f(tx, (ty + 0.025f));
            Gl.glEnd();

            //Cabeça

            float auxX, auxY;
            auxX = tx + ((tx + 0.05f) - tx) / 2;
            auxY = (ty + 0.055f);
            ponto = (2 * PI) / 500;
            raio = 0.033f;
            Gl.glColor3f(cor[0], cor[1], cor[2]);
            Gl.glBegin(Gl.GL_TRIANGLE_FAN);
            Gl.glVertex2f(auxX, auxY);
            for (float angulo = 0; angulo < (2 * PI); angulo += ponto)
            {
                x = (float)(raio * Math.Cos(angulo) + auxX);
                y = (float)(raio * Math.Sin(angulo) + auxY);
                Gl.glVertex2f(x, y);
            }
            Gl.glEnd();
            Gl.glPopMatrix();
        }

        static void goleiroBrasil(float[] cor)
        {
            const float tx = 0.44f;
            const float ty = 0.45f;
            Gl.glPushMatrix();
            Gl.glTranslatef(tx, gbPosy, 0);

            //corpo
            Gl.glColor3f(0f, 0.0f, 0f);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex2f(tx, ty);
            Gl.glVertex2f((tx + 0.05f), ty);
            Gl.glVertex2f((tx + 0.05f), (ty + 0.025f));
            Gl.glVertex2f(tx, (ty + 0.025f));
            Gl.glEnd();

            //Cabeça
            float auxX, auxY;
            auxX = tx + ((tx + 0.05f) - tx) / 2;
            auxY = (ty + 0.055f);
            ponto = (2 * PI) / 500;
            raio = 0.033f;
            Gl.glColor3f(cor[0], cor[1], cor[2]);
            Gl.glBegin(Gl.GL_TRIANGLE_FAN);
            Gl.glVertex2f(auxX, auxY);
            for (float angulo = 0; angulo < (2 * PI); angulo += ponto)
            {
                x = (float)(raio * Math.Cos(angulo) + auxX);
                y = (float)(raio * Math.Sin(angulo) + auxY);
                Gl.glVertex2f(x, y);
            }
            Gl.glEnd();
            Gl.glPopMatrix();
        }

        static void Jogadores(int quantidade, float[] cor, float valueMin, float valueMax)
        {

            int cont = 0;
            float tx, ty;
            Random randon = new Random();
            do
            {
                tx = (float)randon.NextDouble(valueMin, valueMax);
                ty = (float)randon.NextDouble(0.07f, 0.87f);
                jogador(tx, ty, cor);
                cont++;
            } while (cont <= quantidade);
        }

        //static void bola()
        //{
        //    float auxX, auxY;
        //    auxX = tx + ((tx + 0.05f) - tx) / 2;
        //    auxY = (ty + 0.055f);
        //    ponto = (2 * PI) / 500;
        //    raio = 0.033f;
        //    Gl.glColor3f(cor[0], cor[1], cor[2]);
        //    Gl.glBegin(Gl.GL_TRIANGLE_FAN);
        //    Gl.glVertex2f(auxX, auxY);
        //    for (float angulo = 0; angulo < (2 * PI); angulo += ponto)
        //    {
        //        x = (float)(raio * Math.Cos(angulo) + auxX);
        //        y = (float)(raio * Math.Sin(angulo) + auxY);
        //        Gl.glVertex2f(x, y);
        //    }
        //    Gl.glEnd();
        //}

        static void moverGoleiroBrasil(int key, int x, int y)
        {
            // if(key == GLUT_KEY_UP)      { }
            // if(key == GLUT_KEY_DOWN)    { }
            if (key == Glut.GLUT_KEY_DOWN) { gbPosy -= 0.03f; }
            if (key == Glut.GLUT_KEY_UP) { gbPosy += 0.03f; }
            Glut.glutPostRedisplay();
        }

        static void moverGoleiroAlemanha(byte key, int x, int y)
        {

            if (key == 119) { gaPosy += 0.03f; }  //Tecla 0 
            if (key == 115) { gaPosy -= 0.03f; }  //Tecla 1 
             
            Glut.glutPostRedisplay();
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
