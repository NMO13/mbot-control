
namespace mBotRemoteController
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.forward = new System.Windows.Forms.Button();
            this.backward = new System.Windows.Forms.Button();
            this.control = new System.Windows.Forms.GroupBox();
            this.stop = new System.Windows.Forms.Button();
            this.right = new System.Windows.Forms.Button();
            this.left = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.status = new System.Windows.Forms.Label();
            this.devices = new System.Windows.Forms.Label();
            this.update = new System.Windows.Forms.Button();
            this.characteristics = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.control.SuspendLayout();
            this.SuspendLayout();
            // 
            // forward
            // 
            this.forward.Location = new System.Drawing.Point(216, 35);
            this.forward.Margin = new System.Windows.Forms.Padding(4);
            this.forward.Name = "forward";
            this.forward.Size = new System.Drawing.Size(100, 56);
            this.forward.TabIndex = 0;
            this.forward.Text = "Forward";
            this.forward.UseVisualStyleBackColor = true;
            this.forward.Click += new System.EventHandler(this.button1_Click);
            // 
            // backward
            // 
            this.backward.Location = new System.Drawing.Point(216, 201);
            this.backward.Margin = new System.Windows.Forms.Padding(4);
            this.backward.Name = "backward";
            this.backward.Size = new System.Drawing.Size(100, 56);
            this.backward.TabIndex = 1;
            this.backward.Text = "Backward";
            this.backward.UseVisualStyleBackColor = true;
            this.backward.Click += new System.EventHandler(this.backward_Click);
            // 
            // control
            // 
            this.control.Controls.Add(this.stop);
            this.control.Controls.Add(this.right);
            this.control.Controls.Add(this.left);
            this.control.Controls.Add(this.backward);
            this.control.Controls.Add(this.forward);
            this.control.Location = new System.Drawing.Point(31, 180);
            this.control.Name = "control";
            this.control.Size = new System.Drawing.Size(576, 286);
            this.control.TabIndex = 2;
            this.control.TabStop = false;
            this.control.Text = "Control";
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(216, 114);
            this.stop.Margin = new System.Windows.Forms.Padding(4);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(100, 56);
            this.stop.TabIndex = 4;
            this.stop.Text = "Stop";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // right
            // 
            this.right.Location = new System.Drawing.Point(388, 114);
            this.right.Margin = new System.Windows.Forms.Padding(4);
            this.right.Name = "right";
            this.right.Size = new System.Drawing.Size(100, 56);
            this.right.TabIndex = 3;
            this.right.Text = "Right";
            this.right.UseVisualStyleBackColor = true;
            this.right.Click += new System.EventHandler(this.right_Click);
            // 
            // left
            // 
            this.left.Location = new System.Drawing.Point(34, 114);
            this.left.Margin = new System.Windows.Forms.Padding(4);
            this.left.Name = "left";
            this.left.Size = new System.Drawing.Size(100, 56);
            this.left.TabIndex = 2;
            this.left.Text = "Left";
            this.left.UseVisualStyleBackColor = true;
            this.left.Click += new System.EventHandler(this.left_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(131, 34);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(388, 24);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Location = new System.Drawing.Point(28, 133);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(56, 17);
            this.status.TabIndex = 4;
            this.status.Text = "Status: ";
            // 
            // devices
            // 
            this.devices.AutoSize = true;
            this.devices.Location = new System.Drawing.Point(28, 37);
            this.devices.Name = "devices";
            this.devices.Size = new System.Drawing.Size(87, 17);
            this.devices.TabIndex = 5;
            this.devices.Text = "Select mBot:";
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(532, 29);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(75, 32);
            this.update.TabIndex = 9;
            this.update.Text = "Update";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // characteristics
            // 
            this.characteristics.AutoSize = true;
            this.characteristics.Location = new System.Drawing.Point(28, 90);
            this.characteristics.Name = "characteristics";
            this.characteristics.Size = new System.Drawing.Size(141, 17);
            this.characteristics.TabIndex = 10;
            this.characteristics.Text = "Select Characteristic:";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(175, 87);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(344, 24);
            this.comboBox2.TabIndex = 11;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            this.comboBox2.Enter += new System.EventHandler(this.comboBox2_Enter);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 554);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.characteristics);
            this.Controls.Add(this.update);
            this.Controls.Add(this.devices);
            this.Controls.Add(this.status);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.control);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.control.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button forward;
        private System.Windows.Forms.Button backward;
        private System.Windows.Forms.GroupBox control;
        private System.Windows.Forms.Button right;
        private System.Windows.Forms.Button left;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Label devices;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Label characteristics;
        private System.Windows.Forms.ComboBox comboBox2;
    }
}

