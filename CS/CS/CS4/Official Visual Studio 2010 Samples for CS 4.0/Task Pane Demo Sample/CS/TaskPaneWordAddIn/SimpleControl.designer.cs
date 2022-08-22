namespace TaskPaneWordAddIn
{
    partial class SimpleControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimpleControl));
            this.insertButton = new System.Windows.Forms.Button();
            this.insertTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // insertButton
            // 
            resources.ApplyResources(this.insertButton, "insertButton");
            this.insertButton.Name = "insertButton";
            this.insertButton.UseVisualStyleBackColor = true;
            this.insertButton.Click += new System.EventHandler(this.insertButton_Click);
            // 
            // insertTextBox
            // 
            resources.ApplyResources(this.insertTextBox, "insertTextBox");
            this.insertTextBox.Name = "insertTextBox";
            // 
            // SimpleControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.insertButton);
            this.Controls.Add(this.insertTextBox);
            this.Name = "SimpleControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button insertButton;
        internal System.Windows.Forms.TextBox insertTextBox;
    }
}
