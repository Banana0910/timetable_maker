namespace timetable_maker
{
    partial class SubjectBox
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.name = new System.Windows.Forms.TextBox();
            this.teacher = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // name
            // 
            this.name.BackColor = System.Drawing.Color.White;
            this.name.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.name.ForeColor = System.Drawing.Color.Gray;
            this.name.Location = new System.Drawing.Point(3, 9);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(73, 22);
            this.name.TabIndex = 0;
            this.name.Tag = "이름";
            this.name.Text = "이름";
            this.name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // teacher
            // 
            this.teacher.BackColor = System.Drawing.Color.White;
            this.teacher.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.teacher.ForeColor = System.Drawing.Color.Gray;
            this.teacher.Location = new System.Drawing.Point(3, 37);
            this.teacher.Name = "teacher";
            this.teacher.Size = new System.Drawing.Size(73, 22);
            this.teacher.TabIndex = 1;
            this.teacher.Tag = "선생님";
            this.teacher.Text = "선생님";
            this.teacher.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(81, 1);
            this.panel1.TabIndex = 2;
            // 
            // SubjectBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.teacher);
            this.Controls.Add(this.name);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SubjectBox";
            this.Size = new System.Drawing.Size(81, 66);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox name;
        public System.Windows.Forms.TextBox teacher;
    }
}
