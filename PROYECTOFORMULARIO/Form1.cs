using MyCompiler;

namespace PROYECTOFORMULARIO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAnalizar_Click(object sender, EventArgs e)
        {
            lstSimbolos.Items.Clear();
            lstErrores.Items.Clear();
            txtJSON.Clear();

            if (txtcodigo == null)
            {
                MessageBox.Show("No se encontró el control txtcodigo.");
                return;
            }

            string codigo = txtcodigo.Text;

            if (string.IsNullOrWhiteSpace(codigo))
            {
                lstErrores.Items.Add("Por favor, ingresa código para analizar.");
                txtJSON.Text = "";
                return;
            }

            try
            {
                Lexico lexer = new Lexico();
                var simbolos = lexer.Analizar(codigo);

                foreach (var s in simbolos)
                {
                    lstSimbolos.Items.Add($"{s.Token} = '{s.Lexema}'");
                }

                foreach (var eL in lexer.Errors)
                {
                    lstErrores.Items.Add("Léxico: " + eL);
                }

                Sintactico parser = new Sintactico();
                if (!parser.Analizar(simbolos))
                {
                    foreach (var eS in parser.Errors)
                    {
                        lstErrores.Items.Add("Sintáctico: " + eS);
                    }
                    txtJSON.Text = "No se generó JSON por errores sintácticos.";
                    return;
                }

                if (lexer.Errors.Count == 0 && parser.Errors.Count == 0)
                {
                    lstErrores.Items.Add("No existe ningún error.");
                }

                string json = GeneradorCodigo.GenerarJSON(parser.Instancias);
                if (string.IsNullOrWhiteSpace(json))
                {
                    txtJSON.Text = "No se generó JSON (resultado vacío).";
                }
                else
                {
                    txtJSON.Text = json;
                }
            }
            catch (Exception ex)
            {
                lstErrores.Items.Add("Error inesperado: " + ex.Message);
                txtJSON.Text = "Error al generar JSON.";
            }

        }

        private void txtJSON_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtcodigo.Clear();
            lstSimbolos.Items.Clear();
            lstErrores.Items.Clear();
            txtJSON.Clear();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnDescargarJson_Click(object sender, EventArgs e)
        {
            bool hayErrores = false;
            foreach (var item in lstErrores.Items)
            {
                if (item.ToString() != "No existe ningún error.")
                {
                    hayErrores = true;
                    break;
                }
            }

            if (hayErrores || string.IsNullOrWhiteSpace(txtJSON.Text) || txtJSON.Text.StartsWith("No se generó JSON"))
            {
                MessageBox.Show("No se puede descargar el JSON porque existen errores o no se ha generado el archivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Archivo JSON (*.json)|*.json";
                saveFileDialog.Title = "Guardar archivo JSON";
                saveFileDialog.FileName = "resultado.json";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.WriteAllText(saveFileDialog.FileName, txtJSON.Text);
                    MessageBox.Show("Archivo JSON guardado correctamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

    }
}
