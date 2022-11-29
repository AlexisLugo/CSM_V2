using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSM_V2
{
    public partial class Form1 : Form
    {

        private int indice; //indice para el slay de imagenes en el label.
        //public CreateFolder create = new CreateFolder(); //estas son los objetos creados
        //public FurtherDetails details = new FurtherDetails(); // para su respectiva ventana
        public Scrap scrap = new Scrap();                   // segun su funcion.
        public Administrator Admin = new Administrator();
        public Inventory inventory = new Inventory();
        public LastQC last = new LastQC();
        public Form1()
        {
            InitializeComponent();
            indice = 0; // inicializamos la variable indice en el constructor.
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void labelFoto_Click(object sender, EventArgs e)
        {
            indice++; //incremento del indice.

            if (indice > 7) // si el indice es mayor a 7
                indice = 0;  // vuelveme a reiniciar mi indice a 0 para poder estar dando vueltas.

            labelFoto.ImageIndex = indice; // igualamos el indice segun la foto que estamos viendo en el label.

            if (labelFoto.ImageIndex == 0) //esta funcion se asegura de que
            {
                textBox1.Visible = true; //si aparesca el cuadro de texto si esta en el indice 0 o igual a la imagen 1, ya que el indice comienza desde el 0 para el if.
                button1.Visible = false; // y escondeme los botones 1
                button2.Visible = false; // dos y 
                button3.Visible = false; // 3
                button4.Visible = false;  //y 4 = abrir app de administrator
            }

            if (labelFoto.ImageIndex == 1)
            {
                textBox1.Visible = true;
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
            }

            if (labelFoto.ImageIndex == 2)
            {
                textBox1.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = true;
            }

            if (labelFoto.ImageIndex == 3)
            {
                textBox1.Visible = true;
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
            }

            if (labelFoto.ImageIndex == 4) //si esta en el indice 4 
            {
                textBox1.Visible = false; // ocultame el cuadro de texto
                button1.Visible = true; //muestrame el boton 1 para la funcion de scrap
                button2.Visible = false; //y olcultame el boton 2 y 
                button3.Visible = false; //3
                button4.Visible = false;
            }

            if (labelFoto.ImageIndex == 5)
            {
                textBox1.Visible = false;
                button1.Visible = false;
                button2.Visible = true;
                button4.Visible = false;
            }

            if (labelFoto.ImageIndex == 6)
            {
                textBox1.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = true;
                button4.Visible = false;
            }
        }

        #region Si algo tiene el cuadro de texto te redirige a su ventana //
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (labelFoto.ImageIndex == 0)
            {
                textBox1.Visible = true;
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;

                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    if (e.KeyChar == Convert.ToChar(Keys.Enter))
                    {
                        //details
                        Details detail = new Details();
                        detail.ShowDialog();
                    }
                }
            }

            if (labelFoto.ImageIndex == 1)
            {
                textBox1.Visible = true;
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;

                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    if (e.KeyChar == Convert.ToChar(Keys.Enter))
                    {
                        NewFolder create = new NewFolder(textBox1.Text);
                        create.ShowDialog();
                    }
                }
            }

            if (labelFoto.ImageIndex == 2)
            {
                textBox1.Visible = true;
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;

                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    if (e.KeyChar == Convert.ToChar(Keys.Enter))
                    {
                        Admin.ShowDialog();
                    }
                }
            }

            if (labelFoto.ImageIndex == 3)
            {
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    if (e.KeyChar == Convert.ToChar(Keys.Enter))
                    {
                        //Details
                        Details detail = new Details();
                        detail.ShowDialog();
                    }
                }
            }

            /*if (labelFoto.ImageIndex == 4)
            {
                textBox1.Visible = false;
                button1.Visible = true;
                button1.Text = "Open scrap window";
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    
                    if (e.KeyChar == Convert.ToChar(Keys.Enter))
                    {
                        scrap.ShowDialog();
                    }
                }
            }
        

            if (labelFoto.ImageIndex == 5)
            {
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    if (e.KeyChar == Convert.ToChar(Keys.Enter))
                    {
                        inventory.ShowDialog();
                    }
                }
            }

            if (labelFoto.ImageIndex == 6)
            {
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    if (e.KeyChar == Convert.ToChar(Keys.Enter))
                    {
                        last.ShowDialog();
                    }
                }
            }*/
        }
        #endregion

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            
        }

        private void newFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewFolder create = new NewFolder(textBox1.Text);
            create.ShowDialog();  // viene del menustrip del Design para los atajos de teclado.
        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inventory.ShowDialog();
        }

        private void scrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scrap.ShowDialog();
        }

        private void administratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin.ShowDialog();
        }

        private void lastQCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            last.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Admin.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            last.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            inventory.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            scrap.ShowDialog();
        }

        private void furtherDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Details detail = new Details();
            detail.ShowDialog();
        }
    }
}

/*private int indice; //indice para el slay de imagenes en el label.
        //public CreateFolder create = new CreateFolder(); //estas son los objetos creados
        //public FurtherDetails details = new FurtherDetails(); // para su respectiva ventana
        public Scrap scrap = new Scrap();                   // segun su funcion.
        public Administrator Admin = new Administrator();
        public Inventory inventory = new Inventory();
        public LastQC last = new LastQC();

        public Main()
        {
            InitializeComponent();
            indice = 0; // inicializamos la variable indice en el constructor.
        }
        private void Main_Load(object sender, EventArgs e)
        {
            
        }

        private void labelFoto_Click(object sender, EventArgs e)
        {
            indice++; //incremento del indice.

            if (indice > 7) // si el indice es mayor a 7
                indice = 0;  // vuelveme a reiniciar mi indice a 0 para poder estar dando vueltas.

            labelFoto.ImageIndex = indice; // igualamos el indice segun la foto que estamos viendo en el label.

            if (labelFoto.ImageIndex == 0) //esta funcion se asegura de que
            {
                textBox1.Visible = true; //si aparesca el cuadro de texto si esta en el indice 0 o igual a la imagen 1, ya que el indice comienza desde el 0 para el if.
                button1.Visible = false; // y escondeme los botones 1
                button2.Visible = false; // dos y 
                button3.Visible = false; // 3
                button4.Visible = false;  //y 4 = abrir app de administrator
            }

            if (labelFoto.ImageIndex == 1)
            {
                textBox1.Visible = true;
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
            }

            if (labelFoto.ImageIndex == 2)
            {
                textBox1.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = true;
            }

            if (labelFoto.ImageIndex == 3)
            {
                textBox1.Visible = true;
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
            }

            if (labelFoto.ImageIndex == 4) //si esta en el indice 4 
            {
                textBox1.Visible = false; // ocultame el cuadro de texto
                button1.Visible = true; //muestrame el boton 1 para la funcion de scrap
                button2.Visible = false; //y olcultame el boton 2 y 
                button3.Visible = false; //3
                button4.Visible = false;
            }

            if (labelFoto.ImageIndex == 5)
            {
                textBox1.Visible = false;
                button1.Visible = false;
                button2.Visible = true;
                button4.Visible = false;                
            }

            if (labelFoto.ImageIndex == 6)
            {
                textBox1.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = true;
                button4.Visible = false;
            }
        }
        #region Si algo tiene el cuadro de texto te redirige a su ventana //
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (labelFoto.ImageIndex == 0)
            {
                textBox1.Visible = true;
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;

                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    if (e.KeyChar == Convert.ToChar(Keys.Enter))
                    {
                        //details
                    }
                }
            }

            if (labelFoto.ImageIndex == 1)
            {
                textBox1.Visible = true;
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;

                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    if (e.KeyChar == Convert.ToChar(Keys.Enter))
                    {
                        CreateFolder create = new CreateFolder(textBox1.Text);
                        create.ShowDialog();
                    }
                }
            }

            if (labelFoto.ImageIndex == 2)
            {
                textBox1.Visible = true;
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;

                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    if (e.KeyChar == Convert.ToChar(Keys.Enter))
                    {
                        Admin.ShowDialog();
                    }
                }
            }

            if (labelFoto.ImageIndex == 3)
            {
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    if (e.KeyChar == Convert.ToChar(Keys.Enter))
                    {
                        //Details
                    }
                }
            }

            /*if (labelFoto.ImageIndex == 4)
            {
                textBox1.Visible = false;
                button1.Visible = true;
                button1.Text = "Open scrap window";
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    
                    if (e.KeyChar == Convert.ToChar(Keys.Enter))
                    {
                        scrap.ShowDialog();
                    }
                }
            }
        

            if (labelFoto.ImageIndex == 5)
            {
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    if (e.KeyChar == Convert.ToChar(Keys.Enter))
                    {
                        inventory.ShowDialog();
                    }
                }
            }

            if (labelFoto.ImageIndex == 6)
            {
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    if (e.KeyChar == Convert.ToChar(Keys.Enter))
                    {
                        last.ShowDialog();
                    }
                }
            }*/
/*        }
        #endregion

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
{
    CreateFolder create = new CreateFolder(textBox1.Text);
    create.ShowDialog();  // viene del menustrip del Design para los atajos de teclado.
}

private void toolStripMenuItem2_Click(object sender, EventArgs e)
{

    Admin.ShowDialog();
}

private void toolStripMenuItem3_Click(object sender, EventArgs e)
{
    //details
}

private void toolStripMenuItem4_Click(object sender, EventArgs e)
{
    scrap.ShowDialog();
}

private void toolStripMenuItem5_Click(object sender, EventArgs e)
{
    inventory.ShowDialog();
}

private void lastQCToolStripMenuItem1_Click(object sender, EventArgs e)
{
    last.ShowDialog();
}

private void button3_Click(object sender, EventArgs e)
{
    last.ShowDialog();
}

private void button2_Click(object sender, EventArgs e)
{
    inventory.ShowDialog();
}

private void button1_Click(object sender, EventArgs e)
{
    scrap.ShowDialog();
}

private void button4_Click(object sender, EventArgs e)
{
    Admin.ShowDialog();
}
    }*/
