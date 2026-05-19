using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PantallasPrograma
{
    internal class Validaciones
    {
        // Validacion para que un TextBox no esté vacío
        public static bool NoVacio(TextBox txt, string nombreCampo)
        {
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                MessageBox.Show(nombreCampo + " no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt.Focus();
                return false;
            }
            return true;
        }

        // Validacion para que un txtb  solo tenga letras
        public static bool SoloLetras(TextBox txt, string nombreCampo)
        {
            if (!Regex.IsMatch(txt.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show(nombreCampo + " solo puede contener letras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt.Focus();
                return false;
            }
            return true;
        }

        // Validar que solo tenga números validos
        public static bool SoloNumeros(TextBox txt, string nombreCampo)
        {
            if (!Regex.IsMatch(txt.Text, @"^\d+$"))
            {
                MessageBox.Show(nombreCampo + " solo puede contener números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt.Focus();
                return false;
            } 

            if (!decimal.TryParse(txt.Text, out _))
            {
                MessageBox.Show(nombreCampo + " debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt.Focus();
                return false;
            }
            return true;
        }

        //Que un combobox este lleno
        public static bool ComboSeleccionado(ComboBox cb, string nombreCampo)
        {
            if (cb.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un " + nombreCampo + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cb.Focus();
                return false;
            }
            return true;
        }

        public static bool UrlValida(TextBox txt, string nombreCampo)
        {
            if (!Uri.IsWellFormedUriString(txt.Text, UriKind.Absolute))
            {
                MessageBox.Show(nombreCampo + " no tiene un formato válido.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                txt.Focus();
                return false;
            }

            return true;
        }

    }
}
