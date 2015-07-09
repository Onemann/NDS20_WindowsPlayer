namespace NDS20_WindowsPlayer
{
    partial class NDS20frmMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.picbMainLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picbMainLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // picbMainLogo
            // 
            this.picbMainLogo.BackColor = System.Drawing.Color.White;
            this.picbMainLogo.Image = global::NDS20_WindowsPlayer.Properties.Resources.cj_png_powercast_hr_eng;
            this.picbMainLogo.InitialImage = null;
            this.picbMainLogo.Location = new System.Drawing.Point(274, 249);
            this.picbMainLogo.Name = "picbMainLogo";
            this.picbMainLogo.Size = new System.Drawing.Size(300, 100);
            this.picbMainLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picbMainLogo.TabIndex = 1;
            this.picbMainLogo.TabStop = false;
            // 
            // NDS20frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(915, 637);
            this.Controls.Add(this.picbMainLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "NDS20frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NDS20 Player";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NDS20frmMain_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.picbMainLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picbMainLogo;

    }
}

