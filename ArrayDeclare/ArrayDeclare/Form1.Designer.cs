namespace ArrayDeclare
{
	partial class Form1
	{
		/// <summary>
		/// 設計工具所需的變數。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清除任何使用中的資源。
		/// </summary>
		/// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 設計工具產生的程式碼

		/// <summary>
		/// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
		/// 這個方法的內容。
		/// </summary>
		private void InitializeComponent()
		{
			this.btnGen = new System.Windows.Forms.Button();
			this.txtInput = new System.Windows.Forms.TextBox();
			this.txtResult = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btnGen
			// 
			this.btnGen.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.btnGen.Location = new System.Drawing.Point(279, 169);
			this.btnGen.Name = "btnGen";
			this.btnGen.Size = new System.Drawing.Size(84, 27);
			this.btnGen.TabIndex = 0;
			this.btnGen.Text = "Gen";
			this.btnGen.UseVisualStyleBackColor = true;
			this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
			// 
			// txtInput
			// 
			this.txtInput.Location = new System.Drawing.Point(22, 22);
			this.txtInput.Multiline = true;
			this.txtInput.Name = "txtInput";
			this.txtInput.Size = new System.Drawing.Size(599, 131);
			this.txtInput.TabIndex = 1;
			// 
			// txtResult
			// 
			this.txtResult.Location = new System.Drawing.Point(22, 219);
			this.txtResult.Multiline = true;
			this.txtResult.Name = "txtResult";
			this.txtResult.Size = new System.Drawing.Size(599, 131);
			this.txtResult.TabIndex = 2;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(638, 380);
			this.Controls.Add(this.txtResult);
			this.Controls.Add(this.txtInput);
			this.Controls.Add(this.btnGen);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnGen;
		private System.Windows.Forms.TextBox txtInput;
		private System.Windows.Forms.TextBox txtResult;
	}
}

