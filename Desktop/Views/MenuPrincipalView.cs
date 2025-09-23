using Desktop.Views;

namespace Desktop
{
    public partial class MenuPrincipalView : Form
    {
        public MenuPrincipalView()
        {
            InitializeComponent();
        }

        private void subMenuSalirdelsistema_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void subMenuUsuarios_Click(object sender, EventArgs e)
        {
            var usuariosView = new UsuariosView();
            usuariosView.MdiParent = this;
            usuariosView.Show();
        }

        private void subMenuCapacitaciones_Click(object sender, EventArgs e)
        {
            var capacitacionesView = new CapacitacionesView();
            capacitacionesView.MdiParent = this;
            capacitacionesView.Show();
        }
    }
}
