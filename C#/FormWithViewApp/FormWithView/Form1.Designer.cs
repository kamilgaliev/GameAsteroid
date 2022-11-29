namespace FormWithView
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbA = new System.Windows.Forms.TextBox();
            this.tbB = new System.Windows.Forms.TextBox();
            this.btnSum = new System.Windows.Forms.Button();
            this.btnMinus = new System.Windows.Forms.Button();
            this.lbRes = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbA
            // 
            this.tbA.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbA.Location = new System.Drawing.Point(22, 24);
            this.tbA.Name = "tbA";
            this.tbA.Size = new System.Drawing.Size(180, 34);
            this.tbA.TabIndex = 0;
            // 
            // tbB
            // 
            this.tbB.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbB.Location = new System.Drawing.Point(22, 85);
            this.tbB.Name = "tbB";
            this.tbB.Size = new System.Drawing.Size(180, 34);
            this.tbB.TabIndex = 1;
            // 
            // btnSum
            // 
            this.btnSum.Location = new System.Drawing.Point(297, 24);
            this.btnSum.Name = "btnSum";
            this.btnSum.Size = new System.Drawing.Size(75, 34);
            this.btnSum.TabIndex = 2;
            this.btnSum.Text = "+";
            this.btnSum.UseVisualStyleBackColor = true;
            this.btnSum.Click += new System.EventHandler(this.btnSum_Click);
            // 
            // btnMinus
            // 
            this.btnMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnMinus.Location = new System.Drawing.Point(297, 85);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(75, 34);
            this.btnMinus.TabIndex = 3;
            this.btnMinus.Text = "-";
            this.btnMinus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMinus.UseVisualStyleBackColor = true;
            this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // lbRes
            // 
            this.lbRes.AutoSize = true;
            this.lbRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbRes.Location = new System.Drawing.Point(22, 149);
            this.lbRes.Name = "lbRes";
            this.lbRes.Size = new System.Drawing.Size(27, 29);
            this.lbRes.TabIndex = 4;
            this.lbRes.Text = "<";
            this.lbRes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbRes);
            this.Controls.Add(this.btnMinus);
            this.Controls.Add(this.btnSum);
            this.Controls.Add(this.tbB);
            this.Controls.Add(this.tbA);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbA;
        private System.Windows.Forms.TextBox tbB;
        private System.Windows.Forms.Button btnSum;
        private System.Windows.Forms.Button btnMinus;
        private System.Windows.Forms.Label lbRes;
    }
}

