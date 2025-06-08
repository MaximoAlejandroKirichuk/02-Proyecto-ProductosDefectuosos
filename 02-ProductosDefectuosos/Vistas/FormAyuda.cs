using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02_ProductosDefectuosos.Vistas
{
    public partial class FormAyuda : Form
    {
        public FormAyuda()
        {
            InitializeComponent();
        }

        private void FormAyuda_Load(object sender, EventArgs e)
        {
            richTextBoxAyuda.Text =
        @"🆘 AYUDA – Guía paso a paso para usar el sistema

Bienvenido al Sistema de Registro de Productos Defectuosos.
A continuación, te explicamos cómo usar correctamente la aplicación:

✅ 1. Iniciar sesión o registrarse
- Si ya tenés una cuenta, ingresá tu usuario y contraseña en la pantalla de Inicio de sesión.
- Si es tu primera vez, hacé clic en Registrarse para crear una nueva cuenta.

📥 2. Registrar un producto defectuoso
1. Accedé a la sección ""Registrar producto defectuoso"".
2. Completá los siguientes campos obligatorios:
   - Código del producto
   - Nombre del producto
   - Responsable (persona que detectó o es responsable del producto)
   - Costo acumulado hasta el momento del defecto
   - Gasto adicional incurrido antes del defecto
   - Cantidad de productos dañados

📍 3. Ingresar ubicación del producto
En la misma sección de registro:
1. Indicá la ubicación física del producto:
   - Depósito
   - Estante
   - Nivel
   - Columna

🔧 4. Estado del producto defectuoso
1. Seleccioná si el producto:
   - Puede ser reacondicionado
     - En este caso, se debe indicar el costo estimado de mano de obra para su recuperación.
   - Debe ser desechado
     - Se debe indicar la pérdida estimada de materia prima.

🔄 5. Seguimiento del producto
1. Luego de registrar el producto, podés:
   - Agregar eventos al seguimiento del caso, como traslados, evaluaciones, decisiones, etc.
   - Ver el historial completo de pasos desde la declaración del defecto hasta su destino final.

💾 6. Guardar la información
1. Cuando termines de completar todos los datos, hacé clic en ""Guardar"".
2. El sistema generará un registro persistente en un archivo CSV, para mantener un respaldo.

🔍 7. Consultar productos registrados
- Desde la vista de Consulta, podés:
  - Buscar productos registrados por código, nombre o responsable.
  - Ver su ubicación actual, estado (reacondicionable o descartado) y seguimiento.

🧹 8. Limpiar los campos
- Podés usar el botón ""Limpiar"" para borrar los datos cargados en el formulario y empezar uno nuevo.

❓¿Dudas o errores?
- Si tenés alguna duda o detectás un error, comunicate con el equipo de soporte o consultá nuevamente esta sección de ayuda.";
        }




        private void richTextBoxAyuda_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
