namespace timetable_maker
{
    partial class Main
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.main_panel = new System.Windows.Forms.FlowLayoutPanel();
            this.monday = new System.Windows.Forms.FlowLayoutPanel();
            this.tuesday = new System.Windows.Forms.FlowLayoutPanel();
            this.wednesday = new System.Windows.Forms.FlowLayoutPanel();
            this.thursday = new System.Windows.Forms.FlowLayoutPanel();
            this.friday = new System.Windows.Forms.FlowLayoutPanel();
            this.main_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // main_panel
            // 
            this.main_panel.Controls.Add(this.monday);
            this.main_panel.Controls.Add(this.tuesday);
            this.main_panel.Controls.Add(this.wednesday);
            this.main_panel.Controls.Add(this.thursday);
            this.main_panel.Controls.Add(this.friday);
            this.main_panel.Location = new System.Drawing.Point(12, 85);
            this.main_panel.Name = "main_panel";
            this.main_panel.Size = new System.Drawing.Size(680, 629);
            this.main_panel.TabIndex = 0;
            // 
            // monday
            // 
            this.monday.Location = new System.Drawing.Point(3, 3);
            this.monday.Name = "monday";
            this.monday.Size = new System.Drawing.Size(130, 626);
            this.monday.TabIndex = 0;
            // 
            // tuesday
            // 
            this.tuesday.Location = new System.Drawing.Point(139, 3);
            this.tuesday.Name = "tuesday";
            this.tuesday.Size = new System.Drawing.Size(130, 626);
            this.tuesday.TabIndex = 1;
            // 
            // wednesday
            // 
            this.wednesday.Location = new System.Drawing.Point(275, 3);
            this.wednesday.Name = "wednesday";
            this.wednesday.Size = new System.Drawing.Size(130, 626);
            this.wednesday.TabIndex = 2;
            // 
            // thursday
            // 
            this.thursday.Location = new System.Drawing.Point(411, 3);
            this.thursday.Name = "thursday";
            this.thursday.Size = new System.Drawing.Size(130, 626);
            this.thursday.TabIndex = 3;
            // 
            // friday
            // 
            this.friday.Location = new System.Drawing.Point(547, 3);
            this.friday.Name = "friday";
            this.friday.Size = new System.Drawing.Size(130, 626);
            this.friday.TabIndex = 4;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(706, 726);
            this.Controls.Add(this.main_panel);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "white";
            this.main_panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel main_panel;
        private System.Windows.Forms.FlowLayoutPanel monday;
        private System.Windows.Forms.FlowLayoutPanel tuesday;
        private System.Windows.Forms.FlowLayoutPanel wednesday;
        private System.Windows.Forms.FlowLayoutPanel thursday;
        private System.Windows.Forms.FlowLayoutPanel friday;
    }
}

