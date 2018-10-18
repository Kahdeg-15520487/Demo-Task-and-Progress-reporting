namespace WinFormApp
{
    partial class MainForm
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
            this.button_createTask = new System.Windows.Forms.Button();
            this.listView_taskList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // button_createTask
            // 
            this.button_createTask.Location = new System.Drawing.Point(12, 12);
            this.button_createTask.Name = "button_createTask";
            this.button_createTask.Size = new System.Drawing.Size(130, 72);
            this.button_createTask.TabIndex = 0;
            this.button_createTask.Text = "Create task";
            this.button_createTask.UseVisualStyleBackColor = true;
            this.button_createTask.Click += new System.EventHandler(this.button_createTask_Click);
            // 
            // listView_taskList
            // 
            this.listView_taskList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView_taskList.Location = new System.Drawing.Point(148, 12);
            this.listView_taskList.Name = "listView_taskList";
            this.listView_taskList.Size = new System.Drawing.Size(766, 298);
            this.listView_taskList.TabIndex = 1;
            this.listView_taskList.UseCompatibleStateImageBehavior = false;
            this.listView_taskList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Task Name";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Task progress";
            this.columnHeader2.Width = 250;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Message";
            this.columnHeader3.Width = 350;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 487);
            this.Controls.Add(this.listView_taskList);
            this.Controls.Add(this.button_createTask);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_createTask;
        private System.Windows.Forms.ListView listView_taskList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}

