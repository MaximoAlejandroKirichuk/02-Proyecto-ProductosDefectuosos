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
        public FormAyuda(int idioma)
        {
            InitializeComponent();


            cambiaridioma(idioma);
        }
        public void cambiaridioma(int idioma)
        {
            if(idioma == 1)
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
            if (idioma == 2)
            {
                richTextBoxAyuda.Text =
                @"🆘 HELP – Step-by-step guide to using the system

                Welcome to the Defective Product Registration System.
                Below is a guide on how to correctly use the application:

                ✅ 1. Log in or Register
                - If you already have an account, enter your username and password on the login screen.
                - If it’s your first time, click on Register to create a new account.

                📥 2. Register a defective product
                1. Go to the 'Register defective product' section.
                2. Fill in the following required fields:
                   - Product code
                   - Product name
                   - Responsible person (who detected or is responsible for the product)
                   - Accumulated cost up to the point of defect
                   - Additional expenses incurred before the defect
                   - Quantity of damaged products

                📍 3. Enter the product’s location
                In the same registration section:
                1. Indicate the physical location of the product:
                   - Warehouse
                   - Shelf
                   - Level
                   - Column

                🔧 4. Status of the defective product
                1. Select whether the product:
                   - Can be reconditioned
                     - In this case, the estimated labor cost for recovery must be entered.
                   - Must be discarded
                     - The estimated loss in raw materials must be entered.

                🔄 5. Product tracking
                1. After registering the product, you can:
                   - Add events to the case tracking, such as transfers, evaluations, decisions, etc.
                   - View the full history of steps from the defect report to its final destination.

                💾 6. Save the information
                1. When you finish entering all the data, click on 'Save'.
                2. The system will generate a persistent record in a CSV file to keep a backup.

                🔍 7. View registered products
                - From the Consultation view, you can:
                  - Search for registered products by code, name, or responsible person.
                  - See their current location, status (reconditionable or discarded), and tracking.

                🧹 8. Clear the fields
                - You can use the 'Clear' button to erase the form data and start a new one.

                ❓Questions or errors?
                - If you have any questions or detect an error, contact the support team or check this help section again.";
            }
            if (idioma == 3)
            {
                richTextBoxAyuda.Text =
                @"🆘 AJUDA – Guia passo a passo para usar o sistema

                Bem-vindo ao Sistema de Registro de Produtos Defeituosos.
                A seguir, explicamos como usar corretamente o aplicativo:

                ✅ 1. Fazer login ou registrar-se
                - Se você já tem uma conta, insira seu nome de usuário e senha na tela de login.
                - Se for a sua primeira vez, clique em Registrar-se para criar uma nova conta.

                📥 2. Registrar um produto defeituoso
                1. Acesse a seção ""Registrar produto defeituoso"".
                2. Preencha os seguintes campos obrigatórios:
                   - Código do produto
                   - Nome do produto
                   - Responsável (pessoa que detectou ou é responsável pelo produto)
                   - Custo acumulado até o momento do defeito
                   - Despesa adicional incorrida antes do defeito
                   - Quantidade de produtos danificados

                📍 3. Inserir a localização do produto
                Na mesma seção de registro:
                1. Indique a localização física do produto:
                   - Depósito
                   - Prateleira
                   - Nível
                   - Coluna

                🔧 4. Estado do produto defeituoso
                1. Selecione se o produto:
                   - Pode ser recondicionado
                     - Nesse caso, deve-se informar o custo estimado da mão de obra para a recuperação.
                   - Deve ser descartado
                     - Deve-se informar a perda estimada de matéria-prima.

                🔄 5. Acompanhamento do produto
                1. Após registrar o produto, você pode:
                   - Adicionar eventos ao acompanhamento do caso, como transferências, avaliações, decisões, etc.
                   - Ver o histórico completo de etapas desde a declaração do defeito até o destino final.

                💾 6. Salvar as informações
                1. Quando terminar de preencher todos os dados, clique em ""Salvar"".
                2. O sistema gerará um registro persistente em um arquivo CSV, para manter um backup.

                🔍 7. Consultar produtos registrados
                - Na visualização de Consulta, você pode:
                  - Pesquisar produtos registrados por código, nome ou responsável.
                  - Ver sua localização atual, estado (recondicionável ou descartado) e acompanhamento.

                🧹 8. Limpar os campos
                - Você pode usar o botão ""Limpar"" para apagar os dados do formulário e começar um novo.

                ❓Dúvidas ou erros?
                - Se tiver alguma dúvida ou detectar um erro, entre em contato com a equipe de suporte ou consulte novamente esta seção de ajuda.";
            }

        }


        private void FormAyuda_Load(object sender, EventArgs e)
        {
            
        }




        private void richTextBoxAyuda_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
