
namespace Login
{
    partial class ChineseChess
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_NickName1 = new System.Windows.Forms.TextBox();
            this.textBox_NickName2 = new System.Windows.Forms.TextBox();
            this.button_Link = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("华文彩云", 42F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(66, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(671, 73);
            this.label1.TabIndex = 0;
            this.label1.Text = "欢迎来到中国象棋！\r\n";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.13408F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.86592F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_NickName1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_NickName2, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(112, 210);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(537, 169);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("黑体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(45, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "您的昵称：";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("黑体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(31, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "对方的昵称：";
            // 
            // textBox_NickName1
            // 
            this.textBox_NickName1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_NickName1.Location = new System.Drawing.Point(263, 29);
            this.textBox_NickName1.Name = "textBox_NickName1";
            this.textBox_NickName1.Size = new System.Drawing.Size(248, 25);
            this.textBox_NickName1.TabIndex = 2;
            // 
            // textBox_NickName2
            // 
            this.textBox_NickName2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_NickName2.Location = new System.Drawing.Point(263, 114);
            this.textBox_NickName2.Name = "textBox_NickName2";
            this.textBox_NickName2.Size = new System.Drawing.Size(248, 25);
            this.textBox_NickName2.TabIndex = 3;
            // 
            // button_Link
            // 
            this.button_Link.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_Link.Font = new System.Drawing.Font("华文琥珀", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Link.Location = new System.Drawing.Point(332, 403);
            this.button_Link.Name = "button_Link";
            this.button_Link.Size = new System.Drawing.Size(109, 35);
            this.button_Link.TabIndex = 2;
            this.button_Link.Text = "开始连接";
            this.button_Link.UseVisualStyleBackColor = true;
            this.button_Link.Click += new System.EventHandler(this.button_Link_Click);
            // 
            // 中国象棋
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_Link);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Name = "中国象棋";
            this.Text = "中国象棋";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_NickName1;
        private System.Windows.Forms.TextBox textBox_NickName2;
        private System.Windows.Forms.Button button_Link;
    }
}

