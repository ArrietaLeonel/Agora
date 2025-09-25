namespace Desktop
{
    partial class MenuPrincipalView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            toolStrip1 = new ToolStrip();
            menuStrip1 = new MenuStrip();
            menuPrincipal = new FontAwesome.Sharp.IconMenuItem();
            subMenuUsuarios = new FontAwesome.Sharp.IconMenuItem();
            menuSalir = new FontAwesome.Sharp.IconMenuItem();
            subMenuSalirdelsistema = new FontAwesome.Sharp.IconMenuItem();
            subMenuCapacitaciones = new FontAwesome.Sharp.IconMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Location = new Point(0, 24);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 25);
            toolStrip1.TabIndex = 3;
            toolStrip1.Text = "toolStrip1";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuPrincipal, menuSalir });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuPrincipal
            // 
            menuPrincipal.DropDownItems.AddRange(new ToolStripItem[] { subMenuUsuarios, subMenuCapacitaciones });
            menuPrincipal.IconChar = FontAwesome.Sharp.IconChar.HomeLg;
            menuPrincipal.IconColor = Color.Black;
            menuPrincipal.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menuPrincipal.Name = "menuPrincipal";
            menuPrincipal.Size = new Size(81, 20);
            menuPrincipal.Text = "Principal";
            // 
            // subMenuUsuarios
            // 
            subMenuUsuarios.IconChar = FontAwesome.Sharp.IconChar.UserFriends;
            subMenuUsuarios.IconColor = Color.Black;
            subMenuUsuarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            subMenuUsuarios.Name = "subMenuUsuarios";
            subMenuUsuarios.Size = new Size(180, 22);
            subMenuUsuarios.Text = "Usuarios";
            subMenuUsuarios.Click += subMenuUsuarios_Click;
            // 
            // menuSalir
            // 
            menuSalir.DropDownItems.AddRange(new ToolStripItem[] { subMenuSalirdelsistema });
            menuSalir.IconChar = FontAwesome.Sharp.IconChar.DoorClosed;
            menuSalir.IconColor = Color.Black;
            menuSalir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menuSalir.Name = "menuSalir";
            menuSalir.Size = new Size(57, 20);
            menuSalir.Text = "Salir";
            // 
            // subMenuSalirdelsistema
            // 
            subMenuSalirdelsistema.IconChar = FontAwesome.Sharp.IconChar.DoorOpen;
            subMenuSalirdelsistema.IconColor = Color.Black;
            subMenuSalirdelsistema.IconFont = FontAwesome.Sharp.IconFont.Auto;
            subMenuSalirdelsistema.Name = "subMenuSalirdelsistema";
            subMenuSalirdelsistema.Size = new Size(158, 22);
            subMenuSalirdelsistema.Text = "Salir del sistema";
            subMenuSalirdelsistema.Click += subMenuSalirdelsistema_Click;
            // 
            // subMenuCapacitaciones
            // 
            subMenuCapacitaciones.IconChar = FontAwesome.Sharp.IconChar.BookBookmark;
            subMenuCapacitaciones.IconColor = Color.Black;
            subMenuCapacitaciones.IconFont = FontAwesome.Sharp.IconFont.Auto;
            subMenuCapacitaciones.Name = "subMenuCapacitaciones";
            subMenuCapacitaciones.Size = new Size(180, 22);
            subMenuCapacitaciones.Text = "Capacitaciones";
            subMenuCapacitaciones.Click += subMenuCapacitaciones_Click;
            // 
            // MenuPrincipalView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "MenuPrincipalView";
            Text = "Ágora : Software de acreditación de capacitaciones ISP20";
            WindowState = FormWindowState.Maximized;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private MenuStrip menuStrip1;
        private FontAwesome.Sharp.IconMenuItem menuPrincipal;
        private FontAwesome.Sharp.IconMenuItem menuSalir;
        private FontAwesome.Sharp.IconMenuItem subMenuSalirdelsistema;
        private FontAwesome.Sharp.IconMenuItem subMenuUsuarios;
        private FontAwesome.Sharp.IconMenuItem subMenuCapacitaciones;
    }
}
